using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace MacroManager
{
    public partial class DbSelector : Form
    {
        private readonly string _dbFilePath;
        private List<string> _savedDbs = new List<string>();

        public string SelectedDatabase { get; private set; } = string.Empty;

        public DbSelector()
        {
            InitializeComponent();

            // Ensure combo box allows typing
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;

            _dbFilePath = Path.Combine(Application.UserAppDataPath, "databases.json");
            LoadSavedDbs();
        }

        private void DbSelector_Load(object sender, EventArgs e)
        {
            // If there are items, select the first by default
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void btnConfirmDb_Click(object sender, EventArgs e)
        {
            var text = comboBox1.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Please enter or select a database.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedDatabase = text;

            // Persist new entry if it's not already saved
            if (!_savedDbs.Contains(text, StringComparer.OrdinalIgnoreCase))
            {
                _savedDbs.Add(text);

                // Add to UI if not already present (case-insensitive)
                bool existsInUi = comboBox1.Items.Cast<object>()
                    .Any(i => string.Equals(i?.ToString(), text, StringComparison.OrdinalIgnoreCase));
                if (!existsInUi)
                {
                    comboBox1.Items.Add(text);
                }

                SaveSavedDbs();
            }
            //go open and change the other files as needed
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadSavedDbs()
        {
            try
            {
                if (File.Exists(_dbFilePath))
                {
                    var json = File.ReadAllText(_dbFilePath);
                    var list = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                    _savedDbs = list;
                }
            }
            catch (Exception ex)
            {
                // Non-fatal: log for debugging
                System.Diagnostics.Debug.WriteLine($"Failed to load saved DBs: {ex.Message}");
                _savedDbs = new List<string>();
            }

            // Merge into combo box without duplicating existing designer items
            foreach (var db in _savedDbs)
            {
                bool exists = comboBox1.Items.Cast<object>()
                    .Any(i => string.Equals(i?.ToString(), db, StringComparison.OrdinalIgnoreCase));
                if (!exists)
                {
                    comboBox1.Items.Add(db);
                }
            }
        }

        private void SaveSavedDbs()
        {
            try
            {
                Directory.CreateDirectory(Application.UserAppDataPath);
                var json = JsonSerializer.Serialize(_savedDbs, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_dbFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving databases: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
