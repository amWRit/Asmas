Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms

Public Class printReport
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Public contents As String()
    Public tempDS As DataSet

    Public Shared primary As String() = TheClass.primaryShortNames
    Public Shared lowSec As String() = TheClass.lowSecShortNames
    Public Shared sec As String() = TheClass.secShortNames

    Public Shared Sub batch_print(ByVal tempDS As DataSet, ByVal index As Integer, ByVal class_name As String, ByVal class_teacher As String, school_info As String(), class_id As String)
        Dim student_id = tempDS.Tables(0).Rows(index)("student_id")
        Dim student_info = myFunctions.getStudentInfoOf(CInt(student_id))

        myFunctions.prepareTempTable(tempDS, index, class_name, class_teacher, school_info, student_info, class_id)
        Dim report As New LocalReport()
        If primary.Contains(class_name) Then
            report.ReportPath = ".\Rdlc\resultPrimary.rdlc"
            report.DataSources.Add(New ReportDataSource("resultPrimary", myFunctions.getResultDataTable(class_name)))
        ElseIf lowSec.Contains(class_name) Then
            report.ReportPath = ".\Rdlc\resultLowSec.rdlc"
            report.DataSources.Add(New ReportDataSource("resultLowSec", myFunctions.getResultDataTable(class_name)))

        ElseIf sec.Contains(class_name) Then
            report.ReportPath = ".\Rdlc\resultSec.rdlc"
            report.DataSources.Add(New ReportDataSource("resultsSec", myFunctions.getResultDataTable(class_name)))
        End If

        report.EnableExternalImages = True
        Dim imagePath = Application.StartupPath & "\StudentPhotos\photo_not_available.png"
        Dim studentPhoto = getStudentPhoto(student_info)
        Dim schoolLogo = getSchoolLogo(school_info)
        report.SetParameters(New ReportParameter("studentPhotoParam", studentPhoto))
        report.SetParameters(New ReportParameter("schoolLogoParam", schoolLogo))
        report.Refresh()
        Dim dp As directPrint = New directPrint()
        dp.Export(report)
    End Sub

    Public Shared Function getStudentPhoto(student_info As String()) As String
        Dim student_reg = student_info(0)
        Dim student_name = student_info(1).Replace(" ", "")
        Dim strBasePath = Application.StartupPath & "\StudentPhotos\"
        Dim imageName = student_name & "" & student_reg & ".jpg"
        Dim imagePath = strBasePath & imageName
        If imagePath = "" Or Not System.IO.File.Exists(imagePath) Then
            imagePath = Application.StartupPath & "\StudentPhotos\photo_not_available.png"
        End If
        Dim templateImage = New Uri("file:\" & imagePath).AbsoluteUri
        Return templateImage
    End Function

    Public Shared Function getSchoolLogo(school_info As String()) As String
        Dim strBasePath = Application.StartupPath & "\logo\"
        Dim imageName = school_info(3) & ".png" 'school short name 
        Dim imagePath = strBasePath & imageName
        If imagePath = "" Or Not System.IO.File.Exists(imagePath) Then
            imagePath = Application.StartupPath & "\StudentPhotos\photo_not_available.png"
        End If
        Dim templateImage = New Uri("file:\" & imagePath).AbsoluteUri
        Return templateImage
    End Function

    Public Shared Function checkInput(pagefrom As Integer, pageto As Integer, rowcount As Integer) As Boolean
        Dim _exit As Boolean = False
        If pagefrom > rowcount Or pageto > rowcount Then
            MsgBox("Page Start/End number is greater than total pages. Please check", MsgBoxStyle.Exclamation, "ERROR")
            _exit = True
            Return _exit
        End If
        If pagefrom < 1 Or pageto < 1 Then
            MsgBox("Page number can't be less than 1. Please check", MsgBoxStyle.Exclamation, "ERROR")
            _exit = True
            Return _exit
        End If
        If pagefrom > pageto Then
            MsgBox("Wrong Page Number input. Please check", MsgBoxStyle.Exclamation, "ERROR")
            _exit = True
            Return _exit
        End If

        If pagefrom = 1 And pageto = rowcount Then
            Dim I As Integer = MsgBox("You are going to print all the pages. ARE YOU SURE?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Warning")
            If I = MsgBoxResult.No Then
                _exit = True
                Return _exit
            End If
        End If
        If (pageto - pagefrom) > 10 Then
            Dim I As Integer = MsgBox("You are going to print a lot of pages. ARE YOU SURE?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Warning")
            If I = MsgBoxResult.No Then
                _exit = True
                Return _exit
            End If
        End If
        Return _exit
    End Function
End Class
