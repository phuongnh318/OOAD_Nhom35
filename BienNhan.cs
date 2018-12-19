using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvanceDB
{
    public partial class BienNhan : Form
    {
        string tenThanhVien;
        double tien;
        List<ThongTinBienNhan> list;
        public BienNhan()
        {
            InitializeComponent();
        }
        public BienNhan(double tien,List<ThongTinBienNhan> list,string tenThanhVien)
        {
            this.tien = tien;
            this.tenThanhVien = tenThanhVien;
            this.list = list;
            InitializeComponent();
        }

        private void BienNhan_Load(object sender, EventArgs e)
        {
            ReportParameter[] reportParameter = new ReportParameter[3];
            reportParameter[0] = new ReportParameter("TenThanhVien");
            reportParameter[1] = new ReportParameter("NgayIn");
            reportParameter[2] = new ReportParameter("tien");
            reportParameter[0].Values.Add(tenThanhVien);
            reportParameter[1].Values.Add(DateTime.Now.ToShortDateString());
            reportParameter[2].Values.Add(tien.ToString());
            ReportDataSource reportDataSource = new ReportDataSource("ThongTinBienNhan", list);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.LocalReport.SetParameters(reportParameter);
            this.reportViewer1.RefreshReport();
            
        }
    }
}
