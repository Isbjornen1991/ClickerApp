namespace ClickerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Clicker> clickers = new List<Clicker>();
            int? selectedIndex = null;
            string statusMessage = "";

            int clickerCount = 0;

            while (clickerCount <= 0)
            {
                Console.WriteLine("How many clickers do you want in play?");
                string? countInput = Console.ReadLine()?.Trim();

                if (!int.TryParse(countInput, out clickerCount) || clickerCount <= 0)
                {
                    Console.WriteLine("Please enter a whole number greater than 0.");
                    clickerCount = 0;
                }
            }

            for (int i = 0; i < clickerCount; i++)
            {
                clickers.Add(new Clicker());
            }

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                TopBar.RenderTopBar(clickers, selectedIndex);

                if (!string.IsNullOrEmpty(statusMessage))
                {
                    Console.WriteLine(statusMessage);
                    Console.WriteLine();
                }

                if (selectedIndex == null)
                {
                    Console.WriteLine($"Select a clicker (1 - {clickers.Count}) or type 'exit':");
                    string? input = Console.ReadLine()?.Trim().ToLower();

                    if (input == "exit")
                    {
                        isRunning = false;
                    }
                    else if (int.TryParse(input, out int choice) && choice >= 1 && choice <= clickers.Count)
                    {
                        selectedIndex = choice - 1;
                        statusMessage = $"Selected clicker #{choice}.";
                    }
                    else
                    {
                        statusMessage = $"Please enter a number between 1 and {clickers.Count}, or 'exit'.";
                    }
                }
                else
                {
                    Clicker activeClicker = clickers[selectedIndex.Value];
                    int clickerNumber = selectedIndex.Value + 1;

                    Console.WriteLine($"Active: Clicker #{clickerNumber} (Power: +{activeClicker.getPointsPerClick()} / click)");
                    Console.WriteLine($"Type [I] to increase points, [U] to upgrade  for {activeClicker.getUpgradeCost()} pts, or [Q] to go back, then press Enter:");

                    string? actionInput = Console.ReadLine()?.Trim().ToLower();

                    if (actionInput == "i")
                    {
                        activeClicker.increasePoints();
                        statusMessage = $"Clicker #{clickerNumber} gained {activeClicker.getPointsPerClick()} point(s).";
                    }
                    else if (actionInput == "u")
                    {
                        bool upgraded = activeClicker.upgrade();
                        if (upgraded)
                        {
                            statusMessage = $"Clicker #{clickerNumber} upgraded! Now +{activeClicker.getPointsPerClick()} per click.";
                        }
                        else
                        {
                            statusMessage = $"Not enough points to upgrade Clicker #{clickerNumber}. It costs {activeClicker.getUpgradeCost()}. You only have {activeClicker.getPoints()}.";
                        }
                    }
                    else if (actionInput == "q")
                    {
                        selectedIndex = null;
                        statusMessage = "Returned to clicker selection.";
                    }
                    else
                    {
                        statusMessage = "Unknown command. Type [I], [U], or [Q] and press Enter.";
                    }
                }
            }
        }
    }
}