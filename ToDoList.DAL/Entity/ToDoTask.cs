using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.DAL.Enum;

namespace ToDoList.DAL.Entity
{
    internal class ToDoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string TaskTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(80)]
        public string AdditionalDescription { get; set; }

        [Required]
        public DateTime TaskStartTime { get; set; }

        [Required]
        [DisplayName("Finish time")]
        public DateTime TaskEndTime { get; set; }

        [Required]
        public ToDoTaskStatus Status { get; set; }
    }
}
