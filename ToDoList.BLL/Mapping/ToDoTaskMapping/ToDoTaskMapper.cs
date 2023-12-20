using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.DTO.ToDoTaskDTO;
using ToDoList.DAL.Entity;

namespace ToDoList.BLL.Mapping.ToDoTaskMapping
{
    public class ToDoTaskMapper : Profile
    {
        public ToDoTaskMapper()
        {
            CreateMap<ToDoTask, ToDoTaskDTO>().ReverseMap();
            CreateMap<ToDoTask, ToDoTaskCreateDTO>().ReverseMap();
            CreateMap<ToDoTask, ToDoTaskUpdateDTO>().ReverseMap();
        }
    }
}
