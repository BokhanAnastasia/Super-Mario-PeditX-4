using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Level
{
    public class StageLevel : Level
    {
        private int countOfMobs { get; set; }

        public StageLevel(int minLevel, int maxLevel, int currentLevel, int countOfMobs)
            : base(minLevel, maxLevel, currentLevel)
        {
            this.countOfMobs = countOfMobs;
        }


        public bool IsAvailableForPlayer(CharacterLevel level)
        {
            int playerLevel = level.currentLevel;
            if (playerLevel > currentLevel) return false;
            else return true;
        }
        public void GenerateLevel()
        {

        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Stage Level: {currentLevel} (Min: {minLevel}, Max: {maxLevel}), Mobs: {countOfMobs}");
        }
    }
}
