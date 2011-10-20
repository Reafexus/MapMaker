using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMakerTool
{
    public class ImportMap
    {
        private int[, ,] map;
        private StreamReader stream;

        public int[, ,] Map
        {
            get { return map; }
        }

        public ImportMap()
        {
            stream = new StreamReader("MapDef.txt");
            readFile();
            
            


        }

        public void readFile()
        {
            string[] size = stream.ReadLine().Split(' ');
            int height = int.Parse(size[1]);
            int width = int.Parse(size[2]);
            int depth = int.Parse(size[0]);
            stream.ReadLine();
            map = new int[depth,height,width];
            
            for (int i = 0; i < depth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    string[] defs = stream.ReadLine().Split(' ');
                    for (int k = 0; k < width; k++)
                    {
                        map[i,j,k] = int.Parse(defs[k]);
                    }

                }
                stream.ReadLine();
            }
            stream.Close();

        }

    }
}