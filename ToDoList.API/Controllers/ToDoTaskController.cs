using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoList.BLL.DTO.ToDoTaskDTO;
using ToDoList.BLL.GeneralTypes;
using ToDoList.DAL.Entity;
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
                // In case of some exception, produce failing response.
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id:int}", Name = "GetTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetTask(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "Id cannot be less or equal 0" };
                    return BadRequest(_response);
                }

                var task = _toDoTaskRepository.Get(v => v.Id == id);
                if (task == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string>() { $"Entity with Id {id} not found" };
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<ToDoTaskDTO>(task);
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

        [HttpPost(Name = "CreateTask")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> CreateTask([FromBody] ToDoTaskCreateDTO createDTO)
        {
            try
            {
                if (createDTO is null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "Argument is null" };
                    return BadRequest(_response);
                }

                DateTime timeOfCreation = DateTime.Now;
                if (createDTO.TaskEndTime < timeOfCreation)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "Time of task end cannot be less than actual time" };
                    return BadRequest(_response);
                }


                // If everything is ok, save task in database and produce response with code 201.
                var task = _mapper.Map<ToDoTask>(createDTO);
                task.TaskStartTime = timeOfCreation;
                _toDoTaskRepository.Add(task);
                _toDoTaskRepository.Save();

                _response.Result = _mapper.Map<ToDoTaskDTO>(task);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetTask", new { id = task.Id }, _response);
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
