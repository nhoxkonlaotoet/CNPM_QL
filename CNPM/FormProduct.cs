using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CNPM.BL_Layer;
namespace CNPM
{
    public partial class FormProduct : Form
    {
        bool block, blockType, add, addType;



        public FormProduct()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            btnAddType.Image = Image.FromFile("add.png");
            btnEditType.Image = Image.FromFile("edit.png");
            btnDeleteType.Image = Image.FromFile("delete.png");
            btnSearch.Image = Image.FromFile("search.png");

        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadData();
            // BLProduct db = new BLProduct();
            // Image img = Image.FromFile("binh20l.png");
            // pic.Image = img;
            // string err = "";
            //bool f= db.UpdateProductType("00", "Bình nước 20L", 20, 15000, MyConvert.ImageToByteArray(img), ref err);
            // MessageBox.Show(f.ToString() + err);
        }
        void LoadData()
        {
            BLProduct db = new BLProduct();
            cboTypeId.DataSource = db.TypeSource();
            cboTypeId.DisplayMember = "MaLoai";
            cboTypeId1.DataSource = db.TypeSource();
            cboTypeId1.DisplayMember = "MaLoai";

            dgvProduct.DataSource = db.Products();
            Block = false;
            BlockType = false;
        }






        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvProduct.CurrentCell.RowIndex;
            txtId.Text = dgvProduct.Rows[r].Cells["MaSP"].Value.ToString().Trim();
            txtManufactureDate.Text = ((DateTime)dgvProduct.Rows[r].Cells["NgaySanXuat"].Value).ToString("MM/dd/yyyy");
            txtExpireDate.Text = ((DateTime)dgvProduct.Rows[r].Cells["HanSuDung"].Value).ToString("MM/dd/yyyy");
            cboStatus.SelectedIndex = cboStatus.FindString(dgvProduct.Rows[r].Cells["TrangThai"].Value.ToString());
            cboTypeId.SelectedIndex = cboTypeId.FindString(dgvProduct.Rows[r].Cells["MaLoai"].Value.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add = true;
            txtId.ResetText();
            txtExpireDate.ResetText();
            txtManufactureDate.ResetText();
            Block = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            add = false;
            Block = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dgvProduct.CurrentCell.RowIndex;
            string id = dgvProduct.Rows[r].Cells["MaSP"].Value.ToString();
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn xoá?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string err = null;
            if (traloi == DialogResult.Yes)
            {
                BLProduct db = new BLProduct();
                if (!db.DeleteProduct(id, ref err))
                {
                    MessageBox.Show(err);
                    return;
                }
                LoadData();
                MessageBox.Show("Đã xóa xong!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            string id = txtId.Text;
            string typeId = cboTypeId.Text;
            string manufactureDate = txtManufactureDate.Text;
            string expireDate = txtExpireDate.Text;
            string status = cboStatus.Text;
            BLProduct db = new BLProduct();
            string err = "";
            if (add)
            {
                if (db.InsertProduct(id, status, typeId, manufactureDate, expireDate, ref err))
                {
                    LoadData();
                    MessageBox.Show("Đã thêm");
                }
                else
                {
                    MessageBox.Show(err);
                }
            }
            else
            {
                if (db.UpdateProduct(id, status, typeId, manufactureDate, expireDate, ref err))
                {
                    LoadData();
                    MessageBox.Show("Đã cập nhật");
                }
                else
                    MessageBox.Show(err);

            }
            Block = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Block = false;
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {

            addType = true;
            BlockType = true;
        }

        private void btnEditType_Click(object sender, EventArgs e)
        {
            addType = false;
            BlockType = true;
        }

        private void btnDeleteType_Click(object sender, EventArgs e)
        {
            string typeId = cboTypeId1.Text;
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn muốn xoá?", "Trả lời",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string err = null;
            if (traloi == DialogResult.Yes)
            {
                BLProduct db = new BLProduct();
                if (!db.DeleteProductType(typeId, ref err))
                {
                    MessageBox.Show(err);
                    return;
                }
                LoadData();
                MessageBox.Show("Đã xóa xong!");
            }
        }

        private void btnSaveType_Click(object sender, EventArgs e)
        {
            string typeId = cboTypeId1.Text;
            string typeName = txtTypeName.Text;
            float capacity = float.Parse(txtCapacity.Text);
            int price =int.Parse(txtPrice.Text);
            Image img = pic.Image;
            BLProduct db = new BLProduct();
            string err = "";
            if (addType)
            {
                if (db.InsertProductType(typeId, typeName, capacity, price, MyConvert.ImageToByteArray(img) , ref err))
                {
                    LoadData();
                    MessageBox.Show("Đã thêm");
                }
                else
                {
                    MessageBox.Show(err);
                }
            }
            else
            {
                if (db.UpdateProductType(typeId, typeName, capacity, price, MyConvert.ImageToByteArray(img), ref err))
                {
                    LoadData();
                    MessageBox.Show("Đã cập nhật");
                }
                else
                    MessageBox.Show(err);

            }
            BlockType = false;
        }

        private void btnCancelType_Click(object sender, EventArgs e)
        {
            BlockType = false;
        }
        private void cboTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTypeId1.SelectedIndex = cboTypeId1.FindString(cboTypeId.Text);
        }

        public bool Block
        {
            get
            {
                return block;
            }

            set
            {
                block = value;
                if (block)
                {
                    pnlInfor.Enabled = true;
                    if (add)
                    {
                        txtId.Enabled = true;
                    }
                    else
                        txtId.Enabled = false;
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {

                    pnlInfor.Enabled = false;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    dgvProduct_CellClick(null, null);
                }
            }
        }

        private void cboTypeId1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cboTypeId1.SelectedItem;
            string typeId = (string)drv.Row.ItemArray[0];
            BLProduct db = new BLProduct();
            DataTable dt = db.getType(typeId);
            txtTypeName.Text = dt.Rows[0]["TenLoai"].ToString();
            txtCapacity.Text = dt.Rows[0]["DungTich"].ToString();
            txtPrice.Text = dt.Rows[0]["Gia"].ToString();
            try { pic.Image = MyConvert.ByteArrayToImage((byte[])dt.Rows[0]["Hinh"]); }
            catch { pic.Image = null; }

        }

        private void pic_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try { pic.Image = Image.FromFile(openFileDialog1.FileName); }
            catch { }
        }

        public bool BlockType
        {
            get
            {
                return blockType;
            }

            set
            {
                blockType = value;
                if (blockType)
                {
                    btnAddType.Enabled = false;
                    btnEditType.Enabled = false;
                    btnDeleteType.Enabled = false;
                    pic.Enabled = true;
                    if (addType)
                    {
                        cboTypeId1.DataSource = new List<string>();
                        cboTypeId1.Enabled = true;
                        txtTypeName.ResetText();
                        txtCapacity.ResetText();
                        txtPrice.ResetText();
                        pic.Image = null;
                    }
                    else
                        cboTypeId1.Enabled = false;
                    txtTypeName.Enabled = true;
                    txtCapacity.Enabled = true;
                    txtPrice.Enabled = true;
                    btnSaveType.Enabled = true;
                    btnCancelType.Enabled = true;

                }
                else
                {
                    cboTypeId1.Enabled = true;
                    cboTypeId1.DataSource = new BLProduct().TypeSource();
                    cboTypeId1.DisplayMember = "MaLoai";
                    pic.Enabled = false;
                    btnAddType.Enabled = true;
                    btnEditType.Enabled = true;
                    btnDeleteType.Enabled = true;
                    txtTypeName.Enabled = false;
                    txtCapacity.Enabled = false;
                    txtPrice.Enabled = false;
                    btnSaveType.Enabled = false;
                    btnCancelType.Enabled = false;
                }
            }
        }

    }
}
