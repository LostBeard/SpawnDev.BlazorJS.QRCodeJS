using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.QRCodeJS
{
    /// <summary>
    /// 
    /// </summary>
    public class QRCode : JSObject
    {
        static Task? _Init;
        /// <summary>
        /// Loads the QRCode.js Javascript library
        /// </summary>
        /// <returns></returns>
        public static Task Init()
        {
            _Init ??= JS.LoadScript($"_content/{typeof(QRCodeJSService).Namespace!}/qrcode.min.js", "QRCode");
            return _Init;
        }
        /// <summary>
        /// 
        /// </summary>
        public enum CorrectLevel
        {
            /// <summary>
            /// 
            /// </summary>
            M = 0,
            /// <summary>
            /// 
            /// </summary>
            L = 1,
            /// <summary>
            /// 
            /// </summary>
            H = 2,
            /// <summary>
            /// 
            /// </summary>
            Q = 3,
        }
        /// <inheritdoc/>
        public QRCode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="el"></param>
        /// <param name="options"></param>
        public QRCode(HTMLElement el, QRCodeOptions options) : base(JS.New(nameof(QRCode), el, options)) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="el"></param>
        /// <param name="text"></param>
        public QRCode(HTMLElement el, string text) : base(JS.New(nameof(QRCode), el, text)) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="el"></param>
        /// <param name="options"></param>
        public QRCode(ElementReference el, QRCodeOptions options) : base(JS.New(nameof(QRCode), el, options)) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="el"></param>
        /// <param name="text"></param>
        public QRCode(ElementReference el, string text) : base(JS.New(nameof(QRCode), el, text)) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="options"></param>
        public QRCode(string id, QRCodeOptions options) : base(JS.New(nameof(QRCode), id, options)) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        public QRCode(string id, string text) : base(JS.New(nameof(QRCode), id, text)) { }
        /// <summary>
        /// Create a code with the specified text
        /// </summary>
        /// <param name="text"></param>
        public void MakeCode(string text) => JSRef!.CallVoid("makeCode", text);
        /// <summary>
        /// Make the Image from Canvas element
        /// - It occurs automatically
        /// </summary>
        public void MakeImage() => JSRef!.CallVoid("makeImage");
        /// <summary>
        /// Clear the QRCode
        /// </summary>
        public void Clear() => JSRef!.CallVoid("clear");
    }
}
