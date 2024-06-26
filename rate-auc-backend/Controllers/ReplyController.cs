﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;
        public ReplyController(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var replies = await _unitOfWork.Reply.GetAllAsync();
            return Ok(replies);
        }
        [HttpGet]
        [Route("get-all-replys-by-commentId/{commentId}")]
        public async Task<IActionResult> GetAllReplys(int commentId)
        {
            var replys = await _unitOfWork.Reply.GetWhereAsync(x => x.CommentId == commentId);
            return Ok(replys);
        }


        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reply = await _unitOfWork.Reply.GetByIdAsync(id);
            return Ok(reply);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(ReplyInfo replyInfo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is not null)
            {
                Reply reply = _mapper.MapToReply(replyInfo, userId);
                var result = await _unitOfWork.Reply.Add(reply);
                await _unitOfWork.SaveAsync();
                return Ok(result);
            }
            return BadRequest("User not found");
        }
        [HttpPut]
        [Route("update")]
        public IActionResult Update(ReplyInfo replyInfo)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is not null)
            {
                Reply reply = _mapper.MapToReply(replyInfo, userId);
                var result = _unitOfWork.Reply.Update(reply);
                _unitOfWork.SaveAsync();
                return Ok(result);
            }
            return BadRequest("User not found");
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitOfWork.Reply.Delete(id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }
    }
}
