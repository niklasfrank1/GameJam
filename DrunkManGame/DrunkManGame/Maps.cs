using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkManGame
{
    internal class Maps
    {
        public static string GetMapTileRender(char[][] map, int tileI, int tileJ)
        {
            if (tileJ < 0 || tileJ >= map.Length || tileI < 0 || tileI >= map[tileJ].Length)
            {
                if (map == Bar) return Sprites.table;
                return Sprites.open;
            }
            return map[tileJ][tileI] switch
            {

                'W' => Sprites.wall00,
                'B' => Sprites.barwallstart,
                'b' => Sprites.barwallline,
                'R' => Sprites.barwallright,
                'r' => Sprites.barwallrightline,
                'T' => Sprites.table,

                _ => Sprites.Error,
            };
        }

        public static readonly char[][] Bar = new char[][]
        {
            "   WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW   ".ToCharArray(),
            "   W                          B        W   ".ToCharArray(),
            "   W                          b        W   ".ToCharArray(),
            "   W                          b        W   ".ToCharArray(),
            "   W                          R r r r  W   ".ToCharArray(),
            "   W                                   W   ".ToCharArray(),
            "   W                                   W   ".ToCharArray(),
            "   W                                T  W   ".ToCharArray(),
            "   W                                T  W   ".ToCharArray(),
            "   W                              T T  W   ".ToCharArray(),
            "   WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW   ".ToCharArray(),
        };
    }
}

