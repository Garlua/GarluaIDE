using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Garlua.IDE.Steam
{
    /// <summary>
    /// Steam Environment Settings
    /// </summary>
    public class Environment
    {
        public String SteamPath { get; set; }

        /// <summary>
        /// Path to the local Garrys Mod folder
        /// </summary>
        public String GarrysModPath { get; set; }

        /// <summary>
        /// AccountName
        /// </summary>
        public String AccountName { get; set; }

        /// <summary>
        /// Path to the main Steam executable
        /// </summary>
        public String SteamExecutable
        {
            get
            {
                return Path.Combine(SteamPath, "steam.exe");
            }
        }

        /// <summary>
        /// Weapons folder
        /// </summary>
        public String WeaponsPath
        {
            get
            {
                String weaponPath = Path.Combine(GarrysModPath, @"lua\weapons");

                if (!Directory.Exists(weaponPath))
                {
                    Directory.CreateDirectory(weaponPath);
                }

                return weaponPath;
            }
        }

        /// <summary>
        /// Steam Environment initialization
        /// </summary>
        public Environment()
        {
            var key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");

            if (key == null)
            {
                throw new InvalidDataException("Garrys Mod installation not found!");
            }

            AccountName = key.GetValue("LastGameNameUsed").ToString();
            SteamPath = key.GetValue("SteamPath").ToString();
            GarrysModPath = Path.GetFullPath(String.Format(
                @"{0}/steamapps/{1}/garrysmod/garrysmod",
                SteamPath,
                AccountName));
        }

        /// <summary>
        /// Create a new gamemode folder and return the resulting path
        /// </summary>
        /// <param name="name">Gamemode folder</param>
        /// <returns>Full path to the gamemode folder</returns>
        public String GameModeFolder(String name)
        {
            String gameModePath = Path.Combine(GarrysModPath, "gamemodes", name, "gamemode");

            if (!Directory.Exists(gameModePath))
            {
                Directory.CreateDirectory(gameModePath);
            }

            return gameModePath;
        }
    }
}
