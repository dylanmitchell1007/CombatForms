using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatForms
{
    class Ninja : IDamageable
    {
        public Ninja(int Health, int Attack, string name)
        {
            name = null;
            Health = 100;
            Attack = 15;
        }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }
       public class Attack : IDamage
        {
            public Attack(int cost, int amount)
            {
                this.Cost = cost;
                this.Amount = amount;
            }
            public int Amount { get; private set; }

            public int Cost { get; private set; }

            public void GiveDamage()
            {
                throw new NotImplementedException();
            }
        }
    }
}