Imports System.IO.Ports
Imports System.Management
'Imports System.ComponentModel.Component

Public Class Form1
    Dim Ports As String() ' список портов в системе

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        scan_com_port()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        scan_com_port()
    End Sub

    '--------------------------------------------------------------
    ' Запрос списка СОМ портов в системе
    '--------------------------------------------------------------
    Private Sub GetAllSerialPortsName()
        Try
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity")
            For Each queryObj As ManagementObject In searcher.Get()
                If InStr(queryObj("Caption"), "(COM") > 0 Then
                    Log(queryObj("Caption"))
                End If
            Next
        Catch err As ManagementException
            MsgBox(err.Message)
        End Try
    End Sub

    '--------------------------------------------------------------
    ' Вывод СОМ портов.
    '--------------------------------------------------------------
    Sub scan_com_port()
        Ports = SerialPort.GetPortNames

        Dim port As String
        Log("=========================================")

        For Each port In Ports
            Log(port)
        Next port

        Log("----------- Подробно: -------------------")

        GetAllSerialPortsName()

        Log("=========================================")
    End Sub


    '--------------------------------------------------------------
    ' Вывод строки в окно лога.
    '--------------------------------------------------------------
    Sub Log(ByVal s As String)
        tbLog.AppendText(s + vbCrLf)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tbLog.Clear()
    End Sub
End Class
