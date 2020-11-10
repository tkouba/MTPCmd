using CommandLine;
using System;

namespace MTPCmd.Options
{
    [Verb("get", HelpText = "Get/download file device to PC")]
    class GetOption : DeviceOptionBase
    {
        [Value(0, Required = true, HelpText = "Source file name (remote file)")]
        public string Source { get; set; }
        [Value(1, Required = true, HelpText = "Destination file name (local file)")]
        public string Destination { get; set; }
    }
}
