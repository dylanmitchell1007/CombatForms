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
            richTextBox1.Text = "Player Score:" + score;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {            
            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void backtogame_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Dispose();
            form1.Show();
        }
    }
}