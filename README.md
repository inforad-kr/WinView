# WinView

WinView is a desktop image viewer designed for [XPACS](https://iberisoft.github.io/XPacs.doc) and some other backend platforms.

## Prerequisites

* [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48) (already installed in almost any Windows PC)

## Usage

The application can work with local files and files stored in [Simple Storage](https://github.com/iberisoft/x-view-simple-storage),
depending on the value of the `StorageType` setting.

### Local Files

If `StorageType` is set to `local`, the application loads files from the folder specified in the command line.

### Simple Storage

If `StorageType` is set to `simple`, the application loads files from the folder specified in the command line in the form `foldername=`, followed by the folder name.

The service URL is defined in the `StorageUrl` setting.
