using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using StarForum.Application.Models;
using StarForum.Domain.AggregatesModel.QuestionAggregate;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

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
        public async Task<IActionResult> GetQuestions(string orderOption, string tags)
        {
            var filterModel = new FilterModel(orderOption, tags);
            IEnumerable<QuestionShortModel> questionsResult = await _questionsRepository.GetAllAsync(filterModel);
            _mapper.Map<IEnumerable<QuestionModel>>(questionsResult);

            return Ok(questionsResult);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetQuestionById([FromUri] int id)
        {
            Question questionResult = await _questionsRepository.GetAsync(id);

            return Ok(questionResult);
        }

        [HttpGet("isFavourite/{id}")]
        public async Task<IActionResult> IsQuestionFavourite([FromUri] int id)
        {
            bool result = await _questionsRepository.CheckFavourite(id);

            return Ok(result);
        }

        [HttpGet("changeIsFavourite/{questionId}/{value}")]
        public async Task<IActionResult> IsQuestionFavourite([FromUri] int questionId, [FromUri] bool value)
        {
            bool result = await _questionsRepository.UpdateFavourite(questionId, value);

            return Ok(true);
        }

        [HttpGet("getByTag/{tag}")]
        public async Task<IActionResult> GetQuestionsByTag([FromUri] string tag)
        {
            IEnumerable<QuestionShortModel> questionsResult;
            try
            {
                questionsResult = await _questionsRepository.GetByTagAsync(tag);
                _mapper.Map<IEnumerable<QuestionModel>>(questionsResult);
            }
            catch (Exception)
            {

                throw;
            }
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
