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

        float Health
        {
            get;
            set;
        }

    }
    public interface IDamage
    {
        void GiveDamage(IDamageable something);
        //void Knife(IDamageable damage);
        

    }



    public class Player : IDamageable, IDamage
    {
        //make these private
        private float lifes;
        private float attack;
        private float health;
       
        private int knifedurability;
        private int healthPackdurability;
     
        public int attackboost
        {
            get { return attackboost; }
            
        }
        public int Knifedurability
        {
            get { return knifedurability; }
            set { knifedurability = value; }
        }

        public int HealthPackdurability
        {
            get { return healthPackdurability; }
            set { healthPackdurability = value; }


        }
        public float Lifes
        {
            get { return lifes; }
            set { lifes = value; }
        }

        

        public float Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public float Health
        {
            get { return health; }
            set { health = value; }
        }
      
        public Player()
        {
            healthPackdurability = 100;
            knifedurability = 100;
        }
        public Player(float Health, float Attack, float Lifes, string name)
        {
       
            health = Health;
            attack = Attack;
            lifes = Lifes;
            knifedurability = 100;
            healthPackdurability = 100;
            
            //attackboost = 100;
            
           

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
        public void AttackBoost(IDamageable Aboost)
        {
            Aboost.Health -= 8;
            Aboost.TakeDamage(attack);
        }
        public void HealthPack(IDamageable GetsHealth)
        {
            GetsHealth.Health += 50;
            healthPackdurability -= 50;            
        }
        public void Knife(IDamageable damage)
        {
            
            knifedurability -= 5;
            damage.TakeDamage(attack);
        }
     
        public void GiveDamage(IDamageable something)
        {
            
            something.TakeDamage(attack);
        }
      
    }

        public delegate void OnDamaged<T>(T p);
    }




