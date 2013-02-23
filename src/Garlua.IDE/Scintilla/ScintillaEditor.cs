using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Garlua.IDE.Scintilla
{
    /// <summary>
    /// Wrapper voor ScintillaNET Scintilla met custom functies
    /// </summary>
    public class ScintillaEditor : ScintillaNET.Scintilla
    {
        #region Scintilla Constants

        /// <summary>
        /// Constants voor de interface naar de C omgeving
        /// </summary>
        public const int SCI_SETFIRSTVISIBLELINE = 2613;
        public const int SCI_GETFIRSTVISIBLELINE = 2152;
        public const int SCI_SETVIRTUALSPACEOPTIONS = 2596;
        public const int SCI_GETVIRTUALSPACEOPTIONS = 2597;

        #endregion

        /// <summary>
        /// Configure virtual space options
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(VirtualSpaceOption.None)]
        public VirtualSpaceOption VirtualSpace
        {
            get 
            {
                return (VirtualSpaceOption)NativeInterface.SendMessageDirect(SCI_GETVIRTUALSPACEOPTIONS);
            }
            set 
            {
                NativeInterface.SendMessageDirect(SCI_SETVIRTUALSPACEOPTIONS, (int)value, 0);
            }
        }

        /// <summary>
        /// Virtual Namespace settings
        /// </summary>
        public enum VirtualSpaceOption {
            /// <summary>
            /// Geen virtuele ruimte
            /// </summary>
            None = 0,

            /// <summary>
            /// Allow rectangular selection of virtual space
            /// </summary>
            AllowRectangularSelection = 1,

            /// <summary>
            /// Allow cursor in virtual space
            /// </summary>
            AllowCursorMovement = 2,

            /// <summary>
            /// Both rectangular and cursor movement in virtual space
            /// </summary>
            AllowBoth = 3
        };

        /// <summary>
        /// Set or Get the curren visible first line
        /// </summary>
        public int FirstVisibleLine
        {
            get 
            { 
                return (int)NativeInterface.SendMessageDirect(SCI_GETFIRSTVISIBLELINE); 
            }
            set
            {
                NativeInterface.SendMessageDirect(SCI_SETFIRSTVISIBLELINE, value);
            }
        }
    }
}
