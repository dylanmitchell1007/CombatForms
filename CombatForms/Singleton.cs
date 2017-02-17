using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatForms
{
    class Singleton
    {
        private int m_ninjaIndex;

        private List<Ninja> m_ninjaList;

        Form gameform;
        private Ninja m_currentNinja;
        public int NinjaIndex
        {
            get { return m_ninjaIndex; }
            set { m_ninjaIndex = value; }
        }
     
        public List<Ninja> NinjaList
        {
            get; set;
        }
     
        public Ninja CurrentNinja
        {
            get { return m_currentNinja; }
            set { m_currentNinja = value; }
        }


        private int roundnumber = 1;
        private int p1score;
        private Player player;
        public Player Player
        {
            get;
            set;
        }
        
        public int RoundNumber
        {
            get { return roundnumber; }
            set { roundnumber = value; }
        }

        public int P1Score
        {
            get { return p1score; }
            set { p1score = value; }
        }

        public Form Gameform
        {
            get { return gameform; }
            set { gameform = value; }
        }

        private static readonly Singleton instance = new Singleton();
        private Singleton()
        {
          
        }
        public static Singleton Instance
        {
            get { return instance; }

        }
    }
}
