using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMakerTool
{
    public class ExportMap
    {
        private int[, ,] map;
        private StreamWriter stream;

        public ExportMap(int[,,] m)
        {
            map = m;
            File.Delete("MapDef.txt");
            stream = new StreamWriter("MapDef.txt");
            



        }

        public void CreateFile()
        {
            stream.WriteLine(map.GetLength(0) + " " + map.GetLength(1) + " " + map.GetLength(2));
            stream.WriteLine();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    for (int k = 0; k < map.GetLength(2); k++)
                    {
                        stream.Write(map[i, j, k] + " ");

                    }
                    stream.WriteLine();
                }
                stream.WriteLine();
            }

            stream.Close();












        }




    }
}
