using CommandLine;
using System;

namespace MTPCmd.Options
{
    [Verb("dir")]
    class DirOption : DeviceOptionBase
    {
        [Value(0, Required = true, HelpText = "Path")]
        public string Path { get; set; }
    }
}
