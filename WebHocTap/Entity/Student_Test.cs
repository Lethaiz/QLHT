namespace WebHocTap.Entity
{
 using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;


        public class Student_Test
        {

            public Student_Test()
            {
                LearningOutcomes = new HashSet<LearningOutcome>();
            }

            [Key]
            public int studentTestId { get; set; }

            [StringLength(255)]
            public string documentTest { get; set; }

            public double? testMath { get; set; }

            [StringLength(10)]
            public string Student { get; set; }

            public int? Class_Test { get; set; }

            public bool? Status { get; set; }

            public virtual Class_Test Class_Test1 { get; set; }

           // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<LearningOutcome> LearningOutcomes { get; set; }

            public virtual Student Student1 { get; set; }
        }
    }

