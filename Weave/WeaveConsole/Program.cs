using System;
using System.Net.Http;
using System.Threading.Tasks;
using Weave.MixCloud.EndPoints.Authorization;

namespace WeaveConsole
{
    class Program
    {
        private static Authorization _OAuth { get; set; }
        private const string clientId = "your client id";
        private const string clientSecret = "your client secret";

        static async Task Main(string[] args)
        {
            Console.WriteLine(" ----------- 認証キー(OAuth Code)取得開始 ------------------");

            _OAuth = new Authorization(clientId, clientSecret);
            await _OAuth.GetOAuthCodeAsync(clientId);

            Console.WriteLine(" ----------- 認証キー(OAuth Code)取得完了 ------------------");
            Console.Write("your oauth code = ");
            string oauthCode = Console.ReadLine();

            Console.WriteLine(" ----------- 認証キー(Access Token)取得開始 ------------------");
            await _OAuth.GetAccessTokenAsync(clientId, clientSecret, oauthCode);
            Console.WriteLine(" ----------- 認証キー(Access Token)取得完了 ------------------");
        }
    }
}
