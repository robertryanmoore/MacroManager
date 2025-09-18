using System;
using System.Runtime.InteropServices;

public class InputSender
{
    // C# representation of the Windows INPUT structure
    [StructLayout(LayoutKind.Sequential)]
    private struct INPUT
    {
        public int type;
        public KEYBDINPUT ki;
    }

    // C# representation of the Windows KEYBDINPUT structure
    [StructLayout(LayoutKind.Sequential)]
    private struct KEYBDINPUT
    {
        public short wVk; // Virtual-key code
        public short wScan;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    // INPUT type flags
    private const int INPUT_KEYBOARD = 1;

    // KEYBDINPUT flags
    private const int KEYEVENTF_KEYDOWN = 0x0000;
    private const int KEYEVENTF_KEYUP = 0x0002;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    // Other declarations to get the scan code, if needed
    [DllImport("user32.dll")]
    private static extern uint MapVirtualKey(uint uCode, uint uMapType);

    private const uint MAPVK_VK_TO_VSC = 0x00;

    /// <summary>
    /// Sends a virtual keypress (key down and key up) to the system's input stream.
    /// </summary>
    /// <param name="virtualKeyCode">The virtual-key code of the key to send.</param>
    public static void SendKey(short virtualKeyCode)
    {
        // Set up the KEYDOWN event
        INPUT[] inputs = new INPUT[2];
        inputs[0].type = INPUT_KEYBOARD;
        inputs[0].ki.wVk = virtualKeyCode;
        inputs[0].ki.dwFlags = KEYEVENTF_KEYDOWN;
        inputs[0].ki.wScan = (short)MapVirtualKey((uint)virtualKeyCode, MAPVK_VK_TO_VSC);

        // Set up the KEYUP event
        inputs[1].type = INPUT_KEYBOARD;
        inputs[1].ki.wVk = virtualKeyCode;
        inputs[1].ki.dwFlags = KEYEVENTF_KEYUP;
        inputs[1].ki.wScan = (short)MapVirtualKey((uint)virtualKeyCode, MAPVK_VK_TO_VSC);

        // Send the input events
        SendInput(2, inputs, Marshal.SizeOf(typeof(INPUT)));
    }
}