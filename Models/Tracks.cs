using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpotifyPlaylistsApi.Models
{
    public class Tracks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("external_id")]
        [Required]
        public string ExternalId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("duration_ms")]
        public long DurationMs { get; set; }

        [JsonProperty("external_url_spotify")]
        public string ExternalUrlSpotify { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }


        //[ForeignKey("Playlist")]
        //public long PlaylistRefId { get; set; }
        //public virtual Playlists Playlist { get; set; }

        public virtual ICollection<Artists> Artists { get; set; }
    }
}
