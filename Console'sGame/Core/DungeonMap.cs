using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueSharp;

namespace Console_sGame.Core
{
    public class DungeonMap : Map
    {
        public void Draw(RLConsole mapConsole)
        {
            mapConsole.Clear();
            foreach (Cell cell in GetAllCells().OfType<Cell>())
            {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }

        private void SetConsoleSymbolForCell(RLConsole console, Cell cell)
        {
            if (!cell.IsExplored)
                return;

            if (cell.IsWalkable)
                console.Set(cell.X, cell.Y, Colors.FloorFov, Colors.FloorBackground, '.');
            else
                console.Set(cell.X, cell.Y, Colors.WallFov, Colors.WallBAckground, '#');
        }
    }
}
