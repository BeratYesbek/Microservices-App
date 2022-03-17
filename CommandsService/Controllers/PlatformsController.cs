using CommandsService.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using CommandsService.Dtos;

namespace CommandsService.Contollers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _commandRepo;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo commandRepo, IMapper mapper)
        {
            _commandRepo = commandRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from CommandsService");
            var platformItems = _commandRepo.GetAllPlatforms();

            return Ok(platformItems);
        }

        [HttpPost]
        public ActionResult TextInboundConnection()
        {
            Console.WriteLine("-----> Inbound Post # Command Service");
            return Ok("Inbound test of from platforms controller");
        }
    }
}