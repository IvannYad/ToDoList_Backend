using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoList.BLL.DTO.ToDoTaskDTO;
using ToDoList.BLL.GeneralTypes;
using ToDoList.BLL.Services.Validators;
using ToDoList.BLL.Services.Validators.Interfaces;
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
        private readonly IToDoTaskValidator _validator;
        public ToDoTaskController(IToDoTaskRepository toDoTaskRepository, IMapper mapper)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _mapper = mapper;
            _response = new() { ErrorMessages = new List<string>()};
            _validator = new ToDoTaskValidator();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<APIResponse> GetTasks()
        {
            try
            {
                var tasks = _toDoTaskRepository.GetAll();
                var toDoTaskDTOs = _mapper.Map<List<ToDoTaskDTO>>(tasks);
                
                _response.Generate200OK(toDoTaskDTOs);
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
                if (_validator.IsIdValid(id))
                {
                    string error = "Id cannot be less or equal 0";
                    _response.Generate400BadRequest(error);
                    return BadRequest(_response);
                }

                var task = _toDoTaskRepository.Get(v => v.Id == id, tracked: false);
                if (task == null)
                {
                    string error =  $"Entity with Id {id} not found";
                    _response.Generate404NotFound(error);
                    return BadRequest(_response);
                }

                var toDoTaskDTO =  _mapper.Map<ToDoTaskDTO>(task);

                _response.Generate200OK(toDoTaskDTO);
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
                if (_validator.IsCreateDTOValid(createDTO))
                {
                    string error = "Argument is null" ;
                    _response.Generate400BadRequest(error);
                    return BadRequest(_response);
                }

                DateTime timeOfCreation = DateTime.Now;
                if (_validator.IsEndTimeValid(timeOfCreation, createDTO.TaskEndTime))
                {
                    string error = "Time of task end cannot be less than actual time";
                    _response.Generate400BadRequest(error);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> DeleteTask(int id)
        {
            try
            {
                if (_validator.IsIdValid(id))
                {
                    string error = "Id cannot be less or equal 0";
                    _response.Generate400BadRequest(error);
                    return BadRequest(_response);
                }

                var villa = _toDoTaskRepository.Get(v => v.Id == id);
                if (villa == null)
                {
                    string error = $"Entity with Id {id} not found";
                    _response.Generate404NotFound(error);
                    return NotFound(_response);
                }

                _toDoTaskRepository.Remove(villa);
                _toDoTaskRepository.Save();
                
                _response.Generate204NoContent();
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
                if (_validator.IsUpdateDTOValid(id, updateDTO))
                {
                    string error = string.Empty;
                    if (updateDTO is null)
                        error = "Argument is null";
                    else
                        error = "Input Id and Id in body must match";

                    _response.Generate400BadRequest(error);
                    return BadRequest(_response);
                }

                var taskFromDb = _toDoTaskRepository.Get(v => v.Id == id, tracked: false);
                if (taskFromDb == null)
                {
                    string error = $"Entity with Id {id} not found";
                    _response.Generate404NotFound(error);
                    return NotFound(_response);
                }
                
                if (_validator.IsEndTimeValid(taskFromDb.TaskStartTime, updateDTO.TaskEndTime))
                {
                    string error = "Time of task end cannot be less than actual time";
                    _response.Generate400BadRequest(error);
                    return BadRequest(_response);
                }

                // If Everything is ok.
                DateTime timeOfCreation = taskFromDb.TaskStartTime;
                taskFromDb = _mapper.Map<ToDoTask>(updateDTO);
                taskFromDb.TaskStartTime = timeOfCreation;
                
                _toDoTaskRepository.Update(taskFromDb);
                _toDoTaskRepository.Save();
                
                var toDoTaskDTO =  _mapper.Map<ToDoTaskDTO>(taskFromDb);
                _response.Generate200OK(toDoTaskDTO);
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
