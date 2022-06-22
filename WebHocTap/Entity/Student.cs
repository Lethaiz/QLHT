namespace WebHocTap.Entity
{

        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;


        [Table("Student")]
        public class Student
        {

            public Student()
            {
                LearningOutcomes = new HashSet<LearningOutcome>();
                Student_Test = new HashSet<Student_Test>();
                StudentAccounts = new HashSet<StudentAccount>();
            }

            [StringLength(10)]
            public string studentId { get; set; }

            [StringLength(10)]
            public string firstName { get; set; }

            [StringLength(50)]
            public string lastName { get; set; }

            public bool? gender { get; set; }

            [Column(TypeName = "date")]
            public DateTime? birthDay { get; set; }

            [StringLength(5)]
            public string Class { get; set; }

            public bool? Status { get; set; }

            public Class Class1 { get; set; }


            public ICollection<LearningOutcome> LearningOutcomes { get; set; }

            public ICollection<Student_Test> Student_Test { get; set; }


            public ICollection<StudentAccount> StudentAccounts { get; set; }
        }
    }
