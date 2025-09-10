namespace test;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";

        this.lblEmpId = new System.Windows.Forms.Label();
        this.lblerror = new System.Windows.Forms.Label();
        this.lblEmpName = new System.Windows.Forms.Label();
        this.lblsalary = new System.Windows.Forms.Label();
        this.txtEmpId = new System.Windows.Forms.TextBox();
        this.txtEmpName = new System.Windows.Forms.TextBox();
        this.txtSalary = new System.Windows.Forms.TextBox();
        this.txtSearch = new System.Windows.Forms.TextBox();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnUpdate = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnView = new System.Windows.Forms.Button();
        this.dgvEmployees = new System.Windows.Forms.DataGridView();


        this.lblEmpId.AutoSize = true;
        this.lblEmpId.Location = new System.Drawing.Point(30, 20);
        this.lblEmpId.Name = "lblEmpId";
        this.lblEmpId.Size = new System.Drawing.Size(55, 17);
        this.lblEmpId.Text = "Emp ID";

        this.lblEmpName.AutoSize = true;
        this.lblEmpName.Location = new System.Drawing.Point(30, 60);
        this.lblEmpName.Name = "1blEmpName";
        this.lblEmpName.Size = new System.Drawing.Size(77, 17);
        this.lblEmpName.Text = "Emp Name";


        this.lblerror.AutoSize = true;
        this.lblerror.Location = new System.Drawing.Point(100,450);
        this.lblerror.Name = "1blerror";
        this.lblerror.Size = new System.Drawing.Size(77, 17);
        

        this.lblsalary.AutoSize = true;
        this.lblsalary.Location = new System.Drawing.Point(30, 100);
        this.lblsalary.Name = "1blSalary";
        this.lblsalary.Size = new System.Drawing.Size(48, 17);
        this.lblsalary.Text = "Salary";

        this.lblcountry = new System.Windows.Forms.Label(); 
        this.lblcountry.AutoSize = true;
        this.lblcountry.Location = new System.Drawing.Point(30, 150);
        this.lblcountry.Name = "1blcountry";
        this.lblcountry.Size = new System.Drawing.Size(48, 17);
        this.lblcountry.Text = "Country";

        this.txtEmpId.Location = new System.Drawing.Point(170, 17);
        this.txtEmpId.Name = "txtEmpId";
        this.txtEmpId.Size = new System.Drawing.Size(150, 22);

        this.txtEmpName.Location = new System.Drawing.Point(170, 57);
        this.txtEmpName.Name = "txtEmpName";
        this.txtEmpName.Size = new System.Drawing.Size(150, 22);

        this.txtSalary.Location = new System.Drawing.Point(170, 97);
        this.txtSalary.Name = "txtSalary";
        this.txtSalary.Size = new System.Drawing.Size(150, 22);

        this.cmbcountry = new System.Windows.Forms.ComboBox();        
        this.cmbcountry.FormattingEnabled = true;
        this.cmbcountry.Location = new System.Drawing.Point(170,147);
        this.cmbcountry.Name = "cmbcountry";
        this.cmbcountry.Size = new System.Drawing.Size(200, 24);
        this.cmbcountry.TabIndex = 0;
        this.cmbcountry.DropDownStyle = ComboBoxStyle.DropDownList;
        this.Controls.Add(this.cmbcountry);

        this.txtSearch.Location = new System.Drawing.Point(170, 187);
        this.txtSearch.Name = "txtSearch";
        this.txtSearch.Size = new System.Drawing.Size(150, 22);
        this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

        

        this.btnAdd.Location = new System.Drawing.Point(390, 17);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(100, 35);
        this.btnAdd.Text = "Add";
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        this.btnUpdate.Location = new System.Drawing.Point(390, 57);
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Size = new System.Drawing.Size(100, 45);
        this.btnUpdate.Text = "Update";
        this.btnUpdate.UseVisualStyleBackColor = true;
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

        this.btnDelete.Location = new System.Drawing.Point(390, 107);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(100, 45);
        this.btnDelete.Text = "Delete";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

        this.btnView.Location = new System.Drawing.Point(390, 157);
        this.btnView.Name = "btnView";
        this.btnView.Size = new System.Drawing.Size(100, 45);
        this.btnView.Text = "View All";
        this.btnView.UseVisualStyleBackColor = true;
        this.btnView.Click += new System.EventHandler(this.btnView_Click);


        this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvEmployees.Location = new System.Drawing.Point(30, 240);
        this.dgvEmployees.Name = "dgvEmployees";
        this.dgvEmployees.RowHeadersWidth = 51;
        this.dgvEmployees.Size = new System.Drawing.Size(500, 200);
        this.dgvEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellClick);
        this.ClientSize = new System.Drawing.Size(600, 450);
        this.Controls.Add(this.dgvEmployees);
        this.Controls.Add(this.btnView);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnUpdate);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.txtSalary);
        this.Controls.Add(this.txtSearch);
        this.Controls.Add(this.txtEmpId);
        this.Controls.Add(this.lblsalary);
        this.Controls.Add(this.txtEmpName);
        this.Controls.Add(this.lblEmpName);
        this.Controls.Add(this.lblEmpId);
        this.Controls.Add(this.lblerror);
        this.Controls.Add(this.lblcountry);
        this.Name = "FrmEmployee";
        this.Text = "Employee Management";



    }

    private ComboBox cmbcountry;
    private DataGridView dgvEmployees;
    private Button btnAdd, btnUpdate, btnDelete, btnView;
    private TextBox txtEmpId, txtSalary, txtEmpName,txtSearch;
    private Label lblEmpName, lblEmpId, lblsalary,lblcountry,lblerror;
    #endregion
}
