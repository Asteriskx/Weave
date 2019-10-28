using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace Weave.MixCloud.EndPoints.Authorization
{
    /// <summary>
    /// MixCloud 認証クラス
    /// </summary>
    public class Authorization : MixCloudCredentials
    {
        private const string _RedirectUri = "localhost";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientId"> clientID </param>
        /// <param name="clientSecret"> clientSecret </param>
        public Authorization(string clientId, string clientSecret) 
            : base(clientId, clientSecret) 
        {
        }

        /// <summary>
        /// MixCloud からAccess Token取得用の認証コードを取得します。
        /// </summary>
        /// <param name="clientId"> application client id </param>
        public async Task GetOAuthCodeAsync(string clientId)
        {
            const string BaseUrl = "https://www.mixcloud.com/oauth/authorize";

            await Task.Run(() =>
            {
                var url = $"{BaseUrl}?client_id={clientId}&redirect_uri={_RedirectUri}";
                this._RunBrowzer(url);
            });
        }

        /// <summary>
        /// MixCloud から Access Token を取得します。
        /// </summary>
        /// <param name="clientId"> application client id </param>
        /// <param name="clientSecret"> application client secret </param>
        /// <param name="code">oauth code (access token発行用の code) </param>
        public async Task GetAccessTokenAsync(string clientId, string clientSecret, string code)
        {
            const string AuthUrl = "https://www.mixcloud.com/oauth/access_token";

            await Task.Run(async () =>
            {
                var url = $"{AuthUrl}?client_id={clientId}&redirect_uri={_RedirectUri}&client_secret={clientSecret}&code={code}";
                this._RunBrowzer(url);

                var doc = default(IHtmlDocument);

                using var client = new HttpClient();
                using var stream = await client.GetStreamAsync(new Uri(url));

                var parser = new HtmlParser();
                doc = await parser.ParseDocumentAsync(stream);

                var words = doc.Body.TextContent.Split(' ');
                var persedToken = words[5].Split('\n');
                base._AccessToken = persedToken[0].Trim(new char[] { '"' });
            });
        }

        /// <summary>
        /// ブラウザ認証を行うための処理です。
        /// </summary>
        /// <remarks>
        /// .NET Core は Process.Start(url) で既定のブラウザを用いて
        /// Browzing してくれないので、適切に例外処理して対応しています。
        /// </remarks>
        /// <param name="url"></param>
        private void _RunBrowzer(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // For Windows  
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    // For Linux
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    // For Mac  
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
