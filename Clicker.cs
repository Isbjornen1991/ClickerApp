namespace ClickerApp
{
    public class Clicker
    {
        private long points;
        private long pointsPerClick = 1;

        private long upgradeCost = 10;

        public Clicker()
        {
            points = 0;
        }

        public void increasePoints()
        {
            points += pointsPerClick;
        }

        private void decreasePoints(long amount)
        {
            if (amount < 0)
            {
                return;
            }
            if (points - amount >= 0)
            {
                points -= amount;
            }
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

        public long getPoints()
        {
            return points;
        }

        public long getPointsPerClick()
        {
            return pointsPerClick;
        }

        public long getUpgradeCost()
        {
            return upgradeCost;
        }

    }

}
