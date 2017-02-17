using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatForms
{
    public delegate void Handler();
    delegate void Callback();
    delegate void CallbackString(State St);

    public enum GameStates
    {
        INIT,
        START,
        EXIT,
    }

    class Program
    {

            static void Main(string[] args)
            {

            //    Player player = new Player();
            //    Player dylan = new Player();
            //    Player matthew = new Player();

            //    dylan.Attack(matthew);
            //    //player.AddTalk((Callback<string>)SaySomething);
            //    //player.AddTalk((Callback<string>)SayAnotherThing);
            //    player.Talk("\n -Dylan:");
            Singleton.Instance.CurrentNinja = new Ninja();
            Player p = new Player();
            Singleton.Instance.Player = p;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                Application.Exit();
            }
            //    static public void ChangeState(GameStates gs)
            //{

            //}
            //delegate void Callback();
            //delegate void Callback<T>(T n);
            //static public void SaySomething(string s)
            //{
            //    Console.WriteLine("-SaySomething " + s);
            //}

            //static public void SayAnotherThing(string s)
            //{
            //    Console.WriteLine("-SayAnotherThing " + s);

            //}

        }
    }


    