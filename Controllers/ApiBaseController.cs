using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using InnFlow.CoreAPI.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using rwaAPI.Data;

namespace rwaAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ApiBaseController : Controller
    {


 

        protected rwaAPIContext DbContext => (rwaAPIContext)HttpContext.RequestServices.GetService(typeof(rwaAPIContext));


        protected int _uniqueUserId;
        protected int _undermaintence = 0;
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (User.HasClaim(c => c.Type == "uid"))
            {
                var userId = User.Claims.SingleOrDefault(c => c.Type == "uid");
                int.TryParse(userId.Value, out _uniqueUserId);
            }


            // InnFlowDbContext context1 = new InnFlowDbContext();
            // HotelRepository hotel = new HotelRepository(context1);

            // UserRepository _userRepository1 = new UserRepository(context1, hotel);

            int? IsUnderMaintenance = 0;
            //IsUnderMaintenance = DbContext.UnderMaintenance.Select(x => x.IsUnderMaintenance).FirstOrDefault();
            if (IsUnderMaintenance == null)
            {
                IsUnderMaintenance = 0;
            }

            if (IsUnderMaintenance == 1)
            {
                context.Result = new BadRequestObjectResult(new JsonResponse(1001, false, message: "under maintenance"));
            }
        }
    }
}