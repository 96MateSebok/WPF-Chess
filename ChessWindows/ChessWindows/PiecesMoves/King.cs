using System;

namespace ModernUI.PiecesMoves
{
    class King
    {
        public static bool CanKingStep(string color, int start, int finish,
            Func<string, string, bool> IsEnemy)
        {
            color = color.Remove(1, 5);

            if (start + 9 == finish || //Balre fel
                start - 9 == finish || //Jobbra le
                start + 11 == finish || //Jobbra fel
                start - 11 == finish || //Balra le
                start + 1 == finish || //Jobbra
                start - 1 == finish || // Balra
                start + 10 == finish || // Fel
                start - 10 == finish) //Le
            {
                return !IsEnemy(finish.ToString(), color);
            }

            return false;

        }
    }
}
