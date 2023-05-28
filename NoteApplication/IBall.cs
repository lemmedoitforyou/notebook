using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteApplication
{
    internal interface IBall
    {
        void ScoreByColor(ref int hearts, ref int score);
        void BallDisappearHpHandler(ref int hearts, ref int score);
    }
}
