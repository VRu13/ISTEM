Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmPlanVsActual
    Dim grade As String
    Dim mainreport, footer, period As New DataTable
    Dim perintah As New SqlCommand

    Sub BuatTampilanExcel(ByVal dt1 As DataTable, ByVal dt2 As DataTable, ByVal dt3 As DataTable)

        Dim rowsTotal, colsTotal As Short
        Dim I, j As Short
        On Error Resume Next
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

        Dim xlApp As New Excel.Application
        Dim excelBook As Excel.Workbook
        Dim excelWorksheet As Excel.Worksheet

        'Try

        xlApp.Visible = False
        xlApp.UserControl = True
        excelBook = xlApp.Workbooks.Add
        excelWorksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)

        Dim iX As Integer
        Dim iY As Integer

        Dim TheRg As Excel.Range

        xlApp.Visible = True
        rowsTotal = dt1.Rows.Count - 0
        colsTotal = dt1.Columns.Count - 1
        For iX = 0 To dt1.Rows.Count - 2

        Next

        For iY = 0 To dt1.Columns.Count - 2

        Next
        With excelWorksheet
            .Cells.Select()
            .Cells.Delete()
            .Columns(1).NumberFormat = "@"
            .Columns(2).NumberFormat = "0.00;(0.00); "
            .Columns(3).NumberFormat = "0.00;(0.00); "
            .Columns(4).NumberFormat = "0.00;(0.00); "
            .Columns(5).NumberFormat = "0.00;(0.00); "
            .Columns(6).NumberFormat = "0.00;(0.00); "
            .Columns(7).NumberFormat = "0.00;(0.00); "
            .Columns(8).NumberFormat = "0.00;(0.00); "
            .Columns(9).NumberFormat = "0.00;(0.00); "
            .Columns(10).NumberFormat = "0.00;(0.00); "
            .Columns(11).NumberFormat = "0.00;(0.00); "
            .Columns(12).NumberFormat = "0.00;(0.00); "
            .Columns(13).NumberFormat = "0.00;(0.00); "
            .Columns(14).NumberFormat = "@"

            '---TITLE
            .Cells(1, 1).value = "PLAN VS ACTUAL"
            .Cells(2, 1).value = "PRINT DATE : " & Format(CDate(Now).ToString("dd/MM/yyyy"))
            .Cells(3, 1).value = "GRADE : " & grade
            .Cells(6, 14).value = "UNIT : MTR"


            .Range("B5:E5").Merge()
            .Range("F5:I5").Merge()
            .Range("J5:M5").Merge()

            '---Column Name
            .Cells(5, 2).value = dt3.Rows(0).Item(0) & " - " & dt3.Rows(0).Item(1) & " " & dt3.Rows(0).Item(2)
            .Cells(5, 6).value = dt3.Rows(0).Item(3) & " - " & dt3.Rows(0).Item(4) & " " & dt3.Rows(0).Item(5)
            .Cells(5, 10).value = dt3.Rows(0).Item(6) & " " & dt3.Rows(0).Item(2) & " - " & dt3.Rows(0).Item(4) & " " & dt3.Rows(0).Item(5)

            .Range("B5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("F5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("J5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

            .Cells(6, 1).value = "Grey No"
            .Range("A5:A6").Merge()
            .Range("A5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("A5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            .Cells(6, 2).value = "Plan"
            .Cells(6, 3).value = "Actual"
            .Cells(6, 4).value = "Diff"
            .Cells(6, 5).value = "%"
            .Cells(6, 6).value = "Plan"
            .Cells(6, 7).value = "Actual"
            .Cells(6, 8).value = "Diff"
            .Cells(6, 9).value = "%"
            .Cells(6, 10).value = "Plan"
            .Cells(6, 11).value = "Actual"
            .Cells(6, 12).value = "Diff"
            .Cells(6, 13).value = "%"
            .Cells(6, 14).value = "Remarks"

            .Range("N5:N6").Merge()
            .Range("N5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            .Range("N5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

            'MAINREPORT
            For I = 0 To rowsTotal - 1
                For j = 0 To colsTotal - 0
                    .Cells(I + 7, j + 1).value = dt1.Rows(I).Item(j)
                Next j
            Next I

            'FOOTER (TOTAL)
            For k = 0 To colsTotal - 1
                .Cells(rowsTotal + 7, k + 1).value = dt2.Rows(0).Item(k)
                .Range("A" & rowsTotal + 7 & ":N" & rowsTotal + 7).Font.FontStyle = "Bold"
            Next k

        End With
        releaseObject(xlApp)
        releaseObject(excelBook)
        releaseObject(excelWorksheet)

        'Catch ex As Exception


        'releaseObject(xlApp)
        'MsgBox(ex.Message)
        'Exit Sub
        'Finally

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        'End Try


    End Sub

    Private Sub releaseObject(ByVal Obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Obj)
            Obj = Nothing
        Catch ex As Exception
            Obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub btnPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        KoneksiCIM()
        KonCIM.Open()

        perintah = New SqlCommand("EXEC wppc.sp_Rpt_Plan_VS_Actual '" & Format(tgl_input.Value, "dd-MM-yyyy") & "' , '" & grade & "' ", KonCIM)
        DA = New SqlDataAdapter
        DA.SelectCommand = perintah

        DS = New DataSet
        DA.Fill(DS)
        mainreport = DS.Tables(0)
        footer = DS.Tables(1)
        period = DS.Tables(2)
        Call BuatTampilanExcel(mainreport, footer, period)

    End Sub

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged
        grade = "ALL"
    End Sub

    Private Sub rbGarment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGarment.CheckedChanged
        grade = "GARMENT"
    End Sub

    Private Sub rbReguler_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbReguler.CheckedChanged
        grade = "REGULAR"
    End Sub
End Class