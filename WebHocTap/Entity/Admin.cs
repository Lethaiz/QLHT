namespace WebHocTap.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
        [Table("Admin")]
        public class Admin
        {

            public Admin()
            {
         AdminAccount = new HashSet<AdminAccount>();
            }

            [Key]
            [StringLength(10)]
            public string teacherId { get; set; }

            [StringLength(10)]
            public string firstName { get; set; }

            [StringLength(50)]
            public string lastName { get; set; }

            [Column(TypeName = "date")]
            public DateTime? birthDay { get; set; }

            public bool? gender { get; set; }

            [StringLength(255)]
            public string address { get; set; }

            public int? Position { get; set; }

            public int? Subject { get; set; }

            public bool? Status { get; set; }

            public Position Position1 { get; set; }

            public Subject Subject1 { get; set; }


            public ICollection<AdminAccount> AdminAccount { get; set; }
        }
    


