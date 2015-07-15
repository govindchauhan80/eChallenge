using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EChallenge.Models
{
    public class MyRedemptionsViewModel
    {
        public IEnumerable<Gift> GiftsAvailableForRedemption { get; set; }
        public IEnumerable<UserGiftRedemption> GiftsAvailed { get; set; }
    }
}