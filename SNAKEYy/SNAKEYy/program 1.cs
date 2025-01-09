using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using SNAKEYy;

class Program
{
    static void Main(string[] args)
    {
        Coordinate gridDimensions = new Coordinate(50, 20);
            
        Coordinate snakeStart = new Coordinate(10, 05);
        Random random = new Random();
        Coordinate food = new Coordinate(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
        int delay = 100;
        Direction Mdirection = Direction.Down;

        List<Coordinate> snakePosition = new List<Coordinate>();
        int tail = 1;
        int score = 0;




        while (true)
        {
            Console.Clear();

            Console.WriteLine("Score: " + score);
            snakeStart.ApplyMovementDirection(Mdirection);


            for (int y = 0; y < gridDimensions.Y; y++)
            {
                for (int x = 0; x < gridDimensions.X; x++)
                {
                    Coordinate currentCoordinate = new Coordinate(x, y);


                    if (snakeStart.Equals(currentCoordinate) || snakePosition.Contains(currentCoordinate))



                        Console.Write("■");

                    else if (food.Equals(currentCoordinate))
                        Console.Write("☻");




                    else if (x == 0 || x == gridDimensions.X - 1 || y == 0 || y == gridDimensions.Y - 1)



                        Console.Write("■");


                    else Console.Write(" ");
                }
                Console.WriteLine();
            }

            if (snakeStart.Equals(food))
            {
                tail++;
                score++;
                food = new Coordinate(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
            }
            else if (snakeStart.X == 0 || snakeStart.X == gridDimensions.X - 1 || snakeStart.Y == 0 || snakeStart.Y == gridDimensions.Y - 1 || snakePosition.Contains(snakeStart))
            {
                score = 0;
                tail = 1;
                snakeStart = new Coordinate(10, 05);
                snakePosition.Clear();
                Mdirection = Direction.Down;
                continue;
            }



            snakePosition.Add(new Coordinate(snakeStart.X, snakeStart.Y));
             if (snakePosition.Count > tail)
                snakePosition.RemoveAt(0);


            DateTime dateTime = DateTime.Now;

            while((DateTime.Now - dateTime).TotalMilliseconds < delay)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Mdirection = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            Mdirection = Direction.Down;
                            break;
                        case ConsoleKey.LeftArrow:
                            Mdirection = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            Mdirection = Direction.Right;
                            break;
                    }
                }
            }





        }



       











    }








}





