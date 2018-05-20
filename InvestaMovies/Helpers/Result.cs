using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace InvestaMovies.Helpers
{
    /// <summary>
    /// Result helper, value to be passed containing details about request/process
    /// </summary>
    public class Result
    {
        public string Message { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public bool Success { get; set; }
    }
}