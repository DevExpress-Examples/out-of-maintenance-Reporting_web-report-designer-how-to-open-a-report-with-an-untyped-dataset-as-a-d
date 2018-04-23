Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.XtraReports.Native
Imports DevExpress.XtraReports.UI

Namespace WebEUD
    Partial Public Class WebForm1
        Inherits System.Web.UI.Page

        Shared Sub New()
            SerializationService.RegisterSerializer(CustomUntypedDataSetSerializer.Name, New CustomUntypedDataSetSerializer())
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim report As XtraReport = GetReport()
            ASPxReportDesigner1.OpenReport(report)
        End Sub
        Private Shared Function GetReport() As XtraReport
            Dim report As New XtraReport()
            InitDataSource(report)
            InitControls(report)
            InitExtensions(report)
            Return report
        End Function
        Private Shared Sub InitExtensions(ByVal report As XtraReport)
           report.Extensions(SerializationService.Guid) = CustomUntypedDataSetSerializer.Name
        End Sub
        Private Shared Sub InitDataSource(ByVal report As XtraReport)
            report.DataSource = DataSourceInitializer.GetData()
        End Sub
        Private Shared Sub InitControls(ByVal report As XtraReport)
            Dim lbl As New XRLabel()
            lbl.LocationF = New System.Drawing.PointF(0, 0)
            lbl.SizeF = New System.Drawing.SizeF(200, 20)
            lbl.DataBindings.Add(New XRBinding("Text", Nothing, "TaxType"))

            If report.Bands(BandKind.Detail) Is Nothing Then
                report.Bands.Add(New DetailBand())
            End If
            report.Bands(BandKind.Detail).Controls.Add(lbl)
        End Sub
    End Class
End Namespace