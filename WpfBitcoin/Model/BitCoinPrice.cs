using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Windows;

namespace WpfBitcoin.Model
{
    public class BitCoinPrice
    {
        // HttpClientの生成
        private static HttpClient httpClient = new HttpClient();

        // ネットワークの接続状態
        //private 

        // APIエンドポイントURI
        public readonly string Url_BTC = "https://api.bitflyer.jp/v1/ticker?product_code=BTC_JPY";
        public readonly string Url_BTCFX = "https://api.bitflyer.jp/v1/ticker?product_code=FX_BTC_JPY";

        // デストラクタ
        ~BitCoinPrice()
        {
            if (httpClient != null) httpClient.Dispose();
        }

        /// <summary>
        /// BTCJPYのTicker情報を非同期に取得します
        /// </summary>
        /// <returns>取得したTicker情報</returns>
        public async Task<Ticker> GetTickerAsync(string url)
        {
            // Ticker情報を格納する変数
            Ticker ticker = new Ticker();

            try
            {
                // GET
                var response = await httpClient.GetStringAsync(url);

                // Jsonのパース
                ticker = JsonConvert.DeserializeObject<Ticker>(response);
                ticker.isError = false;

            }
            catch (Exception e)
            {
                ticker.isError = true;
                ticker.errorMessage = e.Message;
                //throw;
            }

            // 返却
            return ticker;

        }
    }
}
