; returns 1 if RDSEED was successful (CF=1), 0 if RDSEED failed (CF=0).
; in-pointer is used for value store

; rcx is in pointer
; rax is return value

.code

; ====== 64 bit ======

InternalReadSeed64 PROC
    RDSEED rax              ; put random in rax
    jc Success              ; if carry flag is 1 -> success
    xor rax, rax            ; failed, set rax to 0
    ret
Success:
    mov [rcx], rax          ; put value of rax into mem location pointed by RCX
    mov rax, 1              ; set rax to 1 (success)
    ret
InternalReadSeed64 ENDP

; ====== 32 bit ======

InternalReadSeed32 PROC
    RDSEED eax
    jc Success
    xor eax, eax
    ret
Success:
    mov [rcx], eax 
    mov eax, 1
    ret
InternalReadSeed32 ENDP

; ====== 16 bit ======

InternalReadSeed16 PROC
    RDSEED ax
    jc Success
    xor ax, ax
    ret
Success:
    mov [rcx], ax 
    mov ax, 1
    ret
InternalReadSeed16 ENDP

; ====== 8 bit ======

InternalReadSeed8 PROC
    RDSEED ax
    jc Success
    xor ax, ax
    ret
Success:
    mov [rcx], ah 
    mov ax, 1
    ret
InternalReadSeed8 ENDP

END