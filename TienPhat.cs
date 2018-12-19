using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AdvanceDB
{
    public partial class TienPhat : Form
    {
        MongoClientSettings clientSettings = new MongoClientSettings();
        MongoClient client;
        IMongoDatabase db;
        public TienPhat()
        {
            InitializeComponent();
        }
        public TienPhat(MongoClientSettings clientSettings, MongoClient client, IMongoDatabase db)
        {
            this.clientSettings = clientSettings;
            this.client = client;
            this.db = db;
            InitializeComponent();
        }

        private async void btnCapnhat_ClickAsync(object sender, EventArgs e)
        {
            var tienCollection = db.GetCollection<Tien>("TienPhat");
            if (cbLuachon.SelectedIndex == 0)
            {
                
                var result = await tienCollection.UpdateOneAsync(
                        Builders<Tien>.Filter.Eq("giangvien", Int32.Parse(lblGV.Text)),
                        Builders<Tien>.Update.Set("giangvien", Int32.Parse(txtTien.Text))
                );
                MessageBox.Show(this, "Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbLuachon.SelectedIndex == 1)
            {
               
                var result = await tienCollection.FindOneAndUpdateAsync(
                        Builders<Tien>.Filter.Eq("sinhvien", Int32.Parse(lblSV.Text)),
                        Builders<Tien>.Update.Set(c => c.sinhvien[0], Int32.Parse(txtTien.Text))
                );
                result = await tienCollection.FindOneAndUpdateAsync(
                        Builders<Tien>.Filter.Eq("sinhvien", Int32.Parse(lblToiDaSV.Text)),
                        Builders<Tien>.Update.Set(c => c.sinhvien[1], Int32.Parse(txtToiDaSV.Text))
                );
                result = await tienCollection.FindOneAndUpdateAsync(
                        Builders<Tien>.Filter.Eq("sinhvien", Int32.Parse(lblTuanSV.Text)),
                        Builders<Tien>.Update.Set(c => c.sinhvien[2], Int32.Parse(txtTuanSV.Text))
                );
                MessageBox.Show(this, "Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                var result = await tienCollection.FindOneAndUpdateAsync(
                        Builders<Tien>.Filter.Eq("tudo", Int32.Parse(lblTD.Text)),
                        Builders<Tien>.Update.Set(c=>c.tudo[0], Int32.Parse(txtTien.Text))
                );
                result = await tienCollection.FindOneAndUpdateAsync(
                        Builders<Tien>.Filter.Eq("tudo", Int32.Parse(lblToiDaTD.Text)),
                        Builders<Tien>.Update.Set(c => c.tudo[1], Int32.Parse(txtToiDaTD.Text))
                );
                result = await tienCollection.FindOneAndUpdateAsync(
                        Builders<Tien>.Filter.Eq("tudo", Int32.Parse(lblTuanTD.Text)),
                        Builders<Tien>.Update.Set(c => c.tudo[2], Int32.Parse(txtTuanTD.Text))
                );
                MessageBox.Show(this, "Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TienPhat_Load(object sender, EventArgs e)
        {
            var sachCollection = db.GetCollection<Tien>("TienPhat");
            
            var query = sachCollection.AsQueryable<Tien>().FirstOrDefault();
            
            lblGV.Text = query.giangvien.ToString();
            lblSV.Text = query.sinhvien[0].ToString();
            lblTD.Text = query.tudo[0].ToString();

            lblToiDaSV.Text = query.sinhvien[1].ToString();
            lblTuanSV.Text = query.sinhvien[2].ToString();

            lblToiDaTD.Text = query.tudo[1].ToString();
            lblTuanTD.Text = query.tudo[2].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
