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
    public partial class Form1 : Form
    {
        MongoClientSettings clientSettings = new MongoClientSettings();
        MongoClient client;
        IMongoDatabase db;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            clientSettings.Server = new MongoServerAddress("localhost", 27017);
            client = new MongoClient();
            db = client.GetDatabase("QLNhaHang");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            DanhSach ds = new DanhSach(clientSettings,client,db);
            ds.ShowDialog(this);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTien_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
