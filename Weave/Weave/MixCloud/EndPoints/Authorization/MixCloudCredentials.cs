namespace Weave.MixCloud.EndPoints.Authorization
{
    /// <summary>
    /// Mixcloud 認証情報管理クラス
    /// </summary>
    public class MixCloudCredentials
    {
        #region Tokens

        /// <summary>
        /// Access Token
        /// </summary>
        public string _AccessToken { get; protected set; } = "";

        /// <summary>
        /// Client ID
        /// </summary>
        public string _ClientId { get; private set; } = "";

        /// <summary>
        /// Client Secret
        /// </summary>
        protected string _ClientSecret { get; private set; } = "";

        #endregion Tokens

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        protected MixCloudCredentials(string clientId, string clientSecret) 
        {
            this._ClientId = clientId;
            this._ClientSecret = clientSecret;
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetAccessToken => this._AccessToken;


        #endregion Constructor
    }
}
