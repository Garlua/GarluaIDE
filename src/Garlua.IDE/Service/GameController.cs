using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlua.IDE.Service
{
    /// <summary>
    /// Controls a garrys mod instance
    /// </summary>
    public class GameController
    {
        protected Steam.Environment SteamEnv;

        /// <summary>
        /// Game ID
        /// </summary>
        protected string AppCmd = "-applaunch 4000";

        public GameController()
        {
            SteamEnv = new Steam.Environment();
        }

        /// <summary>
        /// Launch the game
        /// </summary>
        public void LaunchGame()
        {
            RunCommand("-dev");
        }

        /// <summary>
        /// Run a commando, this will start the game
        /// </summary>
        /// <param name="commando"></param>
        protected void RunCommand(String commando)
        {
            var proc = new System.Diagnostics.Process()
            {
                StartInfo =
                {
                    UseShellExecute = true,
                    FileName = SteamEnv.SteamExecutable,
                    Arguments = AppCmd + " " + commando,
                    CreateNoWindow = true
                }
            };

            proc.Start();
        }

        /// <summary>
        /// Run na ingame commando without showing a popup
        /// </summary>
        /// <param name="commando">A Source Engine commando</param>
        public void RunIngameCommand(String commando)
        {
            RunCommand("-silent -hijack " + commando);
        }
    }
}
