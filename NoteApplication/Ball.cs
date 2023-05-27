using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteApplication
{
    public class Ball : Control, IBall
    {
        public event EventHandler CircleClicked;
        private Dictionary<Color, int> colorScore = new Dictionary<Color, int>()
        {
            {Color.MediumAquamarine, 1 },
            {Color.DarkOrange, 3 },
            {Color.BlueViolet, 5 },
            {Color.Black, 2 }
        };

        public Ball(int diameter, int x, int y, Random colorPickerRandom)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            Width = Height = diameter;
            Location = new Point(x, y);
            int randomIndex = colorPickerRandom.Next(colorScore.Count);
            ForeColor = colorScore.ElementAt(randomIndex).Key;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var brush = new SolidBrush(ForeColor))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                e.Graphics.FillEllipse(brush, ClientRectangle);
            }

        }

        public void ScoreByColor(ref int hearts, ref int score)
        {
            if (this.ForeColor == Color.Black)
            {
                --hearts;
            }
            else
            {
                score += colorScore[this.ForeColor];
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            double distance = Math.Sqrt(Math.Pow(e.X - Width / 2, 2) + Math.Pow(e.Y - Height / 2, 2));
            if (distance <= Width / 2)
            {
                CircleClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        public void BallDisappearHpHandler(ref int hearts, ref int score)
        {
            if (this.ForeColor != Color.Black)
            {
                --hearts;
            }
            else
            {
                score += colorScore[this.ForeColor];
            }
        }
    }
}
