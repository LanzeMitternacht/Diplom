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

namespace FlowersShop
{
    public partial class SellProduct : Form
    {
        private readonly int _productId;
        private readonly int _currentUserId;

        public SellProduct(int productId, int currentUserId)
        {
            InitializeComponent();
            _productId = productId;
            _currentUserId = currentUserId;
            
            Logger.LogInfo($"Открыта форма продажи товара ID: {productId}");
            this.Text = "Продажа товара";
        }

        private void BSell_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                int sellQuantity = Convert.ToInt32(TBCount.Text);
                int visitorId = Convert.ToInt32(TBVisitor.Text);

                const string productQuery = "SELECT Name, Type, Price, Count FROM Products WHERE Id = @ProductId";
                var productParams = new Dictionary<string, object> { { "@ProductId", _productId } };
                var productResult = DatabaseManager.ExecuteQuery(productQuery, productParams);

                if (productResult.Rows.Count == 0)
                {
                    MessageBox.Show("Товар не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var productRow = productResult.Rows[0];
                string productName = productRow["Name"].ToString();
                string productType = productRow["Type"].ToString();
                decimal productPrice = Convert.ToDecimal(productRow["Price"]);
                int availableCount = Convert.ToInt32(productRow["Count"]);

                if (availableCount < sellQuantity)
                {
                    MessageBox.Show($"Недостаточно товара в наличии. Доступно: {availableCount}", 
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                const string visitorCheckQuery = "SELECT COUNT(*) FROM Visitors WHERE Id = @VisitorId";
                var visitorCheckParams = new Dictionary<string, object> { { "@VisitorId", visitorId } };
                var visitorExists = Convert.ToInt32(DatabaseManager.ExecuteScalar(visitorCheckQuery, visitorCheckParams)) > 0;

                if (!visitorExists)
                {
                    MessageBox.Show("Посетитель с указанным ID не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int newCount = availableCount - sellQuantity;
                const string updateProductQuery = "UPDATE Products SET Count = @NewCount WHERE Id = @ProductId";
                var updateProductParams = new Dictionary<string, object>
                {
                    { "@NewCount", newCount },
                    { "@ProductId", _productId }
                };

                DatabaseManager.ExecuteNonQuery(updateProductQuery, updateProductParams);

                const string insertArchiveQuery = @"INSERT INTO Archive (Name, Type, Price, Count, VisitorId, StaffId) 
                                                   VALUES (@Name, @Type, @Price, @Count, @VisitorId, @StaffId)";
                var archiveParams = new Dictionary<string, object>
                {
                    { "@Name", productName },
                    { "@Type", productType },
                    { "@Price", productPrice },
                    { "@Count", sellQuantity },
                    { "@VisitorId", visitorId },
                    { "@StaffId", _currentUserId }
                };

                DatabaseManager.ExecuteNonQuery(insertArchiveQuery, archiveParams);

                UpdateVisitorInfo(visitorId);

                Logger.LogUserAction($"ID_{_currentUserId}", $"Продан товар: {productName} (количество: {sellQuantity}) посетителю ID: {visitorId}");
                Logger.LogDatabaseOperation("SELL", "Products", true);

                decimal totalPrice = productPrice * sellQuantity;
                MessageBox.Show($"Продажа успешно завершена!\n" +
                              $"Товар: {productName}\n" +
                              $"Количество: {sellQuantity}\n" +
                              $"Общая стоимость: {totalPrice:C}", 
                              "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при продаже товара", ex);
                MessageBox.Show("Ошибка при продаже товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            var quantityValidation = InputValidator.ValidateQuantity(TBCount.Text);
            if (!quantityValidation.IsValid)
            {
                MessageBox.Show(quantityValidation.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBCount.Focus();
                return false;
            }

            var visitorIdValidation = InputValidator.ValidateId(TBVisitor.Text, "ID посетителя");
            if (!visitorIdValidation.IsValid)
            {
                MessageBox.Show(visitorIdValidation.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBVisitor.Focus();
                return false;
            }

            return true;
        }

        private void UpdateVisitorInfo(int visitorId)
        {
            try
            {
                const string getVisitorQuery = "SELECT CountVisit, Discount FROM Visitors WHERE Id = @VisitorId";
                var getVisitorParams = new Dictionary<string, object> { { "@VisitorId", visitorId } };
                var visitorResult = DatabaseManager.ExecuteQuery(getVisitorQuery, getVisitorParams);

                if (visitorResult.Rows.Count > 0)
                {
                    var visitorRow = visitorResult.Rows[0];
                    int currentVisits = Convert.ToInt32(visitorRow["CountVisit"]);
                    bool currentDiscount = Convert.ToBoolean(visitorRow["Discount"]);

                    int newVisits = currentVisits + 1;
                    bool newDiscount = currentDiscount || (newVisits > 5);

                    const string updateVisitorQuery = @"UPDATE Visitors 
                                                       SET CountVisit = @CountVisit, Discount = @Discount 
                                                       WHERE Id = @VisitorId";
                    var updateVisitorParams = new Dictionary<string, object>
                    {
                        { "@CountVisit", newVisits },
                        { "@Discount", newDiscount },
                        { "@VisitorId", visitorId }
                    };

                    DatabaseManager.ExecuteNonQuery(updateVisitorQuery, updateVisitorParams);

                    if (!currentDiscount && newDiscount)
                    {
                        Logger.LogInfo($"Посетитель ID: {visitorId} получил скидку после {newVisits} посещений");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при обновлении информации о посетителе", ex);
            }
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Форма продажи товара закрыта без совершения продажи");
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TBVisitor_TextChanged(object sender, EventArgs e)
        {
            // TODO: Нужна ли валидность в РЛ
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Logger.LogInfo("Форма продажи товара закрыта");
            base.OnFormClosed(e);
        }
    }
}
