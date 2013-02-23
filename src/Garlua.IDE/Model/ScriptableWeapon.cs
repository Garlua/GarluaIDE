using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlua.IDE.Model
{
    /// <summary>
    /// A scriptable weapon which are commonly used in SWEP scripts
    /// </summary>
    public class ScriptableWeapon
    {
        /// <summary>
        /// This determins how big each clip/magazine for the gun is. You can 
        /// set it to -1 to disable the ammo system, meaning primary ammo will 
        /// not be displayed and will not be affected.
        /// </summary>
        public int ClipSize { get; set; }

        /// <summary>
        /// This sets the number of rounds in the clip when you first get the gun. Again it can be set to -1.
        /// </summary>
        public int DefaultClip { get; set; }

        /// <summary>
        /// Determines whether the primary fire is automatic
        /// </summary>
        public bool Automatic { get; set; }

        /// <summary>
        /// The ammunition type the gun uses
        /// </summary>
        public string Ammo { get; set; }

        /// <summary>
        /// The amount of recoil
        /// </summary>
        public decimal Recoil { get; set; }

        /// <summary>
        /// Damage each bullet does
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Ammo cost for each shot
        /// </summary>
        public int NumberOfShots { get; set; }

        /// <summary>
        /// Spreading of bullets
        /// </summary>
        public decimal Cone { get; set; }

        /// <summary>
        /// Bullet delay
        /// </summary>
        public decimal Delay { get; set; }

        /// <summary>
        /// Sound file
        /// </summary>
        public string SoundFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TracerFrequency { get; set; }

        /// <summary>
        /// Force
        /// </summary>
        public int Force { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ScriptableWeapon()
        {
            ClipSize = -1;
            DefaultClip = -1;
            Automatic = false;
            Ammo = "none";
            Recoil = 1.5M;
            NumberOfShots = 1;
            Cone = 0.01M;
            Delay = 0.08M;

            SoundFile = "weapons/pistol/pistol_fire2.wav";
            TracerFrequency = 1;
            Force = 1;

        }
    }
}
