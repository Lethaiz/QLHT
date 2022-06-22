namespace WebHocTap.Entity
{
  
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;


        [Table("Test")]
        public class Test
        {

            public Test()
            {
                Class_Test = new HashSet<Class_Test>();
            }

            public int testId { get; set; }

            [StringLength(50)]
            public string title { get; set; }

            public int? TestCategory { get; set; }

            public bool? Status { get; set; }


            public ICollection<Class_Test> Class_Test { get; set; }

            public TestCategory TestCategory1 { get; set; }
        }
    }

