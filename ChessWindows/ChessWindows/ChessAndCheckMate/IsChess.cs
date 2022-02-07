﻿using System;
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
            else if (y == 7 && !result)
            {
                x++;
                y--;

                result = IsKing(x.ToString() + y.ToString(), "B") == "BK";
            }
            else if (!result)
            {
                x++;
                result = IsKing(x.ToString() + (y + 1).ToString(), "B") == "BK"  ||
                    IsKing(x.ToString() + (y - 1).ToString(), "B") == "BK";
            }

            return result;
        }

        public static bool ChessBlackPawn(int x, int y, Func<String, String, String> IsKing)
        {
            bool result = false;

            if (x == 0)
            {
                return false;
            }

            if (y == 0)
            {
                y++;
                x--;

                result = IsKing(x.ToString() + y.ToString(), "W") == "WK";
            }
            else if (y == 6 && !result)
            {
                x--;
                y--;

                result = IsKing(x.ToString() + y.ToString(), "W") == "WK";
            }
            else if (!result)
            {
                x--;
                result = IsKing(x.ToString() + (y + 1).ToString(), "W") == "WK" ||
                    IsKing(x.ToString() + (y - 1).ToString(), "W") == "WK";
            }
            return result;
        }

        public static bool ChessHorse(int x, int y, string Color,Func<String, String, String> IsKing)
        {
            bool result = false;            

            if (x > 0 && y < 5 && !result) // Balra 1, fel 2
            {
                result = IsKing((x - 1).ToString() + (y + 2).ToString(), Color) == Color + "K";
            }

            if (x < 7 && y < 5 && !result) // Jobbra 1, fel 2
            {
                result = IsKing((x + 1).ToString() + (y + 2).ToString(), Color) == Color + "K";
            }

            if (x > 0 && y > 1 && !result) // Balra 1, le 2
            {
                result = IsKing((x - 1).ToString() + (y - 2).ToString(), Color) == Color + "K";
            }

            if (x < 7 && y > 1 && !result) // Jobbra 1, le 2
            {
                result = IsKing((x + 1).ToString() + (y - 2).ToString(), Color) == Color + "K";
            }

            if (x > 1 && y > 0) // Balra 2, le 1
            {
                result = IsKing((x - 2).ToString() + (y - 1).ToString(), Color) == Color + "K";
            }

            if (x > 1 && y < 7) // Balra 2, fel 1
            {
                result = IsKing((x - 2).ToString() + (y + 1).ToString(), Color) == Color + "K";
            }

            if (x < 7 && y > 1 && !result) // Jobbra 2, fel 1
            {
                result = IsKing((x + 2).ToString() + (y + 1).ToString(), Color) == Color + "K";
            }

            if (x < 7 && y > 1 && !result) // Jobbra 2, le 1
            {
                result = IsKing((x + 2).ToString() + (y - 1).ToString(), Color) == Color + "K";
            }

            return result;
        }

        public static bool ChessBishop(int x, int y, string Color, Func<String, String, String> IsKing)
        {
            bool result = false;
            int i = x, j = y;

            for (i = x + 1; i < 8; i++) // Jobb fel
            {
                j += 1;

                if (IsKing(i.ToString() + j.ToString(), Color) != "null")
                {
                    result = IsKing(i.ToString() + j.ToString(), Color) == Color + "K";
                }
            }

            for (i = x + 1; i < 8; i++) // Jobb le
            {
                j -= 1;

                if (IsKing(i.ToString() + j.ToString(), Color) != "null")
                {
                    result = IsKing(i.ToString() + j.ToString(), Color) == Color + "K";
                }
            }

            for (i = x - 1; i >= 0; i--) // Balra fel
            {
                j += 1;

                if (IsKing(i.ToString() + j.ToString(), Color) != "null")
                {
                    result = IsKing(i.ToString() + j.ToString(), Color) == Color + "K";
                }
            }

            for (i = x - 1; i >= 0; i--) // Balra le
            {
                j -= 1;

                if (IsKing(i.ToString() + j.ToString(), Color) != "null")
                {
                    result = IsKing(i.ToString() + j.ToString(), Color) == Color + "K";
                }
            }

            return result;
        }

        public static bool ChessRook(int x, int y, string Color, Func<String, String, String> IsKing)
        {
            bool result = false;

            for (int i = x + 1; i < 8; i++) // Fel
            {
                if (IsKing(i.ToString() + y.ToString(), Color) != "null")
                {
                    result = IsKing(i.ToString() + y.ToString(), Color) == Color + "K";
                }
            }


            for (int i = x - 1; i >= 0; i--) // Le
            {
                if (IsKing(i.ToString() + y.ToString(), Color) != "null")
                {
                    result = IsKing(i.ToString() + y.ToString(), Color) == Color + "K";
                }
            }


            for (int i = y + 1; i < 8; i++) // Jobbra
            {
                if (IsKing(x.ToString() + i.ToString(), Color) != "null")
                {
                    result = IsKing(x.ToString() + i.ToString(), Color) == Color + "K";
                }
            }

            for (int i = y - 1; i >= 0; i--) //Balra
            {
                if (IsKing(x.ToString() + i.ToString(), Color) != "null")
                {
                    result = IsKing(x.ToString() + i.ToString(), Color) == Color + "K";
                }
            }

            return result;
        }
    }
}
