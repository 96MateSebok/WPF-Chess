using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;


namespace ModernUI
{
    public partial class Field : Page
    {
        private bool firstPress = true;
        private bool isWhite = false;
        private bool isBlackNext = false;
        private string imageSource;
        private Image senderImage = new Image();
        private int startCoordinate, finishCoordinate;

        public Field()
        {
            InitializeComponent();
        }

        private void OnChessBoardClicked(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;

            foreach (var child in LogicalTreeHelper.GetChildren(senderButton))
            {
                if (child is Image myImage)
                {
                    if (firstPress && (imageSource = myImage.Source?.ToString()) != null)
                    {
                        startCoordinate = int.Parse(senderButton.Name.Remove(0, 6));
                        senderImage = myImage;

                        if (RemoveColorFromImage(imageSource) == "B" && !isWhite)
                        {
                            MessageBox.Show("The WHITE starts the game!");
                            break;
                        }

                        isWhite = true;

                        if (RemoveColorFromImage(imageSource) == "W" && !isBlackNext)
                        {
                            firstPress = false;
                        }
                        else if (RemoveColorFromImage(imageSource) == "B" && isBlackNext)
                        {
                            firstPress = false;
                        }
                        else
                        {
                            MessageBox.Show("It's not that color's turn!");
                        }
                    }
                    else if (imageSource != null)
                    {
                        finishCoordinate = int.Parse(senderButton.Name.Remove(0, 6));

                        if (WhichPiece(imageSource.Remove(0, 30), startCoordinate, finishCoordinate))
                        {
                            myImage.Source = new BitmapImage(new Uri(imageSource));
                            senderImage.Source = null;
                            isBlackNext = !isBlackNext;
                        }
                        firstPress = true;
                    }
                }
            }
        }

        public bool WhichPiece(String imageName, int start, int finish)
        {
            switch (imageName)
            {
                case "BB.png":
                case "WB.png":
                    return PiecesMoves.Bishop.CanBishopStep(imageName, start, finish, IsOccupied, IsEnemy);
                case "BH.png":
                case "WH.png":
                    return PiecesMoves.Horse.CanHorseStep(imageName, start, finish, IsOccupied, IsEnemy);
                case "BK.png":
                case "WK.png":
                    return PiecesMoves.King.CanKingStep(imageName, start, finish, IsEnemy);
                case "BP.png":
                case "WP.png":
                    return PiecesMoves.Pawn.CanPawnStep(imageName, start, finish, IsOccupied, IsEnemy);
                case "BQ.png":
                case "WQ.png":
                    return PiecesMoves.Rook.CanRookStep(imageName, start, finish, IsOccupied, IsEnemy) ||
                        PiecesMoves.Bishop.CanBishopStep(imageName, start, finish, IsOccupied, IsEnemy);
                case "BR.png":
                case "WR.png":
                    return PiecesMoves.Rook.CanRookStep(imageName, start, finish, IsOccupied, IsEnemy);
                default:
                    return false;
            }
        }

        public bool IsOccupied(String coordinate)
            /* Megnézi, hogy az adott mezőn van e ütközés.
             * Ha van, akkor TRUE a visszaküldött érték, 
             * ha nincs, akkor FALSE*/
        {
            if (int.Parse(coordinate) < 10)
            {
                coordinate = "0" + coordinate;
            }

            coordinate = "Button" + coordinate;
            Button isOccupiedButton = LogicalTreeHelper.FindLogicalNode(this, coordinate) as Button;

            foreach (var child in LogicalTreeHelper.GetChildren(isOccupiedButton))
            {
                if (child is Image isOccupiedImage)
                {
                    return isOccupiedImage.Source?.ToString() != null;
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

        public bool IsEnemy(string coordinate, string color)
            /* Megnézi, hogy a végponton ellenfél található e
             * ha igen, akkor TRUE a visszaküldött érték
             * ha nem, akkor FALSE */
        {
            if (int.Parse(coordinate) < 10)
            {
                coordinate = "0" + coordinate;
            }

            coordinate = "Button" + coordinate;
            Button IsEnemyButton = LogicalTreeHelper.FindLogicalNode(this, coordinate) as Button;

            foreach (var child in LogicalTreeHelper.GetChildren(IsEnemyButton))
            {
                return child is Image IsEnemyImage &&
                    RemoveColorFromImage(IsEnemyImage.Source?.ToString()) == color;
            }
            return false;
        }

        public bool IsChessPiece()
        {
            String coordinate = "Button",
                imageSourceRemove;
            Button isChessButton;
            List coordinateList = new List();

            for (int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    coordinate += i.ToString() + j.ToString();
                    isChessButton = LogicalTreeHelper.FindLogicalNode(this, coordinate) as Button;

                    foreach (var child in LogicalTreeHelper.GetChildren(isChessButton))
                    {
                        if (child is Image isChessImage)
                        {
                            imageSourceRemove = isChessImage.Source?.ToString().Remove(0, 30).Remove(2, 5);
                            String color = imageSourceRemove.Remove(1);

                            if (color == "B")
                            {
                                color = "W";
                            }

                            if (imageSourceRemove == "WP")
                            {
                                if (ChessAndCheckMate.IsChess.ChessWhitePawn(i, j, IsKing))
                                {

                                }
                            }
                            else if (imageSourceRemove == "BP")
                            {
                                if (ChessAndCheckMate.IsChess.ChessBlackPawn(i, j, IsKing))
                                {

                                }
                            }
                            else if (imageSourceRemove == "WB" || imageSourceRemove == "BB")
                            {
                                if (ChessAndCheckMate.IsChess.ChessBishop(i, j, color, IsKing))
                                {

                                }
                            }
                            else if (imageSourceRemove == "WH" || imageSourceRemove == "WH")
                            {
                                if (ChessAndCheckMate.IsChess.ChessHorse(i, j, color, IsKing))
                                {

                                }
                            }
                            else if (imageSourceRemove == "WR" || imageSourceRemove == "BR")
                            {
                                if (ChessAndCheckMate.IsChess.ChessRook(i, j, color, IsKing))
                                {

                                }
                            }
                            else if (imageSourceRemove == "WQ" || imageSourceRemove == "BQ")
                            {
                                if (ChessAndCheckMate.IsChess.ChessRook(i, j, color, IsKing) &&
                                    ChessAndCheckMate.IsChess.ChessBishop(i, j, color, IsKing))
                                {

                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public string IsKing(string coordinate, string color)
        {
            coordinate = "Button" + coordinate;
            color = "K" + color;
            Button isKingButton = LogicalTreeHelper.FindLogicalNode(this, coordinate) as Button;

            foreach (var child in LogicalTreeHelper.GetChildren(isKingButton))
            {
                if (child is Image IsChessImage)
                {
                    if (IsChessImage.Source?.ToString().Remove(0, 30).Remove(2, 5) == color)
                    {
                        return IsChessImage.Source?.ToString().Remove(0, 30).Remove(2, 5);
                    }
                }
            }

            return null;
        }
    }
}
