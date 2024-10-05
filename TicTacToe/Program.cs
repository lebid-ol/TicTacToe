namespace TicTacToe
{
    class Program
    {
        // The board is represented by a char array
        // Доска представлена массивом символов
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static int position;

        // The current player is represented by a char
        // Текущий игрок представлен символом
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            // The game ends when the game is won
            // Игра заканчивается, когда игра выиграна
            bool gameWon = false;

            // Loop until the game is won
            // Цикл до выигрыша игры
            while (!gameWon && !CheckDraw())
            {
                // Draw the board, get a position, and make a move 
                // Нарисовать доску, получить позицию и сделать ход
                DrawBoard();
                position = GetPosition();

                if (IsValidMove())
                {
                    MakeMove();

                    // Check if the game is won and switch the player
                    // Проверить, выиграл ли игрок и переключить игрока
                    gameWon = CheckWin();
                    if (!gameWon)
                    {
                        SwitchPlayer();
                    }
                }
                else
                {
                    // The move was invalid, so ask again
                    // Ход был недействителен, поэтому спросите еще раз
                    Console.WriteLine("This move is not possible, select an empty cell for the move");
                    // Ждем 5 секунд (5000 миллисекунд)
                    Thread.Sleep(5000);
                }
            }

            if (CheckDraw() == true)
            {
                DrawBoard();
                Console.WriteLine("Draw");
            }
            else
            {

                // Draw the board one last time and print the winner
                // Нарисуйте доску еще раз и напечатайте победителя
                DrawBoard();

                // Print the winner
                // Напечатать победителя
                Console.WriteLine("Winner " + currentPlayer);
            }
        }

        static void DrawBoard()
        {
            // Clear the console and draw the board
            // Очистить консоль и нарисовать доску
            Console.Clear();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }


        static int GetPosition()
        {
            // Ask the current player for a position
            // Спросить текущего игрока о позиции
            Console.WriteLine($"Player {currentPlayer}, choose a position (1-9): ");

            bool choose_position = int.TryParse(Console.ReadLine(), out int number_field);

            while (!choose_position || number_field < 1 || number_field > 9)
            {
                Console.WriteLine("The position was entered incorrectly. Enter a number from 1 to 9");
                choose_position = int.TryParse(Console.ReadLine(), out number_field);
            }
            return number_field;
        }


        static bool IsValidMove()
        {
            // Check if the position is valid
            // Проверить, действительна ли позиция
            if (board[position - 1] != 'X' && board[position-1] != 'O')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void MakeMove()
        {
            // Make the move
            // Сделать ход
            board[position - 1] = currentPlayer;
        }

        static bool CheckWin()
        {
            // Check if the current player has won
            // Проверить, выиграл ли текущий игрок по горизонтале
            if (board[0] == board[1] && board[1] == board[2])
            {
                return true;
            }
            else if (board[3] == board[4] && board[4] == board[5])
            {
                return true;
            }
            else if (board[6] == board[7] && board[7] == board[8])
            {
                return true;
            }

            // Проверить, выиграл ли текущий игрок по вертикале
            else if (board[0] == board[3] && board[3] == board[6])
            {
                return true;
            }
            else if (board[1] == board[4] && board[4] == board[7])
            {
                return true;
            }
            else if (board[2] == board[5] && board[5] == board[8])
            {
                return true;
            }

            // Проверить, выиграл ли текущий игрок по диагонале
            else if (board[0] == board[4] && board[4] == board[8])
            {
                return true;
            }
            else if (board[2] == board[4] && board[4] == board[6])
            {
                return true;
            }

            else
            {       
                return false;
            }

        }


        static void SwitchPlayer()
        {
            // Switch the current player
            // Переключить текущего игрока
            if (currentPlayer == 'X')
            {
                currentPlayer = 'O';
            }
            else
            {
                currentPlayer = 'X';

            }
        }

        static bool CheckDraw()
        {
            for (int i = 0; i < board.Length; i++)
            {
                //перебирает, есть ли еще свободные клетки
                if (board[i] != 'X' && board[i] != 'O')
                {
                    return false;
                }
            }
         return true;
        }

     }

}

 

