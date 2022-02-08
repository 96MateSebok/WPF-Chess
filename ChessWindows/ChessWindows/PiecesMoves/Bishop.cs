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
                FakeStart2 = start,
                FakeStart3 = start,
                FakeStart4 = start;
            int OccupiedCoordinate;
            bool CanStep = false;

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

            for (int i = 0; i < 7; i++)
            {
                fakeStart1 += 11;
                FakeStart2 -= 11;
                FakeStart3 += 9;
                FakeStart4 -= 9;
                if (fakeStart1 == finish ||
                   FakeStart2 == finish ||
                   FakeStart3 == finish ||
                   FakeStart4 == finish)
                {
                    CanStep = true;
                    break;
                }
            }

            if ((startX < finishX) && CanStep)
            {
                if (startY < finishY) // Jobbra fel
                {
                    for (OccupiedCoordinate = start + 11; OccupiedCoordinate < finish; OccupiedCoordinate += 11)
                    {
                        if (IsOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
                else // Jobbra le
                {
                    for (OccupiedCoordinate = start - 9; OccupiedCoordinate > finish; OccupiedCoordinate -= 9)
                    {
                        if (IsOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
            }
            else if (CanStep)
            {
                if (startY < finishY) //Balra fel
                {
                    for (OccupiedCoordinate = start + 9; OccupiedCoordinate < finish; OccupiedCoordinate += 9)
                    {
                        if (IsOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !IsOccupied(finish.ToString()) || !IsEnemy(finish.ToString(), color);
                }
                else //Balra le
                {
                    for (OccupiedCoordinate = start - 11; OccupiedCoordinate > finish; OccupiedCoordinate -= 11)
                    {
                        if (IsOccupied(OccupiedCoordinate.ToString()))
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
