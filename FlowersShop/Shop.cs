using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;


namespace FlowersShop
{
    public partial class Shop : Form
    {
        private readonly int _currentUserId;
        private readonly string _currentUserName;
        private DataSet dataSet;
        private SqlDataAdapter sqlAdapter;
        
        public Shop(int userId, string userName)
        {
            InitializeComponent();
            _currentUserId = userId;
            _currentUserName = userName;
            
            Logger.LogInfo($"Открыта главная форма магазина пользователем: {userName}");
            
            this.Text = $"FlowersShop - {userName}";
            
            LoadDataProduct();
        }

        private void LoadDataProduct()
        {
            try
            {
                Logger.LogInfo("Загрузка данных о товарах");
                
                DataGridVShop.DataSource = null;
                const string query = "SELECT Id, Name, Type, Price, Count FROM Products ORDER BY Name";
                
                var result = DatabaseManager.ExecuteQuery(query);
                DataGridVShop.DataSource = result;
                DataGridVShop.ReadOnly = true;
                DataGridVShop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridVShop.AllowUserToAddRows = false;
                DataGridVShop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (DataGridVShop.Columns["Id"] != null)
                    DataGridVShop.Columns["Id"].HeaderText = "ID";
                if (DataGridVShop.Columns["Name"] != null)
                    DataGridVShop.Columns["Name"].HeaderText = "Название";
                if (DataGridVShop.Columns["Type"] != null)
                    DataGridVShop.Columns["Type"].HeaderText = "Тип";
                if (DataGridVShop.Columns["Price"] != null)
                    DataGridVShop.Columns["Price"].HeaderText = "Цена";
                if (DataGridVShop.Columns["Count"] != null)
                    DataGridVShop.Columns["Count"].HeaderText = "Количество";

                CBSearch.Items.Clear();
                CBSearch.Items.Add("Name");
                CBSearch.Items.Add("Type");
                if (CBSearch.Items.Count > 0)
                    CBSearch.SelectedIndex = 0;
                
                Logger.LogInfo($"Загружено товаров: {result.Rows.Count}");
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при загрузке данных о товарах", ex);
                MessageBox.Show("Ошибка при загрузке данных о товарах", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataArchive()
        {
            try
            {
                Logger.LogInfo("Загрузка архива продаж");
                
                DataGridArch.DataSource = null;
                const string query = @"SELECT Id, Name, Type, Price, Count, VisitorId, StaffId 
                                      FROM Archive ORDER BY Id DESC";
                
                var result = DatabaseManager.ExecuteQuery(query);
                DataGridArch.DataSource = result;
                DataGridArch.ReadOnly = true;
                DataGridArch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridArch.AllowUserToAddRows = false;
                DataGridArch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (DataGridArch.Columns["Id"] != null)
                    DataGridArch.Columns["Id"].HeaderText = "ID";
                if (DataGridArch.Columns["Name"] != null)
                    DataGridArch.Columns["Name"].HeaderText = "Товар";
                if (DataGridArch.Columns["Type"] != null)
                    DataGridArch.Columns["Type"].HeaderText = "Тип";
                if (DataGridArch.Columns["Price"] != null)
                    DataGridArch.Columns["Price"].HeaderText = "Цена";
                if (DataGridArch.Columns["Count"] != null)
                    DataGridArch.Columns["Count"].HeaderText = "Количество";
                if (DataGridArch.Columns["VisitorId"] != null)
                    DataGridArch.Columns["VisitorId"].HeaderText = "ID Посетителя";
                if (DataGridArch.Columns["StaffId"] != null)
                    DataGridArch.Columns["StaffId"].HeaderText = "ID Сотрудника";

                CBSearch.Items.Clear();
                CBSearch.Items.Add("Name");
                CBSearch.Items.Add("Type");
                if (CBSearch.Items.Count > 0)
                    CBSearch.SelectedIndex = 0;
                
                Logger.LogInfo($"Загружено записей в архиве: {result.Rows.Count}");
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при загрузке архива продаж", ex);
                MessageBox.Show("Ошибка при загрузке архива продаж", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataStaff()
        {
            try
            {
                Logger.LogInfo("Загрузка данных о персонале");
                
                DataGridVStaff.DataSource = null;
                const string query = @"SELECT Id, FName, SName, Post, Phone, Email 
                                      FROM Staff ORDER BY FName, SName";
                
                var result = DatabaseManager.ExecuteQuery(query);
                DataGridVStaff.DataSource = result;
                DataGridVStaff.ReadOnly = true;
                DataGridVStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridVStaff.AllowUserToAddRows = false;
                DataGridVStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (DataGridVStaff.Columns["Id"] != null)
                    DataGridVStaff.Columns["Id"].HeaderText = "ID";
                if (DataGridVStaff.Columns["FName"] != null)
                    DataGridVStaff.Columns["FName"].HeaderText = "Имя";
                if (DataGridVStaff.Columns["SName"] != null)
                    DataGridVStaff.Columns["SName"].HeaderText = "Фамилия";
                if (DataGridVStaff.Columns["Post"] != null)
                    DataGridVStaff.Columns["Post"].HeaderText = "Должность";
                if (DataGridVStaff.Columns["Phone"] != null)
                    DataGridVStaff.Columns["Phone"].HeaderText = "Телефон";
                if (DataGridVStaff.Columns["Email"] != null)
                    DataGridVStaff.Columns["Email"].HeaderText = "Email";

                CBSearch.Items.Clear();
                CBSearch.Items.Add("FName");
                CBSearch.Items.Add("SName");
                CBSearch.Items.Add("Post");
                if (CBSearch.Items.Count > 0)
                    CBSearch.SelectedIndex = 0;
                
                Logger.LogInfo($"Загружено сотрудников: {result.Rows.Count}");
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при загрузке данных о персонале", ex);
                MessageBox.Show("Ошибка при загрузке данных о персонале", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataVisitors()
        {
            try
            {
                Logger.LogInfo("Загрузка данных о посетителях");
                
                DataGirdVVisitor.DataSource = null;
                const string query = @"SELECT Id, FName, SName, CountVisit, Discount 
                                      FROM Visitors ORDER BY FName, SName";
                
                var result = DatabaseManager.ExecuteQuery(query);
                DataGirdVVisitor.DataSource = result;
                DataGirdVVisitor.ReadOnly = true;
                DataGirdVVisitor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGirdVVisitor.AllowUserToAddRows = false;
                DataGirdVVisitor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (DataGirdVVisitor.Columns["Id"] != null)
                    DataGirdVVisitor.Columns["Id"].HeaderText = "ID";
                if (DataGirdVVisitor.Columns["FName"] != null)
                    DataGirdVVisitor.Columns["FName"].HeaderText = "Имя";
                if (DataGirdVVisitor.Columns["SName"] != null)
                    DataGirdVVisitor.Columns["SName"].HeaderText = "Фамилия";
                if (DataGirdVVisitor.Columns["CountVisit"] != null)
                    DataGirdVVisitor.Columns["CountVisit"].HeaderText = "Посещений";
                if (DataGirdVVisitor.Columns["Discount"] != null)
                    DataGirdVVisitor.Columns["Discount"].HeaderText = "Скидка";

                CBSearch.Items.Clear();
                CBSearch.Items.Add("FName");
                CBSearch.Items.Add("SName");
                if (CBSearch.Items.Count > 0)
                    CBSearch.SelectedIndex = 0;
                
                Logger.LogInfo($"Загружено посетителей: {result.Rows.Count}");
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при загрузке данных о посетителях", ex);
                MessageBox.Show("Ошибка при загрузке данных о посетителях", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAddProd_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.LogUserAction(_currentUserName, "Открытие формы добавления товара");
                var addProduct = new AddProduct();
                if (addProduct.ShowDialog() == DialogResult.OK)
                {
                    LoadDataProduct();
                    Logger.LogUserAction(_currentUserName, "Товар успешно добавлен");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при добавлении товара", ex);
                MessageBox.Show("Ошибка при добавлении товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAddStaff_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.LogUserAction(_currentUserName, "Открытие формы добавления сотрудника");
                var addStaff = new AddStaff();
                if (addStaff.ShowDialog() == DialogResult.OK)
                {
                    LoadDataStaff();
                    Logger.LogUserAction(_currentUserName, "Сотрудник успешно добавлен");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при добавлении сотрудника", ex);
                MessageBox.Show("Ошибка при добавлении сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAddVisitor_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.LogUserAction(_currentUserName, "Открытие формы добавления посетителя");
                var addVisitor = new AddVisitor();
                if (addVisitor.ShowDialog() == DialogResult.OK)
                {
                    LoadDataVisitors();
                    Logger.LogUserAction(_currentUserName, "Посетитель успешно добавлен");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при добавлении посетителя", ex);
                MessageBox.Show("Ошибка при добавлении посетителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEditProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridVShop.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите товар для редактирования", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = DataGridVShop.SelectedRows[0].Cells["Id"].Value;
                if (selectedId == null)
                {
                    MessageBox.Show("Не удалось получить ID товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Logger.LogUserAction(_currentUserName, $"Редактирование товара ID: {selectedId}");
                
                const string query = "SELECT * FROM Products WHERE Id = @Id";
                var parameters = new Dictionary<string, object> { { "@Id", selectedId } };
                
                using (var connection = DatabaseManager.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedId);
                        using (var reader = command.ExecuteReader())
                        {
                            var addProduct = new AddProduct(true, reader);
                            if (addProduct.ShowDialog() == DialogResult.OK)
                            {
                                LoadDataProduct();
                                Logger.LogUserAction(_currentUserName, $"Товар ID: {selectedId} успешно отредактирован");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при редактировании товара", ex);
                MessageBox.Show("Ошибка при редактировании товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEditStaff_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridVStaff.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите сотрудника для редактирования", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = DataGridVStaff.SelectedRows[0].Cells["Id"].Value;
                if (selectedId == null)
                {
                    MessageBox.Show("Не удалось получить ID сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Logger.LogUserAction(_currentUserName, $"Редактирование сотрудника ID: {selectedId}");
                
                const string query = "SELECT * FROM Staff WHERE Id = @Id";
                
                using (var connection = DatabaseManager.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedId);
                        using (var reader = command.ExecuteReader())
                        {
                            var addStaff = new AddStaff(true, reader);
                            if (addStaff.ShowDialog() == DialogResult.OK)
                            {
                                LoadDataStaff();
                                Logger.LogUserAction(_currentUserName, $"Сотрудник ID: {selectedId} успешно отредактирован");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при редактировании сотрудника", ex);
                MessageBox.Show("Ошибка при редактировании сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEditVisitor_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGirdVVisitor.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите посетителя для редактирования", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = DataGirdVVisitor.SelectedRows[0].Cells["Id"].Value;
                if (selectedId == null)
                {
                    MessageBox.Show("Не удалось получить ID посетителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Logger.LogUserAction(_currentUserName, $"Редактирование посетителя ID: {selectedId}");
                
                const string query = "SELECT * FROM Visitors WHERE Id = @Id";
                
                using (var connection = DatabaseManager.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedId);
                        using (var reader = command.ExecuteReader())
                        {
                            var addVisitor = new AddVisitor(true, reader);
                            if (addVisitor.ShowDialog() == DialogResult.OK)
                            {
                                LoadDataVisitors();
                                Logger.LogUserAction(_currentUserName, $"Посетитель ID: {selectedId} успешно отредактирован");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при редактировании посетителя", ex);
                MessageBox.Show("Ошибка при редактировании посетителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabCMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabCMain.SelectedIndex == 0)
                LoadDataProduct();
            else if (TabCMain.SelectedIndex == 1)
                LoadDataArchive();
            else if (TabCMain.SelectedIndex == 2)
                LoadDataStaff();
            else if (TabCMain.SelectedIndex == 3)
                LoadDataVisitors();
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = "";
                int selectedId = 0;
                string itemName = "";
                
                switch (TabCMain.SelectedIndex)
                {
                    case 0: // Products
                        if (DataGridVShop.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Выберите товар для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        tableName = "Products";
                        selectedId = Convert.ToInt32(DataGridVShop.SelectedRows[0].Cells["Id"].Value);
                        itemName = DataGridVShop.SelectedRows[0].Cells["Name"].Value?.ToString() ?? "товар";
                        break;
                        
                    case 1: // Archive
                        if (DataGridArch.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Выберите запись архива для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        tableName = "Archive";
                        selectedId = Convert.ToInt32(DataGridArch.SelectedRows[0].Cells["Id"].Value);
                        itemName = DataGridArch.SelectedRows[0].Cells["Name"].Value?.ToString() ?? "запись архива";
                        break;
                        
                    case 2: // Staff
                        if (DataGridVStaff.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Выберите сотрудника для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        tableName = "Staff";
                        selectedId = Convert.ToInt32(DataGridVStaff.SelectedRows[0].Cells["Id"].Value);
                        itemName = $"{DataGridVStaff.SelectedRows[0].Cells["FName"].Value} {DataGridVStaff.SelectedRows[0].Cells["SName"].Value}";
                        break;
                        
                    case 3: // Visitors
                        if (DataGirdVVisitor.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Выберите посетителя для удаления", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        tableName = "Visitors";
                        selectedId = Convert.ToInt32(DataGirdVVisitor.SelectedRows[0].Cells["Id"].Value);
                        itemName = $"{DataGirdVVisitor.SelectedRows[0].Cells["FName"].Value} {DataGirdVVisitor.SelectedRows[0].Cells["SName"].Value}";
                        break;
                        
                    default:
                        MessageBox.Show("Неизвестная вкладка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                var result = MessageBox.Show($"Вы действительно хотите удалить '{itemName}'?", 
                                           "Подтверждение удаления", 
                                           MessageBoxButtons.YesNo, 
                                           MessageBoxIcon.Question);
                
                if (result != DialogResult.Yes)
                    return;

                string deleteQuery = $"DELETE FROM {tableName} WHERE Id = @Id";
                var parameters = new Dictionary<string, object>
                {
                    { "@Id", selectedId }
                };

                var rowsAffected = DatabaseManager.ExecuteNonQuery(deleteQuery, parameters);
                
                if (rowsAffected > 0)
                {
                    Logger.LogUserAction(_currentUserName, $"Удален элемент '{itemName}' из таблицы {tableName}");
                    Logger.LogDatabaseOperation("DELETE", tableName, true);
                    
                    switch (TabCMain.SelectedIndex)
                    {
                        case 0:
                            LoadDataProduct();
                            break;
                        case 1:
                            LoadDataArchive();
                            break;
                        case 2:
                            LoadDataStaff();
                            break;
                        case 3:
                            LoadDataVisitors();
                            break;
                    }
                    
                    MessageBox.Show($"'{itemName}' успешно удален", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Logger.LogDatabaseOperation("DELETE", tableName, false);
                    MessageBox.Show("Не удалось удалить запись", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при удалении записи", ex);
                MessageBox.Show("Ошибка при удалении записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BSell_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridVShop.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите товар для продажи", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = DataGridVShop.SelectedRows[0].Cells["Id"].Value;
                if (selectedId == null)
                {
                    MessageBox.Show("Не удалось получить ID товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int productId = Convert.ToInt32(selectedId);
                string productName = DataGridVShop.SelectedRows[0].Cells["Name"].Value?.ToString() ?? "товар";
                
                Logger.LogUserAction(_currentUserName, $"Открытие формы продажи товара: {productName} (ID: {productId})");
                
                var sellProduct = new SellProduct(productId, _currentUserId);
                if (sellProduct.ShowDialog() == DialogResult.OK)
                {
                    LoadDataProduct();
                    Logger.LogUserAction(_currentUserName, $"Продажа товара завершена: {productName}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при открытии формы продажи", ex);
                MessageBox.Show("Ошибка при открытии формы продажи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Logger.LogUserAction(_currentUserName, "Закрытие главной формы магазина");
            Logger.LogInfo($"Пользователь {_currentUserName} завершил работу с приложением");
            Close();
        }
        
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Logger.LogInfo("Главная форма магазина закрыта");
            base.OnFormClosed(e);
        }

        private void BTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TBSearch.Text))
                {
                    switch (TabCMain.SelectedIndex)
                    {
                        case 0:
                            LoadDataProduct();
                            break;
                        case 1:
                            LoadDataArchive();
                            break;
                        case 2:
                            LoadDataStaff();
                            break;
                        case 3:
                            LoadDataVisitors();
                            break;
                    }
                    return;
                }

                if (CBSearch.SelectedItem == null)
                {
                    MessageBox.Show("Выберите поле для поиска", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string searchField = CBSearch.SelectedItem.ToString();
                string searchValue = InputValidator.SanitizeInput(TBSearch.Text);
                
                Logger.LogUserAction(_currentUserName, $"Поиск в таблице {TabCMain.SelectedTab.Name} по полю {searchField}: '{searchValue}'");

                string tableName = "";
                string query = "";
                
                switch (TabCMain.SelectedIndex)
                {
                    case 0: 
                        tableName = "Products";
                        query = $"SELECT Id, Name, Type, Price, Count FROM {tableName} WHERE {searchField} LIKE @SearchValue ORDER BY Name";
                        break;
                    case 1: 
                        tableName = "Archive";
                        query = $"SELECT Id, Name, Type, Price, Count, VisitorId, StaffId FROM {tableName} WHERE {searchField} LIKE @SearchValue ORDER BY Id DESC";
                        break;
                    case 2: 
                        tableName = "Staff";
                        query = $"SELECT Id, FName, SName, Post, Phone, Email FROM {tableName} WHERE {searchField} LIKE @SearchValue ORDER BY FName, SName";
                        break;
                    case 3:
                        tableName = "Visitors";
                        query = $"SELECT Id, FName, SName, CountVisit, Discount FROM {tableName} WHERE {searchField} LIKE @SearchValue ORDER BY FName, SName";
                        break;
                    default:
                        MessageBox.Show("Неизвестная вкладка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                var parameters = new Dictionary<string, object>
                {
                    { "@SearchValue", $"%{searchValue}%" }
                };

                var result = DatabaseManager.ExecuteQuery(query, parameters);
                
                switch (TabCMain.SelectedIndex)
                {
                    case 0:
                        DataGridVShop.DataSource = result;
                        SetupGridHeaders(DataGridVShop, "Products");
                        break;
                    case 1:
                        DataGridArch.DataSource = result;
                        SetupGridHeaders(DataGridArch, "Archive");
                        break;
                    case 2:
                        DataGridVStaff.DataSource = result;
                        SetupGridHeaders(DataGridVStaff, "Staff");
                        break;
                    case 3:
                        DataGirdVVisitor.DataSource = result;
                        SetupGridHeaders(DataGirdVVisitor, "Visitors");
                        break;
                }
                
                Logger.LogInfo($"Поиск завершен. Найдено записей: {result.Rows.Count}");
                
                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("По вашему запросу ничего не найдено", "Результат поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при выполнении поиска", ex);
                MessageBox.Show("Ошибка при выполнении поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void SetupGridHeaders(DataGridView grid, string tableName)
        {
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            switch (tableName)
            {
                case "Products":
                    if (grid.Columns["Id"] != null) grid.Columns["Id"].HeaderText = "ID";
                    if (grid.Columns["Name"] != null) grid.Columns["Name"].HeaderText = "Название";
                    if (grid.Columns["Type"] != null) grid.Columns["Type"].HeaderText = "Тип";
                    if (grid.Columns["Price"] != null) grid.Columns["Price"].HeaderText = "Цена";
                    if (grid.Columns["Count"] != null) grid.Columns["Count"].HeaderText = "Количество";
                    break;
                case "Archive":
                    if (grid.Columns["Id"] != null) grid.Columns["Id"].HeaderText = "ID";
                    if (grid.Columns["Name"] != null) grid.Columns["Name"].HeaderText = "Товар";
                    if (grid.Columns["Type"] != null) grid.Columns["Type"].HeaderText = "Тип";
                    if (grid.Columns["Price"] != null) grid.Columns["Price"].HeaderText = "Цена";
                    if (grid.Columns["Count"] != null) grid.Columns["Count"].HeaderText = "Количество";
                    if (grid.Columns["VisitorId"] != null) grid.Columns["VisitorId"].HeaderText = "ID Посетителя";
                    if (grid.Columns["StaffId"] != null) grid.Columns["StaffId"].HeaderText = "ID Сотрудника";
                    break;
                case "Staff":
                    if (grid.Columns["Id"] != null) grid.Columns["Id"].HeaderText = "ID";
                    if (grid.Columns["FName"] != null) grid.Columns["FName"].HeaderText = "Имя";
                    if (grid.Columns["SName"] != null) grid.Columns["SName"].HeaderText = "Фамилия";
                    if (grid.Columns["Post"] != null) grid.Columns["Post"].HeaderText = "Должность";
                    if (grid.Columns["Phone"] != null) grid.Columns["Phone"].HeaderText = "Телефон";
                    if (grid.Columns["Email"] != null) grid.Columns["Email"].HeaderText = "Email";
                    break;
                case "Visitors":
                    if (grid.Columns["Id"] != null) grid.Columns["Id"].HeaderText = "ID";
                    if (grid.Columns["FName"] != null) grid.Columns["FName"].HeaderText = "Имя";
                    if (grid.Columns["SName"] != null) grid.Columns["SName"].HeaderText = "Фамилия";
                    if (grid.Columns["CountVisit"] != null) grid.Columns["CountVisit"].HeaderText = "Посещений";
                    if (grid.Columns["Discount"] != null) grid.Columns["Discount"].HeaderText = "Скидка";
                    break;
            }
        }

        private void BPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.LogUserAction(_currentUserName, $"Создание PDF отчета для таблицы: {TabCMain.SelectedTab.Name}");
                
                var reportPath = PathManager.GetReportPath(TabCMain.SelectedTab.Name);
                var document = new iTextSharp.text.Document();
                
                PdfWriter.GetInstance(document, new FileStream(reportPath, FileMode.Create));
                document.Open();

                var fontPath = PathManager.GetSystemFontPath("arial.ttf");
                BaseFont baseFont;
                
                try
                {
                    baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                }
                catch
                {
                    baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                }
                
                var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                
                DataTable currentTable = null;
                string tableName = TabCMain.SelectedTab.Name;
                
                switch (TabCMain.SelectedIndex)
                {
                    case 0: // Products
                        currentTable = (DataTable)DataGridVShop.DataSource;
                        break;
                    case 1: // Archive
                        currentTable = (DataTable)DataGridArch.DataSource;
                        break;
                    case 2: // Staff
                        currentTable = (DataTable)DataGridVStaff.DataSource;
                        break;
                    case 3: // Visitors
                        currentTable = (DataTable)DataGirdVVisitor.DataSource;
                        break;
                }
                
                if (currentTable != null && currentTable.Rows.Count > 0)
                {
                    var table = new PdfPTable(currentTable.Columns.Count);

                    // Заголовок таблицы
                    var headerCell = new PdfPCell(new iTextSharp.text.Phrase($"Отчет по таблице: {tableName}", font));
                    headerCell.Colspan = currentTable.Columns.Count;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.Border = 0;
                    headerCell.PaddingBottom = 10;
                    table.AddCell(headerCell);

                    // Заголовки колонок
                    foreach (DataColumn column in currentTable.Columns)
                    {
                        var cell = new PdfPCell(new Phrase(column.ColumnName, font));
                        cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    // Данные таблицы
                    foreach (DataRow row in currentTable.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            var cellValue = item?.ToString() ?? "";
                            table.AddCell(new Phrase(cellValue, font));
                        }
                    }

                    document.Add(table);
                    
                    var dateParagraph = new Paragraph($"Отчет создан: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", font);
                    dateParagraph.Alignment = Element.ALIGN_RIGHT;
                    dateParagraph.SpacingBefore = 20;
                    document.Add(dateParagraph);
                    
                    var userParagraph = new Paragraph($"Создал: {_currentUserName}", font);
                    userParagraph.Alignment = Element.ALIGN_RIGHT;
                    document.Add(userParagraph);
                }
                else
                {
                    var noDataParagraph = new Paragraph("Нет данных для отображения", font);
                    noDataParagraph.Alignment = Element.ALIGN_CENTER;
                    document.Add(noDataParagraph);
                }

                document.Close();
                
                Logger.LogUserAction(_currentUserName, $"PDF отчет успешно создан: {reportPath}");
                Logger.LogFileOperation("Создание PDF отчета", reportPath, true);
                
                var result = MessageBox.Show($"Отчет успешно создан:\n{reportPath}\n\nОткрыть файл?", 
                                           "Отчет создан", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(reportPath);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError("Ошибка при открытии PDF файла", ex);
                        MessageBox.Show("Не удалось открыть файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Ошибка при создании PDF отчета", ex);
                MessageBox.Show("Ошибка при создании PDF отчета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
