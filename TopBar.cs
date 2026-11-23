namespace ClickerApp
{
    public class TopBar
    {
        public static void RenderTopBar(List<Clicker> clickers, int? selectedIndex)
        {
            for (int i = 0; i < clickers.Count; i++)
            {
                int clickerNumber = i + 1;
                long pts = clickers[i].getPoints();
                string marker = (selectedIndex == i) ? "*" : "";

                Console.Write($"[{marker}{clickerNumber}: {pts} pts]  ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }


    }
}
