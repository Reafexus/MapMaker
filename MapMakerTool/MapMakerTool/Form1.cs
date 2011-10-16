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

        private bool changingRoom;

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
            Map[7, 2] = seventwo;
            Map[7, 3] = seventhree;
            Map[7, 4] = sevenfour;
            Map[7, 5] = sevenfive;
            Map[7, 6] = sevensix;
            Map[7, 7] = sevenseven;

            changingRoom = false;







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
                    if (i < info.GetLength(1) && j < info.GetLength(2))
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
            changingRoom = true;
            if (int.Parse(CurrentLevel.Text) > World.Depth)
                CurrentLevel.Text = World.Depth.ToString();
            else
                CurrLevel = int.Parse(CurrentLevel.Text);
            updateMap(World.RoomInput);
            changingRoom = false;

        }

        private void updateRoomStatus()
        {
            changingRoom = true;
            if (int.Parse(CurrRoom.Text) == 0)
            {
                NoRoomType.Checked = true;
                NorthBox.Checked = false;
                SouthBox.Checked = false;
                EastBox.Checked = false;
                WestBox.Checked = false;
                UpBox.Checked = false;
                DownBox.Checked = false;

            }
            else
            {
                int[] bin = World.ToBinary(int.Parse(CurrRoom.Text));
                if (bin[0] == 1)
                {
                    WestBox.Checked = true;
                }
                else WestBox.Checked = false;
                if (bin[1] == 1)
                {
                    EastBox.Checked = true;
                }
                else EastBox.Checked = false;
                if (bin[2] == 1)
                {
                    SouthBox.Checked = true;
                }
                else SouthBox.Checked = false;
                if (bin[3] == 1)
                {
                    NorthBox.Checked = true;
                }
                else NorthBox.Checked = false;
                if (bin[4] == 1)
                {
                    UpBox.Checked = true;
                }
                else UpBox.Checked = false;
                if (bin[5] == 1)
                {
                    DownBox.Checked = true;
                }
                else DownBox.Checked = false;
                if (bin[6] == 0 && bin[7] == 0)
                {
                    SpecialType.Checked = true;
                }
                if (bin[6] == 0 && bin[7] == 1)
                {
                    TreasureType.Checked = true;
                }
                if (bin[6] == 1 && bin[7] == 0)
                {
                    EnemiesType.Checked = true;
                }
                if (bin[6] == 1 && bin[7] == 1)
                {
                    BossType.Checked = true;
                }
            }
            changingRoom = false;
        }



        private void zerozero_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerozero;
            updateRoomStatus();

        }

        private void zeroone_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zeroone;
            updateRoomStatus();
        }

        private void zerotwo_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerotwo;
            updateRoomStatus();
        }

        private void zerothree_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerothree;
            updateRoomStatus();
        }

        private void zerofour_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerofour;
            updateRoomStatus();
        }

        private void zerofive_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerofive;
            updateRoomStatus();
        }

        private void zerosix_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zerosix;
            updateRoomStatus();
        }

        private void zeroseven_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = zeroseven;
            updateRoomStatus();
        }

        private void onezero_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = onezero;
            updateRoomStatus();
        }

        private void oneone_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = oneone;
            updateRoomStatus();
        }

        private void onetwo_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = onetwo;
            updateRoomStatus();
        }

        private void onethree_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = onethree;
            updateRoomStatus();
        }

        private void onefour_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = onefour;
            updateRoomStatus();
        }

        private void onefive_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = onefive;
            updateRoomStatus();
        }

        private void onesix_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = onesix; updateRoomStatus();
        }

        private void oneseven_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = oneseven; updateRoomStatus();
        }

        private void twozero_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = twozero; updateRoomStatus();
        }

        private void twoone_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = twoone; updateRoomStatus();
        }

        private void twotwo_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = twotwo; updateRoomStatus();
        }

        private void twothree_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = twothree; updateRoomStatus();
        }

        private void twofour_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = twofour; updateRoomStatus();
        }

        private void twofive_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = twofive; updateRoomStatus();
        }

        private void twosix_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = twosix; updateRoomStatus();
        }

        private void twoseven_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = twoseven; updateRoomStatus();
        }

        private void threezero_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = threezero; updateRoomStatus();
        }

        private void threeone_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = threeone; updateRoomStatus();

        }

        private void threetwo_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = threetwo; updateRoomStatus();
        }

        private void threethree_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = threethree; updateRoomStatus();
        }

        private void threefour_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = threefour; updateRoomStatus();
        }

        private void threefive_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = threefive; updateRoomStatus();

        }

        private void threesix_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = threesix; updateRoomStatus();
        }

        private void threeseven_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = threeseven; updateRoomStatus();
        }

        private void fourzero_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fourzero; updateRoomStatus();
        }

        private void fourone_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fourone; updateRoomStatus();
        }

        private void fourtwo_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fourtwo; updateRoomStatus();
        }

        private void fourthree_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fourthree; updateRoomStatus();
        }

        private void fourfour_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fourfour; updateRoomStatus();
        }

        private void fourfive_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fourfive; updateRoomStatus();
        }

        private void foursix_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = foursix; updateRoomStatus();
        }

        private void fourseven_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fourseven; updateRoomStatus();
        }

        private void fivezero_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fivezero; updateRoomStatus();
        }

        private void fiveone_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fiveone; updateRoomStatus();
        }

        private void fivetwo_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fivetwo; updateRoomStatus();
        }

        private void fivethree_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fivethree; updateRoomStatus();
        }

        private void fivefour_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fivefour; updateRoomStatus();
        }

        private void fivefive_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fivefive; updateRoomStatus();
        }

        private void fivesix_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fivesix; updateRoomStatus();
        }

        private void fiveseven_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = fiveseven; updateRoomStatus();
        }

        private void sixzero_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sixzero; updateRoomStatus();
        }

        private void sixone_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sixone; updateRoomStatus();
        }

        private void sixtwo_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sixtwo; updateRoomStatus();
        }

        private void sixthree_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sixthree; updateRoomStatus();
        }

        private void sixfour_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sixfour; updateRoomStatus();
        }

        private void sixfive_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sixfive; updateRoomStatus();
        }

        private void sixsix_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sixsix; updateRoomStatus();
        }

        private void sixseven_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sixseven; updateRoomStatus();
        }

        private void sevenzero_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sevenzero; updateRoomStatus();
        }

        private void sevenone_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sevenone; updateRoomStatus();
        }

        private void seventwo_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = seventwo; updateRoomStatus();
        }

        private void seventhree_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = seventhree; updateRoomStatus();
        }

        private void sevenfour_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sevenfour; updateRoomStatus();
        }

        private void sevenfive_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sevenfive; updateRoomStatus();
        }

        private void sevensix_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sevensix; updateRoomStatus();
        }

        private void sevenseven_MouseDown(object sender, MouseEventArgs e)
        {
            CurrRoom = sevenseven; updateRoomStatus();
        }

        private void UpBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (UpBox.Checked)
                {
                    temp += 16;
                }
                else temp -= 16;
                CurrRoom.Text = temp.ToString();
            }
        }

        private void NorthBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (NorthBox.Checked)
                {
                    temp += 8;
                }
                else temp -= 8;
                CurrRoom.Text = temp.ToString();
            }
        }

        private void WestBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (WestBox.Checked)
                {
                    temp += 1;
                }
                else temp -= 1;
                CurrRoom.Text = temp.ToString();
            }
        }

        private void SouthBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (SouthBox.Checked)
                {
                    temp += 4;
                }
                else temp -= 4;
                CurrRoom.Text = temp.ToString();
            }
        }

        private void DownBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (DownBox.Checked)
                {
                    temp += 32;
                }
                else temp -= 32;
                CurrRoom.Text = temp.ToString();
            }
        }

        private void EnemiesType_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (EnemiesType.Checked)
                {
                    temp += 64;
                }
                else temp -= 64;
                CurrRoom.Text = temp.ToString();
            }
        }

        private void TreasureType_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (TreasureType.Checked)
                {
                    temp += 128;
                }
                else temp -= 128;
                CurrRoom.Text = temp.ToString();
            }
        }

        private void BossType_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (BossType.Checked)
                {
                    temp += 192;
                }
                else temp -= 192;
                CurrRoom.Text = temp.ToString();
            }
        }

        private void SpecialType_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (SpecialType.Checked)
                {
                    temp += 0;
                }
                else temp -= 0;
                CurrRoom.Text = temp.ToString();
            }
        }

        private void NoRoomType_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (NoRoomType.Checked)
                {
                    temp = 0;
                }
                CurrRoom.Text = temp.ToString();
            }
        }

        private void EastBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingRoom)
            {
                int temp = int.Parse(CurrRoom.Text);
                if (EastBox.Checked)
                {
                    temp += 2;
                }
                else temp -= 2;
                CurrRoom.Text = temp.ToString();
            }
        }












    }
}