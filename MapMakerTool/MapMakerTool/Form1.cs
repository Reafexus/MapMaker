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
        private World World;
        private TextBox[,] Map;
        private int CurrLevel;
        private TextBox CurrRoom;

        public Form1(World w)
        {
            InitializeComponent();
            World = w;
            World.ChangeWorldSize(int.Parse(Width.Text), int.Parse(Height.Text), int.Parse(Depth.Text));
           // InitializeComponent();
            createMapArray();
            updateMap(World.RoomInput);
        }

        private void createMapArray()
        {
            Map = new TextBox[8, 8];
            Map[0, 0] = zerozero;
            Map[0, 1] = zeroone;
            Map[0, 2] = zerotwo;
            Map[0, 3] = zerothree;
            Map[0, 4] = zerofour;
            Map[0, 5] = zerofive;
            Map[0, 6] = zerosix;
            Map[0, 7] = zeroseven;
           
            Map[1, 0] = onezero;
            Map[1, 1] = oneone;
            Map[1, 2] = onetwo;
            Map[1, 3] = onethree;
            Map[1, 4] = onefour;
            Map[1, 5] = onefive;
            Map[1, 6] = onesix;
            Map[1, 7] = oneseven;

            Map[2, 0] = twozero;
            Map[2, 1] = twoone;
            Map[2, 2] = twotwo;
            Map[2, 3] = twothree;
            Map[2, 4] = twofour;
            Map[2, 5] = twofive;
            Map[2, 6] = twosix;
            Map[2, 7] = twoseven;

            Map[3, 0] = threezero;
            Map[3, 1] = threeone;
            Map[3, 2] = threetwo;
            Map[3, 3] = threethree;
            Map[3, 4] = threefour;
            Map[3, 5] = threefive;
            Map[3, 6] = threesix;
            Map[3, 7] = threeseven;
            
            Map[4, 0] = fourzero;
            Map[4, 1] = fourone;
            Map[4, 2] = fourtwo;
            Map[4, 3] = fourthree;
            Map[4, 4] = fourfour;
            Map[4, 5] = fourfive;
            Map[4, 6] = foursix;
            Map[4, 7] = fourseven;

            Map[5, 0] = fivezero;
            Map[5, 1] = fiveone;
            Map[5, 2] = fivetwo;
            Map[5, 3] = fivethree;
            Map[5, 4] = fivefour;
            Map[5, 5] = fivefive;
            Map[5, 6] = fivesix;
            Map[5, 7] = fiveseven;

            Map[6, 0] = sixzero;
            Map[6, 1] = sixone;
            Map[6, 2] = sixtwo;
            Map[6, 3] = sixthree;
            Map[6, 4] = sixfour; 
            Map[6, 5] = sixfive;
            Map[6, 6] = sixsix;
            Map[6, 7] = sixseven;

            Map[7, 0] = sevenzero;
            Map[7, 1] = sevenone;
            Map[7, 2] = seventwo ;
            Map[7, 3] = seventhree ;
            Map[7, 4] = sevenfour ;
            Map[7, 5] = sevenfive ;
            Map[7, 6] = sevensix ;
            Map[7, 7] = sevenseven ;
            






        }
       

        private void Height_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(Width.Text) > 8)
            {
                Height.Text = World.Width.ToString();
            }
            World.ChangeWorldSize(int.Parse(Width.Text), int.Parse(Height.Text), int.Parse(Depth.Text));
            updateMap(World.RoomInput);
        }


        private void Width_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(Width.Text) > 8)
            {
                Width.Text = World.Width.ToString();
            }
            World.ChangeWorldSize(int.Parse(Width.Text), int.Parse(Height.Text), int.Parse(Depth.Text));
            updateMap(World.RoomInput);
        }

        private void Depth_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(Depth.Text) > 8)
            {
                Width.Text = World.Width.ToString();
            }
            if (int.Parse(Depth.Text) < CurrLevel)
            {
                CurrLevel = 0;
            }
            World.ChangeWorldSize(int.Parse(Width.Text), int.Parse(Height.Text), int.Parse(Depth.Text));
            updateMap(World.RoomInput);
        }

        public void updateMap(int[, ,] info)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if( i < info.GetLength(1) && j < info.GetLength(2))
                        Map[i, j].Text = info[CurrLevel, i, j].ToString();
                    else
                    {
                        Map[i, j].Text = "--";
                    }
                }
            }

            


        }

        private void CurrentLevel_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(CurrentLevel.Text) > World.Depth)
                CurrentLevel.Text = World.Depth.ToString();
            else
                CurrLevel = int.Parse(CurrentLevel.Text);
            updateMap(World.RoomInput);
            
        }

        

        private void zerozero_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerozero;
        }

        private void zeroone_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zeroone;
        }

        private void zerotwo_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerotwo;
        }

        private void zerothree_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerothree;
        }

        private void zerofour_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerofour;
        }

        private void zerofive_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerofive;
        }

        private void zerosix_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void zeroseven_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void onezero_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void oneone_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void onetwo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void onethree_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void onefour_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void onefive_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void onesix_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void oneseven_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void twozero_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void twoone_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void twotwo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void twothree_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void twofour_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void twofive_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void twosix_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void twoseven_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void threezero_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void threeone_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void threetwo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void threethree_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void threefour_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void threefive_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void threesix_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void threeseven_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fourzero_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fourone_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fourtwo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fourthree_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fourfour_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fourfive_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void foursix_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fourseven_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fivezero_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fiveone_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fivetwo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fivethree_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fivefour_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fivefive_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fivesix_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void fiveseven_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sixzero_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sixone_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sixtwo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sixthree_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sixfour_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sixfive_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sixsix_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sixseven_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sevenzero_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sevenone_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void seventwo_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void seventhree_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sevenfour_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sevenfive_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sevensix_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void sevenseven_MouseDown(object sender, MouseEventArgs e)
        {

        }

        

       

        


        

        
    }
}
