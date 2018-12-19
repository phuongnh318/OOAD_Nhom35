using MongoDB.Bson;

namespace AdvanceDB
{
    public class GiangVien1
    {
        public ObjectId _id { get; set; }
        public int mamonan { get; set; }

        //[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public string tenmonan { get; set; }
        public int soluong { get; set; }
    }
}
