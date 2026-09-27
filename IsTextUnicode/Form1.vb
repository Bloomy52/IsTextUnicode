Imports System.Text
Public Class Form1
    Private Sub btnCheckEncoding_Click(sender As Object, e As EventArgs) Handles btnCheckEncoding.Click
        Dim inputText As String = txtInput.Text

        For i As Integer = 0 To inputText.Length - 1
            Dim codeInt As Integer = Convert.ToInt32(inputText(i))

            If codeInt > &H7F Then
                MessageBox.Show("This input text contains non-ASCII characters. Please enter ASCII characters only.")
                Return
            End If
        Next


        Dim buffer As Byte() = Encoding.ASCII.GetBytes(inputText)
        Dim length As Integer = buffer.Length

        Dim previousLow As Integer = 0
        Dim previousHigh As Integer = 0
        Dim lowByteChanges As Integer = 0
        Dim highByteChanges As Integer = 0

        ' Examine at most 256 complete 16-bit units.
        Dim pairCount As Integer = Math.Min(buffer.Length \ 2, 256)

        For pairIndex As Integer = 0 To pairCount - 1
            Dim i As Integer = pairIndex * 2
            Dim currentLow As Integer = CInt(buffer(i))
            Dim currentHigh As Integer = CInt(buffer(i + 1))

            ' Accumulate the magnitude of each change.
            lowByteChanges += Math.Abs(currentLow - previousLow)
            highByteChanges += Math.Abs(currentHigh - previousHigh)

            previousLow = currentLow
            previousHigh = currentHigh
        Next

        If lowByteChanges > (highByteChanges * 3) Then
            txtEncodingScheme.Text() = "Unicode"
        Else
            txtEncodingScheme.Text() = "ANSI"
        End If


    End Sub

    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged
        ' clear the encoding scheme text box when the input text changes
        txtEncodingScheme.Clear()
    End Sub
End Class
