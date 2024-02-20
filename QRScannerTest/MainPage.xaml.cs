namespace QRScannerTest
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            qrCodeReader.Options = new()
            {
                Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
                AutoRotate = true,
                Multiple = false
            };
        }

        private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            if (e.Results is null) 
                return;
            MainThread.BeginInvokeOnMainThread(new Action(() =>
            {
                // getting the first result.
                string qrCodeValue = e.Results[0].Value;
                qrResultLabel.Text = qrCodeValue;

                if (String.Equals(qrCodeValue, "yes", StringComparison.OrdinalIgnoreCase))
                    resultIndicatorBorder.Stroke = new SolidColorBrush(Colors.Green);
                else if (String.Equals(qrCodeValue, "no", StringComparison.OrdinalIgnoreCase))
                    resultIndicatorBorder.Stroke = new SolidColorBrush(Colors.Red);
                else
                    resultIndicatorBorder.Stroke = new SolidColorBrush(Colors.Yellow);
            }));

            // We can create a viewmodel and bind the properties border stroke property using converters or data trigger to set.
            // Also, we can bind the result value property to label text
        }
    }

}
