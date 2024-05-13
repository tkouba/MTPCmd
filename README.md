# MTPCmd

[![License](https://img.shields.io/github/license/tkouba/MTPCmd)](LICENSE.md)
![Release](https://img.shields.io/github/release/tkouba/MTPCmd.svg)
![Commits since latest release](https://img.shields.io/github/commits-since/tkouba/MTPCmd/latest)
![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/tkouba/MTPCmd/main.yml)

Media device (MTP - Media Transfer Protocol) command line interface

> [!NOTE]
> This is proof of concept (POC) project for MTP command line

## List devices

List connected MTP devices
```
mtpcmd list
```

```console
Friendly Name   Manufacturer            Description
WS50            Zebra Technologies      WS50
XQ-BT52         Sony                    XQ-BT52
MC33            Zebra Technologies      MC33
3 devices found.
```

List connected MTP devices with detailed information
```
mtpcmd list --detailed
```

```console
Friendly Name   Manufacturer            Description             Serial Number                           Model
WS50            Zebra Technologies      WS50                    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX44        WS50
XQ-BT52         Sony                    XQ-BT52                 XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX81        XQ-BT52
MC33            Zebra Technologies      MC33                    XXXXXXXXXXXX57                          MC33
3 devices found.
```


## Information
Information about connected MTP device.

Information about first device
```
mtpcmd info
```

```console
Device Friendly Name is WS50
Device Manufacturer is Zebra Technologies
Device Serial Number is XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX44
Root Directory is \
Drives:
Fixed "\Internal shared storage" free 2,6 GB of 3,6 GB
```

Information about MC33 device
```
mtpcmd info -n MC33
```

```console
Device Friendly Name is MC33
Device Manufacturer is Zebra Technologies
Device Serial Number is XXXXXXXXXXXX57
Root Directory is \
Drives:
Fixed "\Internal shared storage" free 3,2 GB of 8,6 GB
```

## Directory listing
Listing of directory of connected MTP device

Example: List of Download directory of "internal shared storage"
```
mtpcmd dir "Internal shared storage/Download"
```

```console
Device Friendly Name is MC33
Device Manufacturer is Zebra Technologies
Device Serial Number is XXXXXXXXXXXX57

13.03.2024 14:07   <DIR>         Nearby Share
06.11.2020 16:36             657 xxxxxxxxxxxx.key
06.11.2020 16:36             345 xxxxxxxxxxxx.ovpn
06.11.2020 16:36          11 531 xxxxxxxx.ovpn
14.09.2021 12:25          12 581 5105600863.pdf
14.09.2021 12:26         149 223 ZDSPDF_20210914122623.PDF
02.12.2022 12:43      15 773 197 EnterpriseBrowser_signed_3.0.6.0.apk
25.01.2023 14:10      26 236 929 xxxxxxxxxxxxxxxxxxxxxxxxxxxxx.apk
25.01.2023 22:15      26 236 929 xxxxxxxxxxxxxxxxxxxxxxxxxxxxx.apk
25.01.2023 22:15      26 236 929 xxxxxxxxxxxxxxxxxxxxxxxxxxxxx.apk
23.10.2023 22:56      55 138 635 anyconnect-5-0-05042.apk
 10 File(s)  149 796 956 Bytes
  1 Dir(s)
```



## Copying files
Copy single file from/to connected MTP device

### Copy file to device

```
mtpcmd put file.txt "Internal shared storage/Download/file.txt"
```

### Copy file from device
```
mtpcmd get "Internal shared storage/Download/file.txt" file2.txt
```

## Help
Show available verbs - commands

```
mtpcmd help
```

```console
mtpcmd 1.0.0
Copyright (C) 2024 mtpcmd

  list       Display list of MTP devices.

  info       Show information about connected device.

  dir        Device directory listing.

  put        Put/upload file from PC to device.

  get        Get/download file device to PC.

  help       Display more information on a specific command.

  version    Display version information.
```

### Detailed command help

```
mtpcmd help <verb>
```

Examples

```
mtpcmd help list
```

```console
mtpcmd 1.0.0
Copyright (C) 2024 mtpcmd

  --detailed    Include details (like S/N) in device list.

  --help        Display this help screen.

  --version     Display version information.
```

```
mtpcmd help info
```

```console
mtpcmd 1.0.0
Copyright (C) 2024 mtpcmd

  -m, --manufacturer     Filter device by manufacturer. 

  -n, --friendly-name    Filter device by friendy name.

  --help                 Display this help screen.

  --version              Display version information.
```

# License
[MIT](LICENSE.md)

