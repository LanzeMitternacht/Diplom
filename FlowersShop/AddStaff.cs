using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

// TODO: ПЕРЕДЕЛАТЬ

namespace FlowersShop
{
    public partial class AddStaff : Form
    {
        string sConnection = "Server = Lanze; Database = FlowerShop; Trusted_Connection = True";
        int iId;
        bool bEdit;
        public AddStaff()
        {
            InitializeComponent();
        }
        public AddStaff(bool edit, SqlDataReader sqlData)
        {
            InitializeComponent();
            FormLoading(sqlData);
            bEdit = edit;
            TBPassword.Visible = false;
            LPassword.Visible = false;
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
                    TBPost.Text = sqlData.GetValue(4).ToString();
                    MaskTBPhone.Text = sqlData.GetValue(5).ToString();
                    TBEmail.Text = sqlData.GetValue(6).ToString();
                }
            }
        }

        private void BEnter_Click(object sender, EventArgs e)
        {
            string[] sBadWord = { "SELECT", "DELETE", "UPDATE" };
            string hashPassword = null;
            string sqlExpression;
            
            foreach (var item in sBadWord)
            {
                if (item == TBFName.Text || item == TBPassword.Text)
                {
                    MessageBox.Show("Поля имеют недопустимое значение", "Ошибка");
                    return;
                }
            }
            if (!bEdit) {

                if (TBFName.Text == "" || TBSName.Text == "" || TBPassword.Text == "")
                    MessageBox.Show("Поля пустые", "Ошибка");

                using (SqlConnection sqlConnection = new SqlConnection(sConnection))
            {
                string sQrCode = TBFName.Text + TBPassword.Text;
                QrCodeStaff(sQrCode, TBFName.Text);

                hashPassword = HashPassword(TBPassword.Text);
                sqlExpression = $"INSERT INTO Staff VALUES ('{TBFName.Text}', '{TBSName.Text}', '{hashPassword}', '{TBPost.Text}', '{MaskTBPhone.Text}',  '{TBEmail.Text}')";
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            }
            else{
                if (TBFName.Text == "" || TBSName.Text == "")
                    MessageBox.Show("Поля пустые", "Ошибка");

                sqlExpression = $"UPDATE Staff SET FName = '{TBFName.Text}', SName = '{TBSName.Text}', Post = '{TBPost.Text}', Phone = '{MaskTBPhone.Text}', Email = '{TBEmail.Text}' WHERE Id = {iId}";
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

        public static void QrCodeStaff(string sQrCode, string name)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(sQrCode);
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qrCodeGenerator.CreateQrCode(bytes, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap qrCodeImage = qRCode.GetGraphic(20);
            qrCodeImage.Save($"D:\\VS Studio\\FlowersShop\\qrCode\\{name}.png");
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
