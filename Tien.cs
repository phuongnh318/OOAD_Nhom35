using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace AdvanceDB
{
    public class Tien
    {
        public ObjectId _id { get; set; }
        public Int32 giangvien { get; set; }
        public Int32[] sinhvien { get; set; }
        public Int32[] tudo { get; set; }
    }
}
