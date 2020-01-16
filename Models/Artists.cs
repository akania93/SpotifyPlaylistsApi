using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SpotifyPlaylistsApi.Models
{
    public class Artists
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("external_url_spotify")]
        public string ExternalUrlSpotify { get; set; }



        //[ForeignKey("Track")]
        //public long TrackRefId { get; set; }
        //public virtual Tracks Track { get; set; }
    }
}
