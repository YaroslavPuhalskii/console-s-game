using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;

namespace Console_sGame
{
    static class Game
    {
        private static readonly int _screenWidth = 100;
        private static readonly int _screenHeight = 70;

        private static readonly int _mapWidth = 80;
        private static readonly int _mapHeight = 48;
        private static RLConsole _mapConsole;

        private static readonly int _messageWidth = 80;
        private static readonly int _messageHeight = 11;
        private static RLConsole _messageConsole;

        private static readonly int _statWidth = 20;
        private static readonly int _statHeight = 70;
        private static RLConsole _statConsole;

        private static readonly int _invenrotyWidth = 80;
        private static readonly int _inventoryHeight = 11;
        private static RLConsole _inventorConsole;

        private static RLRootConsole _rootConsole;

        static void Main(string[] args)
        {
            string fontFileName = "terminal8x8.png";
            string consoleTitle = "RougeSharp V3 Tutorial - Level 1";

            _rootConsole = new RLRootConsole(fontFileName, _screenWidth, _screenHeight, 8, 8, 1f, consoleTitle);
            _mapConsole = new RLConsole(_mapWidth, _mapHeight);
            _messageConsole = new RLConsole(_messageWidth, _messageHeight);
            _statConsole = new RLConsole(_statWidth, _statHeight);
            _inventorConsole = new RLConsole(_invenrotyWidth, _inventoryHeight);

            _rootConsole.Update += OnRootConsoleUpdate;
            _rootConsole.Render += OnRootConsoleRender;
            _rootConsole.Run();
        }

        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e)
        {
            _mapConsole.SetBackColor(0, 0, _mapWidth, _mapHeight, RLColor.Black);
            _mapConsole.Print(1, 1, "Map", RLColor.White);
            _messageConsole.SetBackColor(0, 0, _messageWidth, _messageHeight, RLColor.Black);
            _messageConsole.Print(1, 1, "Message", RLColor.White);
            _statConsole.SetBackColor(0, 0, _statWidth, _statHeight, RLColor.Black);
            _statConsole.Print(1, 1, "Stats", RLColor.White);
            _inventorConsole.SetBackColor(0, 0, _invenrotyWidth, _inventoryHeight, RLColor.Black);
            _inventorConsole.Print(1, 1, "Inventory", RLColor.White);
        }

        private static void OnRootConsoleRender(object sender, UpdateEventArgs e)
        {
            RLConsole.Blit(_mapConsole, 0, 0, _mapWidth, _mapHeight, _rootConsole, 0, _inventoryHeight);
            RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight, _rootConsole, _mapWidth, 0);
            RLConsole.Blit(_statConsole, 0, 0, _statWidth, _statHeight, _rootConsole, 0, _screenHeight - _inventoryHeight);
            RLConsole.Blit(_inventorConsole, 0, 0, _invenrotyWidth, _inventoryHeight, _rootConsole, 0, 0);
            _rootConsole.Draw();
        }
    }
}
