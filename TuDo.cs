using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AdvanceDB
{
    public class TuDo
    {
        public ObjectId _id { get; set; }
        public string hoten { get; set; }
        public string mathe { get; set; }
    }
}
