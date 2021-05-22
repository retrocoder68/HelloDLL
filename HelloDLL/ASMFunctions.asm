;-----------------------------------------------------------------------------;
; HelloFromAsm - Hello world example in x86-64 assembler                      ;
; Copyright (C) 2021 skywalker <j.karlsson@retrocoder.se>                     ;
;-----------------------------------------------------------------------------;
use64

section .text

global HelloFromAsm
HelloFromAsm:
	push rbp
	mov rbp, rsp

	; Check input buffer pointer != null
	cmp rcx, 0
	jz .exit

	; Check input buffer length
	cmp rdx, 0
	jz .exit
	cmp rdx, text_len
	jl .exit

	xor rax,rax
	mov r8, text
.loop:
	mov r9, [r8, rax]
	mov [rcx, rax], r9
	add rax, 8
	cmp rax, text_len
	jne .loop

.exit:
	mov rsp, rbp
	pop rbp
	ret

section .data
text: ;Text length must be a multiple of 8
db "Hello, from Asm function in DLL", 0x0A, 0x0D
db 0x0,0x0,0x0,0x0,0x0,0x0,0x0
endtext:
text_len equ endtext - text
