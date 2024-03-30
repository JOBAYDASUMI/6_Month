using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar.Reports
{
    public partial class SecondReporForm : Form
    {
        public SecondReporForm()
        {
            InitializeComponent();
        }

        private void SecondReporForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Customers", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Customers");
                    da.SelectCommand.CommandText = "SELECT * FROM Vehicles";
                    da.Fill(ds, "Vehicles");
                    da.SelectCommand.CommandText = "SELECT * FROM Orders";
                    da.Fill(ds, "Orders");
                    da.SelectCommand.CommandText = "SELECT * FROM OrderItems";
                    da.Fill(ds, "OrderItems");
                    SecondReport rtp = new SecondReport();
                    rtp.SetDataSource(ds);
                    this.crystalReportViewer1.ReportSource = rtp;
                    this.crystalReportViewer1.Refresh();

                }
            }
        }
    }
}
