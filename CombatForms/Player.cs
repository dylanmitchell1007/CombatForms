using System;
using System.Xml.Serialization;
namespace CombatForms
{
    public enum PlayerState
    {
        INIT,
        IDLE,
        Attack,
        Exit,
    }

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


    [Serializable]
    public class Player : IDamageable, IDamage
    {
        public Player()
        {
            HealthPackdurability = 100;
            Knifedurability = 100;
        }

        public Player(float h, float a, float l, string n, float s, int cl)
        {

            Health = h;
            Attack = a;
            NumLives = l;
            Knifedurability = 100;
            HealthPackdurability = 100;
            Score = s;
            Currentlevel = cl;
        }
        public float Health { get; set; }
        public int AttackBoost { get; set; }
        public int Knifedurability { get; set; }
        public int HealthPackdurability { get; set; }
        public float NumLives { get; set; }
        public float Attack { get; set; }
        public float Score { get; set; }
        public int Currentlevel { get; set; }

        #region functions


        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                NumLives--;
                Health = 100;

            }
            if (NumLives <= 0)
            {
                Console.WriteLine("YOU LOSE");
            }
        }
        public void BuffAttack(IDamageable ab)
        {
            ab.Health -= 8;
            ab.TakeDamage(Attack);
        }
        public void HealthPack(IDamageable gh)
        {
            gh.Health += 50;
            HealthPackdurability -= 50;
        }
        public void Knife(IDamageable d)
        {
            Knifedurability -= 5;
            d.TakeDamage(Attack);
        }
        public void GiveDamage(IDamageable something)
        {
            something.TakeDamage(Attack);
        }

        #endregion functions

        public delegate void OnDamaged<T>(T p);
    }
}



