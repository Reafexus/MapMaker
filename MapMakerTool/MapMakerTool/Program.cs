using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace MapMakerTool
{
    class Program
    {
        


        static void Main(string[] args)
        {
            World w = new World();
            Editor f = new Editor(w);
            Application.Run(f);


        


        }


        


    }
}
