using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LifeController
    {
        public delegate void GetDamageDelegate();
       // public GetDamageDelegate getDamage;

        public event GetDamageDelegate onGetDamage;

        //public event Action OnGetDamage;

        private int _maxHealth;
        private int currentLife;

        public bool IsAlive => currentLife > 0;

        public int CurrentLife
        {
            get => currentLife;

            set
            {
                currentLife = value;

                if (!IsAlive)
                {
                    GameManager.Instance.ChangeGameState(GameState.GameOverScreen);
                    //OnDead?.Invoke();
                }
            }
        }

        public LifeController(int maxHealth)
        {
            _maxHealth = maxHealth;
            
        //    getDamage += GetDamage;
        //    getDamage += GetDamage2;
        //    getDamage += GetDamage3;
        }

        public void GetDamage(int damage)
        {
            CurrentLife = currentLife - damage;
            onGetDamage.Invoke();
            //Engine.Debug("me ejecute 1");
        }
        public void GetDamage2(int damage)
        {
            CurrentLife = currentLife - damage;
            Engine.Debug("me ejecute 2");
        }
        public void GetDamage3(int damage)
        {
            CurrentLife = currentLife - damage;
            Engine.Debug("me ejecute 3");
        }
    }
}
