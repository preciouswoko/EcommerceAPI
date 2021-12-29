using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceData.Response
{
    public class Response
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object Data { get; set; }

    }
}
