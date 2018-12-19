
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
    public partial class ThemThanhVien : Form
    {
        MongoClientSettings clientSettings;
        MongoClient client;
        IMongoDatabase db;
        public ThemThanhVien()
        {
            InitializeComponent();
        }
        public ThemThanhVien(MongoClientSettings clientSettings, MongoClient client, IMongoDatabase db)
        {
            this.clientSettings = clientSettings;
            this.client = client;
            this.db = db;
            InitializeComponent();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnYes_ClickAsync(object sender, EventArgs e)
        {
            if(txtMa.Text == "" || txtTen.Text == "")
            {
                MessageBox.Show(this, "Xin hãy điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var giangvienCollection = db.GetCollection<GiangVien1>("MonAn");
                
                var check = await giangvienCollection.FindAsync(
                               Builders<GiangVien1>.Filter.Eq("mamonan", txtMa.Text)
                               );
                if (check.SingleOrDefault() != null) 
                {
                    
                    MessageBox.Show(this,"Đã có món ăn, xin hãy kiểm tra lại!","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    check = null;
                }
                else
                {
                    GiangVien1 giangVien = new GiangVien1();
                    giangVien.mamonan = Int32.Parse(txtMa.Text);
                    giangVien.tenmonan = txtTen.Text;
                    giangVien.soluong = (int)numSoLuong.Value;

                    giangvienCollection.InsertOne(giangVien);
                    check = null;
                    MessageBox.Show(this, "Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.ResetText();
                    txtTen.ResetText();
                }
            }
        }
    }
}
