using CommandLine;
using System;

namespace MTPCmd.Options
{
    [Verb("dir", HelpText = "Device directory listing.")]
    class DirOption : DeviceOptionBase
    {
        [Value(0, Required = true, HelpText = "Path (remote device).")]
        public string Path { get; set; }
    }
}
