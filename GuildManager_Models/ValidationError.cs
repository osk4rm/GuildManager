using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GuildManager_Models
{
    public class ValidationError
    {
        [JsonPropertyName("propertyName")]
        public string PropertyName { get; set; }

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("attemptedValue")]
        public string AttemptedValue { get; set; }

        [JsonPropertyName("customState")]
        public object CustomState { get; set; }

        [JsonPropertyName("severity")]
        public int? Severity { get; set; }

        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }
    }
}
