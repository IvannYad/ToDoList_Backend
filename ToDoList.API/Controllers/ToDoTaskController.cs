using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

                var task = _toDoTaskRepository.Get(v => v.Id == id, tracked: false);
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

        [HttpDelete("{id:int}", Name = "DeleteTask")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> DeleteTask(int id)
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

                var villa = _toDoTaskRepository.Get(v => v.Id == id);
                if (villa == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string>() { $"Entity with Id {id} not found" };
                    return NotFound(_response);
                }

                _toDoTaskRepository.Remove(villa);
                _toDoTaskRepository.Save();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateTask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> UpdateVilla(int id, [FromBody] ToDoTaskUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO is null || id != updateDTO.Id)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    if (updateDTO is null)
                        _response.ErrorMessages = new List<string>() { "Argument is null" };
                    else
                        _response.ErrorMessages = new List<string>() { "Input Id and Id in body must match" };

                    return BadRequest(_response);
                }

                var taskFromDb = _toDoTaskRepository.Get(v => v.Id == id, tracked: false);
                if (taskFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string>() { $"Entity with Id {id} not found" };
                    return NotFound(_response);
                }
                
                if (updateDTO.TaskEndTime < taskFromDb.TaskStartTime)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "Time of task end cannot be less than actual time" };
                    return BadRequest(_response);
                }

                // If Everything is ok.
                DateTime timeOfCreation = taskFromDb.TaskStartTime;
                taskFromDb = _mapper.Map<ToDoTask>(updateDTO);
                taskFromDb.TaskStartTime = timeOfCreation;
                
                _toDoTaskRepository.Update(taskFromDb);
                _toDoTaskRepository.Save();
                
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<ToDoTaskDTO>(taskFromDb);
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
