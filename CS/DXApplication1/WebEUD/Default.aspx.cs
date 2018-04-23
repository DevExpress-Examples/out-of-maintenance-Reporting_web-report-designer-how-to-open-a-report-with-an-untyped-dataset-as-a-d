using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.UI;

namespace WebEUD {
    public partial class WebForm1 : System.Web.UI.Page {
        static WebForm1() {
            SerializationService.RegisterSerializer(CustomUntypedDataSetSerializer.Name, new CustomUntypedDataSetSerializer());
        }
        protected void Page_Load(object sender, EventArgs e) {
            XtraReport report = GetReport();
            ASPxReportDesigner1.OpenReport(report);
        }
        private static XtraReport GetReport() {
            XtraReport report = new XtraReport();
            InitDataSource(report);
            InitControls(report);
            InitExtensions(report);
            return report;
        }
        private static void InitExtensions(XtraReport report) {
           report.Extensions[SerializationService.Guid] = CustomUntypedDataSetSerializer.Name;
        }
        private static void InitDataSource(XtraReport report) {
            report.DataSource = DataSourceInitializer.GetData();
        }
        private static void InitControls(XtraReport report) {
            XRLabel lbl = new XRLabel();
            lbl.LocationF = new System.Drawing.PointF(0, 0);
            lbl.SizeF = new System.Drawing.SizeF(200, 20);
            lbl.DataBindings.Add(new XRBinding("Text", null, "TaxType"));
            
            if(report.Bands[BandKind.Detail] == null) {
                report.Bands.Add(new DetailBand());
            }
            report.Bands[BandKind.Detail].Controls.Add(lbl);
        }
    }
}