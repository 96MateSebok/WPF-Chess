using System;

namespace ModernUI.PiecesMoves
{
    class Pawn
    {
        public static bool CanPawnStep(string color, int start, int finish, 
            Func<string, bool> IsOccupied, Func<string, string, bool> IsEnemy)
        {
            color = color.Remove(1, 5);
            return color == "B" ? Black(start, finish, IsOccupied, IsEnemy) 
                : White(start, finish, IsOccupied, IsEnemy);
        }

        public static bool White(int start, int finish, 
            Func<string, bool> isOccupied, Func<string, string, bool> isEnemy)
        {
            int occupiedCoordinate;

            if (start < 19 && start - finish == -20 && start != finish) // Kezdésnél 2-t lép előre
            {
                occupiedCoordinate = start + 10;
                if (isOccupied(occupiedCoordinate.ToString()))
                {
                    return false;
                }

                occupiedCoordinate += 10;
                return !isOccupied(occupiedCoordinate.ToString());
            }
            else if (start + 10 == finish) // Egyet lép előre
            {
                occupiedCoordinate = start + 10;
                return !isOccupied(occupiedCoordinate.ToString());
            }
            else if (start - finish == -9) // Balra támad
            {
                occupiedCoordinate = start + 9;
                return isEnemy(occupiedCoordinate.ToString(), "B");
            }
            else if (start - finish == -11) // Jobbra támad
            {
                occupiedCoordinate = start + 11;
                return isEnemy(occupiedCoordinate.ToString(), "B");
            }
            else
            {
                return false;
            }
        }

        public static bool Black(int start, int finish,
            Func<string, bool> IsOccupied, Func<string, string, bool> IsEnemy)
        {
            int occupiedCoordinate;

            if (start > 59 && start - finish == 20 && start != finish) // Kezdésnél 2-t lép előre
            {
                occupiedCoordinate = start - 10;
                if (IsOccupied(occupiedCoordinate.ToString()))
                {
                    return false;
                }
                occupiedCoordinate -= 10;
                return !IsOccupied(occupiedCoordinate.ToString());
            }
            else if (start - 10 == finish) // Egyett lép előre
            {
                occupiedCoordinate = start - 10;
                return !IsOccupied(occupiedCoordinate.ToString());
            }
            else if (start - finish == 9) // Balra támad
            {
                occupiedCoordinate = start - 9;
                return IsEnemy(occupiedCoordinate.ToString(), "W");
            }
            else if (start - finish == 11) // Jobbra támad
            {
                occupiedCoordinate = start - 11;
                return IsEnemy(occupiedCoordinate.ToString(), "W");
            }
            else
            {
                return false;
            }
        }
    }
}
