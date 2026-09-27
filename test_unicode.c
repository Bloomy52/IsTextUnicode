/*
 * IsTextUnicode
 * Copyright (c) 2026 Louie Bloomberg
 * SPDX-License-Identifier: MIT
 */

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
    if (argc != 2)
    {
        printf("Usage: test_unicode.exe \"text to test\"\n");
        printf("Example: test_unicode.exe \"Bush hid the facts\"\n");
        printf("\nEnclose text in quotes and use ASCII characters.\n");
        return 1;
    }

    test("Command-line text", argv[1], (int)strlen(argv[1]));
    return 0;
}    