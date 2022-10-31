﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAPI.Dtos.Request;
using HospitalAPI.Dtos.Response;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public FeedbackController(FeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        // GET: api/rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackResponse>>> GetAll()
        {
            var feedbacks = await _feedbackService.GetAll();
            var result = _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);
            return Ok(result);
        }
        
        [HttpGet("/api/v1/Feedback-public")]
        public async Task<ActionResult<IEnumerable<FeedbackResponse>>> GetAllPublic()
        {
            var feedbacks = await _feedbackService.GetAllPublic();
            var result = _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);
            return Ok(result);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FeedbackResponse>> CreateFeedback([FromBody] FeedbackRequest feedbackRequest)
        {
            var feedback = _mapper.Map<Feedback>(feedbackRequest);
            var result = await _feedbackService.CreateFeedback(feedback);
            return CreatedAtAction(nameof(GetById), new {id = result.Id}, result);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType( StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FeedbackResponse>> GetById([FromRoute] Guid id)
        {
            var feedback = await _feedbackService.GetById(id);
            var result = _mapper.Map<FeedbackResponse>(feedback);
            return result == null ? NotFound() : Ok(result);
        }
        /*// GET api/rooms/2
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var feedback = _feedbackService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            return Ok(feedback);
        }

        // POST api/rooms
        [HttpPost]
        public ActionResult Create(FeedbackRequest feedbackRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feedback = _mapper.Map<Feedback>(feedbackRequest);
            _feedbackService.Create(feedback);
            return CreatedAtAction("GetById", new { id = feedback.Id }, feedback); // make class FeedbackRequest
        }

        // PUT api/rooms/2
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feedback.Id)
            {
                return BadRequest();
            }

            try
            {
                _feedbackService.Update(feedback);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(feedback);
        }

        // DELETE api/rooms/2
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var feedback = _feedbackService.GetById(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _feedbackService.Delete(feedback);
            return NoContent();
        }
        [HttpGet("/time")]
        public string Time()
        {
            return DateTime.Now.TimeOfDay.ToString();
        }
*/
    }
}
