using System;
using System.Text;

namespace DrunkManGame
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            var map = Maps.Bar; // your map

            RenderMap(map);

            Console.SetCursorPosition(0, map.Length + 2);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        static void RenderMap(char[][] map)
        {
            //Tilemap has no concept of sprite height anymore, it's handled within the sprite class
            StringBuilder[] mapLines = new StringBuilder[4];

            for (int i = 0; i < 4; i++)
                mapLines[i] = new StringBuilder();

            // For each row in the map
            for (int row = 0; row < map.Length; row++)
            {
                // Build the line by appending the specific line parts of each sprite
                for (int col = 0; col < map[row].Length; col++)
                {
                    string sprite = Maps.GetMapTileRender(map, col, row);
                    string[] spriteLines = sprite.Split('\n');

                    // determine width to pad missing lines for alignment
                    int spriteWidth = 0;
                    if (spriteLines.Length > 0)
                    {
                        // trim any trailing '\r' and measure width of the first line
                        spriteLines[0] = spriteLines[0].TrimEnd('\r');
                        spriteWidth = spriteLines[0].Length;
                    }

                    // Add the specific line of the sprite (safe for sprites with fewer than 4 lines)
                    for (int i = 0; i < 4; i++)
                    {
                        string line;
                        if (i < spriteLines.Length)
                            line = spriteLines[i].TrimEnd('\r');
                        else
                            line = new string(' ', spriteWidth); // pad with spaces to keep alignment

                        mapLines[i].AppendLine(line);
                    }
                }
            }

            // Output all the lines
            for (int i = 0; i < 4; i++)
            {
                Console.Write(mapLines[i].ToString());
            }
        }
    }
}
