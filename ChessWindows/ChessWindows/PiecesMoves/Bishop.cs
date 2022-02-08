using System;

namespace ModernUI.PiecesMoves
{
    class Bishop
    {
        public static bool CanBishopStep(String Color, int Start, int Finish,
            Func<String, bool> isOccupied, Func<String, String, bool> isEnemy)
        {
            Color = Color.Remove(1, 5);
            int StartY = 0,
                StartX = Start,
                FinishY = 0,
                FinishX = Finish,
                FakeStart1 = Start,
                FakeStart2 = Start,
                FakeStart3 = Start,
                FakeStart4 = Start;
            int OccupiedCoordinate;
            bool CanStep = false;

            if (Start > 9)
            {
                StartY = (Start - (Start % 10)) / 10;
                StartX = Start % 10;
            }

            if (Finish > 9)
            {
                FinishY = (Finish - (Finish % 10)) / 10;
                FinishX = Finish % 10;
            }

            for (int i = 0; i < 7; i++)
            {
                FakeStart1 += 11;
                FakeStart2 -= 11;
                FakeStart3 += 9;
                FakeStart4 -= 9;
                if (FakeStart1 == Finish ||
                   FakeStart2 == Finish ||
                   FakeStart3 == Finish ||
                   FakeStart4 == Finish)
                {
                    CanStep = true;
                    break;
                }
            }

            if ((StartX < FinishX) && CanStep)
            {
                if (StartY < FinishY) // Jobbra fel
                {
                    for (OccupiedCoordinate = Start + 11; OccupiedCoordinate < Finish; OccupiedCoordinate += 11)
                    {
                        if (isOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !isOccupied(Finish.ToString()) || !isEnemy(Finish.ToString(), Color);
                }
                else // Jobbra le
                {
                    for (OccupiedCoordinate = Start - 9; OccupiedCoordinate > Finish; OccupiedCoordinate -= 9)
                    {
                        if (isOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !isOccupied(Finish.ToString()) || !isEnemy(Finish.ToString(), Color);
                }
            }
            else if (CanStep)
            {
                if (StartY < FinishY) //Balra fel
                {
                    for (OccupiedCoordinate = Start + 9; OccupiedCoordinate < Finish; OccupiedCoordinate += 9)
                    {
                        if (isOccupied(OccupiedCoordinate.ToString()))
                        {
                            return false;
                        }
                    }
                    return !isOccupied(Finish.ToString()) || !isEnemy(Finish.ToString(), Color);
                }
                else //Balra le
                {
                    for (OccupiedCoordinate = Start - 11; OccupiedCoordinate > Finish; OccupiedCoordinate -= 11)
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
