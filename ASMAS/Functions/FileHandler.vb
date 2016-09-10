Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FileHandler
    Public Shared Sub ExportToExcel(ByVal dtTemp As DataTable, ByVal filepath As String)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            Dim I As Integer = MessageBox.Show("Do you want to replace from the existing file?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If I = MsgBoxResult.Ok Then
                System.IO.File.Delete(strFileName)
            End If

        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = CType(wBook.ActiveSheet(), Excel.Worksheet)

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        ' export the Columns 
        For Each dc In dt.Columns
            colIndex = colIndex + 1
            wSheet.Cells(1, colIndex) = dc.ColumnName
        Next

        'export the rows 
        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                wSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
            Next
        Next
        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        MessageBox.Show("File Exported Successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Function GetDatatable(tempDS As DataSet) As DataTable
        'Create the data table at runtime
        Dim DT As New DataTable
        DT = tempDS.Tables(0)
        Return DT
    End Function


    Public Shared Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Public Shared Function ResizeImage(ByVal InputImage As Image, maxWidth As Integer, maxHeight As Integer) As Image
        'Return New Bitmap(InputImage, New Size(198, 188 ))
        Dim ratioX = CDbl(maxWidth / InputImage.Width)
        Dim ratioY = CDbl(maxHeight / InputImage.Height)
        Dim ratio = Math.Min(ratioX, ratioY)

        Dim newWidth = CInt(InputImage.Width * ratio)
        Dim newHeight = CInt(InputImage.Height * ratio)

        Dim newImage = New Bitmap(newWidth, newHeight)

        Using graphics As Graphics = Graphics.FromImage(newImage)
            graphics.DrawImage(InputImage, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Public Shared Function RotateImage(ByVal InputImage As Image) As Image
        Dim rft As RotateFlipType = RotateFlipType.RotateNoneFlipNone
        Dim properties As PropertyItem() = InputImage.PropertyItems
        Dim bReturn As Boolean = False
        For Each p As PropertyItem In properties
            If p.Id = 274 Then
                Dim orientation As Short = BitConverter.ToInt16(p.Value, 0)
                Select Case orientation
                    Case 1
                        rft = RotateFlipType.RotateNoneFlipNone
                    Case 3
                        rft = RotateFlipType.Rotate180FlipNone
                    Case 6
                        rft = RotateFlipType.Rotate90FlipNone
                    Case 8
                        rft = RotateFlipType.Rotate270FlipNone
                End Select
            End If
        Next
        If rft <> RotateFlipType.RotateNoneFlipNone Then
            InputImage.RotateFlip(rft)
        End If
        Return InputImage
    End Function
End Class
