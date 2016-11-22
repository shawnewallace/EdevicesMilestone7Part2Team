using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace EDeviceClaims.WebUi.Controllers
{
  public abstract class AppController : Controller
  {
    public string CurrentUserId { get { return User.Identity.GetUserId(); } }
  }
}