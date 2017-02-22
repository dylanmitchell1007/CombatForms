using System.Diagnostics;
using System.Windows.Forms;

namespace CombatForms
{
    public delegate void Handler();

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Application.Exit();
        }


    }
}


