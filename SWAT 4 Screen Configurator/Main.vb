Imports System.IO

Public Class Main

    Public CurrentLocation As Point

    Private Sub Main_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TripManual()
        CurrentLocation = Me.Location
        ToolTip1.SetToolTip(CheckBox2, "INI settings file is given the read-only attribute")
    End Sub

    Sub Save()
        Try
            Dim Config As New IniFile
            Dim CurrentDir As String = Environment.CurrentDirectory
            Dim ConfigDir As String = CurrentDir & "\content\System\Swat4.ini"

            If File.GetAttributes(ConfigDir) = FileAttributes.ReadOnly Then
                File.SetAttributes(ConfigDir, FileAttributes.ReadOnly = False)
            End If


            'MsgBox(ConfigDir)
            Config.Load(ConfigDir)
            If CheckBox1.Checked = True Then
                Config.SetKeyValue("WinDrv.WindowsClient", "FullscreenViewportX", TextBox1.Text)
                Config.SetKeyValue("WinDrv.WindowsClient", "FullscreenViewportY", TextBox2.Text)
            Else
                Dim Res() As String = Split(ResBox.Text, "x", -1, CompareMethod.Text)
                Config.SetKeyValue("WinDrv.WindowsClient", "FullscreenViewportX", Res(0).Trim)
                Config.SetKeyValue("WinDrv.WindowsClient", "FullscreenViewportY", Res(1).Trim)
            End If
            Dim Brightness As Decimal = MoreSettings.TrackBar2.Value / 10
            Dim Contrast As Decimal = MoreSettings.TrackBar1.Value / 10
            Dim Gamma As Decimal = MoreSettings.TrackBar3.Value / 10
            Config.SetKeyValue("WinDrv.WindowsClient", "Brightness", Brightness)
            Config.SetKeyValue("WinDrv.WindowsClient", "Contrast", Contrast)
            Config.SetKeyValue("WinDrv.WindowsClient", "Gamma", Gamma)
            Config.SetKeyValue("Engine.RenderConfig", "GlowEffectDetail", MoreSettings.ComboBox2.Text)
            Config.SetKeyValue("Engine.RenderConfig", "BumpmapDetail", MoreSettings.ComboBox3.Text)
            Config.SetKeyValue("Engine.RenderConfig", "DynamicShadowDetail", MoreSettings.ComboBox6.Text)
            Config.SetKeyValue("Engine.RenderConfig", "TextureDetail", MoreSettings.ComboBox4.Text)
            Config.SetKeyValue("Engine.RenderConfig", "WorldDetail", MoreSettings.ComboBox5.Text)
            Config.Save(ConfigDir)
            If CheckBox2.Checked = True Then
                File.SetAttributes(ConfigDir, FileAttributes.ReadOnly)
            Else
                File.SetAttributes(ConfigDir, FileAttributes.Normal)
            End If
            MsgBox("Configuration saved.", MsgBoxStyle.Information)

        Catch Exception As System.IO.FileNotFoundException
            MsgBox("Settings file not found!", MsgBoxStyle.Critical)
        Catch exception As System.UnauthorizedAccessException
            MsgBox("Could not open/write to settings file!", MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub TripManual()
        If Me.CheckBox1.Checked = False Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            CheckBox2.Enabled = False
            Button3.Enabled = False
            ResBox.Enabled = True
        Else
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            CheckBox2.Enabled = True
            Button3.Enabled = True
            ResBox.Enabled = False
        End If
    End Sub

    Private Sub Save_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If CheckBox1.Checked = True Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Please enter a custom resolution.", MsgBoxStyle.Exclamation)
            Else
                Save()
            End If
        Else
            If ResBox.Text = "" Then
                MsgBox("Please select a resolution.", MsgBoxStyle.Exclamation)
            Else
                Save()
            End If
        End If
    End Sub

    Private Sub GCSR_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim DisplayRes As String = intX & " x " & intY
        If CheckBox1.Checked = True Then
            TextBox1.Text = intX
            TextBox2.Text = intY
        Else
            If ResBox.Items.Contains(DisplayRes) Then
                ResBox.Text = DisplayRes
            Else
                ResBox.Items.Add(DisplayRes)
                ResBox.Text = DisplayRes
            End If
        End If

    End Sub

    Private Sub VideoSettings_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Dim MainLocationX As Integer = Me.Location.X
        'Dim MainLocationY As Integer = Me.Location.Y
        'Dim MSettingsLocationX As Integer = MainLocationX + 303
        'MoreSettings.Location = New Point(MSettingsLocationX, MainLocationY)
        'MoreSettings.Bounds = New Rectangle()
        'Dim NewWidth As Integer = Me.Width + 50
        'MoreSettings.Left = Me.Left + NewWidth
        'MoreSettings.Top = Me.Top
        MoreSettings.Show()
    End Sub

    Private Sub ManualMode_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        TripManual()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim CurrentDir As String = Environment.CurrentDirectory
        Dim ConfigDir As String = CurrentDir & "\content\System\Swat4.ini"
        System.Diagnostics.Process.Start(ConfigDir)
    End Sub

    Private Sub About_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        MsgBox("Made by Johannes Brittain for S.W.A.T. 4" & vbNewLine & "Program Version: " & Me.ProductVersion, , "About")
    End Sub

    Private Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub

    Private Sub Main_Move(sender As Object, e As System.EventArgs) Handles Me.Move
        'Dim NewLocation As Point
        'NewLocation = Me.Location
        'Dim LocDifferenceX As Integer = NewLocation.X - CurrentLocation.X
        'Dim LocDifferenceY As Integer = NewLocation.Y - CurrentLocation.Y
        'Dim NewX As Integer = MoreSettings.Location.X + LocDifferenceX
        'Dim NewY As Integer = MoreSettings.Location.Y + LocDifferenceY
        'MoreSettings.Location = New Point(NewX, NewY)

        Debug.WriteLine("Main: " & Me.Location.X & ", " & Me.Location.Y)

        Dim mainRectangle = Me.Bounds
        Dim NewRight As Integer = mainRectangle.Right + 12
        MoreSettings.Location = New Point(NewRight, mainRectangle.Top)


        'CurrentLocation = Me.CurrentLocation
        'Dim NewWidth As Integer = Me.Width + 50
        'MoreSettings.Left = Me.Left + NewWidth
        'MoreSettings.Top = Me.Top
        'Dim OldLocation As Point = Me.Location
    End Sub


End Class
