using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21Card
{
    public partial class Form1 : Form
    {
        public Player player = new Player();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            textBox1.Visible = true;

        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            player.pickCard();




        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            player.indicateColumn(1, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.indicateColumn(0, 1, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.indicateColumn(0, 0, 1);
        }
    }
}
