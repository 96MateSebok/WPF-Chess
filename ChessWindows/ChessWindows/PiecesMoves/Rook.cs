using System;

namespace ModernUI.PiecesMoves
{
    class Rook
    {
        public static bool CanRookStep(String Color, int Start, int Finish,
            Func<String, bool> isOccupied, Func<String, String, bool> isEnemy)
        {
            Color = Color.Remove(1, 5);
            int OccupiedCoordinate;

            if (Start < Finish)
            {
                if (Start / 10 == Finish / 10 || Start == Finish / 10)
                {
                    for (OccupiedCoordinate = Start + 1; OccupiedCoordinate < Finish; OccupiedCoordinate++)
                    {
                        if (isOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !isOccupied(Finish.ToString()) || !isEnemy(Finish.ToString(), Color);
                }
                else if (Start % 10 == Finish % 10)
                {
                    for (OccupiedCoordinate = Start + 10; OccupiedCoordinate < Finish; OccupiedCoordinate += 10)
                    {
                        if (isOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }

                    return !isOccupied(Finish.ToString()) || !isEnemy(Finish.ToString(), Color);
                }
            }
            else
            {
                if (Start / 10 == Finish / 10 || Start == Finish / 10)
                {
                    for (OccupiedCoordinate = Start - 1; OccupiedCoordinate > Finish; OccupiedCoordinate--)
                    {
                        if (isOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !isOccupied(Finish.ToString()) || !isEnemy(Finish.ToString(), Color);
                }
                else if (Start % 10 == Finish % 10)
                {
                    for (OccupiedCoordinate = Start - 10; OccupiedCoordinate > Finish; OccupiedCoordinate -= 10)
                    {
                        if (isOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }

                    return !isOccupied(Finish.ToString()) || !isEnemy(Finish.ToString(), Color);
                }
            }
            return false;
        }
    }
}
