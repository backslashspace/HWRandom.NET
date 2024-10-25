; returns 1 if RDRAND was successful (CF=1), 0 if RDRAND failed (CF=0).
; in-pointer is used for value store

; rcx is in pointer
; rax is return value

.code

; ====== 64 bit ======

InternalReadRandom64 PROC
    RDRAND rax              ; put random in rax
    jc Success              ; if carry flag is 1 -> success
    xor rax, rax            ; failed, set rax to 0
    ret
Success:
    mov [rcx], rax          ; put value of rax into mem location pointed by RCX
    mov rax, 1              ; set rax to 1 (success)
    ret
InternalReadRandom64 ENDP

; ====== 32 bit ======

InternalReadRandom32 PROC
    RDRAND eax
    jc Success
    xor eax, eax
    ret
Success:
    mov [rcx], eax 
    mov eax, 1
    ret
InternalReadRandom32 ENDP

; ====== 16 bit ======

InternalReadRandom16 PROC
    RDRAND ax
    jc Success
    xor ax, ax
    ret
Success:
    mov [rcx], ax 
    mov ax, 1
    ret
InternalReadRandom16 ENDP

; ====== 8 bit ======

InternalReadRandom8 PROC
    RDRAND ax
    jc Success
    xor ax, ax
    ret
Success:
    mov [rcx], ah 
    mov ax, 1
    ret
InternalReadRandom8 ENDP

END