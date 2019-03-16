Public Class MoreSettings

    Private Sub MoreSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim NewWidth As Integer = Main.Width + 12
        Me.Left = Main.Left + NewWidth
        Me.Top = Main.Top

        ComboBox2.SelectedItem = "Medium"
        ComboBox3.SelectedItem = "Medium"
        ComboBox4.SelectedItem = "Medium"
        ComboBox5.SelectedItem = "Medium"
        ComboBox6.SelectedItem = "Medium"

        ToolTip1.SetToolTip(ComboBox1, "This control isn't a property itself, it just changes the others")
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "Low" Then
            ComboBox2.SelectedItem = "Low"
            ComboBox3.SelectedItem = "Low"
            ComboBox4.SelectedItem = "Low"
            ComboBox5.SelectedItem = "Low"
            ComboBox6.SelectedItem = "Low"
        ElseIf ComboBox1.SelectedItem = "Medium" Then
            ComboBox2.SelectedItem = "Medium"
            ComboBox3.SelectedItem = "Medium"
            ComboBox4.SelectedItem = "Medium"
            ComboBox5.SelectedItem = "Medium"
            ComboBox6.SelectedItem = "Medium"
        ElseIf ComboBox1.SelectedItem = "High" Then
            ComboBox2.SelectedItem = "High"
            ComboBox3.SelectedItem = "High"
            ComboBox4.SelectedItem = "High"
            ComboBox5.SelectedItem = "High"
            ComboBox6.SelectedItem = "High"
        End If
    End Sub

    Private Sub Main_Move(sender As Object, e As System.EventArgs) Handles Me.Move
        Debug.WriteLine("VSettings: " & Me.Location.X & ", " & Me.Location.Y)
        'Main.Left = Me.Left + Me.Width
        'Main.Top = Me.Top
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.TrackBar1.Value = 6
        Me.TrackBar2.Value = 6
        Me.TrackBar3.Value = 12
        ComboBox1.SelectedItem = ""
        ComboBox2.SelectedItem = "Medium"
        ComboBox3.SelectedItem = "Medium"
        ComboBox4.SelectedItem = "Medium"
        ComboBox5.SelectedItem = "Medium"
        ComboBox6.SelectedItem = "Medium"
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

End Class