using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using StarForum.Application.Models;
using StarForum.Domain.AggregatesModel.QuestionAggregate;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Collections.Generic;

namespace StarForum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IQuestionRepository _questionsRepository;
        private readonly Mapper _mapper;

        public TagsController(IQuestionRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        [HttpGet("filter/{filter?}")]
        public async Task<IActionResult> GetQuestionById([FromUri] string filter = null)
        {
            List<Tag> tagsResult = await _questionsRepository.FilterTagsAsync(filter);

            return Ok(tagsResult);
        }
    }
}
