using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatForms
{

    public partial class Form1 : Form
    {
        private int RoundNumber;
        private int NinjaIndex;
        

        Player p1;

        List<Ninja> NinjaList;

        Ninja currentNinja;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            p1 = new Player(100 + RoundNumber, 10, 5, "P1");

            NinjaList = new List<Ninja>();

            for (int a = 1; a < 101; a++)
            {
                NinjaList.Add(new Ninja(100, 5 + RoundNumber, "Ninja " + a));
            }




            RoundNumber = 1;
            NinjaIndex = 0;



            currentNinja = NinjaList[NinjaIndex];


            progressBar2.Value = (int)p1.Health;
            progressBar1.Value = (int)currentNinja.Health;
            richTextBox3.Text = "Round: " + RoundNumber;
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p1.GiveDamage(currentNinja);
            Update();
            currentNinja.GiveDamage(p1);
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "Player";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Update()
        {
            richTextBox4.Text += "\n Lifes:" + p1.Lifes;

            richTextBox4.Text += " \n Attack Log:" + p1.Attack;
            if (currentNinja.Health == 0)
            {

                RoundNumber++;
                NinjaIndex++;
                NinjaList[NinjaIndex].Attack += RoundNumber;
                currentNinja = NinjaList[NinjaIndex];
               


                Update();
            }

            
            progressBar2.Value = (int)p1.Health;
            progressBar1.Value = (int)currentNinja.Health;
            richTextBox3.Text = "Round: " + RoundNumber;

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
