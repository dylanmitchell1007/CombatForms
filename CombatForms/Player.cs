using CombatForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatForms
{


    public enum PlayerState
    {
        INIT,
        IDLE,
        Attack,
        Exit,
    }






    /// <summary>
    /// This is the inteface Attemp 1.
    /// Ninja vs Zombie.
    /// </summary>
    public interface IDamageable
    {
        void TakeDamage(float damage);



    }
    public interface IDamage
    {
        void GiveDamage(IDamageable something);

    }



    public class Player : IDamageable, IDamage
    {
        //make these private
        private float lifes;
        private float attack;
        private float health;
        private int save1;
        public float Lifes
        {
            get { return lifes; }
        }

        public float Attack
        {
            get { return attack; }
        }
        public float Health
        {
            get { return health; }
        }

        public Player(float Health, float Attack, float Lifes, string name)
        {
            name = null;
            health = Health;
            attack = Attack;
            lifes = Lifes;

        }

      

        public void TakeDamage(float damage)
        {
            health -= damage;
            if(health<= 0)
            {
                lifes--;
                health = 100;

             }
            if(lifes<= 0)
            {
                Console.WriteLine("YOU LOSE");
            }
        }

        public void GiveDamage(IDamageable something)
        {
            something.TakeDamage(attack);
        }
        public void Save(float a)
        {
              
         
        }
    }

        public delegate void OnDamaged<T>(T p);
    }




