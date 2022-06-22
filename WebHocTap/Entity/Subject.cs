namespace WebHocTap.Entity
{
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;


        [Table("Subject")]
        public class Subject
        {

            public Subject()
            {
                Admins = new HashSet<Admin>();
                Courses = new HashSet<Course>();
               Documents = new HashSet<Document>();
            }

            public int subjectId { get; set; }

            [StringLength(255)]
            public string subjectName { get; set; }

            [StringLength(255)]
            public string description { get; set; }

            public bool? Status { get; set; }


            public ICollection<Admin> Admins { get; set; }


            public ICollection<Course> Courses { get; set; }


            public ICollection<Document> Documents { get; set; }
        }
    }
