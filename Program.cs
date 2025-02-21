/*
* This Project is to simulate a game of Tic Tac Toe between two players.
* The game board is represented by a 3x3 grid, and players take turns to place their markers (X or O) on the grid.
* The game ends when one player wins, or when the grid is full and there is no winner.
* To place your marker you enter a number between 1 and 9, corresponding to the position on the grid.
* You cannot place your marker in a position that is already occupied.
*
*  - Asvitha Vibeeshanan (Finished on : 1/30/25)
*/

using System.Numerics;
using System.Reflection.Metadata;

namespace Assignment2{

    /*
    - Program Class that creates the game and utilizes the other classes
    */
    class Program
    {
        static void Main(string[] args)
        {
            Game ticTacToe = new Game();
            Marker player1 = new Marker('X');
            Marker player2 = new Marker('X');
            Marker[,] board = new Marker[3, 3];


            //Fills the board with empty chars so they aren't null
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = new Marker(' '); // Initialize with a default value
                }
            }

            //Prints who won or if there was a draw
            int result = ticTacToe.playGame(board);
            if(result == 1){
                Console.WriteLine("Player 1 wins!");
            }else if(result == 2){
                Console.WriteLine("Player 2 wins!");
            }
            else{
                Console.WriteLine("It's a draw!");
            }
            
        }

    }
 
    /*
    - Game Class places markers, checks for wins, prints board, and simulates the game.
    */
    class Game{

        /*
        - Places an 'X' on the board at a desired location
        - @param board The board to place the 'X' on
        - @param position The location to place the 'X'
        - @param marker The marker to place
        - @return The updated board with the 'X' placed
        */
        public Marker[,] placeX(Marker[,] board, int position, Marker marker){
            return marker.placeMarker(board, position);
        }

        /*
        - Places an 'O' on the board at a desired location
        - @param board The board to place the 'O' on
        - @param position The location to place the 'O'
        - @param marker The marker to place
        - @return The updated board with the 'O' placed
        */
        public Marker[,] placeO(Marker[,] board, int position, Marker marker){
            return marker.placeMarker(board, position);
        }

        /*
        - Prints the board
        - @param board The board to print
        */
        public void printBoard(Marker[,] board){
            for(int i = 0; i < 3; i++){
                for(int j = 0; j < 3; j++){
                    if(j != 2){
                        Console.Write(board[i, j].getType().ToString() + " | ");
                    }else{
                        Console.WriteLine(board[i, j].getType().ToString());
                    }
                }
                if(i != 2){
                    Console.WriteLine("---------");
                }
            }
        }

        /*
        - Checks if Player 1 has won
        - @param board The board to check
        - @return True if Player 1 has won, false otherwise
        */
        public bool checkWinX(Marker[,] board) {
            for (int i = 0; i < 3; i++) {
                if (board[i, 0].getType() == 'X' && board[i, 1].getType() == 'X' && board[i, 2].getType() == 'X') {
                    return true;
                }
                if (board[0, i].getType() == 'X' && board[1, i].getType() == 'X' && board[2, i].getType() == 'X') {
                    return true;
                }
            }
            if (board[0, 0].getType() == 'X' && board[1, 1].getType() == 'X' && board[2, 2].getType() == 'X') {
                return true;
            }
            if (board[0, 2].getType() == 'X' && board[1, 1].getType() == 'X' && board[2, 0].getType() == 'X') {
                return true;
            }
            return false;
        }

        /*
        - Checks if Player 2 has won
        - @param board The board to check
        - @return True if Player 2 has won, false otherwise
        */
        public bool checkWinO(Marker[,] board) {
            for (int i = 0; i < 3; i++) {
                if (board[i, 0].getType() == 'O' && board[i, 1].getType() == 'O' && board[i, 2].getType() == 'O') {
                    return true;
                }
                if (board[0, i].getType() == 'O' && board[1, i].getType() == 'O' && board[2, i].getType() == 'O') {
                    return true;
                }
            }
            if (board[0, 0].getType() == 'O' && board[1, 1].getType() == 'O' && board[2, 2].getType() == 'O') {
                return true;
            }
            if (board[0, 2].getType() == 'O' && board[1, 1].getType() == 'O' && board[2, 0].getType() == 'O') {
                return true;
            }
            return false;
        }


        /*
        - Checks if the game is a draw
        - @param board The board to check
        - @return True if the game is a draw, false otherwise
        */
        public bool checkDraw(Marker[,] board){
            if(checkWinO(board) || checkWinX(board)){
                return false;
            }
            else{
                for(int i = 0; i < 3; i++){
                    for(int j = 0; j < 3; j++){
                        if(board[i, j].getType() == ' '){
                            return false;
                        }
                    }
                }
                return true;
            }
        }


        /*
        - Simulates playing a game of Tic Tac Toe between two players.
        - @param board The Game that is to be played
        - Players take turns entering a position to place their marker (X or O) on the board.
        - Checks for a win or draw after each move.
        - Prints the current state of the board after each move.
        - @return An integer indicating the result of the game: 1 for Player 1 win, 2 for Player 2 win, 3 for a draw.
        */
        public int playGame(Marker[,] board){
            
            //Variables
            bool win = false;
            bool p1 = false;
            bool p2 = false;
            int position = 1, turn = 0;

            //Rules of the game
            Console.WriteLine("Welcome to Tic Tac Toe!\nPlayer 1 will be X's and Player 2 will be O's.\nPlayer 1 will go first.");
            Console.WriteLine("To place your marker, enter a number between 1 and 9, corresponding to the position on the grid:\n");
            Console.WriteLine("1 | 2 | 3\n---------\n4 | 5 | 6\n---------\n7 | 8 | 9\n");
            Console.WriteLine("Player 1, enter your move (1-9): ");

            //Starts the game
            while (true) {
                if (turn % 2 == 0) { // Player 1 turn
                    Console.WriteLine("Player 1, enter your move (1-9): ");
                    //Checks if the input is valid
                    while (true) {
                        try {
                            position = Int32.Parse(Console.ReadLine());
                            if (position < 1 || position > 9) {
                                Console.WriteLine("Please enter a number between 1 and 9");
                            } else {
                                break;
                            }
                        } catch (Exception nI) {
                            Console.WriteLine("Please enter a number between 1 and 9");
                        }
                    }
                    board = placeX(board, position, new Marker('X'));
                    printBoard(board);
                    if (checkWinX(board)) {
                        Console.WriteLine("Player 1 wins!");
                        break;
                    } else if (checkDraw(board)) {
                        Console.WriteLine("It's a draw!");
                        break;
                    }
                } else { // Player 2 turn
                    Console.WriteLine("Player 2, enter your move (1-9): ");
                    //Checks if the input is valid
                    while (true) {
                        try {
                            position = Int32.Parse(Console.ReadLine());
                            if (position < 1 || position > 9) {
                                Console.WriteLine("Please enter a number between 1 and 9");
                            } else {
                                break;
                            }
                        } catch (Exception nI) {
                            Console.WriteLine("Please enter a number between 1 and 9");
                        }
                    }
                    board = placeO(board, position, new Marker('O'));
                    printBoard(board);
                    if (checkWinO(board)) {
                        Console.WriteLine("Player 2 wins!");
                        break;
                    } else if (checkDraw(board)) {
                        Console.WriteLine("It's a draw!");
                        break;
                    }
                }
                turn++;
            }

            if(p1 == true){
                return 1;
            }
            else if(p2 == true){
                return 2;
            }
            else{
                return 3;
            }
            
        }
    }

    /*
    - A class representing a marker on the board.
    - A marker can be either an 'X', an 'O', or an empty space (' ').
    - @param type The type of the marker ('X', 'O', or ' ').
    */
    public class Marker{

        char marker;

        /*
        - Constructor for the Marker class.
        - @param type The type of the marker ('X', 'O', or ' ').
        */
        public Marker(char type){
            marker = type;
        }

        /*
        - Returns the type of the marker ('X', 'O', or ' ').
        */
        public char getType(){
            if (marker == 'X' || marker == 'O'){
                return marker;
            }
            else{
                return ' ';
            }
        }
        
        
        /*
        - Places the marker on the board at the given position.
        - @param board The board to place the marker on.
        - @param position The position to place the marker at (1-9).
        - @return The updated board with the marker placed.
        */
        public Marker[,] placeMarker(Marker[,] board, int position)
        {
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;
            bool turnFinished = false;
            while(turnFinished == false){
                if(position < 1 || position > 9){
                    Console.WriteLine("Please enter a number between 1 and 9");
                } 
                else{
                    if (board[row, col].getType() == ' '){
                        board[row, col] = this;
                    }
                    turnFinished = true;
                }
            }

            return board;
        }
    }
}