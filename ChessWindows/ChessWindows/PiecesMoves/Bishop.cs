using System;

namespace ModernUI.PiecesMoves
{
    class Bishop
    {
        public static bool CanBishopStep(string color, int start, int finish,
            Func<string, bool> IsOccupied, Func<string, string, bool> IsEnemy)
        {
            color = color.Remove(1, 5);
            int startY = 0,
                startX = start,
                finishY = 0,
                finishX = finish,
                fakeStart1 = start,
                fakeStart2 = start,
                fakeStart3 = start,
                fakeStart4 = start;
            int occupiedCoordinate;
            bool canStep = false;

            if (start > 9)
            {
                startY = (start - (start % 10)) / 10;
                startX = start % 10;
            }

            if (finish > 9)
            {
                finishY = (finish - (finish % 10)) / 10;
                finishX = finish % 10;
            }

            for (int i = 0; i < 7; i++) // A lépés lehetséges e
            {
                fakeStart1 += 11;
                fakeStart2 -= 11;
                fakeStart3 += 9;
                fakeStart4 -= 9;
                if (fakeStart1 == finish ||
                   fakeStart2 == finish ||
                   fakeStart3 == finish ||
                   fakeStart4 == finish)
                {
                    canStep = true;
                    break;
                }
            }

            if ((startX < finishX) && canStep)
            {
                if (startY < finishY) // Jobbra fel
                {
                    for (occupiedCoordinate = start + 11; occupiedCoordinate < finish; occupiedCoordinate += 11)
                    {
                        if (IsOccupied(occupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
                else // Jobbra le
                {
                    for (occupiedCoordinate = start - 9; occupiedCoordinate > finish; occupiedCoordinate -= 9)
                    {
                        if (IsOccupied(occupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
            }
            else if (canStep)
            {
                if (startY < finishY) //Balra fel
                {
                    for (occupiedCoordinate = start + 9; occupiedCoordinate < finish; occupiedCoordinate += 9)
                    {
                        if (IsOccupied(occupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
                else //Balra le
                {
                    for (occupiedCoordinate = start - 11; occupiedCoordinate > finish; occupiedCoordinate -= 11)
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
