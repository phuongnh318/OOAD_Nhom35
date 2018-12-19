using MongoDB.Bson;

namespace AdvanceDB
{
    public class GiangVien
    {
        public ObjectId _id { get; set; }
        public string hoten { get; set; }
        public string mathe { get; set; }

        //[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public string hanthe { get; set; }
    }
}
