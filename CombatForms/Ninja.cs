using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatForms
{
    
    class Ninja : IDamageable, IDamage
    {
        private float attack;
        private float health;
        public float Attack
        {
            get { return attack;}
            set { attack = value; }
        }
        public float Health
        {
            get { return health; }
            set { health = value; }
            
        }

        public Ninja(float Health, float Attack, string name)
        {
            name = null;
            health = Health;
            attack = Attack;

        }

        public void TakeDamage(float damage)
        {
            health -= damage;
        }

        public void GiveDamage(IDamageable something)
        {
            something.TakeDamage(attack);
        }


    }
}







