using CommandLine;
using System;

namespace MTPCmd.Options
{
    [Verb("list", HelpText = "Display list of MTP devices.")]
    class ListOption
    {
        [Option("detailed", HelpText = "Include details (like S/N) in device list.")]
        public bool Detailed { get; set; }
    }
}
