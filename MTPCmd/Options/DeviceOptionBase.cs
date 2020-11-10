using CommandLine;
using System;

namespace MTPCmd.Options
{
    class DeviceOptionBase
    {
        [Option('m', "manufacturer")]
        public string Manufacturer { get; set; }
        [Option('n', "friendly-name")]
        public string FriendlyName { get; set; }
    }
}
