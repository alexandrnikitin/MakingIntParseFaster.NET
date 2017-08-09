0:000> !U /d 00007ff838540900
Normal JIT generated code
MakingIntParseFaster.V5.FasterInt.ParseInt32Fast(System.String, System.Globalization.NumberFormatInfo)
Begin 00007ff838540900, size 1a3

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 17:
>>> 00007ff8`38540900 4156            push    r14
00007ff8`38540902 57              push    rdi
00007ff8`38540903 56              push    rsi
00007ff8`38540904 55              push    rbp
00007ff8`38540905 53              push    rbx
00007ff8`38540906 4883ec30        sub     rsp,30h
00007ff8`3854090a 33c0            xor     eax,eax
00007ff8`3854090c 4889442428      mov     qword ptr [rsp+28h],rax
00007ff8`38540911 4889442420      mov     qword ptr [rsp+20h],rax
00007ff8`38540916 488bf2          mov     rsi,rdx
00007ff8`38540919 4885c9          test    rcx,rcx
00007ff8`3854091c 0f840e010000    je      00007ff8`38540a30

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 18:
00007ff8`38540922 33ff            xor     edi,edi

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 19:
00007ff8`38540924 33db            xor     ebx,ebx
00007ff8`38540926 48894c2428      mov     qword ptr [rsp+28h],rcx

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 21:
00007ff8`3854092b 488be9          mov     rbp,rcx
00007ff8`3854092e 4885ed          test    rbp,rbp
00007ff8`38540931 7404            je      00007ff8`38540937
00007ff8`38540933 4883c50c        add     rbp,0Ch

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 23:
00007ff8`38540937 48896c2420      mov     qword ptr [rsp+20h],rbp

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 24:
00007ff8`3854093c 8b5108          mov     edx,dword ptr [rcx+8]
00007ff8`3854093f 4863d2          movsxd  rdx,edx
00007ff8`38540942 4c8d745500      lea     r14,[rbp+rdx*2]

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 27:
00007ff8`38540947 488b542420      mov     rdx,qword ptr [rsp+20h]
00007ff8`3854094c 0fb712          movzx   edx,word ptr [rdx]
00007ff8`3854094f 83c2d0          add     edx,0FFFFFFD0h

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 28:
00007ff8`38540952 83fa09          cmp     edx,9
00007ff8`38540955 771a            ja      00007ff8`38540971
00007ff8`38540957 85db            test    ebx,ebx
00007ff8`38540959 7c16            jl      00007ff8`38540971

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 30:
00007ff8`3854095b 8d0c9b          lea     ecx,[rbx+rbx*4]
00007ff8`3854095e 8d1c4a          lea     ebx,[rdx+rcx*2]

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 31:
00007ff8`38540961 488b542420      mov     rdx,qword ptr [rsp+20h]
00007ff8`38540966 4883c202        add     rdx,2
00007ff8`3854096a 4889542420      mov     qword ptr [rsp+20h],rdx
00007ff8`3854096f ebd6            jmp     00007ff8`38540947

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 35:
00007ff8`38540971 488b542420      mov     rdx,qword ptr [rsp+20h]
00007ff8`38540976 493bd6          cmp     rdx,r14
00007ff8`38540979 7456            je      00007ff8`385409d1

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 38:
00007ff8`3854097b 488b542420      mov     rdx,qword ptr [rsp+20h]
00007ff8`38540980 483bd5          cmp     rdx,rbp
00007ff8`38540983 7535            jne     00007ff8`385409ba

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 40:
00007ff8`38540985 488b4c2420      mov     rcx,qword ptr [rsp+20h]
00007ff8`3854098a 488b5628        mov     rdx,qword ptr [rsi+28h]
00007ff8`3854098e e83df7ffff      call    00007ff8`385400d0 (MakingIntParseFaster.V5.FasterInt.MatchChars(Char*, System.String), mdToken: 0000000006000048)

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 41:
00007ff8`38540993 4885c0          test    rax,rax
00007ff8`38540996 740c            je      00007ff8`385409a4

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 43:
00007ff8`38540998 bf01000000      mov     edi,1

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 44:
00007ff8`3854099d 4889442420      mov     qword ptr [rsp+20h],rax
00007ff8`385409a2 eba3            jmp     00007ff8`38540947

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 48:
00007ff8`385409a4 488d4c2420      lea     rcx,[rsp+20h]
00007ff8`385409a9 498bd6          mov     rdx,r14
00007ff8`385409ac 4c8bc6          mov     r8,rsi
00007ff8`385409af e8fcf6ffff      call    00007ff8`385400b0 (MakingIntParseFaster.V5.FasterInt.HandleLeadingSymbols(Char* ByRef, Char*, System.Globalization.NumberFormatInfo), mdToken: 0000000006000044)
00007ff8`385409b4 400fb6f8        movzx   edi,al
00007ff8`385409b8 eb8d            jmp     00007ff8`38540947

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 53:
00007ff8`385409ba 488b4c2420      mov     rcx,qword ptr [rsp+20h]
00007ff8`385409bf 493bce          cmp     rcx,r14
00007ff8`385409c2 730d            jae     00007ff8`385409d1

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 55:
00007ff8`385409c4 488b4c2420      mov     rcx,qword ptr [rsp+20h]
00007ff8`385409c9 498bd6          mov     rdx,r14
00007ff8`385409cc e8f7f6ffff      call    00007ff8`385400c8 (MakingIntParseFaster.V5.FasterInt.HandleTrailingWhite(Char*, Char*), mdToken: 0000000006000047)

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 59:
00007ff8`385409d1 33c0            xor     eax,eax
00007ff8`385409d3 4889442428      mov     qword ptr [rsp+28h],rax
00007ff8`385409d8 85ff            test    edi,edi
00007ff8`385409da 7417            je      00007ff8`385409f3

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 61:
00007ff8`385409dc f7db            neg     ebx

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 62:
00007ff8`385409de 85db            test    ebx,ebx
00007ff8`385409e0 0f8f83000000    jg      00007ff8`38540a69

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 69:
00007ff8`385409e6 8bc3            mov     eax,ebx
00007ff8`385409e8 4883c430        add     rsp,30h
00007ff8`385409ec 5b              pop     rbx
00007ff8`385409ed 5d              pop     rbp
00007ff8`385409ee 5e              pop     rsi
00007ff8`385409ef 5f              pop     rdi
00007ff8`385409f0 415e            pop     r14
00007ff8`385409f2 c3              ret

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 66:
00007ff8`385409f3 85db            test    ebx,ebx
00007ff8`385409f5 7def            jge     00007ff8`385409e6
00007ff8`385409f7 48b9f0691087f87f0000 mov rcx,offset mscorlib_ni+0x7169f0 (00007ff8`871069f0) (MT: System.OverflowException)
00007ff8`38540a01 e81a1b5f5f      call    clr!JIT_TrialAllocSFastMP_InlineGetThread (00007ff8`97b32520)
00007ff8`38540a06 488bf0          mov     rsi,rax
00007ff8`38540a09 b947000000      mov     ecx,47h
00007ff8`38540a0e 48baf8404238f87f0000 mov rdx,7FF8384240F8h
00007ff8`38540a18 e80398795f      call    clr!JIT_StrCns (00007ff8`97cda220)
00007ff8`38540a1d 488bd0          mov     rdx,rax
00007ff8`38540a20 488bce          mov     rcx,rsi
00007ff8`38540a23 e84853254f      call    mscorlib_ni+0xda5d70 (00007ff8`87795d70) (System.OverflowException..ctor(System.String), mdToken: 00000000060010a9)
00007ff8`38540a28 488bce          mov     rcx,rsi
00007ff8`38540a2b e810e6735f      call    clr!IL_Throw (00007ff8`97c7f040)

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 17:
00007ff8`38540a30 48b9783a1087f87f0000 mov rcx,offset mscorlib_ni+0x713a78 (00007ff8`87103a78) (MT: System.ArgumentNullException)
00007ff8`38540a3a e8e11a5f5f      call    clr!JIT_TrialAllocSFastMP_InlineGetThread (00007ff8`97b32520)
00007ff8`38540a3f 488bf0          mov     rsi,rax
00007ff8`38540a42 b977000000      mov     ecx,77h
00007ff8`38540a47 48baf8404238f87f0000 mov rdx,7FF8384240F8h
00007ff8`38540a51 e8ca97795f      call    clr!JIT_StrCns (00007ff8`97cda220)
00007ff8`38540a56 488bd0          mov     rdx,rax
00007ff8`38540a59 488bce          mov     rcx,rsi
00007ff8`38540a5c e8f75b8e4e      call    mscorlib_ni+0x436658 (00007ff8`86e26658) (System.ArgumentNullException..ctor(System.String), mdToken: 0000000006000977)
00007ff8`38540a61 488bce          mov     rcx,rsi
00007ff8`38540a64 e8d7e5735f      call    clr!IL_Throw (00007ff8`97c7f040)

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 62:
00007ff8`38540a69 48b9f0691087f87f0000 mov rcx,offset mscorlib_ni+0x7169f0 (00007ff8`871069f0) (MT: System.OverflowException)
00007ff8`38540a73 e8a81a5f5f      call    clr!JIT_TrialAllocSFastMP_InlineGetThread (00007ff8`97b32520)
00007ff8`38540a78 488bf0          mov     rsi,rax
00007ff8`38540a7b b947000000      mov     ecx,47h
00007ff8`38540a80 48baf8404238f87f0000 mov rdx,7FF8384240F8h
00007ff8`38540a8a e89197795f      call    clr!JIT_StrCns (00007ff8`97cda220)
00007ff8`38540a8f 488bd0          mov     rdx,rax
00007ff8`38540a92 488bce          mov     rcx,rsi
00007ff8`38540a95 e8d652254f      call    mscorlib_ni+0xda5d70 (00007ff8`87795d70) (System.OverflowException..ctor(System.String), mdToken: 00000000060010a9)

C:\Projects\my\MakingIntParseFaster.NET\MakingIntParseFaster\V5\FasterInt.cs @ 17:
00007ff8`38540a9a 488bce          mov     rcx,rsi
00007ff8`38540a9d e89ee5735f      call    clr!IL_Throw (00007ff8`97c7f040)
00007ff8`38540aa2 cc              int     3
