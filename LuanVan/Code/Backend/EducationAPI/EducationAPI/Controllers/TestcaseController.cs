﻿using AutoMapper;
using EducationAPI.Context;
using EducationAPI.Data;
using EducationAPI.DTOs;
using EducationAPI.Entities;
using EducationAPI.Implement.Repositories;
using EducationAPI.Interfaces.Repositories;
using EducationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestcaseController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TestcaseController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /*[HttpGet]
        public async Task<IEnumerable<QuizDTO>> Get()
        {
            return mapper.Map<IEnumerable<QuizDTO>>(await quizRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestCaseDTO testCaseDTO)
        {
            context.TestCases.Add(mapper.Map<TestCase>(testCaseDTO));
            context.SaveChanges();
            return Ok();
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
            catch (Exception ex)
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
