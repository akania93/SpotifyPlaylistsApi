using Newtonsoft.Json;

namespace SpotifyPlaylistsApi.Models
{
    public class PlaylistCategories
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
