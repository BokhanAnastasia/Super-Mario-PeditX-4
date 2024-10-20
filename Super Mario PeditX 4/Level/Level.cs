using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Level
{
    public abstract class Level
    {
        protected int maxLevel { get; set; }
        protected int minLevel { get; set; }
        public int currentLevel { get; set; }

        public Level(int minLevel, int maxLevel, int currentLevel)
        {
            this.minLevel = minLevel;
            this.maxLevel = maxLevel;
            SetLevel(currentLevel);
        }

        // Метод для установки уровня
        public void SetLevel(int level)
        {
            if (level >= minLevel && level <= maxLevel)
            {
                currentLevel = level;
            }
            else
            {
                throw new ArgumentException("Level is out of bounds.");
            }
        }

        // Абстрактный метод для отображения информации об уровне
        public abstract void ShowInfo();
    }
}
