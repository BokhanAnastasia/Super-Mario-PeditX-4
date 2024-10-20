﻿using Super_Mario_PeditX_4.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Mario_PeditX_4.UI
{
    public class FightScreen
    {
        private Player player;
        private Enemy enemy;
        public FightScreen(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        // получение дамага от игрока злодею
        private int getDamageFromPlayer(FightMethod method)
        {
            if      (method == FightMethod.PUNCH && !player.hardPunchState)  { return player.punchDamage();     }
            else if (method == FightMethod.PUNCH &&  player.hardPunchState)  { return player.hardPunchDamage(); }
            else if (method == FightMethod.WAIT  && !player.hardPunchState)  { return player.waitDamage();      }
            else if (method == FightMethod.DASH  && !player.hardPunchState)  { return player.dashDamage();      }
            else if (method == FightMethod.MOVE  && !player.hardPunchState)  { return player.moveDamage();      }
            
            else return 0;

        }
        // получение дамага от злодея плееру
        private int getDamageFromEnemy()
        {   
            Random random = new Random();
            int method = random.Next(0, 4);
            if      (method == 0 && !enemy.hardPunchState) { return enemy.punchDamage();    }
            else if (method == 0 &&  enemy.hardPunchState) { return enemy.hardPunchDamage();}
            else if (method == 1 && !enemy.hardPunchState) { return enemy.waitDamage();     }
            else if (method == 2 && !enemy.hardPunchState) { return enemy.dashDamage();     }
            else if (method == 3 && !enemy.hardPunchState) { return enemy.moveDamage();     }
            
            else return 0;

        }

        // ударяем игрока
        private void setDamageToPlayer()
        {
            player.setDamage(getDamageFromEnemy());
        }
        // ударяем злодея
        private void setDamageToEnemy(FightMethod method)
        {
            enemy.setDamage(getDamageFromPlayer(method));
        }

        public void Fight()
        {
            FightState state = FightState.IN_PROGRESS;
            while(state == FightState.IN_PROGRESS)
            {
                // запускаем экран СРАЖЕНИЯ
                // ждем, пока пользователь выберет МЕТОД
                
                FightMethod method = 0; // п р и м е р
                // бьем врага
                setDamageToEnemy(method);
                // бьем игрока
                setDamageToPlayer();
                // проверяем стейт игры
                // если приходит отличное от FightState.IN_PROGRESS значение
                // цикл останавливется
                state = player.getState(enemy.getHP()); 
                
            }
            
        }


    }
}
