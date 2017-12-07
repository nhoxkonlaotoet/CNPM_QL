namespace CNPM
{
    partial class FormOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlInfor = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.cboEmpID = new System.Windows.Forms.ComboBox();
            this.cboCusID = new System.Windows.Forms.ComboBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveDetail = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.btnCancelDetail = new System.Windows.Forms.Button();
            this.btnRemoveDetail = new System.Windows.Forms.Button();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.cboTypeName = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAvailable = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbIsTransported = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.pnlInfor.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(90, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(350, 37);
            this.label7.TabIndex = 4;
            this.label7.Text = "Sản phẩm trong đơn hàng";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvOrder);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Location = new System.Drawing.Point(12, 274);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(844, 344);
            this.panel3.TabIndex = 4;
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrder.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOrder.Location = new System.Drawing.Point(3, 102);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.Size = new System.Drawing.Size(836, 189);
            this.dgvOrder.TabIndex = 6;
            this.dgvOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(335, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(35, 35);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(557, 297);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 39);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(303, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(275, 37);
            this.label12.TabIndex = 4;
            this.label12.Text = "Danh sách đơn hàng";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(368, 297);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(140, 39);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(176, 297);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 39);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(143, 67);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(185, 29);
            this.txtSearch.TabIndex = 2;
            // 
            // pnlInfor
            // 
            this.pnlInfor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfor.Controls.Add(this.cbIsTransported);
            this.pnlInfor.Controls.Add(this.btnCancel);
            this.pnlInfor.Controls.Add(this.btnSave);
            this.pnlInfor.Controls.Add(this.label6);
            this.pnlInfor.Controls.Add(this.txtEmpName);
            this.pnlInfor.Controls.Add(this.txtCusName);
            this.pnlInfor.Controls.Add(this.cboStatus);
            this.pnlInfor.Controls.Add(this.cboEmpID);
            this.pnlInfor.Controls.Add(this.cboCusID);
            this.pnlInfor.Controls.Add(this.txtDate);
            this.pnlInfor.Controls.Add(this.txtId);
            this.pnlInfor.Controls.Add(this.lblEmpID);
            this.pnlInfor.Controls.Add(this.lblEmpName);
            this.pnlInfor.Controls.Add(this.label13);
            this.pnlInfor.Controls.Add(this.label16);
            this.pnlInfor.Controls.Add(this.label3);
            this.pnlInfor.Controls.Add(this.label14);
            this.pnlInfor.Controls.Add(this.label2);
            this.pnlInfor.Controls.Add(this.label1);
            this.pnlInfor.Location = new System.Drawing.Point(12, 12);
            this.pnlInfor.Name = "pnlInfor";
            this.pnlInfor.Size = new System.Drawing.Size(844, 256);
            this.pnlInfor.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(438, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(188, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 39);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(303, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 37);
            this.label6.TabIndex = 4;
            this.label6.Text = "Thông tin đơn hàng";
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.Color.White;
            this.txtEmpName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpName.Location = new System.Drawing.Point(632, 146);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.ReadOnly = true;
            this.txtEmpName.Size = new System.Drawing.Size(192, 29);
            this.txtEmpName.TabIndex = 2;
            // 
            // txtCusName
            // 
            this.txtCusName.BackColor = System.Drawing.Color.White;
            this.txtCusName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCusName.Location = new System.Drawing.Point(631, 71);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.ReadOnly = true;
            this.txtCusName.Size = new System.Drawing.Size(192, 29);
            this.txtCusName.TabIndex = 2;
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.White;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Enabled = false;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Đã gửi",
            "Đang chuyển",
            "Đã nhận"});
            this.cboStatus.Location = new System.Drawing.Point(132, 146);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(168, 29);
            this.cboStatus.TabIndex = 3;
            // 
            // cboEmpID
            // 
            this.cboEmpID.BackColor = System.Drawing.Color.White;
            this.cboEmpID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEmpID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpID.FormattingEnabled = true;
            this.cboEmpID.Location = new System.Drawing.Point(409, 146);
            this.cboEmpID.Name = "cboEmpID";
            this.cboEmpID.Size = new System.Drawing.Size(94, 29);
            this.cboEmpID.TabIndex = 3;
            this.cboEmpID.SelectedIndexChanged += new System.EventHandler(this.cboEmpID_SelectedIndexChanged);
            // 
            // cboCusID
            // 
            this.cboCusID.BackColor = System.Drawing.Color.White;
            this.cboCusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCusID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCusID.FormattingEnabled = true;
            this.cboCusID.Location = new System.Drawing.Point(409, 71);
            this.cboCusID.Name = "cboCusID";
            this.cboCusID.Size = new System.Drawing.Size(94, 29);
            this.cboCusID.TabIndex = 3;
            this.cboCusID.SelectedIndexChanged += new System.EventHandler(this.cboCusID_SelectedIndexChanged);
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(133, 109);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(167, 29);
            this.txtDate.TabIndex = 2;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(133, 71);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(167, 29);
            this.txtId.TabIndex = 2;
            // 
            // lblEmpID
            // 
            this.lblEmpID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpID.Location = new System.Drawing.Point(318, 136);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(85, 45);
            this.lblEmpID.TabIndex = 1;
            this.lblEmpID.Text = "Nhân viên giao hàng: ";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.Location = new System.Drawing.Point(539, 149);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(64, 21);
            this.lblEmpName.TabIndex = 1;
            this.lblEmpName.Text = "Tên NV:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(538, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 21);
            this.label13.TabIndex = 1;
            this.label13.Text = "Tên khách: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Khách: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(43, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 21);
            this.label14.TabIndex = 1;
            this.label14.Text = "Trạng thái";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thời điểm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã ĐH: ";
            // 
            // btnSaveDetail
            // 
            this.btnSaveDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDetail.Location = new System.Drawing.Point(179, 310);
            this.btnSaveDetail.Name = "btnSaveDetail";
            this.btnSaveDetail.Size = new System.Drawing.Size(117, 39);
            this.btnSaveDetail.TabIndex = 5;
            this.btnSaveDetail.Text = "Lưu";
            this.btnSaveDetail.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(186, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Mặt hàng: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.nudQuantity);
            this.panel1.Controls.Add(this.pic);
            this.panel1.Controls.Add(this.dgvDetail);
            this.panel1.Controls.Add(this.btnCancelDetail);
            this.panel1.Controls.Add(this.btnRemoveDetail);
            this.panel1.Controls.Add(this.btnAddDetail);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnSaveDetail);
            this.panel1.Controls.Add(this.cboTypeName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtCost);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.txtAvailable);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(862, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 606);
            this.panel1.TabIndex = 6;
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.White;
            this.pic.Location = new System.Drawing.Point(3, 85);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(168, 204);
            this.pic.TabIndex = 7;
            this.pic.TabStop = false;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetail.Location = new System.Drawing.Point(3, 364);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersVisible = false;
            this.dgvDetail.Size = new System.Drawing.Size(478, 189);
            this.dgvDetail.TabIndex = 6;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // btnCancelDetail
            // 
            this.btnCancelDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelDetail.Location = new System.Drawing.Point(352, 310);
            this.btnCancelDetail.Name = "btnCancelDetail";
            this.btnCancelDetail.Size = new System.Drawing.Size(117, 39);
            this.btnCancelDetail.TabIndex = 5;
            this.btnCancelDetail.Text = "Hủy";
            this.btnCancelDetail.UseVisualStyleBackColor = true;
            // 
            // btnRemoveDetail
            // 
            this.btnRemoveDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDetail.Location = new System.Drawing.Point(256, 559);
            this.btnRemoveDetail.Name = "btnRemoveDetail";
            this.btnRemoveDetail.Size = new System.Drawing.Size(140, 39);
            this.btnRemoveDetail.TabIndex = 5;
            this.btnRemoveDetail.Text = "Xóa";
            this.btnRemoveDetail.UseVisualStyleBackColor = true;
            this.btnRemoveDetail.Click += new System.EventHandler(this.btnRemoveDetail_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDetail.Location = new System.Drawing.Point(83, 559);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(140, 39);
            this.btnAddDetail.TabIndex = 5;
            this.btnAddDetail.Text = "Thêm";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // cboTypeName
            // 
            this.cboTypeName.BackColor = System.Drawing.Color.White;
            this.cboTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypeName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTypeName.FormattingEnabled = true;
            this.cboTypeName.Location = new System.Drawing.Point(281, 87);
            this.cboTypeName.Name = "cboTypeName";
            this.cboTypeName.Size = new System.Drawing.Size(178, 29);
            this.cboTypeName.TabIndex = 3;
            this.cboTypeName.SelectedIndexChanged += new System.EventHandler(this.cboTypeName_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(186, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "Đơn giá: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(186, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "Số lượng: ";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(281, 208);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(178, 29);
            this.txtPrice.TabIndex = 2;
            // 
            // nudQuantity
            // 
            this.nudQuantity.BackColor = System.Drawing.Color.White;
            this.nudQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantity.Location = new System.Drawing.Point(281, 128);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(97, 29);
            this.nudQuantity.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(186, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 21);
            this.label15.TabIndex = 1;
            this.label15.Text = "Kho còn: ";
            // 
            // txtAvailable
            // 
            this.txtAvailable.BackColor = System.Drawing.Color.White;
            this.txtAvailable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvailable.Location = new System.Drawing.Point(281, 169);
            this.txtAvailable.Name = "txtAvailable";
            this.txtAvailable.Size = new System.Drawing.Size(97, 29);
            this.txtAvailable.TabIndex = 2;
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.Color.White;
            this.txtCost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCost.Location = new System.Drawing.Point(281, 251);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(178, 29);
            this.txtCost.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(186, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "Thành tiền: ";
            // 
            // cbIsTransported
            // 
            this.cbIsTransported.AutoSize = true;
            this.cbIsTransported.Checked = true;
            this.cbIsTransported.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsTransported.Location = new System.Drawing.Point(409, 118);
            this.cbIsTransported.Name = "cbIsTransported";
            this.cbIsTransported.Size = new System.Drawing.Size(15, 14);
            this.cbIsTransported.TabIndex = 6;
            this.cbIsTransported.UseVisualStyleBackColor = true;
            this.cbIsTransported.CheckedChanged += new System.EventHandler(this.cbIsTransported_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(317, 112);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 21);
            this.label16.TabIndex = 1;
            this.label16.Text = "Giao hàng: ";
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 630);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlInfor);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOrder";
            this.Text = "FormOrder";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.pnlInfor.ResumeLayout(false);
            this.pnlInfor.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlInfor;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.ComboBox cboCusID;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveDetail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelDetail;
        private System.Windows.Forms.ComboBox cboTypeName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Button btnRemoveDetail;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.ComboBox cboEmpID;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAvailable;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.CheckBox cbIsTransported;
        private System.Windows.Forms.Label label16;
    }
}