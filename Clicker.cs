namespace ClickerApp
{
    public class Clicker
    {
        private int points;
        private int pointsPerClick = 1;

        private int upgradeCost = 10;

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
            if (points >= upgradeCost)
            {
                decreasePoints(upgradeCost);
                upgradeCost = upgradeCost + upgradeCost;
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

        public int getUpgradeCost()
        {
            return upgradeCost;
        }

    }

}
