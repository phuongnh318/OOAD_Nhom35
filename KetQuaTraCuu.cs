using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace AdvanceDB
{
    public partial class KetQuaTraCuu : Form
    {
        MongoClientSettings clientSettings;
        MongoClient client;
        IMongoDatabase db;
        int loai;
        string maTaiKhoan;
        double tienPhat = 0;
        string tenThanhVien;
        List<ThongTinBienNhan> list;
        public KetQuaTraCuu()
        {
            InitializeComponent();
        }

        public KetQuaTraCuu(int loai, string maTaiKhoan, MongoClientSettings clientSettings, MongoClient client, IMongoDatabase db)
        {
            this.clientSettings = clientSettings;
            this.client = client;
            this.db = db;
            this.maTaiKhoan = maTaiKhoan;
            this.loai = loai;
            InitializeComponent();
        }

        private void KetQuaTraCuu_Load(object sender, EventArgs e)
        {
            var sachCollection = db.GetCollection<Sach>("Sach");
            var tienCollection = db.GetCollection<Tien>("TienPhat").AsQueryable().SingleOrDefault();
            var danhsachnguoimuonCollection = db.GetCollection<DanhSachNguoiMuon>("DanhSachNguoiMuon");
            if (loai == 0)
            {
                var thongtinnguoimuonCollection = db.GetCollection<GiangVien>("GiangVien").AsQueryable().Where(ma => ma.mathe == maTaiKhoan);
                var tensachdamuonCollection = danhsachnguoimuonCollection.AsQueryable().Where(ma => ma.nguoimuon == maTaiKhoan);

                var query = (from t in tensachdamuonCollection
                             join s in sachCollection.AsQueryable() on t.masach equals s.masach
                             select new ThongTinBienNhan()
                             {
                                 tensach = s.tensach,
                                 masach = s.masach,
                                 soluong = t.soluong,
                                 ngaymuon = t.ngaymuon,
                                 trangthai = t.trangthai
                             }).ToList();
                list = query;
                dgvKetQua.DataSource = query;

                var thongtin = thongtinnguoimuonCollection.FirstOrDefault();
                tenThanhVien = thongtin.hoten;
                lblTen.Text = thongtin.hoten;
                lblMa.Text = thongtin.mathe;
                lblHethan.Text = thongtin.hanthe;


            }
            else if(loai == 1)
            {
                var thongtinnguoimuonCollection = db.GetCollection<SinhVien>("SinhVien").AsQueryable().Where(ma => ma.mathe == maTaiKhoan);
                var tensachdamuonCollection = danhsachnguoimuonCollection.AsQueryable().Where(ma => ma.nguoimuon == maTaiKhoan);
                var query = (from t in tensachdamuonCollection
                             join s in sachCollection.AsQueryable() on t.masach equals s.masach
                             select new ThongTinBienNhan()
                             {
                                 tensach = s.tensach,
                                 masach = s.masach,
                                 soluong = t.soluong,
                                 ngaymuon = t.ngaymuon,
                                 trangthai = t.trangthai
                             }).ToList();
                list = query;
                dgvKetQua.DataSource = query;

                var thongtin = thongtinnguoimuonCollection.FirstOrDefault();
                tenThanhVien = thongtin.hoten;
                lblTen.Text = thongtin.hoten;
                lblMa.Text = thongtin.mathe;

                if (dgvKetQua.RowCount >= 1)
                {
                    
                    string startDateString = dgvKetQua.Rows[0].Cells[3].Value.ToString();
                    DateTime ngayHetHan = Convert.ToDateTime(startDateString).AddDays(tienCollection.sinhvien[2]*7);
                    lblHethan.Text = ngayHetHan.ToShortDateString();
                }
                else
                    lblHethan.Text = "";
            }
            else
            {
                var thongtinnguoimuonCollection = db.GetCollection<TuDo>("TuDo").AsQueryable().Where(ma => ma.mathe == maTaiKhoan);
                var tensachdamuonCollection = danhsachnguoimuonCollection.AsQueryable().Where(ma => ma.nguoimuon == maTaiKhoan);


               var query = (from t in tensachdamuonCollection
                             join s in sachCollection.AsQueryable() on t.masach equals s.masach
                             select new ThongTinBienNhan()
                             {
                                 tensach = s.tensach,
                                 masach = s.masach,
                                 soluong = t.soluong,
                                 ngaymuon = t.ngaymuon,
                                 trangthai = t.trangthai
                             }).ToList();
                list = query;
                dgvKetQua.DataSource = query;
                var thongtin = thongtinnguoimuonCollection.FirstOrDefault();
                tenThanhVien = thongtin.hoten;
                lblTen.Text = thongtin.hoten;
                lblMa.Text = thongtin.mathe;

                if (dgvKetQua.RowCount >= 1)
                {

                    string startDateString = dgvKetQua.Rows[0].Cells[3].Value.ToString();
                    DateTime ngayHetHan = Convert.ToDateTime(startDateString).AddDays(tienCollection.sinhvien[2] * 7);
                    lblHethan.Text = ngayHetHan.ToShortDateString();
                }
                else
                    lblHethan.Text = "";
            }
            dgvKetQua.Columns[0].HeaderText = "Tên sách";
            dgvKetQua.Columns[1].HeaderText = "Mã sách";
            dgvKetQua.Columns[2].HeaderText = "Số lượng";
            dgvKetQua.Columns[3].HeaderText = "Ngày mượn";
            dgvKetQua.Columns[4].HeaderText = "Trạng thái";
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {

            String startDateString = lblHethan.Text;
            DateTime ngayHetHan = Convert.ToDateTime(startDateString);
            var tienCollection = db.GetCollection<Tien>("TienPhat");

            int tongQuyenNo = dgvKetQua.RowCount;
            if (DateTime.Now > ngayHetHan)
            {
                MessageBox.Show(this, "Tài khoản phải gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var query = tienCollection.AsQueryable<Tien>().SingleOrDefault();
                if (loai == 1)
                {
                    if (tongQuyenNo >= query.sinhvien[1])
                    {
                        MessageBox.Show(this, "Đã quá số quyển được mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        KiemTraSach kiemTraSach = new KiemTraSach(maTaiKhoan, clientSettings, client, db);
                        kiemTraSach.ShowDialog(this);
                    }
                }
                else if (loai == 2)
                {
                    if (tongQuyenNo >= query.tudo[1])
                    {
                        MessageBox.Show(this, "Đã quá số quyển được mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        KiemTraSach kiemTraSach = new KiemTraSach(maTaiKhoan, clientSettings, client, db);
                        kiemTraSach.ShowDialog(this);
                    }
                }
                else
                {
                    KiemTraSach kiemTraSach = new KiemTraSach(maTaiKhoan, clientSettings, client, db);
                    kiemTraSach.ShowDialog(this);
                }
            }
        }

        private async void btnTra_ClickAsync(object sender, EventArgs e)
        {
            String startDateString = lblHethan.Text;
            DateTime ngayHetHan = Convert.ToDateTime(startDateString);
            if (DateTime.Now > ngayHetHan)
            {
                MessageBox.Show(this, "Tài khoản phải gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dgvKetQua.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "Hãy chọn sách để trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var nguoimuonCollection = db.GetCollection<DanhSachNguoiMuon>("DanhSachNguoiMuon");
                    var result3 = await nguoimuonCollection.FindOneAndDeleteAsync(
                                    Builders<DanhSachNguoiMuon>.Filter.Where(c=> c.masach == dgvKetQua.SelectedRows[0].Cells[1].Value.ToString() && c.nguoimuon == maTaiKhoan)
                                    );
                    var sachCollection = db.GetCollection<Sach>("Sach");
                    var sach = sachCollection.AsQueryable().Where(masach => masach.masach == dgvKetQua.SelectedRows[0].Cells[1].Value.ToString()).FirstOrDefault();
                    int soluongmuon = sach.soluongmuon - 1;
                    var result2 = await sachCollection.FindOneAndUpdateAsync(
                                    Builders<Sach>.Filter.Eq("masach", dgvKetQua.SelectedRows[0].Cells[1].Value.ToString()),
                                    Builders<Sach>.Update.Set("soluongmuon", soluongmuon)
                                    );
                    MessageBox.Show(this, "Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void btnGiaHan_ClickAsync(object sender, EventArgs e)
        {

            var sachCollection = db.GetCollection<Tien>("TienPhat");
            var query = sachCollection.AsQueryable<Tien>().FirstOrDefault();
            if (loai == 0)
            {
                DateTime expiredDay = DateTime.Now;
                DateTime rentDaylbl = Convert.ToDateTime(lblHethan.Text);
                if (expiredDay > rentDaylbl)
                {
                    if (dgvKetQua.RowCount > 0)
                    {


                        tienPhat = dgvKetQua.RowCount * query.giangvien;
                        DialogResult dialogResult = MessageBox.Show(this, "Tiền phạt sẽ là: " + tienPhat, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var nguoimuonCollection = db.GetCollection<DanhSachNguoiMuon>("DanhSachNguoiMuon");


                            var result = await nguoimuonCollection.FindOneAndUpdateAsync(
                                            Builders<DanhSachNguoiMuon>.Filter.Eq("nguoimuon", maTaiKhoan),
                                            Builders<DanhSachNguoiMuon>.Update.Set("trangthai", "đã trả")
                                            );
                            MessageBox.Show(this, "Gia hạn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else if(loai == 1)
            {
                DateTime expiredDay = DateTime.Now;
                DateTime rentDaylbl = Convert.ToDateTime(lblHethan.Text);
                if (expiredDay > rentDaylbl)
                {
                    foreach (DataGridViewRow row in dgvKetQua.Rows)
                    {
                        string ngayMuon = row.Cells[3].Value.ToString();
                        DateTime rentDay = Convert.ToDateTime(ngayMuon);

                        if (expiredDay > rentDay)
                        {
                            TimeSpan songaytre = expiredDay.Subtract(rentDay);
                            double ngaytre = songaytre.TotalDays;
                            tienPhat += Math.Round(query.sinhvien[0] * ngaytre);
                        }
                    }
                    string message = "Tiền phạt sẽ là: " + tienPhat.ToString("N0",
                                        System.Globalization.CultureInfo.GetCultureInfo("de")) + " VNĐ";
                    DialogResult dialogResult = MessageBox.Show(this, message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var nguoimuonCollection = db.GetCollection<DanhSachNguoiMuon>("DanhSachNguoiMuon");


                        foreach (DataGridViewRow row in dgvKetQua.Rows)
                        {
                            string ngayMuon = row.Cells[3].Value.ToString();
                            DateTime rentDay = Convert.ToDateTime(ngayMuon);

                            if (expiredDay > rentDay)
                            {
                                var result = await nguoimuonCollection.FindOneAndDeleteAsync(
                                                Builders<DanhSachNguoiMuon>.Filter.Where(c => c.ngaymuon == ngayMuon && c.nguoimuon == maTaiKhoan)
                                                );
                            }
                        }



                        MessageBox.Show(this, "Gia hạn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if(loai == 2)
            {

                DateTime expiredDay = DateTime.Now;
                DateTime rentDaylbl = Convert.ToDateTime(lblHethan.Text);
                if (expiredDay > rentDaylbl)
                {
                    foreach (DataGridViewRow row in dgvKetQua.Rows)
                    {
                        string ngayMuon = lblHethan.Text;
                        DateTime rentDay = Convert.ToDateTime(ngayMuon);

                        if (expiredDay > rentDay)
                        {
                            TimeSpan songaytre = expiredDay.Subtract(rentDay);
                            double ngaytre = songaytre.TotalDays;
                            tienPhat += Math.Round(query.tudo[0] * ngaytre);
                        }
                    }
                    string message = "Tiền phạt sẽ là: " + tienPhat.ToString("N0",
                                        System.Globalization.CultureInfo.GetCultureInfo("de")) + " VNĐ";
                    DialogResult dialogResult = MessageBox.Show(this, message, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var nguoimuonCollection = db.GetCollection<DanhSachNguoiMuon>("DanhSachNguoiMuon");


                        foreach (DataGridViewRow row in dgvKetQua.Rows)
                        {
                            string ngayMuon = row.Cells[3].Value.ToString();
                            DateTime rentDay = Convert.ToDateTime(ngayMuon);

                            if (expiredDay > rentDay)
                            {
                                var result = await nguoimuonCollection.FindOneAndDeleteAsync(
                                                Builders<DanhSachNguoiMuon>.Filter.Where(c => c.ngaymuon == ngayMuon && c.nguoimuon == maTaiKhoan)
                                                );
                            }
                        }
                        MessageBox.Show(this, "Gia hạn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void KetQuaTraCuu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(this, "Bạn có muốn xuất biên nhận cho tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                BienNhan bienNhan = new BienNhan(tienPhat, list,tenThanhVien);
                bienNhan.ShowDialog(this);
            }
        }
    }
}

