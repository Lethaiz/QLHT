namespace WebHocTap.Entity
{
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;


        [Table("Course")]
        public partial class Course
        {

            public Course()
            {
                Class_Course = new HashSet<Class_Course>();

            }

            public int courseId { get; set; }

            [Column(TypeName = "date")]
            public DateTime? startDate { get; set; }

            [Column(TypeName = "date")]
            public DateTime? endDate { get; set; }

            [StringLength(255)]
            public string linkOnline { get; set; }

            public int? Subject { get; set; }

            public bool? Status { get; set; }


            public ICollection<Class_Course> Class_Course { get; set; }

            public Subject Subject1 { get; set; }



        }
    }

