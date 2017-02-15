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
    public partial class Form2 : Form
    {        
        public Form2()
        {
            InitializeComponent();            
            Update();
        }
        private void Form2_Load(object sender, EventArgs e)
        {          
            Update();
        }
        public new void Update()
        {
            richTextBox1.Text = "Player Score:" + Singleton.Instance.P1Score;
            
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {            
            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (Singleton.Instance.P1Score < 0)
            {
                button1.Enabled = false;
                Singleton.Instance.P1Score = 0;
            }

            if (Singleton.Instance.P1Score < 100)
            {
                button1.Enabled = false;
                richTextBox1.Text = "You do not have enough credits";
            }
            if (Singleton.Instance.P1Score >= 100)
            {
             Singleton.Instance.P1Score -= 100;
             Singleton.Instance.Player.Knifedurability = 100;
             
             Update();
            }
          
        }

        private void backtogame_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Dispose();
            form1.Show();
            Update();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (Singleton.Instance.P1Score <= 0)
            //{
            //    button2.Enabled = false;
            //    Singleton.Instance.P1Score = 0;
            //}

            if (Singleton.Instance.P1Score < 100)
            {
                button2.Enabled = false;
                richTextBox1.Text = "You do not have enough credits";
                
            }
            if(Singleton.Instance.P1Score >= 500)
            {
            Singleton.Instance.Player.Health = 100;
            Singleton.Instance.P1Score -= 500;
            }
            
          
            Update();
        }
    }
}