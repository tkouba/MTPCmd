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

## Information
Information about connected MTP device

Example:
```
mtpcmd info
```

## Directory listing
Listing of directory of connected MTP device

Example: List of Download directory of "internal shared storage"
```
mtpcmd dir "Internal shared storage/Download"
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

### Detailed command help

```
mtpcmd help <verb>
```

# License
[MIT](LICENSE.md)

