using Super_Mario_PeditX_4.Items;
using Super_Mario_PeditX_4.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Character
{
    public enum WeekPoint
    {
        LEGS,
        HANDS,
        HEAD,
        CHEST
    }
    public class Enemy: Character
    {
        private int HP;
        private int strength;
        private int agility;
        WeekPoint weekPoint;

        public Enemy(int HP, int strength, int agility, WeekPoint weekPoint,
                      string name, CharacterLevel level): base(name, level)
        {
            this.HP = HP;
            this.strength = strength;
            this.agility = agility;
            this.weekPoint = weekPoint;
        }

        public override void ShowInfo()
        {
            Console.WriteLine(
                $"Player: {name}, " +
                $"Level: {level.GetLevel()}, " +
                $"HP: {HP}, " +
                $"Strength: {strength}, " +
                $"Week Point: {weekPoint}");
        }
    }
}
