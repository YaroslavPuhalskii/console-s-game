using Console_sGame.Core;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_sGame.Systems
{
    public class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;

        private readonly DungeonMap _map;

        public MapGenerator(int width, int heigth)
        {
            _width = width;
            _height = heigth;
            _map = new DungeonMap();
        }

        public DungeonMap CreatMap()
        {
            _map.Initialize(_width, _height);
            foreach (Cell cell in _map.GetAllCells().OfType<Cell>())
            {
                _map.SetCellProperties(cell.X, cell.Y, true, true, true);
            }

            foreach (Cell cell in _map.GetCellsInRows(0, _height - 1).OfType<Cell>())
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }

            foreach (Cell cell in _map.GetCellsInColumns(0, _width - 1).OfType<Cell>())
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }

            return _map;
        }

    }
}
