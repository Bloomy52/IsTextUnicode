#include <windows.h>
#include <stdio.h>
#include <string.h>

static void test(const char *name, const void *data, int size)
{
    int flags = IS_TEXT_UNICODE_STATISTICS;
    BOOL result = IsTextUnicode(data, size, &flags);

    printf("%s (%d bytes)\n", name, size);
    printf("  Statistics only: %s, flags = 0x%04X\n",
           result ? "TRUE" : "FALSE", (unsigned int)flags);

    flags = IS_TEXT_UNICODE_UNICODE_MASK |
            IS_TEXT_UNICODE_REVERSE_MASK |
            IS_TEXT_UNICODE_NOT_UNICODE_MASK |
            IS_TEXT_UNICODE_NOT_ASCII_MASK;

    result = IsTextUnicode(data, size, &flags);

    printf("  All tests:       %s, flags = 0x%04X\n\n",
           result ? "TRUE" : "FALSE", (unsigned int)flags);
}

int main(int argc, char **argv)
{
    if (argc > 1)
    {
        test("Command-line text", argv[1], (int)strlen(argv[1]));
        return 0;
    }

    const char ascii[] = "Hello, world!";
    const char troublesome[] = "bush hid the facts";
    const WCHAR utf16[] = L"Hello, world!";

    /* Exclude terminating NULs from every test. */
    test("ASCII", ascii, (int)(sizeof(ascii) - sizeof(ascii[0])));
    test("Historical example", troublesome,
         (int)(sizeof(troublesome) - sizeof(troublesome[0])));
    test("UTF-16 LE", utf16,
         (int)(sizeof(utf16) - sizeof(utf16[0])));

    return 0;
}    