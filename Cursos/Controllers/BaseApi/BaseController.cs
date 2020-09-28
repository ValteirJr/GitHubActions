using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Cursos.Controllers.BaseApi
{
    public abstract class BaseController : ControllerBase
    {

        protected BadRequestObjectResult BadRequest(IReadOnlyCollection<Notification> notifications)
        {
            return new BadRequestObjectResult(new ErrorModel(notifications));
        }

        protected NotFoundObjectResult NotFound(string message)
        {
            return new NotFoundObjectResult(new ErrorModel(message));
        }

    }
}
