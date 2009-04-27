using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Togi.Tools
{
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8,
        Modkeyup = 0x1000,
    }

    public class HandleKeys
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
        IntPtr hWnd, // handle to window
        int id, // hot key identifier
        int Modifiers, // key-modifier options
        int key //virtual-key code
        );

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(KeyModifiers
        modifiers, int keyID);
        public static void RegisterRecordKey(IntPtr hWnd)
        {
            UnregisterHotKey(KeyModifiers.Windows, (int)Keys.Enter);
            RegisterHotKey(hWnd, (int)Keys.Enter, (int)KeyModifiers.Control + (int)KeyModifiers.Alt, (int)Keys.Enter);
        }
    }
}
