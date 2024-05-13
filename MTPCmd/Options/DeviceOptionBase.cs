using CommandLine;
using System;

namespace MTPCmd.Options
{
    class DeviceOptionBase
    {
        [Option('m', "manufacturer", HelpText = "Filter device by manufacturer.")]
        public string Manufacturer { get; set; }
        [Option('n', "friendly-name", HelpText = "Filter device by friendly name.")]
        public string FriendlyName { get; set; }
    }
}
