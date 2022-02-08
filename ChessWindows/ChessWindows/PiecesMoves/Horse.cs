using System;

namespace ModernUI.PiecesMoves
{
    class Horse
    {
        public static bool CanHorseStep(String Color, int start, int finish,
            Func<string, bool> isOccupied, Func<string, string, bool> IsEnemy)
        {
            Color = Color.Remove(1, 5);

            if (start - 21 == finish || start + 21 == finish ||
               start - 19 == finish || start + 19 == finish ||
               start - 12 == finish || start + 12 == finish ||
               start - 8 == finish || start + 8 == finish)
            {
                return !isOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), Color);
            }
            else
            {
                return false;
            }
        }
    }
}
