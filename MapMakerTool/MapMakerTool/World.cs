using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMakerTool
{
    public class World
    {

        Room[, ,] WorldMap;
        public int[, ,] RoomInput;
        private int width;
        private int height;
        private int depth;

        public int Width 
        {
            get{ return width;}
        }
        
         
        
        public int Height 
        {
            get{ return height;}
        }
        public int Depth
        {
            get { return depth; }
        }

        public World()
        {

            CreateWorld();

        }

        public void CreateWorld()
        {
            //Will take in input
            //TakeInDefinition();

            //For now all lists are [3,3,3]
            //When finished they will be user defined and WorldMap will be based on the arrays brought in.
            //[i,j,k]
            //i = level
            //j = row (horizantal)
            //k = col (vertical)

            
            char[, ,] RoomType;

            RoomInput = new int[3, 3, 3];
            RoomType = new char[3, 3, 3];
            WorldMap = new Room[RoomInput.GetLength(0), RoomInput.GetLength(1), RoomInput.GetLength(2)];

            for(int i =0;i<RoomInput.GetLength(0);i++)
            {
                for(int j =0;j<RoomInput.GetLength(1);j++)
                {
                    for(int k =0;k<RoomInput.GetLength(2);k++)
                    {
                        
                        RoomInput[i,j,k] = 0;
                        
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            //Level 1
            RoomInput[0, 0, 1] = 4;
            RoomInput[0, 1, 0] = 6;
            RoomInput[0, 1, 1] = 11;
            RoomInput[0, 1, 2] = 1;
            RoomInput[0, 2, 0] = 36;
            RoomInput[0, 2, 1] = 1;
           

            //Level 2
            
            RoomInput[1, 1, 1] = 52;
            RoomInput[1, 2, 0] = 18;
            RoomInput[1, 2, 1] = 9;

            //Level 3
            RoomInput[2, 1, 0] = 2;
            RoomInput[2, 1, 1] = 17;
            


           

            CreateRooms(RoomInput,RoomType);
            
           
        }

        /// <summary>
        /// Will take in input to create list in order to create World
        /// </summary>
        public void TakeInDefinition()
        {

        }

        public void CreateRooms(int[,,] exits, char[,,] type)
        {
            for (int i = 0; i < WorldMap.GetLength(0); i++)
            {
                for (int j = 0; j < WorldMap.GetLength(1); j++)
                {
                    for (int k = 0; k < WorldMap.GetLength(2); k++)
                    {
                        WorldMap[i, j, k] = new Room();
                    }
                }
            }

            for (int i = 0; i < WorldMap.GetLength(0); i++)
            {
                for (int j = 0; j < WorldMap.GetLength(1); j++)
                {
                    for (int k = 0; k < WorldMap.GetLength(2); k++)
                    {
                        if (exits[i, j, k] != 0)
                        {
                            WorldMap[i, j, k] = CreateRoom(exits[i, j, k]);

                        } 
                    }
                }
            }




        }

        public Room CreateRoom(int exits)
        {
            //temp room variable
            Room temp = new Room();

            //Array of 1's and 0's to determine where exits and maybe the type of the room eventually
            int[] bin = ToBinary(exits);

            //Compare binary to specific tests
            //1st bit = east
            //2nd = west
            //3rd = south
            //4th = north
            // 5th = up
            // 6th = down
            //7th and 8th may mean type eventually.

            if (bin[0] == 1)
            {
                temp.AddExit("east");
            }
            if (bin[1] == 1)
            {
                temp.AddExit("west");
            }
            if (bin[2] == 1)
            {
                temp.AddExit("south");
            }
            if (bin[3] == 1)
            {
                temp.AddExit("north");
            }
            if (bin[4] == 1)
            {
                temp.AddExit("up");
            }
            if (bin[5] == 1)
            {
                temp.AddExit("down");
            } 
            if (bin[6] == 0 && bin[7] == 0)
            {
                temp.changeType("Special");
            }
            if (bin[6] == 0 && bin[7] == 1)
            {
                temp.changeType("Treasures");
            }
            if (bin[6] == 1 && bin[7] == 0)
            {
                temp.changeType("Enemies");
            }
            if (bin[6] == 1 && bin[7] == 1)
            {
                temp.changeType("Boss");
            }

            return new Room();


        }

        public int[] ToBinary(int i)
        {
            int[] bin = new int[8];
            int count = 0;
            while (i != 0)
            {
                bin[count] = i % 2;
                i /= 2;
                count++;
               


            }
            for (int j = 0; j < 8; j++)
            {
                Console.Write(bin[j]);
            }
            Console.WriteLine();

            return bin;
        }

        public void ChangeWorldSize(int x, int y, int z)
        {
            width = x;
            height = y;
            depth = z;

            int[, ,] temp = new int[z, x, y];

            for (int i = 0; i < z && i < RoomInput.GetLength(0); i++)
            {
                for (int j = 0; j < x && j < RoomInput.GetLength(1); j++)
                {
                    for (int k = 0; k < y && k < RoomInput.GetLength(2); k++)
                    {
                        if (i < z && j < x && k < y)
                            temp[i, j, k] = RoomInput[i, j, k];
                        else
                            temp[i, j, k] = 0;

                    
                    }
                }
            }

            RoomInput = temp;



        }


        public void UpdateRoomValue(int CurrLevel, int row, int col, int temp)
        {
            RoomInput[CurrLevel, row, col] = temp;
        }
    }
}