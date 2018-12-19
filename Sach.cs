using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AdvanceDB
{
    public class Sach
    {
        public ObjectId _id { get; set; }
        public string tensach { get; set; }
        public string tacgia { get; set; }
        public string masach { get; set; }
        public Int32 soluong { get; set; }
        public Int32 soluongmuon { get; set; }
    }
}
