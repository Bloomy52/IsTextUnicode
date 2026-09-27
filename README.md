# IsUnicodeText?
Detects text encoding with the confidence of Windows and the accuracy of a coin toss.

## Why Exactly?
Have you ever heard of `Bush hid the facts`? Well, TLDR, it was a bug found in the old Windows Notepad in Windows NT 3.5 up to Windows Vista caused by a function named `IsTextUnicode`. This is a function with multiple different parts, but the main issue was how it used statistical heuristics to determine whether a file was Unicode/UTF-16 or ASCII/ANSI by requesting `IS_TEXT_UNICODE_STATISTICS` (which still exists in Windows). `IsUnicodeText` replicates the original functionality of the `IS_TEXT_UNICODE_STATISTICS` functionality in Visual Basic using the .NET Framework because it's better than C++ and you know it.

## How does this work?
Well, `IS_TEXT_UNICODE_STATISTICS` used a trick where it split hex values into a high-byte stream and a low-byte stream. It then converted the hex values into decimal and did some fancy math and ended up with two numbers that get compared to where `IS_TEXT_UNICODE_STATISTICS` returned true if the total changes of all of the low bytes was greater than the total changes of the high bytes multiplied by three. 

This faithful recreation takes an ASCII input, converts it to bytes, and then implements the separation of the bytes into high-byte streams and low-byte streams. The function finds the absolute value of the changes from the previous byte and the current byte, sums them together and then decides whether the text is `Unicode` or `ANSI` based on whether the total changes of the low bytes is greater than the total changes of the high bytes times three. For those who like to visualize it in math notation, here it is below.

1. Find the absolute value of the changes: $|\text{bytes}_{\text{previous}} - \text{bytes}_{\text{current}}| = \Delta_{i}$
2. Sum the total changes for the byte stream: $\Delta_1 + \Delta_2 + ... + \Delta_n$
3. Compare the summed changes for each stream and decide whether the text is `Unicode` or `ANSI`:\
Unicode Encoded if: $\sum_{i=1}^n \Delta_{i_{\text{ low-bytes}}} \gt \left(\sum_{i=1}^n \Delta_{i_{\text{ high-bytes}}} \right) * 3$\
ANSI Encoded if: &emsp; $\sum_{i=1}^n \Delta_{i_{\text{ low-bytes}}} \leq \left(\sum_{i=1}^n \Delta_{i_{\text{ high-bytes}}} \right) * 3$


## Using the Software
> [!NOTE]
> This software was tested using Windows 11 and is built for the .NET Framework. This software has not been tested on other devices. 

### Downloading from GitHub Releases (Recommended)
You can download the software from the latest [GitHub Release](https://github.com/Bloomy52/IsUnicodeText/releases/latest). Then you can run it by double-clicking on the `IsUnicodeText.exe` file. 

You can verify the attestation by using the GitHub CLI and entering the following command from your working directory:
```bash
gh attestation verify IsUnicodeText.exe --repo Bloomy52/IsUnicodeText
```

### Building from Source
If you really want to build this from source, you can do so with the following instructions.

You will need `Git`. You can download it via `winget` using the following command:
```powershell
winget install Git.Git --silent
```
Then, make sure you have the `.NET desktop build tools` for Visual Studio 2026. You can download them here https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2026. `IsUnicodeText` targets v4.7.2 of the .NET Framework.

1. Clone the repo
```bash
git clone https://github.com/Bloomy52/IsUnicodeText.git
```
2. Search for "Developer Command Prompt for VS" and press Enter.
3. `cd` to the directory where you cloned the repo.
4. Then run the following command:
```bat
msbuild IsUnicodeText/IsUnicodeText.vbproj /restore /m /p:Configuration=Release /p:Platform=AnyCPU
```
5. Then you can navigate to the `\bin\Release` directory and double click on the app there via File Explorer or you can invoke it in the terminal like so:
```bat
IsUnicodeText\bin\Release\IsUnicodeText.exe 
```


## What about that C file?
If you didn't notice, there is a C file named `test_unicode.c` in the repo. You can test the actual `IsTextUnicode` function found in the Win32 API. To do this, you can do it one of two ways.

### 1. Downloading the Executable from GitHub Releases
You can download the EXE from the latest [GitHub Release](https://github.com/Bloomy52/IsUnicodeText/releases/latest). To test it out, please use the following command from the directory where the file was downloaded in the Command Prompt (cmd.exe):
```bat
test_unicode.exe "bush hid the facts"
:: you can enter any phrase you want as long as it is in quotes
```
And you should get the following response:
```text
Command-line text (18 bytes)
  Statistics only: TRUE, flags = 0x0002
  All tests:       TRUE, flags = 0x0002
```
You can verify the attestation by using the GitHub CLI and entering the following command from your working directory:
```bash
gh attestation verify test_unicode.exe --repo Bloomy52/IsUnicodeText
```

### 2. Building from Source
You can also build from source if you so desire, but this is only recommended for users who already have the `MSVC` C compiler installed, specifically `cl`. If you don't have `MSVC`, then I recommend that you just download the EXE.

1. Clone the repo
```bash
git clone https://github.com/Bloomy52/IsUnicodeText.git
```
2. Search for "Developer Command Prompt for VS" and press Enter.
3. `cd` to the directory where you cloned the repo.
4. Then use the following command to compile the C file.
```bat
cl /W4 test_unicode.c /link Advapi32.lib
```
5. Then you can invoke it in the terminal like so:
```bat
test_unicode.exe "bush hid the facts"
:: you can enter any phrase you want as long as it is in quotes
```
And you should get the following response:
```text
Command-line text (18 bytes)
  Statistics only: TRUE, flags = 0x0002
  All tests:       TRUE, flags = 0x0002
```

## Contributing
Contributions are welcome! If you find a bug, notice something inaccurate, or have a small improvement to suggest, feel free to open an issue or submit a pull request.

Please keep changes focused on the purpose of the project. For larger changes, opening an issue first is appreciated.

## License
This project is licensed under the MIT License. See the LICENSE file for more details: [LICENSE.txt](LICENSE.txt)