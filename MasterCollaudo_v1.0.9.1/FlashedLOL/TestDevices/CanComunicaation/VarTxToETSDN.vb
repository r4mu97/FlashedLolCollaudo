Public Class VarTxToETSDN
    Dim setRL1, setRL2, setRL3, setAllRl, setSupplyRl1, setSupplyRl2, setSupplyRl3, setIP1, setIP2, setIN1, setIN2, set10V, Set5V As Byte


    Public Sub SetStateRL1(stato)
        setRL1 = stato
    End Sub

    Public Sub SetStateRL2(stato)
        setRL2 = stato
    End Sub

    Public Sub SetStateRL3(stato)
        setRL3 = stato
    End Sub

    Public Sub SetStateAllRl(stato)
        setRL1 = stato
        setRL2 = stato
        setRL3 = stato
    End Sub

    Public Sub SetPwrRL1(stato)
        setSupplyRl1 = stato
    End Sub

    Public Sub SetPwrRL2(stato)
        setSupplyRl2 = stato
    End Sub

    Public Sub SetPwrRL3(stato)
        setSupplyRl3 = stato
    End Sub
    Public Sub SetAllPwrRL(stato)
        setSupplyRl1 = stato
        setSupplyRl2 = stato
        setSupplyRl3 = stato
    End Sub
    Public Sub SetState10V(stato)
        set10V = stato
    End Sub

    Public Sub SetState5V(stato)
        Set5V = stato
    End Sub
    Public Sub SetStateIP1(stato)
        setIP1 = stato
    End Sub

    Public Sub SetStateIP2(stato)
        setIP2 = stato
    End Sub

    Public Sub SetStateIN1(stato)
        setIN1 = stato
    End Sub

    Public Sub SetStateIN2(stato)
        setIN2 = stato
    End Sub


    Function MsgComposer() As UShort
        Dim VarTempComposer As UShort

        VarTempComposer = 0
        VarTempComposer = VarTempComposer + setRL1
        VarTempComposer = VarTempComposer + (CType(setRL2, UShort) << 1)
        VarTempComposer = VarTempComposer + (CType(setRL3, UShort) << 2)
        VarTempComposer = VarTempComposer + (CType(setSupplyRl1, UShort) << 3)
        VarTempComposer = VarTempComposer + (CType(setSupplyRl2, UShort) << 4)
        VarTempComposer = VarTempComposer + (CType(setSupplyRl3, UShort) << 5)
        VarTempComposer = VarTempComposer + (CType(set10V, UShort) << 6)
        VarTempComposer = VarTempComposer + (CType(Set5V, UShort) << 7)


        VarTempComposer = VarTempComposer + (CType(setIP1, UShort) << 8)
        VarTempComposer = VarTempComposer + (CType(setIP2, UShort) << 9)
        VarTempComposer = VarTempComposer + (CType(setIN1, UShort) << 10)
        VarTempComposer = VarTempComposer + (CType(setIN2, UShort) << 11)

        Return VarTempComposer
    End Function

End Class