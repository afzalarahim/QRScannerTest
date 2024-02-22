using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui;

namespace QRScannerTest
{
    public static class DataStore
    {
        public static BarcodeResult[]? Results { get; set; }
    }
}
