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
using MongoDB.Bson;

namespace AdvanceDB
{
    public partial class SuaThanhVien : Form
    {
        MongoClientSettings clientSettings;
        MongoClient client;
        IMongoDatabase db;
        string dgvTen;
        int dgvMa;
        int soluong;
        public SuaThanhVien()
        {
            InitializeComponent();
        }

        public SuaThanhVien(MongoClientSettings clientSettings, MongoClient client, IMongoDatabase db,int dgvMa,string dgvTen, int soluong)
        {
            this.clientSettings = clientSettings;
            this.client = client;
            this.db = db;
            this.dgvTen = dgvTen;
            this.dgvMa = dgvMa;
            this.soluong = soluong;
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private async void btnLuu_ClickAsync(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                MessageBox.Show(this, "Xin hãy điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var giangvienCollection = db.GetCollection<GiangVien1>("MonAn");
                var result = await giangvienCollection.FindOneAndUpdateAsync(
                                Builders<GiangVien1>.Filter.Eq("mamonan", dgvMa),
                                Builders<GiangVien1>.Update.Set("tenmonan", txtTen.Text)

                                );
                result = await giangvienCollection.FindOneAndUpdateAsync(
                Builders<GiangVien1>.Filter.Eq("mamonan", dgvMa),
                Builders<GiangVien1>.Update.Set("soluong", numericUpDown1.Value)
                );

                MessageBox.Show(this, "Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void SuaThanhVien_Load(object sender, EventArgs e)
        {
            txtTen.Text = dgvTen;
            numericUpDown1.Value = soluong;
        }
    }
}
