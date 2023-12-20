using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.BLL.DTO.ToDoTaskDTO;

namespace ToDoList.BLL.Services.Validators.Interfaces
{
    public interface IToDoTaskValidator
    {
        bool IsIdValid(int id);
        bool IsEndTimeValid(DateTime startDate, DateTime endDate);
        bool IsUpdateDTOValid(int id, ToDoTaskUpdateDTO? updateDTO);
        bool IsCreateDTOValid(ToDoTaskCreateDTO? createDTO);
    }
}
