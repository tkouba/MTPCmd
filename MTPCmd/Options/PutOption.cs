using CommandLine;
using System;

namespace MTPCmd.Options
{
    [Verb("put", HelpText = "Put/upload file from PC to device.")]
    class PutOption : DeviceOptionBase
    {
        [Value(0, Required = true, HelpText = "Source file name (local file).")]
        public string Source { get; set; }
        [Value(1, Required = true, HelpText = "Destination file name (remote file).")]
        public string Destination { get; set; }
    }
}
