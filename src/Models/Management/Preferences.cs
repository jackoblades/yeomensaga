using System;

namespace yeomensaga.Models.Management
{
    [Flags]
    public enum Preferences
    {
        None  = 0x0000,
        Vsync = 0x0001,
    }
}
