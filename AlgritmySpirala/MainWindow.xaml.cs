using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlgritmySpirala {

    public partial class MainWindow : Window {
        private double wallLength = 400;
        private static double gap = 40;
        private double startX = 200;
        private double startY = 200;
        private double workingGap = gap / 2;

        public MainWindow() {
            InitializeComponent();
            DrawSpiral(startX, startY, wallLength, 0, 0);
        }

        private void DrawSpiral(double currentX, double currentY, double length, int direction, int steps) {
            if (length <= workingGap)
                return;

            if (steps == 1) {
                length += workingGap;
            }

            if (steps >= 3) {
                length -= workingGap;
            }

            DrawLine(currentX, currentY, length, direction);

            switch (direction) {
                case 0:
                    currentX += length;
                    break;
                case 1:
                    currentY += length;
                    break;
                case 2:
                    currentX -= length;
                    break;
                case 3:
                    currentY -= length;
                    break;
            }

            direction = (direction + 1) % 4;

            if (steps == 1) {
                length -= workingGap;
            }

            DrawSpiral(currentX, currentY, length, direction, steps + 1);
        }

        private void DrawLine(double startX, double startY, double length, int direction) {
            Line line = new Line {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                X1 = startX,
                Y1 = startY
            };

            switch (direction) {
                case 0:
                    line.X2 = startX + length;
                    line.Y2 = startY;
                    break;
                case 1:
                    line.X2 = startX;
                    line.Y2 = startY + length;
                    break;
                case 2:
                    line.X2 = startX - length;
                    line.Y2 = startY;
                    break;
                case 3:
                    line.X2 = startX;
                    line.Y2 = startY - length;
                    break;
            }

            SpiralCanvas.Children.Add(line);
        }
    }
}