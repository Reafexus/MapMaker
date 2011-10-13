using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMakerTool
{
    class Room
    {
        Room[] rooms;
        String type;

        public Room()
        {
            rooms = new Room[6];
            type = "-";
        }

        /// <summary>
        /// Adds an exit to the Array rooms
        /// </summary>
        /// <param name="s">Direction to add</param>
        public void AddExit(String s)
        {
            if (s == "east") { }
            if (s == "west") { }
            if (s == "south") { }
            if (s == "north") { }
            if (s == "up") { }
            if (s == "down") { }



        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">Type of room made</param>
        public void changeType(String s)
        {
            if (s == "Enemies") { }
            if (s == "Treasure") { }
            if (s == "Boss") { }
            if (s == "Empty") { }
        }







    }
}
