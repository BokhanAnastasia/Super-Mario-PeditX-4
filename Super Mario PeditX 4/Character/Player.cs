using Super_Mario_PeditX_4.Items;
using Super_Mario_PeditX_4.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.Character
{
    public class Player : Character, Fighting
    {
        private int HP;
        private int strength;
        private int agility;
        public int money;

        public Armor? armor = null;
        public Weapon? weapon = null;
        private readonly ItemsProvider inventory;


        private static readonly int LEVEL_PROGRESSION = 5;
        private static readonly int BASE_HP = 5;
        private static readonly int BASE_MONEY = 0;
        private static readonly int BASE_AGILITY = 10;
        private static readonly int BASE_STRENGTH = 10;

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

        public void punch()
        {
            throw new NotImplementedException();
        }

        public void hardPunch()
        {
            throw new NotImplementedException();
        }

        public void dash()
        {
            throw new NotImplementedException();
        }

        public void wait()
        {
            throw new NotImplementedException();
        }

        public void chooseMethod(FightMethod method)
        {
            if (method == FightMethod.PUNCH)        { punch(); }
            if (method == FightMethod.HARD_PUNCH)   { hardPunch(); }
            if (method == FightMethod.DASH)         { dash(); }
            if (method == FightMethod.WAIT)         { wait(); }
        }

        public bool compareAgility(int agility)
        {
            if (agility >= this.agility) return false;
            else return true;
        }

        public void startFight()
        {
            throw new NotImplementedException();
        }

        public void stopFight()
        {
            getResult();
        }

        public FightState getResult()
        {
            if (HP <= 0) return FightState.LOOSE;
            else return FightState.WIN;
        }

        public void getDamage(int damage)
        {
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
    }
}
