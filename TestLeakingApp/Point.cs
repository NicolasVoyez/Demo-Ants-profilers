using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using TestLeakingAppExternalLibrary;

namespace TestLeakingApp
{
    public class Point : IPositionnable
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Brush Color { get; set; }


        public string TypeName
        {
            get { return "Point"; }
        }
    }
}
