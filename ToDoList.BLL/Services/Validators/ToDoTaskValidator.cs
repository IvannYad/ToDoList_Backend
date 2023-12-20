using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.DTO.ToDoTaskDTO;
using ToDoList.BLL.Services.Validators.Interfaces;

namespace ToDoList.BLL.Services.Validators
{
    public class ToDoTaskValidator : IToDoTaskValidator
    {
        public bool IsCreateDTOValid(ToDoTaskCreateDTO? createDTO)
        {
            return createDTO is null ? false : true;
        }

        public bool IsEndTimeValid(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate;
        }

        public bool IsIdValid(int id)
        {
            return id > 0;
        }

        public bool IsUpdateDTOValid(int id, ToDoTaskUpdateDTO? updateDTO)
        {
            if (updateDTO is null || id != updateDTO.Id)
                return true;

            return false;
        }
    }
}
