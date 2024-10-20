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
    public class Enemy: Character, Fighting, Actions
    {
        private int HP;
        private int strength;
        private int agility;
        WeekPoint weekPoint;
        Random random = new Random();

        private bool hardPunchState = false;
        private int dashLowingParam = 0;

        private static readonly int ZERO_DAMAGE = 0;
        private static readonly int BASE_DAMAGE = 5;

        private static readonly int MAX_PUNCH_RANDOM_VALUE = 10;
        private static readonly int MAX_HARD_PUNCH_RANDOM_VALUE = 20;
        private static readonly int MIN_PUNCH_RANDOM_VALUE = 0;
        private static readonly int MIN_HARD_PUNCH_RANDOM_VALUE = 1;
        private static readonly int MAX_DASH_LOWING_PARAMETR = 5;
        private static readonly int MIN_DASH_LOWING_PARAMETR = 1;

        public Enemy(int HP, int strength, int agility, WeekPoint weekPoint,
                      string name, CharacterLevel level): base(name, level)
        {
            this.HP = HP;
            this.strength = strength;
            this.agility = agility;
            this.weekPoint = weekPoint;
        }

        public bool compareAgility(int agility)
        {
            if (agility >= this.agility) return false;
            else return true;
        }

        public int getHP() { return this.HP; }



        public override void ShowInfo()
        {
            Console.WriteLine(
                $"Player: {name}, " +
                $"Level: {level.GetLevel()}, " +
                $"HP: {HP}, " +
                $"Strength: {strength}, " +
                $"Week Point: {weekPoint}");
        }
        // __________________ БОЕВКА ____________________

        public int moveDamage()
        {
            throw new NotImplementedException();
        }
        public int dashDamage()
        {
            dashLowingParam = level.currentLevel * random.Next(MIN_DASH_LOWING_PARAMETR, MAX_DASH_LOWING_PARAMETR);
            return ZERO_DAMAGE;
        }
        public int waitDamage()
        {
            hardPunchState = true;
            return ZERO_DAMAGE;
        }
        private int hardPunchDamage()
        {
            if (hardPunchState)
            {
                hardPunchState = false;
                // если до этого нажимали "ПОДГОТОВКА", то 
                // урон = сила * рандом от 1 до 20 + уровень персонажа * рандом от 1 до 20
                return strength * random.Next(MIN_HARD_PUNCH_RANDOM_VALUE, MAX_HARD_PUNCH_RANDOM_VALUE) +
                       level.currentLevel * random.Next(MIN_HARD_PUNCH_RANDOM_VALUE, MAX_HARD_PUNCH_RANDOM_VALUE);
            }
            else return ZERO_DAMAGE;

        }
        public int punchDamage()
        {
            // урон = сила * рандом от 0 до 10 + уровень персонажа * рандом от 0 до 10
            return strength * random.Next(MIN_PUNCH_RANDOM_VALUE, MAX_PUNCH_RANDOM_VALUE) +
                   level.currentLevel * random.Next(MIN_PUNCH_RANDOM_VALUE, MAX_PUNCH_RANDOM_VALUE);
        }
        public void setDamage(int damage)
        {
            // если значение уворота больше дамага, то приравниваем эти значения
            //                                      иначе будет прибавка к ХП
            if (dashLowingParam >= damage) { dashLowingParam = damage; }
            //хп новое = старое хп - полученный дамаг от противника + значение при уклонении
            //(если мы до этого нажимали на кнопку "УВОРТ"), если нет, то этот параметр = 0
            HP = HP - damage + dashLowingParam;
            if (HP <= 0) { die(); }
            dashLowingParam = 0;
        }

        //__________________ ТУТ НАДО НАКОДИТЬ UI ___________________________

        public void move(int x, int y)
        {
            // вызов функции UI
            throw new NotImplementedException();
        }

        public void die()
        {
            // вызов функции UI
            throw new NotImplementedException();
        }

        public void appearOnTheScreen(int x, int y)
        {
            // вызов функции UI
            throw new NotImplementedException();
        }
    }
}
