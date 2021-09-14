using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snipplets.ViewModel
{
    public class BuySellViewModel
    {
        public transType BuySellAssets { get; set; }

        public float AmountEUR { get; set; } = 0.0f;



    }

    public enum transType { BuyAssets, SellAssets }
}