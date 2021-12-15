using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarForum.Domain.AggregatesModel.UserAggregate;
using StarForum.Domain.AggregatesModel.UserLoginsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarForum.Domain.AggregatesModel.QuestionAggregate;

namespace StarForum.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionsController : ControllerBase
	{
		private readonly IQuestionRepository _questionsRepository;

		public QuestionsController(IQuestionRepository questionsRepository)
		{
            _questionsRepository = questionsRepository;
		}

		[HttpGet("questions")]
		public async Task<IActionResult> GetQuestions()
        {
            return Ok("hi");
		}
	}
}
