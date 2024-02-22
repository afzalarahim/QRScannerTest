
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRScannerTest
{


    public class CameraOverlay : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (DataStore.Results == null || !DataStore.Results.Any())
                return;

            foreach (var result in DataStore.Results)
            {
                Color strokeColor = Colors.Yellow;
                if (result.Value?.Equals("yes", StringComparison.OrdinalIgnoreCase) == true)
                    strokeColor = Colors.Green;
                else if (result.Value?.Equals("no", StringComparison.OrdinalIgnoreCase) == true)
                    strokeColor = Colors.Red;

                canvas.StrokeColor = strokeColor;
                canvas.StrokeSize = 3;

                var x = result.PointsOfInterest.Select(p => p.X).OrderBy(x => x).FirstOrDefault();
                var x_l = result.PointsOfInterest.Select(p => p.X).OrderBy(x => x).LastOrDefault();

                var y = result.PointsOfInterest.Select(p => p.Y).OrderBy(y => y).FirstOrDefault();
                var y_l = result.PointsOfInterest.Select(p => p.Y).OrderBy(y => y).LastOrDefault();

                canvas.DrawRectangle(x, y, x_l - x, y_l - y);
            }

        }
    }
}
