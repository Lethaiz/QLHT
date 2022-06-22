namespace WebHocTap.Entity
{

        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;


        [Table("AdminAccount")]
        public class AdminAccount
        {
            [Key]
            [StringLength(50)]
            public string userName { get; set; }

            [StringLength(255)]
            public string passWord { get; set; }

            public bool? isLogin { get; set; }

            [StringLength(10)]
            public string Admin { get; set; }

            public bool? Status { get; set; }

            public Admin Admin1 { get; set; }
        }
    }

