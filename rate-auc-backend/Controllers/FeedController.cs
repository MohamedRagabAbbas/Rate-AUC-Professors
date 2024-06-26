﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateAucProfessors.DTO.Requests;
using RateAucProfessors.IRepository;
using RateAucProfessors.Models;
using RateAucProfessors.ObjectsMapping;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RateAucProfessors.Controllers
{
    [Route("api/[controller]")]
    // allow only authorized users to access the feed controller
    [Authorize]
    
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public FeedController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("get-all")]
        [HttpOptions]
        public async Task<IActionResult> GetAll()
        {
            var feeds = await _unitOfWork.Feed.GetAllAsync();
            return Ok(feeds);
        }
        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feed = await _unitOfWork.Feed.GetByIdAsync(id);
            return Ok(feed);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(FeedInfo feedInfo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           // var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            if (userId is not null)
            {
                Feed feed = _mapper.MapToFeed(feedInfo, userId);
                var result = await _unitOfWork.Feed.Add(feed);
                await _unitOfWork.SaveAsync();
                return Ok(result);
            }
            return BadRequest("User not found");
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(FeedInfo feedInfo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is not null)
            {
                Feed feed = _mapper.MapToFeed(feedInfo, userId);
                var result = _unitOfWork.Feed.Update(feed);
                _unitOfWork.SaveAsync();
                return Ok(result);
            }
            return BadRequest("User not found");

        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Feed.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

    }
}
