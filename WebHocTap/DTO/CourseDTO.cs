namespace WebHocTap.DTO
{
    public class CourseDTO
    {
        public int courseId { get; set; }


        public DateTime? startDate { get; set; }


        public DateTime? endDate { get; set; }


        public string linkOnline { get; set; }

        public int? Subject { get; set; }

        public bool? Status { get; set; }
    }
}
