﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DAL.Enum;

namespace ToDoList.BLL.DTO.ToDoTaskDTO
{
    public class ToDoTaskUpdateDTO
    {
        [Required]
        public int Id { get; set; }

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
        public DateTime TaskStartTime { get; set; }

        [Required]
        [DisplayName("Finish time")]
        public DateTime TaskEndTime { get; set; }

        [Required]
        public ToDoTaskStatus Status { get; set; }
    }
}
