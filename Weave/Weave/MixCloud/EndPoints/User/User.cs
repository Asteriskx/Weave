using Newtonsoft.Json;

namespace Weave.MixCloud.EndPoints.User
{
    public class User
    {
        public User() { }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("pictures")]
        public Pictures Pictures { get; set; }
    }

    public class Pictures
    {
        [JsonProperty("medium")]
        public string Medium { get; set; }

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

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
