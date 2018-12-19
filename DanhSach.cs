using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;

namespace AdvanceDB
{
    public partial class DanhSach : Form
    {
        MongoClientSettings clientSettings;
        MongoClient client;
        IMongoDatabase db;
        public DanhSach()
        {
            InitializeComponent();
        }
        public DanhSach(MongoClientSettings clientSettings,MongoClient client, IMongoDatabase db)
        {
            this.clientSettings = clientSettings;
            this.client = client;
            this.db = db;
            InitializeComponent();
        }

        /*private void cbDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbDocGia.SelectedIndex == 0)
            {
                var giangvienCollection = db.GetCollection<GiangVien>("GiangVien");
                var query = giangvienCollection.AsQueryable<GiangVien>().ToList();
                dgvDanhSach.DataSource = query;
                
                dgvDanhSach.Columns[1].HeaderText = "Họ tên Giảng Viên";
                dgvDanhSach.Columns[2].HeaderText = "Mã cán bộ";
            }
            else if (cbDocGia.SelectedIndex == 1)
            {
                var sinhvienCollection = db.GetCollection<SinhVien>("SinhVien");
                
                var query = sinhvienCollection.AsQueryable<SinhVien>().ToList();
                dgvDanhSach.DataSource = query;

                dgvDanhSach.Columns[1].HeaderText = "Họ tên Sinh Viên";
                dgvDanhSach.Columns[2].HeaderText = "Mã số sinh siên";
            }
            else
            {
                var sinhvienCollection = db.GetCollection<TuDo>("TuDo");
                var query = sinhvienCollection.AsQueryable<TuDo>().ToList();
                dgvDanhSach.DataSource = query;

            }
            dgvDanhSach.Columns[0].Visible = false;
            dgvDanhSach.Columns[3].HeaderText = "Ngày hết hạn";

        }*/

        private void btnThem_Click(object sender, EventArgs e)
        {
                ThemThanhVien themThanhVien = new ThemThanhVien(clientSettings, client, db);
                themThanhVien.ShowDialog(this);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (dgvDanhSach.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Xin hãy chọn dòng muốn sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                    SuaThanhVien suaThanhVien = new SuaThanhVien(clientSettings, client, db, Int32.Parse(dgvDanhSach.SelectedRows[0].Cells[1].Value.ToString()), dgvDanhSach.SelectedRows[0].Cells[2].Value.ToString(), Int32.Parse(dgvDanhSach.SelectedRows[0].Cells[3].Value.ToString()));
                    suaThanhVien.ShowDialog(this);
            }
            
        }

        private async void btnXoa_ClickAsync(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "Xin hãy chọn thành viên muốn xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult =  MessageBox.Show(this, "Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    var giangvienCollection = db.GetCollection<GiangVien1>("MonAn");
                    var result = await giangvienCollection.FindOneAndDeleteAsync(
                                    Builders<GiangVien1>.Filter.Eq("mamonan", Int32.Parse(dgvDanhSach.SelectedRows[0].Cells[1].Value.ToString()))
                                        );
                    MessageBox.Show(this, "Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void DanhSach_Load(object sender, EventArgs e)
        {
            var giangvienCollection = db.GetCollection<GiangVien1>("MonAn");
            var query = giangvienCollection.AsQueryable<GiangVien1>().ToList();
            dgvDanhSach.DataSource = query;
            dgvDanhSach.Columns[0].Visible = false;
            dgvDanhSach.Columns[1].HeaderText = "Mã món ăn";
            dgvDanhSach.Columns[2].HeaderText = "Tên món ăn";
            dgvDanhSach.Columns[3].HeaderText = "Số lượng";
        }

        private void DanhSach_Activated(object sender, EventArgs e)
        {
            dgvDanhSach.Refresh();
        }
    }
}
