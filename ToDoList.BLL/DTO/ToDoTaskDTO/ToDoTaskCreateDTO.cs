using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ToDoList.BLL.DTO.ToDoTaskDTO
{
    public class ToDoTaskCreateDTO
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [DisplayName("Title")]
        public string TaskTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(80)]
        public string AdditionalDescription { get; set; }
        
        [Required]
        [DisplayName("Finish time")]
        public DateTime TaskEndTime { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
