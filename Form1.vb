Option Infer Off
Option Explicit On

Imports System.Drawing.Text
Imports System.IO
Imports System.Media
Imports System.Runtime.InteropServices
Imports Connect_Four.Form1.gamedata
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'All this apparently adds the Helvetica font I need to use or something-
        Dim fontData As Byte() = My.Resources.HelveticaLTStd_Bold
        Dim fontDataPtr As IntPtr = Marshal.AllocCoTaskMem(fontData.Length)
        Marshal.Copy(fontData, 0, fontDataPtr, fontData.Length)
        Dim fontCollection As New System.Drawing.Text.PrivateFontCollection()
        fontCollection.AddMemoryFont(fontDataPtr, fontData.Length)
        Dim fontFamily As System.Drawing.FontFamily = fontCollection.Families(0)
        Dim font As New System.Drawing.Font(fontFamily, 12)
        Marshal.FreeCoTaskMem(fontDataPtr)

        For Each thing As Control In {lblPinkWins, lblGreenWins, PictureBox1, GameBoardFLP, Me}
            AddHandler thing.KeyPress, AddressOf ErrorClick
            AddHandler thing.Click, AddressOf ErrorClick
        Next

        GenerateBoard()
    End Sub



    Private Sub ErrorClick(sender As Object, e As EventArgs)
        If freezeboard Then
            My.Computer.Audio.PlaySystemSound(SystemSounds.Beep)
        End If
    End Sub

    Structure gamedata
        Shared current_player As String
        Shared green_wins As Integer
        Shared pink_wins As Integer
    End Structure

    Public game As New gamedata

    Private lastwinner As String = "green"

    Private boardcells(6, 5) As PictureBox
    Public Sub GenerateBoard()
        current_player = lastwinner
        GameBoardFLP.Controls.Clear()
        For y As Integer = 5 To 0 Step -1
            For x As Integer = 0 To 6
                Dim cell As New PictureBox
                With cell
                    .Size = New Size(100, 100)
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    .Margin = New Padding(1, 1, 1, 1)
                    .Image = My.Resources._default
                    .Tag = "empty"
                End With
                AddHandler cell.MouseEnter, AddressOf CellEnter
                AddHandler cell.MouseLeave, AddressOf CellExit
                AddHandler cell.MouseDown, AddressOf CellClick
                AddHandler cell.MouseUp, AddressOf CellMouseUp
                AddHandler cell.Click, AddressOf ErrorClick
                AddHandler cell.KeyPress, AddressOf ErrorClick
                boardcells(x, y) = cell
                GameBoardFLP.Controls.Add(cell)
            Next
        Next
    End Sub

    Public hoveredcell As PictureBox

    Private Sub CellEnter(sender As PictureBox, e As EventArgs)
        If Not freezeboard Then
            Dim validcell As PictureBox = GetValidCell(sender)
            If current_player = "green" Then
                If validcell IsNot Nothing Then
                    validcell.Image = My.Resources.green_hover
                End If
                hoveredcell = validcell
            ElseIf current_player = "pink" Then
                If validcell IsNot Nothing Then
                    validcell.Image = My.Resources.pink_hover
                End If
                hoveredcell = validcell
            End If
        End If
    End Sub

    Private Sub CellExit(sender As PictureBox, e As EventArgs)
        'GetValidCell(sender).Image = My.Resources._default
        If hoveredcell IsNot Nothing Then
            hoveredcell.Image = My.Resources._default
        End If
        hoveredcell = Nothing
    End Sub

    Public freezeboard As Boolean = False

    Private Sub CellClick(sender As Object, e As EventArgs)
        If Not freezeboard Then
            If hoveredcell IsNot Nothing Then
                Select Case current_player
                    Case "green"
                        hoveredcell.Tag = "green"
                        hoveredcell.Image = My.Resources.green_placed

                    Case "pink"
                        hoveredcell.Tag = "pink"
                        hoveredcell.Image = My.Resources.pink_placed

                End Select
                SwitchCharacters()
            End If
            If CheckForWin("green") Then
                WinPopup.BackgroundImage = My.Resources.green_wins
                WinPopup.Text = "Winner!"
                green_wins += 1
                lblGreenWins.Text = green_wins
                freezeboard = True
                WinPopup.Show()
                lastwinner = "green"
            ElseIf CheckForWin("pink") Then
                WinPopup.BackgroundImage = My.Resources.pink_wins
                WinPopup.Text = "Winner!"
                pink_wins += 1
                lblPinkWins.Text = pink_wins
                freezeboard = True
                WinPopup.Show()
                lastwinner = "pink"
            ElseIf CheckForFullColumn(0) AndAlso
                   CheckForFullColumn(1) AndAlso
                   CheckForFullColumn(2) AndAlso
                   CheckForFullColumn(3) AndAlso
                   CheckForFullColumn(4) AndAlso
                   CheckForFullColumn(5) AndAlso
                   CheckForFullColumn(6) Then
                WinPopup.BackgroundImage = My.Resources.nobody_wins
                WinPopup.Text = "No Winner!"
                freezeboard = True
                WinPopup.Show()
            End If

        End If
        hoveredcell = Nothing
    End Sub

    Private Function CheckForFullColumn(x As Integer)
        Dim full As Boolean = True
        For y As Integer = 0 To 5
            If boardcells(x, y).Tag = "empty" Then full = False
        Next
        Return full
    End Function

    Private Sub CellMouseUp(sender As PictureBox, e As EventArgs)
        If Not freezeboard Then
            CellEnter(sender, EventArgs.Empty)
        End If

    End Sub

    Private Function GetValidCell(sender As PictureBox) As PictureBox
        Dim c = FindIndex(boardcells, sender)
        If Not CheckForFullColumn(c(0)) Then
            Dim y As Integer = c(1)
            Dim boardheight As Integer = boardcells.GetLength(1) - 1
            For i As Integer = boardheight To 0 Step -1
                If boardcells(c(0), i).Tag <> "empty" Then
                    If i + 1 < boardcells.GetLength(1) Then
                        Return boardcells(c(0), i + 1)
                    End If

                End If
            Next
            Return boardcells(c(0), 0)
        End If
    End Function

    Private Sub SwitchCharacters()
        If current_player = "green" Then
            current_player = "pink"
        ElseIf current_player = "pink" Then
            current_player = "green"
        End If
    End Sub

    Function FindIndex(ByVal arr As Object(,), ByVal element As Object) As Array
        For i As Integer = 0 To arr.GetLength(0) - 1
            For j As Integer = 0 To arr.GetLength(1) - 1
                If arr(i, j) Is element Then
                    Return {i, j}
                End If
            Next
        Next
        Return {-1, -1} ' Returns -1, -1 if element not found
    End Function


    'This function was written completely by ChatGPT
    Private Function CheckForWin(tag As String) As Boolean
        ' Check horizontal
        For y As Integer = 0 To 5
            For x As Integer = 0 To 3
                If boardcells(x, y).Tag = tag AndAlso
               boardcells(x + 1, y).Tag = tag AndAlso
               boardcells(x + 2, y).Tag = tag AndAlso
               boardcells(x + 3, y).Tag = tag Then
                    Return True
                End If
            Next
        Next

        ' Check vertical
        For x As Integer = 0 To 6
            For y As Integer = 0 To 2
                If boardcells(x, y).Tag = tag AndAlso
               boardcells(x, y + 1).Tag = tag AndAlso
               boardcells(x, y + 2).Tag = tag AndAlso
               boardcells(x, y + 3).Tag = tag Then
                    Return True
                End If
            Next
        Next

        ' Check diagonal (top left to bottom right)
        For x As Integer = 0 To 3
            For y As Integer = 0 To 2
                If boardcells(x, y).Tag = tag AndAlso
               boardcells(x + 1, y + 1).Tag = tag AndAlso
               boardcells(x + 2, y + 2).Tag = tag AndAlso
               boardcells(x + 3, y + 3).Tag = tag Then
                    Return True
                End If
            Next
        Next

        ' Check diagonal (top right to bottom left)
        For x As Integer = 3 To 6
            For y As Integer = 0 To 2
                If boardcells(x, y).Tag = tag AndAlso
               boardcells(x - 1, y + 1).Tag = tag AndAlso
               boardcells(x - 2, y + 2).Tag = tag AndAlso
               boardcells(x - 3, y + 3).Tag = tag Then
                    Return True
                End If
            Next
        Next

        ' No win found
        Return False
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class

