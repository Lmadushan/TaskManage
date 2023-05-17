using Microsoft.AspNetCore.Mvc;
using TaskManage.Base.DTOs;
using TaskManage.Core.Services;
using TaskManage.DTOs;
using TaskManage.ViewModels;

namespace TaskManage.WebAPI.Controllers
{
    /// <summary>
    /// Controller class - API test 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class TaskController : Controller
    {
        #region Private Declarations

        private readonly ILogger<TaskController> _logger;
        private readonly IConfiguration _config;
        private readonly ITaskService _taskService;

        #endregion  Private Declarations

        #region Constructor
        /// <summary>
        /// Api Test Controller
        /// </summary>
        /// <param name="apiTestService"> Api test service </param>
        /// <param name="logger"> logger di object </param>
        /// <param name="authSvc"> auth di object </param>
        public TaskController(IConfiguration config, ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _config = config;
            _taskService = taskService;
        }
        #endregion Constructor

        #region Controller Methods

        /// <summary>
        /// Get All Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAll")]
        public async Task<TaskListResponse> GetAll()
        {
            TaskListResponse response = new();

            try
            {
                response.IsSuccess = true;
                response.Tasks = await _taskService.GetAll();
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                throw new BaseException(ex, response);
            }
        }


        /// <summary>
        /// Get by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{Id}", Name = "Get")]
        public async Task<TaskResponse> Get(string Id)
        {
            TaskResponse response = new();

            try
            {
                response.IsSuccess = true;
                response.Task = await _taskService.Get(Id);
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                throw new BaseException(ex, response);
            }
        }

        /// <summary>
        /// Create Task
        /// </summary>
        /// <returns></returns>
        [HttpPost(Name = "Create")]
        public async Task<TaskResponse> Create([FromBody] TaskRequest request)
        {
            TaskResponse response = new();

            TaskVM req = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description,
                AttachmentId = request.AttachmentId
            };

            try
            {
                response.IsSuccess = true;
                response.Task = await _taskService.Create(req);
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                throw new BaseException(ex, response);
            }
        }

        /// <summary>
        /// Update Task
        /// </summary>
        /// <returns></returns>
        [HttpPut(Name = "Update")]
        public async Task<BaseResponse> Update([FromBody] TaskRequest request)
        {
            TaskResponse response = new();
            TaskVM req = new()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                AttachmentId = request.AttachmentId
            };

            try
            {
                response.IsSuccess = true;
                await _taskService.Update(req);
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                throw new BaseException(ex, response);
            }
        }

        /// <summary>
        /// Update Task
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{Id}", Name = "Delete")]
        public async Task<BaseResponse> Delete(string Id)
        {
            TaskResponse response = new();

            try
            {
                response.IsSuccess = true;
                await _taskService.Delete(Id);
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                throw new BaseException(ex, response);
            }
        }


        #endregion
    }
}