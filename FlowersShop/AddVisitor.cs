using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

// TODO: ПЕРЕДЕЛАТЬ

namespace FlowersShop
{
    public partial class AddVisitor : Form
    {
        string sConnection = "Server = Lanze; Database = FlowerShop; Trusted_Connection = True";
        bool bEdit = false;
        int iId = 0;
        public AddVisitor()
        {
            InitializeComponent();
            CheckDiscount.Checked = false;
        }
        public AddVisitor(bool edit, SqlDataReader sqlData)
        {
            bEdit = edit;
            InitializeComponent();
            FormLoading(sqlData);
            LCount.Visible = true;
            TBCount.Visible = true;
            CheckDiscount.Visible = true;
        }

        private void FormLoading(SqlDataReader sqlData)
        {
            using (sqlData)
            {
                while (sqlData.Read())
                {
                    iId = (int)sqlData.GetValue(0);
                    TBFName.Text = sqlData.GetValue(1).ToString();
                    TBSName.Text = sqlData.GetValue(2).ToString();
                    TBCount.Text = sqlData.GetValue(3).ToString();
                    CheckDiscount.Checked = (bool)sqlData.GetValue(4);
                }
            }
        }

        private void BEnter_Click(object sender, EventArgs e)
        {
            if (TBFName.Text == "" || TBSName.Text == "")
                return;

            if (!bEdit) { 
                string sqlExpression = $"INSERT INTO Visitors VALUES ('{TBFName.Text}', '{TBSName.Text}', 0, {Convert.ToInt32(CheckDiscount.Checked)})";

                using (SqlConnection sqlConnection = new SqlConnection(sConnection))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            else
            {
                string sqlExpression = $"UPDATE Visitors SET FName = '{TBFName.Text}', SName = '{TBSName.Text}', CountVisit = '{Convert.ToInt32(TBCount.Text)}', Discount = '{CheckDiscount.Checked}' WHERE Id = {iId}";
                using(SqlConnection sqlConnection = new SqlConnection(sConnection))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            Close();
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
