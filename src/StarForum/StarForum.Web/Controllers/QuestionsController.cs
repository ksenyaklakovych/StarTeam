using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarForum.Domain.AggregatesModel.UserAggregate;
using StarForum.Domain.AggregatesModel.UserLoginsAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StarForum.Application.Models;
using StarForum.Domain.AggregatesModel.QuestionAggregate;

namespace StarForum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionsRepository;
        private readonly Mapper _mapper;

        public QuestionsController(IQuestionRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
            var config = new MapperConfiguration(cfg => 
                cfg.CreateMap<QuestionShortModel, QuestionModel>());
            _mapper = new Mapper(config);
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetQuestions()
        {
            IEnumerable<QuestionShortModel> questionsResult = await _questionsRepository.GetAllAsync();
            _mapper.Map<IEnumerable<QuestionModel>>(questionsResult);

            return Ok(questionsResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddQuestion(QuestionRequestModel request)
        {
            Question questionModel = new Question()
            {
                Title = request.Title,
                Description = request.Description,
                Tags = string.Join(',', request.Tags),
                CreatedDate = DateTime.Now,
                AuthorId = 1
            };

            Question question = await _questionsRepository.AddAsync(questionModel);

            return Ok(question);
        }
    }
}
