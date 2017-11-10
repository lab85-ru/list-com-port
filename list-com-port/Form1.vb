Imports System.IO.Ports

Public Class Form1
    Dim Ports As String() ' список портов в системе



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        scan_com_port()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        scan_com_port()
    End Sub


    Sub scan_com_port()
        Ports = SerialPort.GetPortNames
        Dim port As String
        Log("========================")
        For Each port In Ports
            Log(port)
        Next port
        Log("========================")
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
