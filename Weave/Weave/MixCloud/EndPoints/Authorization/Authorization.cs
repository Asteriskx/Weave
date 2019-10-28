using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Weave.MixCloud.EndPoints.Authorization
{
    /// <summary>
    /// MixCloud 認証クラス
    /// </summary>
    public class Authorization : MixCloudCredentials
    {
        private const string _BaseUrl = "https://www.mixcloud.com/oauth/authorize";
        private const string _RedirectUri = "www.example.com";

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
        /// <param name="clientId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task GetOAuthCodeAsync(string clientId, HttpMethod type)
        {
            await Task.Run(() =>
            {
                var url = $"{_BaseUrl}?client_id={clientId}&redirect_uri={_RedirectUri}";
                this._RunBrowzer(url);
            });
        }

        /// <summary>
        /// MixCloud から Access Token を取得します。
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task GetAccessTokenAsync(string clientId, string clientSecret, string code)
        {
            const string AuthUrl = "https://www.mixcloud.com/oauth/access_token";

            await Task.Run(() =>
            {
                var url = $"{AuthUrl}?client_id={clientId}&redirect_uri={_RedirectUri}&client_secret={clientSecret}&code={code}";
                this._RunBrowzer(url);
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
