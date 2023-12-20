using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList.BLL.GeneralTypes;
using ToDoList.DAL.Repository.Interfaces;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/Task")]
    public class ToDoTaskController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IMapper _mapper;
        public ToDoTaskController(IToDoTaskRepository toDoTaskRepository, IMapper mapper)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _mapper = mapper;
            _response = new();
        }
    }
}
