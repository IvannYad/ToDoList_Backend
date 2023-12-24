using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.DAL.Entity
{
    [Table(name: "Tasks")]
    public class ToDoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Order = 1)]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [Display(Order = 2)]
        [Column(name: "Title")]
        public string TaskTitle { get; set; }

        [Required]
        [MaxLength(80)]
        [Display(Order = 3)]
        [Column(name: "Description")]
        public string AdditionalDescription { get; set; }

        [Required]
        [Display(Order = 4)]
        [Column(name: "Start time")]
        public DateTime TaskStartTime { get; set; }

        [Required]
        [Display(Order = 5)]
        [Column(name: "End time")]
        public DateTime TaskEndTime { get; set; }

        [Required]
        [Display(Order = 6)]
        public string Status { get; set; }
        
        [Required]
        [Display(Order = 7)]
        public string Type { get; set; }
    }
}
