using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;


namespace ModernUI
{
    public partial class Field : Page
    {
        private bool FirstPress = true;
        private bool isWhite = false;
        private bool isBlackNext = false;
        private string ImageSource;
        private Image SenderImage = new Image();
        private int StartCoordinate, FinishCoordinate;

        public Field()
        {
            InitializeComponent();
        }

        private void OnChessBoardClicked(object sender, RoutedEventArgs e)
        {
            Button SenderButton = sender as Button;

            foreach (var child in LogicalTreeHelper.GetChildren(SenderButton))
            {
                if (child is Image myImage)
                {
                    if (FirstPress && (ImageSource = myImage.Source?.ToString()) != null)
                    {
                        StartCoordinate = int.Parse(SenderButton.Name.Remove(0, 6));
                        SenderImage = myImage;

                        if (RemoveColorFromImage(ImageSource) == "B" && !isWhite)
                        {
                            MessageBox.Show("The WHITE starts the game!");
                            break;
                        }

                        isWhite = true;

                        if (RemoveColorFromImage(ImageSource) == "W" && !isBlackNext)
                        {
                            FirstPress = false;
                        }
                        else if (RemoveColorFromImage(ImageSource) == "B" && isBlackNext)
                        {
                            FirstPress = false;
                        }
                        else
                        {
                            MessageBox.Show("It's not that color's turn!");
                        }
                    }
                    else if (ImageSource != null)
                    {
                        FinishCoordinate = int.Parse(SenderButton.Name.Remove(0, 6));

                        if (WhichPiece(ImageSource.Remove(0, 30), StartCoordinate, FinishCoordinate))
                        {
                            myImage.Source = new BitmapImage(new Uri(ImageSource));
                            SenderImage.Source = null;
                            isBlackNext = !isBlackNext;
                        }
                        FirstPress = true;
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
                    return PiecesMoves.Pawn.CanPawnStep(ImageName, Start, Finish, IsOccupied, IsEnemy);
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

        private string RemoveColorFromImage(string chessPiecesImage)
        {
            return chessPiecesImage.Remove(0, 30).Remove(1, 5);
        }

        public bool IsEnemy(string Coordinate, string Color)
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
                    RemoveColorFromImage(IsEnemyImage.Source?.ToString()) == Color;
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
                            String Color = ImageSourceRemove.Remove(1);

                            if (Color == "B")
                            {
                                Color = "W";
                            }

                            if (ImageSourceRemove == "WP")
                            {
                                if (ChessAndCheckMate.IsChess.ChessWhitePawn(i, j, IsKing))
                                {

                                }
                            }
                            else if (ImageSourceRemove == "BP")
                            {
                                if (ChessAndCheckMate.IsChess.ChessBlackPawn(i, j, IsKing))
                                {

                                }
                            }
                            else if (ImageSourceRemove == "WB" || ImageSourceRemove == "BB")
                            {
                                if (ChessAndCheckMate.IsChess.ChessBishop(i, j, Color, IsKing))
                                {

                                }
                            }
                            else if (ImageSourceRemove == "WH" || ImageSourceRemove == "WH")
                            {
                                if (ChessAndCheckMate.IsChess.ChessHorse(i, j, Color, IsKing))
                                {

                                }
                            }
                            else if (ImageSourceRemove == "WR" || ImageSourceRemove == "BR")
                            {
                                if (ChessAndCheckMate.IsChess.ChessRook(i, j, Color, IsKing))
                                {

                                }
                            }
                            else if (ImageSourceRemove == "WQ" || ImageSourceRemove == "BQ")
                            {
                                if (ChessAndCheckMate.IsChess.ChessRook(i, j, Color, IsKing) &&
                                    ChessAndCheckMate.IsChess.ChessBishop(i, j, Color, IsKing))
                                {

                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public string IsKing(string Coordinate, string Color)
        {
            Coordinate = "Button" + Coordinate;
            Color = "K" + Color;
            Button isKingButton = LogicalTreeHelper.FindLogicalNode(this, Coordinate) as Button;

            foreach (var child in LogicalTreeHelper.GetChildren(isKingButton))
            {
                if (child is Image IsChessImage)
                {
                    if (IsChessImage.Source?.ToString().Remove(0, 30).Remove(2, 5) == Color)
                    {
                        return IsChessImage.Source?.ToString().Remove(0, 30).Remove(2, 5);
                    }
                }
            }

            return null;
        }
    }
}
