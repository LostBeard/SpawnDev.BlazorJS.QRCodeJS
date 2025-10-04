using System.Text.Json.Serialization;
using static SpawnDev.BlazorJS.QRCodeJS.QRCode;

namespace SpawnDev.BlazorJS.QRCodeJS
{
    /// <summary>
    /// 
    /// </summary>
    public class QRCodeOptions
    {
        /// <summary>
        /// Allows implicit conversion from a string to a QRCodeOptions
        /// </summary>
        /// <param name="text"></param>
        public static implicit operator QRCodeOptions(string text) => new QRCodeOptions { Text = text };
        /// <summary>
        /// QRCode link data
        /// </summary>
        public string Text { get; set; } = "";
        /// <summary>
        /// Width. Default 256
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width { get; set; }
        /// <summary>
        /// Height. Default 256
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Height { get; set; }
        /// <summary>
        /// The dark color to use. Default: #000000
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ColorDark { get; set; }
        /// <summary>
        /// The light color to use. Default: #ffffff
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ColorLight { get; set; }
        /// <summary>
        /// CorrectLevel. Default: CorrectLevel.H
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CorrectLevel? CorrectLevel { get; set; }
    }
}
