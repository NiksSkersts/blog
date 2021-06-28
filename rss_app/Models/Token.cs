using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
//https://app.quicktype.io/?l=csharp
namespace rss_app.Models
{
    public partial class Token
    {
        [JsonProperty("token")]
        public TokenClass TokenToken { get; set; }
    }

    public partial class TokenClass
    {
        [JsonProperty("value")]
        public Value Value { get; set; }

        [JsonProperty("formatters")]
        public object[] Formatters { get; set; }

        [JsonProperty("contentTypes")]
        public object[] ContentTypes { get; set; }

        [JsonProperty("declaredType")]
        public object DeclaredType { get; set; }

        [JsonProperty("statusCode")]
        public long StatusCode { get; set; }
    }

    public partial class Value
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiration")]
        public DateTimeOffset Expiration { get; set; }
    }
}