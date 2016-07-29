Imports System.Data
Imports System.Data.OleDb
Public Class addResultLowSecForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Public contents As String() = {}

    Public Sub New(params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        contents = params
        loadRegNumber(params)
    End Sub


    Private Sub studentRegCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles studentRegCombo.SelectedIndexChanged
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "SELECT f_name, m_name, l_name, id from student where reg_number = '" & studentRegCombo.Text & "'"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim Val = DS.Tables(0).Rows(0)(0).ToString & " " & DS.Tables(0).Rows(0)(1).ToString & " " & DS.Tables(0).Rows(0)(2).ToString

            studentName.Text = Val

            ReDim Preserve contents(4)
            contents(4) = DS.Tables(0).Rows(0)(3).ToString
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Public Sub loadRegNumber(params As String())
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "SELECT * from 
                    student s
                    INNER JOIN
                    (SELECT student_id from 
                    class c
                    INNER JOIN
                    class_student cs
                    on c.class_id = cs.class_id
                    where c.class_id =" & params(0) & ") tb
                    on s.id = tb.student_id"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count

            For i As Integer = 0 To rowCount - 1
                Dim Val = DS.Tables(0).Rows(i)(1).ToString
                studentRegCombo.Items.Add(Val)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Dim textBoxes As TextBox() = {engTh, engPr, nepTh, nepPr, mathTh, mathPr, socTh, socPr, sciTh, sciPr, obtTh, obtPr, compTh, compPr, heaTh, heaPr, morTh, heaPr}

        Dim valid As Boolean = checkNumberValidity(textBoxes)

        If valid = False Then
            MessageBox.Show("You must enter a Number.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim terminal = termCombo.Text
        Dim class_name = contents(3)

        Try
            Dim insertSQL As String = "INSERT INTO results_" & class_name & " ([student_id], [school_year], [school_name], [terminal], [eng_th], [eng_pr], [eng_total], [nep_th], [nep_pr], [nep_total], [math_th], [math_pr], [math_total], [sci_th], [sci_pr], [sci_total],
[soc_th], [soc_pr], [soc_total], [obt_th], [obt_pr], [obt_total], [comp_th], [comp_pr], [comp_total], [hea_th], [hea_pr], [hea_total], [mor_th], [mor_pr], [mor_total]) 
VALUES
(@student_id, @school_year, @school_name, @terminal, @eng_th, @eng_pr, @eng_total, @nep_th, @nep_pr, @nep_total, @math_th, @math_pr, @math_total, @sci_th, @sci_pr, @sci_total,
@soc_th, @soc_pr, @soc_total, @obt_th, @obt_pr, @obt_total, @comp_th, @comp_pr, @comp_total, @hea_th, @hea_pr, @hea_total, @mor_th, @mor_pr, @mor_total)"
            Con.Open()
            Dim cmd As New OleDbCommand(insertSQL, Con)
            cmd.Parameters.AddWithValue("@student_id", contents(4))
            cmd.Parameters.AddWithValue("@school_year", contents(1))
            cmd.Parameters.AddWithValue("@school_name", contents(2))
            cmd.Parameters.AddWithValue("@terminal", terminal)
            cmd.Parameters.AddWithValue("@eng_th", engTh.Text)
            cmd.Parameters.AddWithValue("@eng_pr", engPr.Text)
            cmd.Parameters.AddWithValue("@eng_total", CInt(engTh.Text) + CInt(engPr.Text))
            cmd.Parameters.AddWithValue("@nep_th", nepTh.Text)
            cmd.Parameters.AddWithValue("@nep_pr", nepPr.Text)
            cmd.Parameters.AddWithValue("@nep_total", CInt(nepTh.Text) + CInt(nepPr.Text))
            cmd.Parameters.AddWithValue("@math_th", mathTh.Text)
            cmd.Parameters.AddWithValue("@math_pr", mathPr.Text)
            cmd.Parameters.AddWithValue("@math_total", CInt(mathTh.Text) + CInt(mathPr.Text))
            cmd.Parameters.AddWithValue("@sci_th", sciTh.Text)
            cmd.Parameters.AddWithValue("@sci_pr", sciPr.Text)
            cmd.Parameters.AddWithValue("@sci_total", CInt(sciTh.Text) + CInt(sciPr.Text))
            cmd.Parameters.AddWithValue("@soc_th", socTh.Text)
            cmd.Parameters.AddWithValue("@soc_pr", socPr.Text)
            cmd.Parameters.AddWithValue("@soc_total", CInt(socTh.Text) + CInt(socPr.Text))
            cmd.Parameters.AddWithValue("@obt_th", obtTh.Text)
            cmd.Parameters.AddWithValue("@obt_pr", obtPr.Text)
            cmd.Parameters.AddWithValue("@obt_total", CInt(obtTh.Text) + CInt(obtPr.Text))
            cmd.Parameters.AddWithValue("@comp_th", compTh.Text)
            cmd.Parameters.AddWithValue("@comp_pr", compPr.Text)
            cmd.Parameters.AddWithValue("@comp_total", CInt(compTh.Text) + CInt(compPr.Text))
            cmd.Parameters.AddWithValue("@hea_th", heaTh.Text)
            cmd.Parameters.AddWithValue("@hea_pr", heaPr.Text)
            cmd.Parameters.AddWithValue("@hea_total", CInt(heaTh.Text) + CInt(heaPr.Text))
            cmd.Parameters.AddWithValue("@mor_th", morTh.Text)
            cmd.Parameters.AddWithValue("@mor_pr", morPr.Text)
            cmd.Parameters.AddWithValue("@mor_total", CInt(morTh.Text) + CInt(morPr.Text))



            cmd.ExecuteNonQuery()

            MsgBox("Insert Successful", MsgBoxStyle.Information, "INSERTED")
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
            'AddTable()
        End Try
    End Sub

    Public Function checkNumberValidity(textboxes As TextBox()) As Boolean
        For i As Integer = 0 To textboxes.Count - 1
            If Not IsNumeric(textboxes(i).Text) Or textboxes(i).Text = "" Then
                Return False
            End If
        Next
        Return True
    End Function
End Class