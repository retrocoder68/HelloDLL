#include "pch.h"

extern "C" {
    __declspec(dllexport)
        void HelloFromC(char* buf, int len)
    {
        char text[] = "Hello, from C function in DLL\n\0";
        const int text_len = 31;
        if (buf == nullptr) return;
        if (len >= text_len) {
            for (int i = 0; i < text_len; i++) {
                buf[i] = text[i];
            }
        }
        else if (len > 0) {
            buf[0] = '\0';
        }
    }
}
