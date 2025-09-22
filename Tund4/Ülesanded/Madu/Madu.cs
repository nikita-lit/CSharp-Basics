namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    internal class Madu
    {
        public const int MAP_WIDTH = 85;
        public const int MAP_HEIGHT = 25;

        public static void Start()
        {
            Walls walls = new Walls(MAP_WIDTH, MAP_HEIGHT);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);

            FoodCreator foodCreator = new FoodCreator(MAP_WIDTH, MAP_HEIGHT, '$');
            Point food = foodCreator.CreateFood();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                    break;

                if (snake.Eat(food))
                    food = foodCreator.CreateFood();
                else
                    snake.Move();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

                Thread.Sleep(100);
            }

            string gameOver = "GAME OVER";
            Console.SetCursorPosition((MAP_WIDTH/2) - gameOver.Length, MAP_HEIGHT/2);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(gameOver);
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }
    }
}
