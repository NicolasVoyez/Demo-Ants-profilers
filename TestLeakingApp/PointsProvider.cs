using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace TestLeakingApp
{
    public static class PointsProvider
    {
        private static readonly Random _Random = new Random();
        public static IEnumerable<Point> GetPoints()
        {
            for (int i = 0; i < 1000; i++)
            {
                yield return new Point
                {
                    X = _Random.Next(0,525),
                    Y = _Random.Next(0, 320),
                    Color = new SolidColorBrush(_Colors[_Random.Next(0, 13)])
                };
            }
        }

        private static List<Color> _Colors = new List<Color>
        {
            System.Windows.Media.Colors.AliceBlue,
            System.Windows.Media.Colors.AntiqueWhite,
            System.Windows.Media.Colors.Aqua,
            System.Windows.Media.Colors.Azure,
            System.Windows.Media.Colors.Bisque,
            System.Windows.Media.Colors.BlanchedAlmond,
            System.Windows.Media.Colors.Red,
            System.Windows.Media.Colors.Yellow,
            System.Windows.Media.Colors.Green,
            System.Windows.Media.Colors.Orange,
            System.Windows.Media.Colors.Blue,
            System.Windows.Media.Colors.Violet,
            System.Windows.Media.Colors.Black            
        };

    }
}
