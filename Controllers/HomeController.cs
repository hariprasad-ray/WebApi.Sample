using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Sample.Models;
using WebApi.Sample.Models.Custom;

namespace WebApi.Sample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManagementContext _context;

        public HomeController(ILogger<HomeController> logger, UserManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public List<UserDetail> List()
        {
            #region EF 

            int totalCount = 0, activeCount = 0, inActiveCount = 0;
            var data = new List<UserDetail>();

            try
            {
                data = _context.UserDetails.ToList(); //linq queries

                if (data != null)
                {
                    totalCount = data.Count;
                    activeCount = data.Where(p => p.IsActive == true).Count();
                    inActiveCount = data.Where(p => p.IsActive == false).Count();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return data;

            #endregion
        }

        [HttpGet]
        [Route("api/[controller]/[action]/{id}")]
        public UserDetail Details(int Id)
        {
            int totalCount = 0, activeCount = 0, inActiveCount = 0;
            var data = new List<UserDetail>();
            var userDetails = new UserDetail();

            try
            {
                data = _context.UserDetails.ToList();

                if (data != null)
                {
                    totalCount = data.Count;
                    activeCount = data.Where(p => p.IsActive == true).Count();
                    inActiveCount = data.Where(p => p.IsActive == false).Count();

                    userDetails = data.Where(p => p.Id == Id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return userDetails;
        }

        [HttpGet]
        public UserCountDetails GetUserCount()
        {
            var obj = new UserCountDetails();

            try
            {
                var data = _context.UserDetails; //linq queries

                if (data != null)
                {
                   obj.TotalUserCount = data.Count();
                   obj.ActiveUserCount = data.Where(p => p.IsActive == true).Count();
                   obj.InActiveUserCount = data.Where(p => p.IsActive == false).Count();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return obj;
        }
    }
}