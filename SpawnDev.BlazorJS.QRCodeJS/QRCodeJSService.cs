using Microsoft.AspNetCore.Components;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.QRCodeJS
{
    /// <summary>
    /// QRCodeJSService
    /// </summary>
    public class QRCodeJSService(BlazorJSRuntime JS, NavigationManager NavigationManager) : IAsyncBackgroundService
    {
        ///  <inheritdoc/>
        public Task Ready => QRCode.Init();
        QRCodeOptions CloneQRCodeOptions(QRCodeOptions options)
        {
            return new QRCodeOptions
            {
                ColorDark = options.ColorDark,
                ColorLight = options.ColorLight,
                CorrectLevel = options.CorrectLevel,
                Height = options.Height,
                Width = options.Width,
                Text = options.Text,
            };
        }
        /// <summary>
        /// Create a data url using the specified options
        /// </summary>
        /// <param name="options"></param>
        /// <param name="type"></param>
        /// <param name="textType"></param>
        /// <returns></returns>
        public string CreateDataUrl(QRCodeOptions options, string type = "image/png", DataTextType textType = DataTextType.Text)
        {
            var opts = CloneQRCodeOptions(options);
            opts.Text = GetText(opts.Text, textType);
            using var document = JS.Get<Document>("document");
            using var div = document.CreateElement<HTMLDivElement>("div");
            using var qrcode = new QRCode(div, opts);
            using var canvas = div.QuerySelector<HTMLCanvasElement>("canvas")!;
            var ret = canvas.ToDataURL(type);
            return ret;
        }
        /// <summary>
        /// Creates an HTMLDivElement containing a canvas (hidden) and an image (visible, but with no src set yet).<br/>
        /// The div is not attached to the DOM.<br/>
        /// The canvas has the qr code drawn on it. The image will (eventually) show the data url from the canvas.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="textType"></param>
        /// <returns></returns>
        public HTMLDivElement CreateDiv(QRCodeOptions options, DataTextType textType = DataTextType.Text)
        {
            var opts = CloneQRCodeOptions(options);
            opts.Text = GetText(opts.Text, textType);
            using var document = JS.Get<Document>("document");
            var div = document.CreateElement<HTMLDivElement>("div");
            using var qrcode = new QRCode(div, opts);
            return div;
        }
        /// <summary>
        /// Returns an HTMLCanvasElement with the qr code drawn on it.<br/>
        /// The canvas is not attached to the DOM.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="textType"></param>
        /// <returns></returns>
        public HTMLCanvasElement CreateCanvas(QRCodeOptions options, DataTextType textType = DataTextType.Text)
        {
            using var div = CreateDiv(options, textType);
            var canvas = div.QuerySelector<HTMLCanvasElement>("canvas")!;
            return canvas;
        }
        /// <summary>
        /// Returns a Blob created from the canvas containing the drawn qr code.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="type"></param>
        /// <param name="textType"></param>
        /// <returns></returns>
        public async Task<Blob> CreateBlob(QRCodeOptions options, string type = "image/png", DataTextType textType = DataTextType.Text)
        {
            using var canvas = CreateCanvas(options, textType);
            var blob = await canvas.ToBlobAsync(type);
            return blob;
        }
        /// <summary>
        /// Returns a Blob created from the canvas containing the drawn qr code.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="type"></param>
        /// <param name="quality"></param>
        /// <param name="textType"></param>
        /// <returns></returns>
        public async Task<Blob> CreateBlob(QRCodeOptions options, string type, float quality, DataTextType textType = DataTextType.Text)
        {
            using var canvas = CreateCanvas(options, textType);
            var blob = await canvas.ToBlobAsync(type, quality);
            return blob;
        }
        /// <summary>
        /// Returns a byte[] created from the canvas containing the drawn qr code.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="type"></param>
        /// <param name="textType"></param>
        /// <returns></returns>
        public async Task<byte[]> CreateBytes(QRCodeOptions options, string type = "image/png", DataTextType textType = DataTextType.Text)
        {
            using var canvas = CreateCanvas(options, textType);
            using var blob = await canvas.ToBlobAsync(type);
            using var arrayBuffer = await blob.ArrayBuffer();
            return arrayBuffer.ReadBytes();
        }
        /// <summary>
        /// Returns a byte[] created from the canvas containing the drawn qr code.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="type"></param>
        /// <param name="quality"></param>
        /// <param name="textType"></param>
        /// <returns></returns>
        public async Task<byte[]> CreateBytes(QRCodeOptions options, string type, float quality, DataTextType textType = DataTextType.Text)
        {
            using var canvas = CreateCanvas(options, textType);
            using var blob = await canvas.ToBlobAsync(type, quality);
            using var arrayBuffer = await blob.ArrayBuffer();
            return arrayBuffer.ReadBytes();
        }
        /// <summary>
        /// Returns the text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="textType"></param>
        /// <returns></returns>
        public string GetText(string text, DataTextType textType = DataTextType.Text)
        {
            var txt = text;
            switch (textType)
            {
                case DataTextType.UriRelativeUrl:
                    if (string.IsNullOrEmpty(txt))
                    {
                        txt = NavigationManager.Uri;
                    }
                    else
                    {
                        var pageUrl = new Uri(new Uri(NavigationManager.Uri).GetLeftPart(UriPartial.Path).TrimEnd('/') + "/");
                        txt = new Uri(pageUrl, txt).ToString();
                    }
                    break;
                case DataTextType.BaseUriRelativeUrl:
                    txt = new Uri(new Uri(NavigationManager.BaseUri), txt).ToString();
                    break;
            }
            return txt;
        }
    }
}
