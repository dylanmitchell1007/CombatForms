using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatForms
{
    
    class Ninja : IDamageable, IDamage
    {
        private int attack;
        private int health;
        public int Attack
        {
            get { return attack;}
            set { attack = value; }
        }
        public int Health
        {
            get { return health; }
            
        }

        public Ninja(int Health, int Attack, string name)
        {
            name = null;
            health = Health;
            attack = Attack;

        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void GiveDamage(IDamageable something)
        {
            something.TakeDamage(attack);
        }
    }
}







