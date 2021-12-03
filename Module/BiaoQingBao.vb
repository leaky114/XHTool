Module BiaoQingBao

    Private biaoqingbao As String() = {"", "(´⊙ω⊙`)！", "ʕ⊙ᴥ⊙ʔ", "╰(◕﹏◕)つ", "ʕ ͡°̲ (oo) ͡°̲ ʔ", "୧༼◔益◔╭∩╮༽", "╭∩╮໒(✪ਊ✪)७╭∩╮", "︻╦̵̵͇̿̿̿̿══╤─", _
                                       "(▀̿ ̿ -▀̿ ̿ )つ├┬┴┬┴", "ε=(･д･｀*)ﾊｧ…", "(:ㄏ■ Д ■ :)ㄏ", "(>﹏<。)～呜呜呜……", "w(@。@;)w", "óÔÔò ʕ·͡ᴥ·ʔ óÔÔò", _
 "ˋのˊ I LǒvのYoひ" & vbCrLf & " ˊˋ ㄖ你爱我 =__我爱你〆 " & vbCrLf & "╭~~~╮ ╭ ﹌╮" & vbCrLf & "(=^.^=) (o.o)" & vbCrLf & "(~)ǒ(~) (~)ǒ(~) 石头--剪子--布~你输了~罚你爱我一辈子!~~~ ", _
 " |||||||||||||" & vbCrLf & "╭| ━ ━ |╮" & vbCrLf & "╰| • • |╯找女朋友中……………………" & vbCrLf & " ╰╭╮-╭╮╯"}

    Public Function GetBiaoQing() As String
        Dim strlength As Integer
        Dim i As Integer
        strlength = biaoqingbao.Length
        i = Math.Round(Rnd() * strlength)

        GetBiaoQing = vbCrLf & vbCrLf & vbCrLf & biaoqingbao(i)

    End Function

End Module