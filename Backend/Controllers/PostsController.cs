using Backend.Logic.Intefaces;
using Backend.Models;
using Backend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net;

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        ILogic<Post> postLogic;

        public PostsController(ILogic<Post> postLogic)
        {
            this.postLogic = postLogic;
        }

        [HttpGet("{postId}")]
        public IActionResult Get(string postId)
        {
            try
            {
                return Ok(postLogic.Get(postId));
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error Code {HttpStatusCode.InternalServerError} - Error: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAll()
        {
            try
            {
                return Ok(postLogic.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error Code {HttpStatusCode.InternalServerError} - Error: {ex.Message}");
            }
        }

        [HttpPost]
        [HttpPost]
        [HttpPost]
        public IActionResult Post([FromBody] PostDTO newPost)
        {
            try
            {
                Post p = new Post
                {
                    UserId = newPost.UserId,
                    ImageUrl = newPost.ImageUrl,
                    Caption = newPost.Caption,
                };

                postLogic.Create(p);
                return Ok(newPost);
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error Code {HttpStatusCode.InternalServerError} - Error: {ex.Message}");
            }
        }

        [HttpDelete("{toDeletePostId}")]
        public IActionResult Delete(string toDeletePostId)
        {
            try
            {
                Post deleted = postLogic.Delete(toDeletePostId);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error Code {HttpStatusCode.InternalServerError} - Error: {ex.Message}");
            }
        }

        //we dont do this ever :))
        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAllPosts()
        {
            try
            {
                postLogic.DeleteAll();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error Code {HttpStatusCode.InternalServerError} - Error: {ex.Message}");
            }
        }
    }
}
