using AutoMapper;
using EducationAPI.Context;
using EducationAPI.Data;
using EducationAPI.DTOs;
using EducationAPI.Entities;
using EducationAPI.Implement.Repositories;
using EducationAPI.Interfaces.Repositories;
using EducationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PracticeController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        /*[HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var quiz = await quizRepository.GetById(id);
                if (quiz != null)
                {
                    return Ok(mapper.Map<QuizDTO>(quiz));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        /*[HttpGet("/api/Practice/getPracticeOfCourse")]
        public async Task<IActionResult> Get(int courseId)
        {
            try
            {
                var practices = context.Sections.Include(s => s.Practices).Where(s => s.CourseId == courseId)
                    .Select(s => new
                    {
                        Id = s.Id,
                        Name = s.Name,
                        CourseId = s.Id,
                        Practices = s.Practices,
                    }).ToList();
                return Ok(practices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpPost]
        public IActionResult Post([FromBody] PracticeDTO practiceDTO)
        {
            try
            {
                Practice practice = new Practice();
                practice = mapper.Map<Practice>(practiceDTO);

                // Thêm Order vào cơ sở dữ liệu
                context.Practices.Add(practice);
                context.SaveChanges();

                foreach (var testCaseDTO in practiceDTO.TestCasesDTO)
                {
                    var testCase = new TestCase
                    {
                        Input = testCaseDTO.Input,
                        Expected =  testCaseDTO.Expected,
                        CreateAt = testCaseDTO.CreateAt,
                        UpdateAt = testCaseDTO.UpdateAt,
                        PracticeId = practice.Id
                    };
                    context.TestCases.Add(testCase);
                    context.SaveChanges();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QuizDTO quizDto)
        {
            try
            {
                var updateQuiz = await quizRepository.GetById(id);
                if (updateQuiz != null)
                {
                    return Ok(mapper.Map<QuizDTO>(await quizRepository.Update(id, mapper.Map<Quiz>(quizDto))));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        /*[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var quiz = await quizRepository.GetById(id);
                if (quiz != null)
                {
                    await quizRepository.Delete(quiz);
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}
