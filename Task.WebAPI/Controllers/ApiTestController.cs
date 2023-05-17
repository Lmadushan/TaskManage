using Microsoft.AspNetCore.Mvc;

namespace TaskManage.WebAPI.Controllers
{
    /// <summary>
    /// Controller class - API test 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ApiTestController : Controller
    {
        #region Private Declarations

        private readonly ILogger<ApiTestController> _logger;
        private readonly IConfiguration _config;

        #endregion  Private Declarations

        #region Constructor
        /// <summary>
        /// Api Test Controller
        /// </summary>
        /// <param name="apiTestService"> Api test service </param>
        /// <param name="logger"> logger di object </param>
        /// <param name="authSvc"> auth di object </param>
        public ApiTestController(IConfiguration config, ILogger<ApiTestController> logger)
        {
            _logger = logger;
            _config = config;
        }
        #endregion Constructor

        #region Controller Methods

        /// <summary>
        /// Get Api Check
        /// </summary>
        /// <param name="msg">Test msg </param>
        /// <returns></returns>
        [HttpGet("{msg}", Name = "GetApiCheck")]
        public async Task<string> GetApiCheck(string msg)
        {
            return "Recived " + msg;
        }
        #endregion
    }
}