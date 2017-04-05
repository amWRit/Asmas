Option Strict Off

Imports System.Runtime.InteropServices
Imports System.Management
Imports System.Data
Imports System.Data.OleDb
Imports System.Text
Imports System.IO


Public Class Registration
    Private Declare Function GetVolumeInformation Lib "Kernel32" Alias "GetVolumeInformationA" (ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As StringBuilder, ByVal nVolumeNameSize As Integer, lpVolumeSerialNumber As Integer, lpMaximumComponentLength As Integer, lpFileSystemFlags As Integer, ByVal lpFileSystemNameBuffer As StringBuilder, ByVal nFileSystemNameSize As Integer) As Integer

    ' Return true if the program is properly registered.
    Public Shared Function IsRegistered(ByVal program_id As UInt32,
        ByVal default_value As Boolean) As Boolean

        Dim serial_number As Long
        ' Get the information. If we fail, return the default
        ' value.
        serial_number = GetDriveSerialNumber()

        If serial_number = 0 Or serial_number = -1 Then
            Return default_value
        End If

        ' Encrypt the serial number to get the product key.
        Dim product_key As String = Hex(Encrypt(program_id,
            serial_number))

        ' If this matches the saved product key, then the
        ' program is registered.
        If (My.Settings.ProductKey = product_key) Then Return _
            True

        ' It's not registered properly.
        ' Display the registration form.
        Dim frm As New RegistrationForm()
        frm.productID.Text = serial_number.ToString()
        If (frm.ShowDialog() = DialogResult.Cancel) Then Return _
            False

        ' See if the product key matches.
        Dim entered_key As String = ""
        Try
            entered_key = frm.productCode.Text
        Catch
        End Try
        If (entered_key = product_key) Then
            My.Settings.ProductKey = entered_key
            My.Settings.Save()
            Return True
        End If

        ' No match. Give up.
        MessageBox.Show("Incorrect product key.", "Invalid Key", _
 _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
    End Function

    ' Simple encryption and decryption.
    Public Shared Function Encrypt(ByVal seed As UInt32, ByVal value _
        As Long) As Long
        Dim rand As New Random(CInt(seed \ 2))
        Dim pass As Long = CInt((value Xor CUInt(UInt32.MaxValue *
        rand.NextDouble())))
        Return pass
    End Function

    Public Shared Function GetDriveSerialNumber() As String
        Dim DriveSerial As Long = 0
        Dim fso As Object, Drv As Object
        'Create a FileSystemObject object
        fso = CreateObject("Scripting.FileSystemObject")
        Drv = fso.GetDrive(fso.GetDriveName(AppDomain.CurrentDomain.BaseDirectory))
        With Drv
            If .IsReady Then
                DriveSerial = .SerialNumber
            Else    '"Drive Not Ready!"
                DriveSerial = -1
            End If
        End With
        'Clean up
        Drv = Nothing
        fso = Nothing
        'GetDriveSerialNumber = Hex(DriveSerial)
        Return DriveSerial
    End Function
End Class
