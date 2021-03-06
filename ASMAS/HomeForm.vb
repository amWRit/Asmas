﻿Public Class HomeForm
    'Dim strHelpPath As String = System.IO.Path.Combine(Application.StartupPath, "\Help\AsmasHelp.chm")

    Dim strHelpPath As String = Application.StartupPath & "\Help\AsmasHelp.chm"
    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentUser As DataSet
        currentUser = User.user
        currentUserLabel.Text = User.userName

        If User.userRole = "Viewer" Or User.userRole = "Teacher" Then
            AdminToolsToolStripMenuItem.Enabled = False
            AdminToolsToolStripMenuItem.Visible = False
        End If

        If User.userRole = "Viewer" Or User.userRole = "Admin" Then
            MyClassesToolStripMenuItem.Enabled = False
            MyClassesToolStripMenuItem.Visible = False
        End If

        HelpProvider.HelpNamespace = strHelpPath
    End Sub

    Private Sub YearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YearToolStripMenuItem.Click
        Me.Hide()
        addYearForm.Show()
    End Sub

    Private Sub SchoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolToolStripMenuItem.Click
        Me.Hide()
        Dim _addSchoolForm As New addSchoolForm({"", "False"})
        _addSchoolForm.Show()
    End Sub

    Private Sub ClassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassToolStripMenuItem.Click
        Me.Hide()
        Dim _addClassForm As New addClassForm({"", "FALSE"})
        _addClassForm.Show()
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        Me.Hide()
        'params = {user_id, edit}
        Dim _addUserForm As New addUserForm({"", "False"})
        _addUserForm.Show()
    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click
        Me.Hide()
        Dim _addStudentForm As New addStudentForm({"", "FALSE"})
        _addStudentForm.Show()
    End Sub

    Private Sub MyClassesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MyClassesToolStripMenuItem.Click
        Me.Hide()
        myClassesForm.Show()
    End Sub

    Private Sub StudentDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentDatabaseToolStripMenuItem.Click
        Me.Hide()
        viewDatabaseForm.Show()
    End Sub

    Private Sub ResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResultsToolStripMenuItem.Click
        Me.Hide()
        viewResultsForm.Show()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        Me.Hide()
        SearchForm.Show()
    End Sub

    Private Sub HomeForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Dim I As Integer = MsgBox("Are you sure?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Exit")
            If I = MsgBoxResult.Yes Then
                Me.Hide()
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub viewResultBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ViewUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewUsersToolStripMenuItem.Click
        viewUsersForm.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    Private Sub SupportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupportToolStripMenuItem.Click
        Help.ShowHelp(Me, HelpProvider.HelpNamespace, HelpNavigator.TableOfContents)

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Dim objDlg As New SaveFileDialog
        objDlg.Filter = "Access File|*.accdb"
        objDlg.OverwritePrompt = True
        Dim db_file_path As String = DBConnection.data_source_path

        If objDlg.ShowDialog = DialogResult.OK Then
            Dim filepath As String = objDlg.FileName
            Try
                System.IO.File.Copy(db_file_path, filepath)
                MessageBox.Show("Database exported successfully!", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        Dim objDlg As New OpenFileDialog
        objDlg.Filter = "Access File|*.accdb"
        Dim old_file_path As String = DBConnection.data_source_path
        Dim random = New Random
        Dim backup_path As String = ".\Backup\db_backup_" & random.Next.ToString & ".accdb"

        If objDlg.ShowDialog = DialogResult.OK Then
            Dim new_filepath As String = objDlg.FileName
            Try
                Dim I As Integer = MessageBox.Show("Importing a new database will completely REPLACE the existing database. ARE YOU ABSOLUTELY SURE?", "IMPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If I = MsgBoxResult.Yes Then
                    FileHandler.ReleaseObject(old_file_path)
                    'System.IO.File.Replace(old_file_path, new_filepath, backup_path)
                    System.IO.File.Copy(old_file_path, backup_path)
                    'making sure the file has been backed up 
                    If System.IO.File.Exists(backup_path) Then
                        System.IO.File.Delete(old_file_path)
                        System.IO.File.Copy(new_filepath, old_file_path)
                        MessageBox.Show("Database imported successfully!", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        MessageBox.Show("You have a new database. So, the program needs to restart.", "RESTART", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        Application.Restart()
                    Else
                        MessageBox.Show("The backup of current database couldn't be created.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub MySubjectAnalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MySubjectAnalysisToolStripMenuItem.Click
        mySubjectAnalysisForm.Show()
    End Sub

    Private Sub ViewSchoolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSchoolsToolStripMenuItem.Click
        viewSchoolsForm.show()
    End Sub
End Class