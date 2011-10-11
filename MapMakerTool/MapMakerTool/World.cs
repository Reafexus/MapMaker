using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMakerTool
{
    class World
    {

        Room[, ,] WorldMap;

        public World()
        {

            CreateWorld();

        }

        public void CreateWorld()
        {
            //Will take in input
            //TakeInDefinition();

            //For now all lists are [3,3,2]
            //When finished they will be user defined and WorldMap will be based on the arrays brought in.

            int[, ,] RoomInput;
            char[, ,] RoomType;

            RoomInput = new int[3, 4, 2];
            RoomType = new char[3, 4, 2];
            WorldMap = new Room[RoomInput.GetLength(0), RoomInput.GetLength(1), RoomInput.GetLength(2)];

            for(int i =0;i<RoomInput.GetLength(0);i++)
            {
                for(int j =0;j<RoomInput.GetLength(1);j++)
                {
                    for(int k =0;k<RoomInput.GetLength(2);k++)
                    {
                        
                        RoomInput[i,j,k] = 0;
                        //Console.Write("" + RoomInput[i,j,k]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            RoomInput[1, 3, 0] = 4;
            RoomInput[0, 1, 0] = 0;
            RoomInput[2, 2, 0] = 0;

            for(int i =0;i<RoomInput.GetLength(0);i++)
            {
                for(int j =0;j<RoomInput.GetLength(1);j++)
                {
                    for(int k =0;k<RoomInput.GetLength(2);k++)
                    {
                        Console.Write("" + RoomInput[i, j, k]);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
            //RoomInput[
           
        }

        /// <summary>
        /// Will take in input to create list in order to create World
        /// </summary>
        public void TakeInDefinition()
        {

        }


    }
}