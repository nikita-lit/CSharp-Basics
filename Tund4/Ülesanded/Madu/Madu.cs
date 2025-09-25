namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    internal class Madu
    {
        public static void Start()
        {
            Walls walls = new Walls(MAP_WIDTH, MAP_HEIGHT);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(MAP_WIDTH, MAP_HEIGHT, '$');
            Point food = foodCreator.CreateFood();

            int points = 0;
            DrawPoints(points);

            bool isPaused = false;

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                    break;

                if (!isPaused)
                {
                    if (snake.Eat(food))
                    {
                        food = foodCreator.CreateFood();
                        points++;
                        DrawPoints(points);
                    }
                    else
                        snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (!isPaused)
                        snake.HandleKey(key.Key);

                    if (key.Key == ConsoleKey.T)
                    {
                        isPaused = !isPaused;
                        string gamePaused = "GAME PAUSED";

                        if (isPaused)
                        {
                            Console.SetCursorPosition(MAP_WIDTH + 5, 1);
                            Console.WriteLine(gamePaused);
                        }
                        else
                        {
                            Console.SetCursorPosition(MAP_WIDTH + 5, 1);
                            Console.WriteLine(new string(' ', gamePaused.Length));
                        }
                    }
                }

                Thread.Sleep(100);
            }

            string gameOver = "<== GAME OVER ==>";
            Console.SetCursorPosition((MAP_WIDTH/2) - (gameOver.Length/2), MAP_HEIGHT/2);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(gameOver);
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }

        public static void DrawPoints(int points)
        {
            Console.SetCursorPosition(MAP_WIDTH + 5, 0);
            Console.WriteLine($"POINTS: {points}");
        }
    }
}
