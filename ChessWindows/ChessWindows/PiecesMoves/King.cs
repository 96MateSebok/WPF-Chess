using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModernUI.PiecesMoves
{
    class King
    {
        public static bool CanKingStep(String Color, int Start, int Finish,
            Func<String, String, bool> isEnemy)
        {
            Color = Color.Remove(1, 5);

            if (Start + 9 == Finish || //Balre fel
                Start - 9 == Finish || //Jobbra le
                Start + 11 == Finish || //Jobbra fel
                Start - 11 == Finish || //Balra le
                Start + 1 == Finish || //Jobbra
                Start - 1 == Finish || // Balra
                Start + 10 == Finish || // Fel
                Start - 10 == Finish) //Le
            {
                return !isEnemy(Finish.ToString(), Color);
            }

            return false;

        }
    }
}
