using Spectre.Console;

namespace CSharpBasics.Tund4.Ülesanded.Madu
{
    public partial class Game
    {
        public static void ShowMenu()
        {
            var title = new FigletText("SNAKE GAME");
            title.LeftJustified();
            title.Color(Color.Green1);

            AnsiConsole.Write(title);

            var prompt = new SelectionPrompt<string>();
            prompt.PageSize(3);
            prompt.AddChoices(["Start Game", "Leaderboard", "Quit"]);

            var input = AnsiConsole.Prompt(prompt);
            switch (input)
            {
                case "Start Game": Start(); break;
                case "Leaderboard": break;
                case "Quit": Program.Stop(); break;
                default: Start(); break;
            }
        }
    }
}
