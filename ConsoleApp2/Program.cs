using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static string[] pos = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // Array that contains board positions, 0 isnt used --------------------------------

        static void DrawBoard() // Draw board method ==========================================
        {
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[1], pos[2], pos[3]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[4], pos[5], pos[6]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}   ", pos[7], pos[8], pos[9]);
        }

        static void Main(string[] args) // Main ==============================================
        {
            string player1 = "", player2 = "";
            int choice = 0, turn = 1, score1 = 0, score2 = 0;
            bool winFlag = false, playing = true, correctInput = false;

            Console.WriteLine("What is the name of player 1?");
            player1 = Console.ReadLine();
            Console.WriteLine("Very good. What is the name of player 2?");
            player2 = Console.ReadLine();
            Console.WriteLine("Okay good. {0} is O and {1} is X.", player1, player2);
            Console.WriteLine("{0} goes first.", player1);
            Console.ReadLine();
            Console.Clear();

            while (playing == true)
            {
                while (winFlag == false) // Game loop ------------------------------------------------------
                {
                    DrawBoard();
                    Console.WriteLine("");

                    Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                    if (turn == 1)
                    {
                        Console.WriteLine("{0}'s (O) turn", player1);
                    }
                    if (turn == 2)
                    {
                        Console.WriteLine("{0}'s (X) turn", player2);
                    }

                    while (correctInput == false)
                    {
                        Console.WriteLine("Which position would you like to take?");
                        choice = int.Parse(Console.ReadLine());
                        if (choice > 0 && choice < 10)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    correctInput = false; // Reset -------

                    if (turn == 1)
                    {
                        if (pos[choice] == "X") // Checks to see if spot is taken already --------------------
                        {
                            Console.WriteLine("You can't steal positions asshole! ");
                            Console.Write("Try again.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            pos[choice] = "O";
                        }
                    }
                    if (turn == 2)
                    {
                        if (pos[choice] == "O") // Checks to see if spot is taken already -------------------
                        {
                            Console.WriteLine("You can't steal positions asshole! ");
                            Console.Write("Try again.");
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            pos[choice] = "X";
                        }
                    }

                    winFlag = CheckWin();

                    if (winFlag == false)
                    {
                        if (turn == 1)
                        {
                            turn = 2;
                        }
                        else if (turn == 2)
                        {
                            turn = 1;
                        }
                        Console.Clear();
                    }
                }

                Console.Clear();

                DrawBoard();

                for (int i = 1; i < 10; i++) // Resets board ------------------------
                {
                    pos[i] = i.ToString();
                }

                if (winFlag == false) // No one won ---------------------------
                {
                    Console.WriteLine("It's a draw!");
                    Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                    Console.WriteLine("");
                    Console.WriteLine("What would you like to do now?");
                    Console.WriteLine("1. Play again");
                    Console.WriteLine("2. Leave");
                    Console.WriteLine("");

                    while (correctInput == false)
                    {
                        Console.WriteLine("Enter your option: ");
                        choice = int.Parse(Console.ReadLine());

                        if (choice > 0 && choice < 3)
                        {
                            correctInput = true;
                        }
                    }

                    correctInput = false; // Reset -------------

                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                            playing = false;
                            break;
                    }
                }

                if (winFlag == true) // Someone won -----------------------------
                {
                    if (turn == 1)
                    {
                        score1++;
                        Console.WriteLine("{0} wins!", player1);
                        Console.WriteLine("What would you like to do now?");
                        Console.WriteLine("1. Play again");
                        Console.WriteLine("2. Leave");

                        while (correctInput == false)
                        {
                            Console.WriteLine("Enter your option: ");
                            choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 3)
                            {
                                correctInput = true;
                            }
                        }

                        correctInput = false; // Reset --------------

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Thanks for playing!");
                                Console.ReadLine();
                                playing = false;
                                break;
                        }
                    }

                    if (turn == 2)
                    {
                        score2++;
                        Console.WriteLine("{0} wins!", player2);
                        Console.WriteLine("What would you like to do now?");
                        Console.WriteLine("1. Play again");
                        Console.WriteLine("2. Leave");

                        while (correctInput == false)
                        {
                            Console.WriteLine("Enter your option: ");
                            choice = int.Parse(Console.ReadLine());

                            if (choice > 0 && choice < 3)
                            {
                                correctInput = true;
                            }
                        }

                        correctInput = false; // Reset -----------------

                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                winFlag = false;
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Thanks for playing!");
                                Console.ReadLine();
                                playing = false;
                                break;
                        }
                    }
                }
            }
        }

        static bool CheckWin() // Win checker method ================================================
        {
            if (pos[1] == "O" && pos[2] == "O" && pos[3] == "O") // Horizontal ----------------------------------------
            {
                return true;
            }
            else if (pos[4] == "O" && pos[5] == "O" && pos[6] == "O")
            {
                return true;
            }
            else if (pos[7] == "O" && pos[8] == "O" && pos[9] == "O")
            {
                return true;
            }

            else if (pos[1] == "O" && pos[5] == "O" && pos[9] == "O") // Diagonal -----------------------------------------
            {
                return true;
            }
            else if (pos[7] == "O" && pos[5] == "O" && pos[3] == "O")
            {
                return true;
            }

            else if (pos[1] == "O" && pos[4] == "O" && pos[7] == "O")// Coloumns ------------------------------------------
            {
                return true;
            }
            else if (pos[2] == "O" && pos[5] == "O" && pos[8] == "O")
            {
                return true;
            }
            else if (pos[3] == "O" && pos[6] == "O" && pos[9] == "O")
            {
                return true;
            }

            if (pos[1] == "X" && pos[2] == "X" && pos[3] == "X") // Horizontal ----------------------------------------
            {
                return true;
            }
            else if (pos[4] == "X" && pos[5] == "X" && pos[6] == "X")
            {
                return true;
            }
            else if (pos[7] == "X" && pos[8] == "X" && pos[9] == "X")
            {
                return true;
            }

            else if (pos[1] == "X" && pos[5] == "X" && pos[9] == "X") // Diagonal -----------------------------------------
            {
                return true;
            }
            else if (pos[7] == "X" && pos[5] == "X" && pos[3] == "X")
            {
                return true;
            }

            else if (pos[1] == "X" && pos[4] == "X" && pos[7] == "X") // Coloumns ------------------------------------------
            {
                return true;
            }
            else if (pos[2] == "X" && pos[5] == "X" && pos[8] == "X")
            {
                return true;
            }
            else if (pos[3] == "X" && pos[6] == "X" && pos[9] == "X")
            {
                return true;
            }
            else // No winner ----------------------------------------------
            {
                return false;
            }
        }
    }
}
