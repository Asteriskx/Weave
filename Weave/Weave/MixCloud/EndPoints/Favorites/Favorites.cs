using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Weave.MixCloud.EndPoints.Favorites
{
    public class Favorites
    {
        public Paging Paging { get; set; }
        public Data[] Data { get; set; }
        public string Name { get; set; }

        public Favorites() { }

        /// <summary>
        /// MixCloud からお気に入り登録した曲情報を取得します。
        /// </summary>
        /// <param name="clientId"> application client id </param>
        public async Task GetFavoriteSongsAsync(string accessToken, string userName)
        {
            const string BaseUrl = "https://api.mixcloud.com/";

            await Task.Run(() =>
            {
                var url = $"{BaseUrl}{userName}/Favorites/";
                //this._RunBrowzer(url);
            });
        }
    }

    public class Paging
    {
        [JsonProperty("previous")]
        public string Previous { get; set; }
    }

    public class Data
    {
        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }

        [JsonProperty("play_count")]
        public int PlayCount { get; set; }

        [JsonProperty("user")]
        public User.User User { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("audio_length")]
        public int AudioLength { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        [JsonProperty("listener_count")]
        public int ListenerCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("pictures")]
        public Pictures1 Pictures { get; set; }

        [JsonProperty("repost_count")]
        public int RepostCount { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }
    }

    public class Pictures1
    {
        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("768wx768h")]
        public string _768wx768h { get; set; }

        [JsonProperty("320wx320h")]
        public string _320wx320h { get; set; }

        [JsonProperty("extra_large")]
        public string ExtraLarge { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("640wx640h")]
        public string _640wx640h { get; set; }

        [JsonProperty("medium_mobile")]
        public string MediumMobile { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("1024wx1024h")]
        public string _1024wx1024h { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }

    public class Tag
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }

}