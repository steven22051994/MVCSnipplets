using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snipplets.Models
{
    public class JSONBitcoin
    {
        public int Id { get; set; }
        public string  Time { get; set; }

        public string  ChartName { get; set; }

        public float PriceEur { get; set; } = 0.0f;

        public float Amount { get; set; } = 0.0f;

        public action Transaction { get; set; }
        
        public bool Active { get; set; } = true;
    }

    public enum action
    {
        bought, sold 
    }


}

/*
 
https://api.coindesk.com/v1/bpi/currentprice.json

{"time":{"updated":"Oct 28, 2020 05:28:00 UTC","updatedISO":"2020-10-28T05:28:00+00:00",
"updateduk":"Oct 28, 2020 at 05:28 GMT"},"disclaimer":"This data was produced from the CoinDesk Bitcoin Price Index (USD). Non-USD currency data converted using hourly conversion rate from openexchangerates.org",
"chartName":"Bitcoin",
"bpi":{"USD":{"code":"USD","symbol":"&#36;","rate":"13,721.8947","description":"United States Dollar","rate_float":13721.8947},
"GBP":{"code":"GBP","symbol":"&pound;","rate":"10,521.9763","description":"British Pound Sterling","rate_float":10521.9763},
"EUR":{"code":"EUR","symbol":"&euro;","rate":"11,648.9144","description":"Euro","rate_float":11648.9144}}}
*/
