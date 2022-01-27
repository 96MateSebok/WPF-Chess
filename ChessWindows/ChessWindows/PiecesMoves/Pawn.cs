using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ModernUI.PiecesMoves
{
    class Pawn
    {
        public static bool CanPawStep(String Color, int Start, int Finish, 
            Func<String, bool> isOccupied, Func<String, String, bool> isEnemy)
        {
            Color = Color.Remove(1, 5);
            return Color == "B" ? Black(Start, Finish, isOccupied, isEnemy) : White(Start, Finish, isOccupied, isEnemy);

        }

        public static bool White(int Start, int Finish, 
            Func<String, bool> isOccupied, Func<String, String, bool> isEnemy)
        {
            int OccupiedCoordinate;

            if (Start < 19 && Start - Finish == -20 && Start != Finish) // Kezdésnél 2-t lép előre
            {
                OccupiedCoordinate = Start + 10;
                if (isOccupied(OccupiedCoordinate.ToString()))
                {
                    return false;
                }
                OccupiedCoordinate += 10;
                return !isOccupied(OccupiedCoordinate.ToString());
            }
            else if (Start + 10 == Finish) // Egyett lép előre
            {
                OccupiedCoordinate = Start + 10;
                return !isOccupied(OccupiedCoordinate.ToString());
            }
            else if (Start - Finish == -9) // Balra támad
            {
                OccupiedCoordinate = Start + 9;
                return isEnemy(OccupiedCoordinate.ToString(), "B");
            }
            else if (Start - Finish == -11) // Jobbra támad
            {
                OccupiedCoordinate = Start + 11;
                return isEnemy(OccupiedCoordinate.ToString(), "B"); ;
            }
            else
            {
                return false;
            }
        }
        public static bool Black(int Start, int Finish,
            Func<String, bool> isOccupied, Func<String, String, bool> isEnemy)
        {
            int OccupiedCoordinate;

            if (Start > 59 && Start - Finish == 20 && Start != Finish) // Kezdésnél 2-t lép előre
            {
                OccupiedCoordinate = Start - 10;
                if (isOccupied(OccupiedCoordinate.ToString()))
                {
                    return false;
                }
                OccupiedCoordinate -= 10;
                return !isOccupied(OccupiedCoordinate.ToString());
            }
            else if (Start - 10 == Finish) // Egyett lép előre
            {
                OccupiedCoordinate = Start - 10;
                return !isOccupied(OccupiedCoordinate.ToString());
            }
            else if (Start - Finish == 9) // Balra támad
            {
                OccupiedCoordinate = Start - 9;
                return isEnemy(OccupiedCoordinate.ToString(), "W");
            }
            else if (Start - Finish == 11) // Jobbra támad
            {
                OccupiedCoordinate = Start - 11;
                return isEnemy(OccupiedCoordinate.ToString(), "W");
            }
            else
            {
                return false;
            }
        }
    }
}
