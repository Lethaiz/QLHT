namespace WebHocTap.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
       


        [Table("Class")]
        public class Class
        {

            public Class()
            {
                Class_Course = new HashSet<Class_Course>();
                Class_Test = new HashSet<Class_Test>();
                Students = new HashSet<Student>();
            }

            [StringLength(5)]
            public string classId { get; set; }

            public int? Grade { get; set; }

            public bool? Status { get; set; }

            public Grade Grade1 { get; set; }


            public ICollection<Class_Course> Class_Course { get; set; }

            public ICollection<Class_Test> Class_Test { get; set; }


            public ICollection<Student> Students { get; set; }
        }
    }

