namespace WebHocTap.Entity
{

        using System;
        using System.Collections.Generic;
        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;


        [Table("Grade")]
        public class Grade
        {

            public Grade()
            {
                Classes = new HashSet<Class>();
            }

            public int gradeId { get; set; }

            [StringLength(3)]
            public string gradeName { get; set; }

            public bool? Status { get; set; }


            public ICollection<Class> Classes { get; set; }
        }
    }

