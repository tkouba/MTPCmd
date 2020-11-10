using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTPCmd.Options
{
    [Verb("list", HelpText = "List of MTP devices")]
    class ListOption
    {
        [Option("detailed", HelpText = "Include details (like S/N) in device list.")]
        public bool Detailed { get; set; }
    }
}
