using System;

namespace ModernUI.PiecesMoves
{
    class Horse
    {
        public static bool CanHorseStep(String Color, int Start, int Finish,
            Func<String, bool> isOccupied, Func<String, String, bool> isEnemy)
        {
            Color = Color.Remove(1, 5);

            if (Start - 21 == Finish || Start + 21 == Finish ||
               Start - 19 == Finish || Start + 19 == Finish ||
               Start - 12 == Finish || Start + 12 == Finish ||
               Start - 8 == Finish || Start + 8 == Finish)
            {
                return !isOccupied(Finish.ToString()) || !isEnemy(Finish.ToString(), Color);
            }
            else
            {
                return false;
            }
        }
    }
}
