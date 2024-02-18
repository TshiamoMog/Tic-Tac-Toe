using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        /// <summary>
        /// Holds the current results of cells in an active game
        /// </summary>
        /// <returns></returns>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is player one's turn (x)
        /// </summary>
        private bool mPlayerOneTurn;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion

        /// <summary>
        /// Starts a new game and set all values to their defaults
        /// </summary>
        private void NewGame()
        {
            // Create a new blank array of open cells
            mResults = new MarkType[9];

            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Open;
            }

            // Make player one start the game
            mPlayerOneTurn = true;

            // Iterate through every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                // Setting up the default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            // Setting the status of the game ending to false
            mGameEnded = false;
        }

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                // Start a new game on the first click after a game is over
                NewGame();
                return;
            }

            // Cast the sender to a button
            var button = (Button)sender;

            // Find the position of the buttons in the array
            var col = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var i = col + (row * 3);

            // Do nothing if the cell has a value
            if (mResults[i] != MarkType.Open)
            {
                return;
            }

            // Set unique cell values for each player's turn
            mResults[i] = mPlayerOneTurn ? MarkType.Exes : MarkType.Oes; // Tenary operator

            // Set the button text to the result
            button.Content = mPlayerOneTurn ? "x" : "o";

            // Change the oes to the colour Red
            if (!mPlayerOneTurn)
                button.Foreground = Brushes.Red;

            // Toggle players' turns
            mPlayerOneTurn ^= true; // Bitwise operator

            // Check for a winner
            CheckForWinner();

        }

        /// <summary>
        /// Checks if there's a winner of a straight line of three
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void CheckForWinner()
        {
            // 8 Possible ways to win

            #region Bitwises
            // Bitwise Operators for the horizontal checks
            var same1 = (mResults[0] & mResults[1] & mResults[2]) == mResults[0];
            var same2 = (mResults[3] & mResults[4] & mResults[5]) == mResults[3];
            var same3 = (mResults[6] & mResults[7] & mResults[8]) == mResults[6];

            // Bitwise Operators for the vertical checks
            var same4 = (mResults[0] & mResults[3] & mResults[6]) == mResults[0];
            var same5 = (mResults[1] & mResults[4] & mResults[7]) == mResults[1];
            var same6 = (mResults[2] & mResults[5] & mResults[8]) == mResults[2];

            // Bitwise Operators for the diagonal checks
            var same7 = (mResults[0] & mResults[4] & mResults[8]) == mResults[0];
            var same8 = (mResults[2] & mResults[4] & mResults[6]) == mResults[2];
            #endregion

            #region Horizontals
            // The 3 horizontal ways
            // Check row 0
            if (mResults[0] != MarkType.Open && same1)
            {
                // Identifing the winner visually
                button0_0.Background = button1_0.Background = button2_0.Background = Brushes.Green;

                // Ending the game
                mGameEnded = true;
            }
            // Check row 1
            else if (mResults[3] != MarkType.Open && same2)
            {
                // Identifing the winner visually
                button0_1.Background = button1_1.Background = button2_1.Background = Brushes.Green;

                // Ending the game
                mGameEnded = true;
            }
            // Check row 2
            else if (mResults[6] != MarkType.Open && same3)
            {
                // Identifing the winner visually
                button0_2.Background = button1_2.Background = button2_2.Background = Brushes.Green;

                // Ending the game
                mGameEnded = true;
            }
            #endregion

            #region Verticals
            // The 3 vertical wins
            // Check column 0
            else if (mResults[0] != MarkType.Open && same4)
            {
                // Identifing the winner visually
                button0_0.Background = button0_1.Background = button0_2.Background = Brushes.Green;

                // Ending the game
                mGameEnded = true;
            }
            // Check column 1
            else if (mResults[1] != MarkType.Open && same5)
            {
                // Identifing the winner visually
                button1_0.Background = button1_1.Background = button1_2.Background = Brushes.Green;

                // Ending the game
                mGameEnded = true;
            }
            // Check column 2
            else if (mResults[2] != MarkType.Open && same6)
            {
                // Identifing the winner visually
                button2_0.Background = button2_1.Background = button2_2.Background = Brushes.Green;

                // Ending the game
                mGameEnded = true;
            }
            #endregion

            #region Diagonals
            // The 2 diagonal ways
            // Top left bottom right
            else if (mResults[0] != MarkType.Open && same7)
            {
                // Identifing the winner visually
                button0_0.Background = button1_1.Background = button2_2.Background = Brushes.Green;

                // Ending the game
                mGameEnded = true;
            }
            // Top right bottom left
            else if (mResults[2] != MarkType.Open && same8)
            {
                // Identifing the winner visually
                button2_0.Background = button1_1.Background = button0_2.Background = Brushes.Green;

                // Ending the game
                mGameEnded = true;
            }
            #endregion

            #region No Winner
            // Check for no winner and a full board
            else if (!mResults.Any(result => result == MarkType.Open)) // Link expression
            {
                // Turn all cells to orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });

                // Ending the game
                mGameEnded = true;
            }
            #endregion
        }
    }
}
