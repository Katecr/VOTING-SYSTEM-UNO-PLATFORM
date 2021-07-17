using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace PUNTO_VOTACION.Models
{
    class TokesResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiration")]
        public DateTimeOffset Expiration { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
