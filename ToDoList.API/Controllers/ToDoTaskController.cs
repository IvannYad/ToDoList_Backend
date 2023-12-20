using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoList.BLL.DTO.ToDoTaskDTO;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<APIResponse> GetTasks()
        {
            try
            {
                var tasks = _toDoTaskRepository.GetAll();
                _response.Result = _mapper.Map<List<ToDoTaskDTO>>(tasks);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
