using CommandLine;
using System;

namespace MTPCmd.Options
{
    [Verb("info", HelpText = "Show information about connected device.")]
    class InfoOption : DeviceOptionBase
    { }
}
