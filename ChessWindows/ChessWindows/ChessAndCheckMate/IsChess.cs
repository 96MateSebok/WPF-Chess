using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUI.ChessAndCheckMate
{
    class IsChess
    {
        public static bool ChessWhitePawn(int x, int y, Func<String, String, String> IsKing)
        {
            bool result = false;
            if (x == 7)
            {
                return false;
            }

            if (y == 0)
            {
                y++;
                x++;

                result = IsKing(x.ToString() + y.ToString(), "B") == "BK";
            }
            else if (y == 7)
            {
                x++;
                y--;

                result = IsKing(x.ToString() + y.ToString(), "B") == "BK";
            }
            else
            {
                x++;
                result = IsKing(x.ToString() + (y + 1).ToString(), "B") ? 
                    IsKing(x.ToString() + (y - 1).ToString(), "B") : "BK";
            }

            return result;
        }

        public static bool ChessBlackPawn(int x, int y, Func<String, String, String> IsKing)
        {
            if (x == 0)
            {
                return false;
            }

            if (y == 0)
            {
                y++;
                x--;

                return IsKing(x.ToString() + y.ToString(), "W");
            }
            else if (y == 6)
            {
                x--;
                y--;

                return IsKing(x.ToString() + y.ToString(), "W");
            }
            else
            {
                x--;
                return IsKing(x.ToString() + (y + 1).ToString(), "W") ||
                    IsKing(x.ToString() + (y - 1).ToString(), "W");
            }
        }

        public static bool ChessHorse(int x, int y, string Color,Func<String, String, String> IsKing)
        {
            bool result = false;            

            if (x > 0 && y < 5 && !result) // Balra 1, fel 2
            {
                result = IsKing((x - 1).ToString() + (y + 2).ToString(), Color);
            }

            if (x < 7 && y < 5 && !result) //Jobbra 1, fel 2
            {
                result = IsKing((x + 1).ToString() + (y + 2).ToString(), Color);
            }

            if (x > 0 && y > 1 && !result) //Balra 1, le 2
            {
                result = IsKing((x - 1).ToString() + (y - 2).ToString(), Color);
            }

            if (x < 7 && y > 1 && !result) //Jobbra 1, le 2
            {
                result = IsKing((x + 1).ToString() + (y - 2).ToString(), Color);
            }

            if (x > 1 && y > 0) //Balra 2, le 1
            {
                result = IsKing((x - 2).ToString() + (y - 1).ToString(), Color);
            }

            if (x > 1 && y < 7) //Balra 2, fel 1
            {
                result = IsKing((x - 2).ToString() + (y + 1).ToString(), Color);
            }

            if (x < 7 && y > 1 && !result) //Jobbra 2, fel 1
            {
                result = IsKing((x + 2).ToString() + (y + 1).ToString(), Color);
            }

            if (x < 7 && y > 1 && !result) //Jobbra 2, le 1
            {
                result = IsKing((x + 2).ToString() + (y - 1).ToString(), Color);
            }

            return result;
        }

        public static bool ChessBishop(int x, int y, Func<String, String, String> IsKing)
        {

            return false;
        }

        public static bool ChessRook(int x, int y, Func<String, String, String> IsKing)
        {

            return false;
        }
    }
}
