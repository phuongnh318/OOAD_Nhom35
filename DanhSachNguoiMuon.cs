using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceDB
{
    public class DanhSachNguoiMuon
    {
        public ObjectId _id { get; set; }
        public string masach { get; set; }
        public string nguoimuon { get; set; }
        public Int32 soluong { get; set; }
        public string ngaymuon { get; set; }
        public string trangthai { get; set; }

    }
}