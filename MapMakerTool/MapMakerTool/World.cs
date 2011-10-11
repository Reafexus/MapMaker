using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMakerTool
{
    class World
    {
        Room[, ,] WorldMap;
        Room[, ,] RoomType;

        public World()
        {
            WorldMap = new Room[3, 3, 2];

        }

        public void CreateWorld()
        {
            //Will take in input
            //TakeInDefinition();

            
        }

        /// <summary>
        /// Will take in input to create list in order to create World
        /// </summary>
        public void TakeInDefinition()
        {

        }


    }
}
