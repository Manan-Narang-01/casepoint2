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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee
                {
                    EmpId = int.Parse(txtEmpId.Text),
                    EmpName = txtEmpName.Text,
                    EmpSalary = decimal.Parse(txtSalary.Text)
                };
                service.AddEmployee(emp);
                MessageBox.Show("Inserted!!");
                LoadEmployee();
                clearfields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!! " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {   
                Employee emp = new Employee
                {
                    EmpId = int.Parse(txtEmpId.Text),
                    EmpName = txtEmpName.Text,
                    EmpSalary = decimal.Parse(txtSalary.Text)
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
                    MessageBox.Show("Not Updated!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!! " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Not Deleted!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!! " + ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadEmployee();
        }

         private void LoadEmployee()
        {
            string sql = "SELECT * FROM t1 ORDER BY c_cid";

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
                    MessageBox.Show("Error loading employees: " + ex.Message);
                }
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
