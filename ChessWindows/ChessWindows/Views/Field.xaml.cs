using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ModernUI
{
    public partial class Field : Page
    {
        private bool Press = true;
        private bool isWhite = false;
        private bool isBlackNext = false;
        private string ImageSource;
        private Button SenderButton1 = new Button();
        private Button SenderButton2 = new Button();
        private Image SenderImage = new Image();
        private int StartCoordinate, FinishCoordinate;

        public Field()
        {
            InitializeComponent();
        }

        private void Try1(object sender, RoutedEventArgs e)
        {
            Button SenderButton = sender as Button;

            foreach (var child in LogicalTreeHelper.GetChildren(SenderButton))
            {
                if (child is Image myImage)
                {
                    if (Press && (ImageSource = myImage.Source?.ToString()) != null)
                    {
                        SenderButton1 = SenderButton;
                        StartCoordinate = int.Parse(SenderButton1.Name.Remove(0, 6));
                        SenderImage = myImage;

                        if (ImageSource.Remove(0, 30).Remove(1, 5) == "B" && !isWhite)
                        {
                            MessageBox.Show("The WHITE start the game!");
                            break;
                        }

                        isWhite = true;

                        if (ImageSource.Remove(0, 30).Remove(1, 5) == "W" && !isBlackNext)
                        {
                            Press = false;
                        }
                        else if (ImageSource.Remove(0, 30).Remove(1, 5) == "B" && isBlackNext)
                        {
                            Press = false;
                        }
                        else
                        {
                            MessageBox.Show("Not that color turn");
                        }



                    }
                    else if (ImageSource != null)
                    {
                        SenderButton2 = SenderButton;
                        FinishCoordinate = int.Parse(SenderButton2.Name.Remove(0, 6));
                        if (WhichPiece(ImageSource.Remove(0, 30), StartCoordinate, FinishCoordinate))
                        {
                            myImage.Source = new BitmapImage(new Uri(ImageSource));
                            SenderImage.Source = null;
                            isBlackNext = !isBlackNext;
                        }
                        Press = true;
                    }
                }
            }
        }

        public bool WhichPiece(String ImageName, int Start, int Finish)
        {
            switch (ImageName)
            {
                case "BB.png":
                case "WB.png":
                    return PiecesMoves.Bishop.CanBishopStep(ImageName, Start, Finish, IsOccupied, IsEnemy);
                case "BH.png":
                case "WH.png":
                    return PiecesMoves.Horse.CanHorseStep(ImageName, Start, Finish, IsOccupied, IsEnemy);
                case "BK.png":
                case "WK.png":
                    return PiecesMoves.King.CanKingStep(ImageName, Start, Finish, IsEnemy);
                case "BP.png":
                case "WP.png":
                    return PiecesMoves.Pawn.CanPawStep(ImageName, Start, Finish, IsOccupied, IsEnemy);
                case "BQ.png":
                case "WQ.png":
                    return PiecesMoves.Rook.CanRookStep(ImageName, Start, Finish, IsOccupied, IsEnemy) ||
                        PiecesMoves.Bishop.CanBishopStep(ImageName, Start, Finish, IsOccupied, IsEnemy);
                case "BR.png":
                case "WR.png":
                    return PiecesMoves.Rook.CanRookStep(ImageName, Start, Finish, IsOccupied, IsEnemy);
                default:
                    return false;
            }
        }

        public bool IsOccupied(String Coordinate)
            /* Megnézi, hogy az adott mezőn van e ütközés.
             * Ha van, akkor TRUE a visszaküldött érték, 
             * ha nincs, akkor FALSE*/
        {
            if (int.Parse(Coordinate) < 10)
            {
                Coordinate = "0" + Coordinate;
            }

            Coordinate = "Button" + Coordinate;
            Button IsOccupiedButton = LogicalTreeHelper.FindLogicalNode(this, Coordinate) as Button;

            foreach (var child in LogicalTreeHelper.GetChildren(IsOccupiedButton))
            {
                if (child is Image IsOccupiedImage)
                {
                    return IsOccupiedImage.Source?.ToString() != null;
                }
                else
                {
                    MessageBox.Show("IsOccupied Error 1");
                    return false;
                }
            }
            MessageBox.Show("IsOccupied Error 2");
            return false;
        }

        public bool IsEnemy(String Coordinate, String Color)
            /* Megnézi, hogy a végponton ellenfél található e
             * ha igen, akkor TRUE a visszaküldött érték
             * ha nem, akkor FALSE */
        {
            if (int.Parse(Coordinate) < 10)
            {
                Coordinate = "0" + Coordinate;
            }

            Coordinate = "Button" + Coordinate;
            Button IsEnemyButton = LogicalTreeHelper.FindLogicalNode(this, Coordinate) as Button;

            foreach (var child in LogicalTreeHelper.GetChildren(IsEnemyButton))
            {
                return child is Image IsEnemyImage &&
                    IsEnemyImage.Source?.ToString().Remove(0, 30).Remove(1, 5) == Color;
            }
            return false;
        }

        public bool IsChessPiece()
        {
            String Coordinate = "Button",
                ImageSourceRemove;
            Button isChessButton;
            List CoordinateList = new List();

            for (int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Coordinate += i.ToString() + j.ToString();
                    isChessButton = LogicalTreeHelper.FindLogicalNode(this, Coordinate) as Button;

                    foreach (var child in LogicalTreeHelper.GetChildren(isChessButton))
                    {
                        if (child is Image IsChessImage)
                        {
                            ImageSourceRemove = IsChessImage.Source?.ToString().Remove(0, 30).Remove(2, 5);

                            if (ImageSourceRemove == "WP")
                            {
                                if (ChessAndCheckMate.IsChess.ChessWhitePawn(i, j, IsKing))
                                {

                                }
                            }
                            else if (ImageSourceRemove == "BP")
                            {

                            }
                            else if (ImageSourceRemove == "WB")
                            {

                            }
                            else if (ImageSourceRemove == "BB")
                            {

                            }
                            else if (ImageSourceRemove == "WH")
                            {

                            }
                            else if (ImageSourceRemove == "BH")
                            {

                            }
                            else if (ImageSourceRemove == "WR")
                            {

                            }
                            else if (ImageSourceRemove == "BR")
                            {

                            }
                            else if (ImageSourceRemove == "WQ")
                            {

                            }
                            else if (ImageSourceRemove == "BQ")
                            {

                            }

                        }
                    }
                }
            }
            return false;
        }

        public bool IsKing(String Coordinate, String Color)
        {
            return false;
        }

    }
}
