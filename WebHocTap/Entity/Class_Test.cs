namespace WebHocTap.Entity
{
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;


        public class Class_Test
        {
            public Class_Test()
            {
                Student_Test = new HashSet<Student_Test>();
            }

            [Key]
            public int classTestId { get; set; }

            public int? isComplete { get; set; }

            [Column(TypeName = "date")]
            public DateTime? testDate { get; set; }

            public int? testDuration { get; set; }

            [StringLength(5)]
            public string Class { get; set; }

            public int? Test { get; set; }

            public bool? Status { get; set; }

            public Class Class1 { get; set; }

            public Test Test1 { get; set; }


            public ICollection<Student_Test> Student_Test { get; set; }
        }
    }

