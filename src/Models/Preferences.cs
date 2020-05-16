using System;

namespace yeomensaga.Models
{
    [Flags]
    public enum Preferences
    {
        None  = 0x0000,
        Vsync = 0x0001,
    }
}
