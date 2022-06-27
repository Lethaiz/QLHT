namespace WebHocTap.DTO
{
    public class DocumentDTO
    {
        public int docId { get; set; }


        public string title { get; set; }


        public string description { get; set; }


        public string docPath { get; set; }

        public int? Subject { get; set; }

        public bool? Status { get; set; }
    }
}
