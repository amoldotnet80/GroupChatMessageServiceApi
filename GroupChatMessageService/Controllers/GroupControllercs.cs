using AutoMapper;
using GroupChatMessageService.Model;
using GroupChatMessageService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Controllers
{
    [Route("api/v{version:apiVersion}/Group")]
  //  [Route("api/[controller]")]
    [ApiController]
    public class GroupControllercs : ControllerBase
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper mapper;
        public GroupControllercs(IGroupRepository groupRepo, IMapper mapper)
        {
            this._groupRepo = groupRepo;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(GroupDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateGroup([FromBody] GroupDto grouplDto)
        {
            if (grouplDto == null)
            {
                return BadRequest(new { message = "Error while creating Group" });
            }
            var group = this.mapper.Map<Group>(grouplDto);
            if (this._groupRepo.CreateGroup(group))
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "Error in creating Group");
            }
        }
    }
}
