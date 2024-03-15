﻿using Microsoft.AspNetCore.Mvc;

namespace RubberCityAPI.Controllers
{
    [ApiController]
    [Route("[users]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }


    }
}