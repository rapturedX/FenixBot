using System;
using System.Net;

namespace DiscourseDotNet
{
    public class DiscourseException : Exception
    {
        public DiscourseException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public DiscourseException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public DiscourseException(string message, HttpStatusCode statusCode, Exception inner) : base(message, inner)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; private set; }
    }
}