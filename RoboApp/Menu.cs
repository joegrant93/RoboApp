using static System.Console;

namespace RoboApp
{
    internal class Menu
    {
        private string prompt;
        private string[] options;
        private int selected = 0;
        private string prefix;

        public Menu(string prompt_, string[] options_)
        {
            prompt = prompt_;
            options = options_;
        }
        private void Display()
        {
            WriteLine(prompt);
            for (int i = 0; i < options.Count(); i++)
            {
                if (i == selected)
                {
                    prefix = "> ";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                    WriteLine($"{prefix}{i + 1}. {options[i]}");
                }
                else
                {
                    prefix = "  ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                    WriteLine($"{prefix}{i + 1}. {options[i]}");
                }
            }
            ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                Display();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                selected = (keyPressed == ConsoleKey.UpArrow) ? selected - 1 : (keyPressed == ConsoleKey.DownArrow) ? selected + 1 : selected;
                selected = (selected < 0) ? options.Count() - 1 : selected % options.Count();
            } while (keyPressed != ConsoleKey.Enter);

            return selected;
        }
    }
}
