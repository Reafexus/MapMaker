using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapMakerTool
{
    public partial class Form1 : Form
    {
        private World world;

        public Form1(World w)
        {
            world = w;
            InitializeComponent();
        }

       

        private void Height_TextChanged(object sender, EventArgs e)
        {

            world.ChangeWorldSize(int.Parse(Width.Text), int.Parse(Height.Text), int.Parse(textBox2.Text));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            world.ChangeWorldSize(int.Parse(Width.Text), int.Parse(Height.Text), int.Parse(textBox2.Text));
        }

        private void Width_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(Width.Text) > 8)
            {
                Width.Text = world.Width.ToString();
            }
            world.ChangeWorldSize(int.Parse(Width.Text), int.Parse(Height.Text), int.Parse(textBox2.Text));
        }

       

        


        

        
    }
}
