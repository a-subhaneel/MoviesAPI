using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProducersController : ControllerBase
    {
        private readonly ILogger<ProducersController> _logger;

    }
}
