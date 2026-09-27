# IsTextUnicode
Detects text encoding with the confidence of Windows and the accuracy of a coin toss.

## Why Exactly?
Have you ever heard of `Bush hid the facts`? Well, TLDR, it was a bug found in the old Windows Notepad in Windows NT 3.5 up to Windows Vista caused by a function named `IsTextUnicode`. This is a function with multiple different parts, but the main issue was how it used statistical heuristics to determine whether a file was Unicode/UTF-16 or ASCII/ANSI by requesting `IS_TEXT_UNICODE_STATISTICS` (which still exists in Windows). This Windows Forms App replicates the original functionality of the app in Visual Basic using the .NET Framework because its better than C++ and you know it.

## How does this work?
Well, `IS_TEXT_UNICODE_STATISTICS` used a trick where it split hex values into a high-byte stream and a low-byte stream. It then converted the hex values into decimal and did some fancy math and ended up with two numbers that get compared to where `IS_TEXT_UNICODE_STATISTICS` returned true if the total changes of all of the low bytes was greater than the total changes of the high bytes multiplied by three. 

## Using the Software
> [!NOTE]
> This software was tested using Windows 11 and is built for the .NET Framework. This software has not been tested on other devices. 

### Downloading from GitHub Releases
You can download the software from the latest GitHub Release. You can verify the attestation by using the GitHub CLI and entering the following command from your working directory:
```bash
gh attestation verify IsUnicodeText.exe --repo Bloomy52/IsUnicodeText
```

### Building from Source
If you really want to build this from source, you can do so with the following instructions.

You will need `Git`. You can download it via `winget` using the following command:
```powershell
winget install Git.Git --silent
```
Then, make sure you have the `.NET desktop build tools` for Visual Studio 2026. You can download them here https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2026.

1. Clone the repo and `cd` into it
```bash
git clone https://github.com/Bloomy52/IsTextUnicode.git
```
2. Search for "Developer Command Prompt for VS" and click enter.
3. `cd` to the directory where you cloned the repo.
4. Then run the following command:
```bat
msbuild IsTextUnicode/IsTextUnicode.vbproj /restore /m /p:Configuration=Release /p:Platform=AnyCPU
```
5. Then you can navigate to the `\bin\Release` directory and double click on the app there via File Explorer or you can invoke it in the terminal like so:
```bat
.\IsTextUnicode\bin\Release\IsTextUnicode.exe 
```

