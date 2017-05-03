using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using FenixBot.Helpers;
using FenixBot.Logic.Wrappers;

namespace FenixBot.Logic
{
    public class AuctionLogic
    {
        private const string Region = "Auction";
        private static Client _apiClient;
        private static ConfigurationModel _configuration;

        public AuctionLogic(ConfigurationModel configuration)
        {
            _configuration = configuration;
            _apiClient = new Client(_configuration.BaseAPIUrl);
        }

        public async Task Handle(MessageEventArgs e)
        {
            var itemId = e.Message.Text.ToLower().Replace("!auction ", "");
            var response = await GetAuctionSummary(itemId);
            await e.Channel.SendMessage(response);
        }

        private async Task<string> GetAuctionSummary(string itemName)
        {
            try
            {
                var auctions = CacheHelper.GetCache<IEnumerable<AuctionModel>>("guild_auctions", Region);

                if (auctions == null)
                {
                    auctions = await _apiClient.ApiWarcraftGuildAuctionsByRealmByGuildGetAsync(_configuration.Realm,
                        _configuration.Guild);

                    CacheHelper.Cache("auctions", Region, auctions, TimeSpan.FromMinutes(30));
                }

                var itemAuction =
                    auctions.FirstOrDefault(x => x.ItemName.Equals(itemName, StringComparison.OrdinalIgnoreCase));

                if (itemAuction != null)
                {
                    var price = (decimal) itemAuction.Buyout / itemAuction.Quantity;
                    return string.Format(
                        "The lowest buyout price offered by a guild member for {0} is listed at {1} per unit by {2} for a duration of {3}.",
                        itemAuction.ItemName, price, itemAuction.Owner, itemAuction.TimeLeft);
                }

                return string.Format("No guild auctions for {0} found.", itemName);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}