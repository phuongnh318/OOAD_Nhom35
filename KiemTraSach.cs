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
    public partial class KiemTraSach : Form
    {
        MongoClientSettings clientSettings;
        MongoClient client;
        IMongoDatabase db;
        string maTaiKhoan;
        public KiemTraSach()
        {
            InitializeComponent();
        }
        public KiemTraSach(string maTaiKhoan,MongoClientSettings clientSettings, MongoClient client, IMongoDatabase db)
        {
            this.clientSettings = clientSettings;
            this.client = client;
            this.db = db;
            this.maTaiKhoan = maTaiKhoan;
            InitializeComponent();
        }

        private void KiemTraSach_Load(object sender, EventArgs e)
        {
            var sachCollection = db.GetCollection<Sach>("Sach");
            var query = sachCollection.AsQueryable<Sach>().ToList();
            dgvKiemTraSach.DataSource = query;

            dgvKiemTraSach.Columns[0].Visible = false;
            dgvKiemTraSach.Columns[1].HeaderText = "Tên sách";
            dgvKiemTraSach.Columns[2].HeaderText = "Tác giả";
            dgvKiemTraSach.Columns[3].HeaderText = "Mã sách";
            dgvKiemTraSach.Columns[4].HeaderText = "Số lượng";
            dgvKiemTraSach.Columns[5].HeaderText = "Số lượng mượn";
        }

        private async void btnTracuu_ClickAsync(object sender, EventArgs e)
        {
            if(txtMa.Text == "")
            {
                MessageBox.Show(this, "Xin hãy điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var sachCollection = db.GetCollection<Sach>("Sach");
                var result = await sachCollection.FindAsync(
                                sach => sach.masach.Equals(txtMa.Text)
                                );
                var query = result.ToList();
                dgvKiemTraSach.DataSource = query;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnMuon_ClickAsync(object sender, EventArgs e)
        {
            var sachCollection = db.GetCollection<Sach>("Sach");
            var danhsachnguoimuonCollection = db.GetCollection<DanhSachNguoiMuon>("DanhSachNguoiMuon");
            int soluongmuon = Int32.Parse(dgvKiemTraSach.SelectedRows[0].Cells[5].Value.ToString()) + 1;

            var result = await sachCollection.FindOneAndUpdateAsync(
                Builders<Sach>.Filter.Eq("masach", dgvKiemTraSach.SelectedRows[0].Cells[3].Value.ToString()),
                Builders<Sach>.Update.Set("soluongmuon", soluongmuon)
                );

            var check = await danhsachnguoimuonCollection.FindAsync(
                           Builders<DanhSachNguoiMuon>.Filter.Where(c => c.masach == dgvKiemTraSach.SelectedRows[0].Cells[3].Value.ToString() && c.nguoimuon == maTaiKhoan)
                           );
            if (!check.Any())
            {
                DanhSachNguoiMuon danhSachNguoiMuon = new DanhSachNguoiMuon();
                danhSachNguoiMuon.masach = dgvKiemTraSach.SelectedRows[0].Cells[3].Value.ToString();
                danhSachNguoiMuon.nguoimuon = maTaiKhoan;
                danhSachNguoiMuon.soluong = 1;
                danhSachNguoiMuon.trangthai = "chưa trả";
                danhSachNguoiMuon.ngaymuon = DateTime.Now.ToShortDateString();
                danhsachnguoimuonCollection.InsertOne(danhSachNguoiMuon);
                MessageBox.Show(this, "Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Đã mượn sách trước đó", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
