﻿using System;
using System.Linq;
using BadNews.Models.Comments;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsRepository commentsRepository;

        public CommentsController(ICommentsRepository commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        // GET
        [HttpGet("api/news/{id}/comments")]
        public ActionResult<CommentsDto> GetCommentsForNews(Guid newsId)
        {
            return new CommentsDto
            {
               NewsId = newsId,
               Comments = commentsRepository.GetComments(newsId)
                   .Select(comment => new CommentDto{User = comment.User, Value = comment.Value})
                   .ToArray()
            };
        }
    }
}
