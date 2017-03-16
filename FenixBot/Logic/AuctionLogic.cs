using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FenixBot.Helpers;
using FenixBot.Wrappers;

namespace FenixBot.Logic
{
    public class AuctionLogic
    {
        private static readonly string Region = "Auction";
        private static string _realm;
        private static string _guild;
        private static Client _apiClient;

        public AuctionLogic(string realm, string guild, Client apiClient)
        {
            _realm = realm;
            _guild = guild;
            _apiClient = apiClient;
        }

        public async Task<string> GetAuctionSummary(string itemName)
        {
            try
            {
                var auctions = CacheHelper.GetCache<IEnumerable<AuctionModel>>("guild_auctions", Region);

                if (auctions == null)
                {
                    auctions = await _apiClient.ApiWarcraftGuildAuctionsByRealmByGuildGetAsync(_realm, _guild);

                    CacheHelper.Cache("auctions", Region, auctions, TimeSpan.FromMinutes(30));
                }

                var itemAuction = auctions.FirstOrDefault(x => x.ItemName.Equals(itemName, StringComparison.OrdinalIgnoreCase));

                if (itemAuction != null)
                {
                    var price = (decimal)itemAuction.Buyout / itemAuction.Quantity;
                    return string.Format("The lowest buyout price offered by a guild member for {0} is listed at {1} per unit by {2} for a duration of {3}.", itemAuction.ItemName, price, itemAuction.Owner, itemAuction.TimeLeft);
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
