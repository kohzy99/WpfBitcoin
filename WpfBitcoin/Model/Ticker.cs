using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBitcoin.Model
{
    public class Ticker
    {
        public string product_code { get; set; }
        public DateTime timestamp { get; set; }
        public int tick_id { get; set; }
        public float best_bid { get; set; }
        public float best_ask { get; set; }
        public float best_bid_size { get; set; }
        public float best_ask_size { get; set; }
        public float total_bid_depth { get; set; }
        public float total_ask_depth { get; set; }
        public float ltp { get; set; }
        public float volume { get; set; }
        public float volume_by_product { get; set; }
        // 追加
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }

}
