using CommandLine;
using MediaDevices;
using MTPCmd.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace MTPCmd
{
    class Program
    {
        static int Main(string[] args)
        {
            Parser parser = new Parser(config =>
            {
                config.CaseSensitive = false;
                config.CaseInsensitiveEnumValues = true;
                config.AutoHelp = true;
                config.HelpWriter = Console.Out;
                config.AutoVersion = true;
            });
            int result = 255;
            try
            {
                result = parser.ParseArguments<ListOption, InfoOption, DirOption, PutOption, GetOption>(args)
                    .MapResult(
                        (ListOption opts) => RunCommand(opts),
                        (InfoOption opts) => RunCommand(opts),
                        (DirOption opts) => RunCommand(opts),
                        (PutOption opts) => RunCommand(opts),
                        (GetOption opts) => RunCommand(opts),
                        errs => ShowErrors(errs));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }

            return result;
        }

        private static int RunCommand(ListOption opts)
        {
            MediaDevice[] devices = MediaDevice.GetDevices().ToArray();
            if (devices.Length > 0)
            {
                if (opts.Detailed)
                    Console.WriteLine("Friendly Name  \tManufacturer        \tDescription         \tSerial Number                      \tModel");
                else
                    Console.WriteLine("Friendly Name  \tManufacturer        \tDescription");
                foreach (MediaDevice device in devices)
                {
                    string friendlyName = device.FriendlyName;
                    string manufacturer = device.Manufacturer;
                    string description = device.Description;
                    if (opts.Detailed)
                    {
                        try
                        {
                            device.Connect();
                            Console.WriteLine($"{friendlyName,-15}\t{manufacturer,-20}\t{description,-20}\t{device.SerialNumber,-35}\t{device.Model}");
                            device.Disconnect();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{friendlyName}: {ex.Message}");
                        }
                        finally
                        {
                            device.Dispose();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{friendlyName,-15}\t{manufacturer,-20}\t{description}");
                    }
                }
            }
            Console.WriteLine("{0} devices found.", devices.Length);
            return 0;
        }

        private static int RunCommand(InfoOption opts)
        {
            using (MediaDevice device = MediaDevice.GetDevices().FirstOrDefault(opts))
            {
                if (device != null)
                {
                    Console.WriteLine($"Device Friendly Name is {device.FriendlyName}");
                    Console.WriteLine($"Device Manufacturer is {device.Manufacturer}");
                    device.Connect();
                    Console.WriteLine($"Device Serial Number is {device.SerialNumber}");
                    var root = device.GetRootDirectory();
                    Console.WriteLine($"Root Directory is {root.FullName}");

                    Console.WriteLine("Drives:");
                    foreach (var drv in device.GetDrives())
                    {
                        Console.WriteLine($"{drv.DriveType} \"{drv.RootDirectory.FullName}\" free {Extensions.SizeSuffix(drv.AvailableFreeSpace)} of {Extensions.SizeSuffix(drv.TotalSize)}");
                    }


                    foreach (var item in device.GetContentLocations(ContentType.Certificate))
                    {
                        Console.WriteLine(item);
                    }

                    device.Disconnect();
                }
                else
                {
                    Console.WriteLine("No device connected.");
                    return 1;
                }
            }
            return 0;
        }

        private static int RunCommand(DirOption opts)
        {
            using (MediaDevice device = MediaDevice.GetDevices().FirstOrDefault(opts))
            {
                if (device != null)
                {
                    Console.WriteLine($"Device Friendly Name is {device.FriendlyName}");
                    Console.WriteLine($"Device Manufacturer is {device.Manufacturer}");
                    device.Connect();
                    Console.WriteLine($"Device Serial Number is {device.SerialNumber}");
                    Console.WriteLine();
                    int fils = 0;
                    int dirs = 0;
                    ulong size = 0;
                    try
                    {
                        foreach (var item in device.EnumerateDirectories(opts.Path))
                        {
                            dirs++;
                            var info = device.GetDirectoryInfo(item);
                            Console.WriteLine($"{info.LastWriteTime:g}   <DIR>         {info.Name}");
                        }

                        foreach (var item in device.EnumerateFiles(opts.Path))
                        {
                            fils++;
                            var info = device.GetFileInfo(item);
                            size += info.Length;
                            Console.WriteLine($"{info.LastWriteTime:g} {info.Length,15:N0} {info.Name}");
                        }

                        Console.WriteLine($"{fils,3} File(s)  {size:N0} Bytes");
                        Console.WriteLine($"{dirs,3} Dir(s)");
                    }
                    catch (System.IO.DirectoryNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    device.Disconnect();
                }
                else
                {
                    Console.WriteLine("No device connected.");
                    return 1;
                }
            }
            return 0;
        }

        private static int RunCommand(PutOption opts)
        {
            using (MediaDevice device = MediaDevice.GetDevices().FirstOrDefault(opts))
            {
                if (device != null)
                {
                    device.Connect();
                    string destDir = Path.GetDirectoryName(opts.Destination);
                    if (!device.DirectoryExists(destDir))
                        device.CreateDirectory(destDir);
                    device.UploadFile(opts.Source, opts.Destination);
                    device.Disconnect();
                }
                else
                {
                    Console.WriteLine("No device connected.");
                    return 1;
                }
            }
            return 0;
        }

        private static int RunCommand(GetOption opts)
        {
            using (MediaDevice device = MediaDevice.GetDevices().FirstOrDefault(opts))
            {
                if (device != null)
                {
                    device.Connect();
                    device.DownloadFile(opts.Source, opts.Destination);
                    device.Disconnect();
                }
                else
                {
                    Console.WriteLine("No device connected.");
                    return 1;
                }
            }
            return 0;
        }

        static int ShowErrors(IEnumerable<Error> errs)
        {
            return 254;
        }

    }
}
