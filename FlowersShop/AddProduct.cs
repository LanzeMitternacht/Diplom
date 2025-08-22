using BarcodeStandard;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Converters;

namespace FlowersShop
{
    public partial class AddProduct : Form
    {
        private bool _isEditMode = false;
        private int _productId = 0;
        
        public AddProduct()
        {
            InitializeComponent();
            InitializeForm();
            Logger.LogInfo("Открыта форма добавления товара");
        }
        public AddProduct(bool edit, SqlDataReader sqlData)
        {
            InitializeComponent();
            InitializeForm();
            _isEditMode = edit;
            LoadFormData(sqlData);
            Logger.LogInfo($"Открыта форма редактирования товара ID: {_productId}");
        }
        
        private void InitializeForm()
        {
            string[] productTypes = { "Цветы", "Декорации", "Садовая утварь" };
            CBType.Items.AddRange(productTypes);
            CBType.SelectedIndex = 0;
            
            this.Text = _isEditMode ? "Редактирование товара" : "Добавление товара";
        }

        private void LoadFormData(SqlDataReader sqlData)
        {
            try
            {
                using (sqlData)
                {
                    if (sqlData.Read())
                    {
                        _productId = Convert.ToInt32(sqlData["Id"]);
                        TBName.Text = sqlData["Name"].ToString();
                        CBType.Text = sqlData["Type"].ToString();
                        TBPrice.Text = sqlData["Price"].ToString();
                        TBCount.Text = sqlData["Count"].ToString();
                        
                        Logger.LogInfo($"Загружены данные товара ID: {_productId}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при загрузке данных товара", ex);
                MessageBox.Show("Ошибка при загрузке данных товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                var name = InputValidator.SanitizeInput(TBName.Text);
                var type = CBType.Text;
                var price = Convert.ToDecimal(TBPrice.Text);
                var count = Convert.ToInt32(TBCount.Text);

                if (!_isEditMode)
                {
                    const string insertQuery = @"INSERT INTO Products (Name, Type, Price, Count) 
                                               VALUES (@Name, @Type, @Price, @Count)";
                    
                    var parameters = new Dictionary<string, object>
                    {
                        { "@Name", name },
                        { "@Type", type },
                        { "@Price", price },
                        { "@Count", count }
                    };

                    var rowsAffected = DatabaseManager.ExecuteNonQuery(insertQuery, parameters);
                    
                    if (rowsAffected > 0)
                    {
                        CreateBarcode(name);
                        
                        Logger.LogDatabaseOperation("INSERT", "Products", true);
                        Logger.LogInfo($"Добавлен новый товар: {name}");
                        
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Logger.LogDatabaseOperation("INSERT", "Products", false);
                        MessageBox.Show("Не удалось добавить товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    const string updateQuery = @"UPDATE Products 
                                               SET Name = @Name, Type = @Type, Price = @Price, Count = @Count 
                                               WHERE Id = @Id";
                    
                    var parameters = new Dictionary<string, object>
                    {
                        { "@Name", name },
                        { "@Type", type },
                        { "@Price", price },
                        { "@Count", count },
                        { "@Id", _productId }
                    };

                    var rowsAffected = DatabaseManager.ExecuteNonQuery(updateQuery, parameters);
                    
                    if (rowsAffected > 0)
                    {
                        Logger.LogDatabaseOperation("UPDATE", "Products", true);
                        Logger.LogInfo($"Обновлен товар ID: {_productId}, Название: {name}");
                        
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Logger.LogDatabaseOperation("UPDATE", "Products", false);
                        MessageBox.Show("Не удалось обновить товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при сохранении товара", ex);
                MessageBox.Show("Ошибка при сохранении товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool ValidateInput()
        {
            var nameValidation = InputValidator.ValidateProductName(TBName.Text);
            if (!nameValidation.IsValid)
            {
                MessageBox.Show(nameValidation.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBName.Focus();
                return false;
            }

            var typeValidation = InputValidator.ValidateProductType(CBType.Text);
            if (!typeValidation.IsValid)
            {
                MessageBox.Show(typeValidation.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBType.Focus();
                return false;
            }

            var priceValidation = InputValidator.ValidatePrice(TBPrice.Text);
            if (!priceValidation.IsValid)
            {
                MessageBox.Show(priceValidation.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBPrice.Focus();
                return false;
            }

            var countValidation = InputValidator.ValidateQuantity(TBCount.Text);
            if (!countValidation.IsValid)
            {
                MessageBox.Show(countValidation.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBCount.Focus();
                return false;
            }

            return true;
        }
        
        private void CreateBarcode(string productName)
        {
            try
            {
                var barcodePath = PathManager.GetBarcodePath(productName);
                
                var barcode = new Barcode();
                barcode.IncludeLabel = true;
                
                var barcodeData = Math.Abs(productName.GetHashCode()).ToString().PadLeft(12, '0');
                if (barcodeData.Length > 12)
                    barcodeData = barcodeData.Substring(0, 12);
                
                var skImage = barcode.Encode(BarcodeStandard.Type.UpcA, barcodeData, SKColors.Black, SKColors.White, 290, 120);
                
                using (var fileStream = new FileStream(barcodePath, FileMode.Create))
                {
                    var image = SKImage.FromBitmap(new SKBitmap(skImage.Info));
                    var encodedImage = image.Encode(SKEncodedImageFormat.Png, 100);
                    encodedImage.SaveTo(fileStream);
                }
                
                Logger.LogFileOperation("Создание штрих-кода", barcodePath, true);
                Logger.LogInfo($"Создан штрих-код для товара: {productName}");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Ошибка при создании штрих-кода для товара: {productName}", ex);
            }
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Форма добавления/редактирования товара закрыта без сохранения");
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Logger.LogInfo("Форма добавления/редактирования товара закрыта");
            base.OnFormClosed(e);
        }

    }
}
