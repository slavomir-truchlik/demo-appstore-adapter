using Microsoft.AspNetCore.Mvc;
using ST.GitHub.DemoAppStoreAdapter.AppStore.Models.Apple;

namespace ST.GitHub.DemoAppStoreAdapter.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        public NotificationsController()
        {
        }


        [HttpPost]
        [Route("receive")]
        public async Task<IActionResult> ReceiveNotificationAsync(Notification notification)
            => Ok("Received!");
    }
}