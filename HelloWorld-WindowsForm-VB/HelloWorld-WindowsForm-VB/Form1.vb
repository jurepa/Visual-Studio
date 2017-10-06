Public Class Form1
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged

    End Sub
    ''' <summary>
    ''' Evento causado por el click del boton saludo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub boton_Click(sender As Object, e As EventArgs) Handles boton.Click
        Dim nombre As String
        nombre = Me.TextBox1.Text
        'MessageBox.Show(String.Format("Hola {0} crack", nombre), "Las cagao")
        MessageBox.Show($"Hola {nombre} crackº")
    End Sub
End Class
