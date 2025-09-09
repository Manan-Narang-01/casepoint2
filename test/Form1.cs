namespace test
{
    public partial class Form1 : Form
    {
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
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = service.GetAllEmployee();
        }

        private void clearfields()
        {
            txtEmpId.Clear();
            txtEmpName.Clear();
            txtSalary.Clear();
        }
    }
}
