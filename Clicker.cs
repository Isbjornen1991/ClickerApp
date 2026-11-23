namespace ClickerApp
{
    public class Clicker
    {
        private int points;
        private int pointsPerClick = 1;

        public Clicker()
        {
            points = 0;
        }

        public void increasePoints()
        {
            points += pointsPerClick;
        }

        public void decreasePoints(int amount)
        {
            points -= amount;
        }

        public bool upgrade()
        {
            if (points >= 10)
            {
                decreasePoints(10);
                pointsPerClick++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void showPoints()
        {
            Console.WriteLine(points);
        }

        public int getPoints()
        {
            return points;
        }

        public int getPointsPerClick()
        {
            return pointsPerClick;
        }

    }

}
