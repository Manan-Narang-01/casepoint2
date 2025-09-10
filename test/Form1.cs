using System.Data;
using Npgsql;

namespace test
{
    public partial class Form1 : Form
    {
        private string connectionstring = "Server=localhost;Port=5432;Database=intern093;User Id=postgres;Password=root";

        private EmployeeService service = new EmployeeService();

        public Form1()
        {
            InitializeComponent();
            LoadEmployee();
            List<string> countries = new List<string>
            {
                "United States", "Canada", "United Kingdom", "Australia", "Germany",
                "India", "China", "Japan", "France", "Brazil", "South Africa"
            };
            cmbcountry.DataSource = countries;

            // lblerror.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string searchText = txtSearch.Text.Trim().ToLower();
            FilterEmployees(searchText);

        }

        private void FilterEmployees(string searchText)
        {

            if (dgvEmployees.DataSource is DataTable dt)
            {
                DataView dataView = new DataView(dt);
                dataView.RowFilter = string.Format("c_name LIKE '%{0}%' OR c_country LIKE '%{0}%'", searchText);
                dgvEmployees.DataSource = dataView;
            }

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";

            if (string.IsNullOrEmpty(txtEmpId.Text) || string.IsNullOrEmpty(txtEmpName.Text) || string.IsNullOrEmpty(txtSalary.Text)) {
                lblerror.Text = "All  fields are required!";
                return;
            }

            if (string.IsNullOrEmpty(txtEmpId.Text))
            {
                lblerror.Text = "Employee ID is required!";
                return;
            }
            if (string.IsNullOrEmpty(txtEmpName.Text))
            {
                lblerror.Text = "Employee Name is required!";
                return;
            }
            if (string.IsNullOrEmpty(txtSalary.Text))
            {
                lblerror.Text = "Salary is required!";
                return;
            }

            try
            {
                Employee emp = new Employee
                {
                    EmpId = int.Parse(txtEmpId.Text),
                    EmpName = txtEmpName.Text,
                    EmpSalary = decimal.Parse(txtSalary.Text),
                    Country = cmbcountry.SelectedItem.ToString()
                };

                service.AddEmployee(emp);
                MessageBox.Show("Inserted!!");
                LoadEmployee();
                clearfields();
            }
            catch (FormatException)
            {
                lblerror.Text = "Please enter valid values for Employee ID and Salary.";
            }
            catch (Exception ex)
            {
                lblerror.Text = "Error: " + ex.Message;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";

            if (string.IsNullOrEmpty(txtEmpId.Text))
            {
                lblerror.Text = "Employee ID is required!";
                return;
            }
            if (string.IsNullOrEmpty(txtEmpName.Text))
            {
                lblerror.Text = "Employee Name is required!";
                return;
            }
            if (string.IsNullOrEmpty(txtSalary.Text))
            {
                lblerror.Text = "Salary is required!";
                return;
            }

            try
            {
                Employee emp = new Employee
                {
                    EmpId = int.Parse(txtEmpId.Text),
                    EmpName = txtEmpName.Text,
                    EmpSalary = decimal.Parse(txtSalary.Text),
                    Country = cmbcountry.SelectedItem.ToString()
                };

                bool updated = service.UpdateEmployee(emp);
                if (updated)
                {
                    MessageBox.Show("Updated!!");
                    LoadEmployee();
                    clearfields();
                }
                else
                {
                    lblerror.Text = "Failed to update employee. Please try again.";
                }
            }
            catch (FormatException)
            {
                lblerror.Text = "Please enter valid values for Employee ID and Salary.";
            }
            catch (Exception ex)
            {
                lblerror.Text = "Error: " + ex.Message;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";

            if (string.IsNullOrEmpty(txtEmpId.Text))
            {
                lblerror.Text = "Employee ID is required to delete!";
                return;
            }

            try
            {
                int EmpId = int.Parse(txtEmpId.Text);
                bool deleted = service.DeleteEmployee(EmpId);
                if (deleted)
                {
                    MessageBox.Show("Deleted!!");
                    LoadEmployee();
                    clearfields();
                }
                else
                {
                    lblerror.Text = "Failed to delete employee. Please try again.";
                }
            }
            catch (FormatException)
            {
                lblerror.Text = "Please enter a valid Employee ID.";
            }
            catch (Exception ex)
            {
                lblerror.Text = "Error: " + ex.Message;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";
            LoadEmployee();
        }

        private void LoadEmployee()
        {
            string sql = "SELECT *,(SELECT SUM(c_balance) FROM t1) AS TotalSalary FROM t1 ORDER BY c_cid;";
            using (var connection = new NpgsqlConnection(connectionstring))
            using (var cmd = new NpgsqlCommand(sql, connection))
            {
                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dgvEmployees.DataSource = dt;

               
                }
                catch (Exception ex)
                {
                    lblerror.Text = "Error loading employees: " + ex.Message;
                }
            }
        }
        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;


                txtEmpId.Text = dgvEmployees.Rows[rowIndex].Cells["c_cid"].Value?.ToString() ?? string.Empty;

                txtEmpName.Text = dgvEmployees.Rows[rowIndex].Cells["c_name"].Value?.ToString() ?? string.Empty;

                var balanceValue = dgvEmployees.Rows[rowIndex].Cells["c_balance"].Value?.ToString();
                cmbcountry.SelectedItem = dgvEmployees.Rows[rowIndex].Cells["c_country"].Value?.ToString() ?? string.Empty;

                if (decimal.TryParse(balanceValue, out decimal salary))
                {
                    txtSalary.Text = salary.ToString();
                }
                else
                {
                    txtSalary.Clear();
                }
            }
            else
            {

                clearfields();
            }

        }


        private void clearfields()
        {
            txtEmpId.Clear();
            txtEmpName.Clear();
            txtSalary.Clear();
        }

    }

}
