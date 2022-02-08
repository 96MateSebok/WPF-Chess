using System;

namespace ModernUI.PiecesMoves
{
    class Pawn
    {
        public static bool CanPawnStep(string Color, int start, int finish, 
            Func<string, bool> isOccupied, Func<string, string, bool> isEnemy)
        {
            Color = Color.Remove(1, 5);
            return Color == "B" ? Black(start, finish, isOccupied, isEnemy) : White(start, finish, isOccupied, isEnemy);
        }

        public static bool White(int start, int finish, 
            Func<string, bool> isOccupied, Func<string, string, bool> isEnemy)
        {
            int OccupiedCoordinate;

            if (start < 19 && start - finish == -20 && start != finish) // Kezdésnél 2-t lép előre
            {
                OccupiedCoordinate = start + 10;
                if (isOccupied(OccupiedCoordinate.ToString()))
                {
                    return false;
                }

                OccupiedCoordinate += 10;
                return !isOccupied(OccupiedCoordinate.ToString());
            }
            else if (start + 10 == finish) // Egyet lép előre
            {
                OccupiedCoordinate = start + 10;
                return !isOccupied(OccupiedCoordinate.ToString());
            }
            else if (start - finish == -9) // Balra támad
            {
                OccupiedCoordinate = start + 9;
                return isEnemy(OccupiedCoordinate.ToString(), "B");
            }
            else if (start - finish == -11) // Jobbra támad
            {
                OccupiedCoordinate = start + 11;
                return isEnemy(OccupiedCoordinate.ToString(), "B");
            }
            else
            {
                return false;
            }
        }

        public static bool Black(int start, int finish,
            Func<String, bool> isOccupied, Func<String, String, bool> isEnemy)
        {
            int OccupiedCoordinate;

            if (start > 59 && start - finish == 20 && start != finish) // Kezdésnél 2-t lép előre
            {
                OccupiedCoordinate = start - 10;
                if (isOccupied(OccupiedCoordinate.ToString()))
                {
                    return false;
                }
                OccupiedCoordinate -= 10;
                return !isOccupied(OccupiedCoordinate.ToString());
            }
            else if (start - 10 == finish) // Egyett lép előre
            {
                OccupiedCoordinate = start - 10;
                return !isOccupied(OccupiedCoordinate.ToString());
            }
            else if (start - finish == 9) // Balra támad
            {
                OccupiedCoordinate = start - 9;
                return isEnemy(OccupiedCoordinate.ToString(), "W");
            }
            else if (start - finish == 11) // Jobbra támad
            {
                OccupiedCoordinate = start - 11;
                return isEnemy(OccupiedCoordinate.ToString(), "W");
            }
            else
            {
                return false;
            }
        }
    }
}
