using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMakerTool
{
    class Room
    {
        Room[] rooms;
        Boolean[] roomDef;
        String type;

        public Room()
        {
            rooms = new Room[6];
            roomDef = new Boolean[6];
            type = "-";
        }

        /// <summary>
        /// Adds an exit to the Array rooms
        /// </summary>
        /// <param name="s">Direction to add</param>
        public void AddExit(String s)
        {
            if (s == "east")        { roomDef[0] = true; }
            else if (s == "west")   { roomDef[1] = true; }
            else if (s == "south")  { roomDef[2] = true; }
            else if (s == "north")  { roomDef[3] = true; }
            else if (s == "up")     { roomDef[4] = true; }
            else if (s == "down")   { roomDef[5] = true; }



        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">Type of room made</param>
        public void changeType(String s)
        {
            type = s;
        }







    }
}
