namespace WebHocTap.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Document")]
    public class Document
    {
        [Key]
        public int docId { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string docPath { get; set; }

        public int? Subject { get; set; }

        public bool? Status { get; set; }

        public Subject Subject1 { get; set; }
    }
}