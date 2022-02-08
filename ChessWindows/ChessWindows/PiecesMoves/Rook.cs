using System;

namespace ModernUI.PiecesMoves
{
    class Rook
    {
        public static bool CanRookStep(string color, int start, int finish,
            Func<string, bool> IsOccupied, Func<string, string, bool> IsEnemy)
        {
            color = color.Remove(1, 5);
            int occupiedCoordinate;

            if (start < finish)
            {
                if (start / 10 == finish / 10 || start == finish / 10)
                {
                    for (occupiedCoordinate = start + 1; occupiedCoordinate < finish; occupiedCoordinate++)
                    {
                        if (IsOccupied(occupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }

                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
                else if (start % 10 == finish % 10)
                {
                    for (occupiedCoordinate = start + 10; occupiedCoordinate < finish; occupiedCoordinate += 10)
                    {
                        if (IsOccupied(occupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }

                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
            }
            else
            {
                if (start / 10 == finish / 10 || start == finish / 10)
                {
                    for (occupiedCoordinate = start - 1; occupiedCoordinate > finish; occupiedCoordinate--)
                    {
                        if (IsOccupied(occupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
                else if (start % 10 == finish % 10)
                {
                    for (occupiedCoordinate = start - 10; occupiedCoordinate > finish; occupiedCoordinate -= 10)
                    {
                        if (IsOccupied(occupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }

                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
            }
            return false;
        }
    }
}
