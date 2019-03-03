using System;

namespace battleship_dotnet
{
    class Program
    {
        static PlayerBoard board;
        static void Main(string[] args)
        {
            board = new PlayerBoard(10);
            Console.WriteLine("Create board of size {0}", board.Size);

            /* //Test ships
            Console.WriteLine(board.AddShipHorizontal(0, 0, 10));
            Console.WriteLine(board.AddShipHorizontal(0, 1, 10));
            Console.WriteLine(board.AddShipHorizontal(0, 2, 10));
            */
            Start();
        }

        //This
        private static void Start()
        {
            string input = "";
            bool exit = false;
            while (!exit)
            {
                input = Console.ReadLine();
                string[] cmds = input.Split(' ');
                switch (cmds[0])
                {
                    case "render-board":
                        Console.Write(board.Render());
                        break;
                    case "hello":
                        Console.WriteLine(" ...world");
                        break;
                    case "addship":     //Format: "addship right|down left top length" 
                        try
                        {
                            string dir = cmds[1];
                            int left = Int32.Parse(cmds[2]);
                            int top = Int32.Parse(cmds[3]);
                            int length = Int32.Parse(cmds[4]);

                            if (dir == "right")
                            {
                                if (board.AddShipHorizontal(left, top, length))
                                    Console.Write(board.Render());
                                else
                                    Console.Write("Can't add a ship there");
                            }
                            else if (dir == "down")
                            {
                                if (board.AddShipVertical(left, top, length))
                                    Console.Write(board.Render());
                                else
                                    Console.Write("Can't add a ship there");
                            }
                            else
                            {
                                Console.WriteLine("Command was poorly formatted. Try 'addship right|down left top length'");
                                break;
                            }

                        }
                        catch 
                        {
                            Console.WriteLine("Command was poorly formatted. Try 'addship right|down left top length'");
                        }
                        break;
                    case "attack":
                        try
                        {
                            int left = Int32.Parse(cmds[1]);
                            int top = Int32.Parse(cmds[2]);
                            if (board.Attack(left, top)) Console.WriteLine("hit");
                            else Console.WriteLine("miss");
                        }
                        catch
                        {
                            Console.WriteLine("Command was poorly formatted. Try 'attack left top'");
                        }
                        break;
                    case "winstate":
                        {
                            if (board.LoseState) Console.WriteLine("Game lost :(");
                            else Console.WriteLine("Still in the game!");
                        }
                        break;
                    case "quit":
                    case "goodbye":
                    case "exit":
                        Console.WriteLine("Bye :)");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Didn't understand '{0}'", input);
                        break;
                }

                Console.WriteLine();
            }
        }

    }
}
