using Super_Mario_PeditX_4.Items;
using Super_Mario_PeditX_4.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Character
{
    public class Player : Character, Fighting, Actions
    {
        private int HP;
        private int strength;
        private int agility;
        public int money;

        private float points = 0f;

        public Armor? armor = null;
        public Weapon? weapon = null;
        private readonly ItemsProvider inventory;




        private static readonly int LEVEL_PROGRESSION = 5;
        private static readonly int BASE_HP = 5;
        private static readonly int BASE_MONEY = 0;
        private static readonly int BASE_AGILITY = 10;
        private static readonly int BASE_STRENGTH = 10;

        private static readonly int ZERO_DAMAGE = 0;
        private static readonly int BASE_DAMAGE = 5;

        private static readonly int MAX_PUNCH_RANDOM_VALUE = 10;
        private static readonly int MAX_HARD_PUNCH_RANDOM_VALUE = 20;
        private static readonly int MIN_PUNCH_RANDOM_VALUE = 0;
        private static readonly int MIN_HARD_PUNCH_RANDOM_VALUE = 1;
        private static readonly int MAX_DASH_LOWING_PARAMETR = 5;
        private static readonly int MIN_DASH_LOWING_PARAMETR = 1;

        public bool hardPunchState = false;
        private int dashLowingParam = 0;
        Random random = new Random();

        public Player( string name, CharacterLevel level)
            : base(name, level)
        {

            // инициализация базовых статов
            baseInit();
            SetHPByLevel(level); // Устанавливаем HP в зависимости от уровня при создании конструктора
            this.inventory = new ItemsProvider();
            
        }

        private void baseInit()
        {
            strength = BASE_STRENGTH;
            agility = BASE_AGILITY;
            money = BASE_MONEY;
        }

        // Установка HP в зависимости от уровня
        public void SetHPByLevel(CharacterLevel level) { HP = level.currentLevel * LEVEL_PROGRESSION + BASE_HP;}

        // Методы для снятия и надевания брони оружия
        public void setArmor(Armor armor) { this.armor = armor; }
        public void takeOffArmor() { armor = null; }
        public void setWeapon(Weapon weapon) { this.weapon = weapon; }
        public void takeOffWeapon() { weapon = null; }


        // Метод для сбора предметов
        public void CollectItem(Item item)
        {
            inventory.AddItem(item);
        }


        public override void ShowInfo()
        {
            Console.WriteLine(
                $"Player: {name}, " +
                $"Level: {level.GetLevel()}, " +
                $"HP: {HP}, " +
                $"Strength: {strength}, " +
                $"Armor: {armor?.ToString()}, " +
                $"Weapon: {weapon?.ToString()}, " +
                $"Agility: {agility}, " +
                $"Money: {money}");
        }


        public bool compareAgility(int agility)
        {
            if (agility >= this.agility) return false;
            else return true;
        }

        private void addPoints()
        {
            points += 10;
            money += 10; // ПЕРЕДЕЛАТЬ
        }


        public FightState getState(int enemyHP)
        {
            if (HP <= 0)           { die();        return FightState.LOOSE; }
            else if (enemyHP <= 0) { addPoints();  return FightState.WIN;   }
            else                                   return FightState.IN_PROGRESS;
        }


        // __________________ БОЕВКА ____________________

        public int moveDamage()
        {
            throw new NotImplementedException();
        }
        public int punchDamage()
        {
            // урон = сила * рандом от 0 до 10 + уровень персонажа * рандом от 0 до 10
            return strength * random.Next(MIN_PUNCH_RANDOM_VALUE, MAX_PUNCH_RANDOM_VALUE) +
                   level.currentLevel * random.Next(MIN_PUNCH_RANDOM_VALUE, MAX_PUNCH_RANDOM_VALUE);
        }

        public int hardPunchDamage()
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

        public int dashDamage()
        {
            // зависит от ловкости персонажа и случайного значения
            dashLowingParam = agility * random.Next(MIN_DASH_LOWING_PARAMETR, MAX_DASH_LOWING_PARAMETR);
            return ZERO_DAMAGE;
        }

        public int waitDamage()
        {
            hardPunchState = true;
            return ZERO_DAMAGE;
        }

        public void setDamage(int damage)
        {
            // если значение уворота больше дамага, то приравниваем эти значения
            //                                      иначе будет прибавка к ХП
            if (dashLowingParam >= damage) { dashLowingParam = damage; }
            damage = damage - dashLowingParam;

            // если у игрока есть броня
            if (armor != null)
            {
                // если броня мощнее урона
                if (armor.HP >= damage) 
                { 
                    armor.HP -= damage;  // наносим урон броне
                }
                // если броня НЕ мощнее урона
                else
                {
                    damage = damage - armor.HP;
                    armor = null; // ломаем броню
                    HP -= damage; // остаток урона наносим игроку
                }
            }
            // если у игрока НЕТ брони
            else { HP -= damage; } // наносим игроку full damage
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
