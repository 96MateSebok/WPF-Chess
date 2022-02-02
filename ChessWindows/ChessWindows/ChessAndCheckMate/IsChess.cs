using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUI.ChessAndCheckMate
{
    class IsChess
    {
        public static bool ChessWhitePawn(int x, int y, Func<String, String, bool> IsKing)
        {
            if (x == 7)
            {
                return false;
            }

            if (y == 0)
            {
                y++;
                x++;

                return IsKing(x.ToString() + y.ToString(), "B");
            }
            else if (y == 7)
            {
                x++;
                y--;

                return IsKing(x.ToString() + y.ToString(), "B");
            }
            else
            {
                x++;
                return IsKing(x.ToString() + (y + 1).ToString(), "B") || 
                    IsKing(x.ToString() + (y - 1).ToString(), "B");
            }
        }

        public static bool ChessBlackPawn(int x, int y, Func<String, String, bool> IsKing)
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

        public static bool ChessHorse(int x, int y, Func<String, String, bool> IsKing)
        {

            return false;
        }

        public static bool ChessBishop(int x, int y, Func<String, String, bool> IsKing)
        {

            return false;
        }

        public static bool ChessRook(int x, int y, Func<String, String, bool> IsKing)
        {

            return false;
        }
    }
}
