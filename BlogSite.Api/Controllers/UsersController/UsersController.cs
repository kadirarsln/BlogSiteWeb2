//using BlogSite.Models.Dtos.Users.Requests;
//using BlogSite.Models.Dtos.Users.Responses;
//using BlogSite.Service.Abstracts;
//using Core.Exceptions;
//using Core.Responses;
//using Microsoft.AspNetCore.Mvc;

//namespace BlogSite.Api.Controllers.UsersController
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController(IUserService _userService) : ControllerBase
//    {
//        [HttpGet("getall")]
//        public IActionResult GetAll()
//        {
//            var result = _userService.GetAll();
//            return Ok(result);
//        }

//        [HttpGet("{id}")]
//        public ActionResult<ReturnModel<UserResponseDto?>> GetById([FromRoute] long id)
//        {
//            try
//            {
//                var result = _userService.GetById(id);
//                return Ok(result);
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(new ReturnModel<UserResponseDto?>
//                {
//                    Success = false,
//                    Message = ex.Message,
//                    Data = null,
//                    StatusCode = 404
//                });
//            }
//        }

//        [HttpPost("add")]
//        public ActionResult<ReturnModel<UserResponseDto?>> Add([FromBody] CreateUserRequest request)
//        {
//            try
//            {
//                var result = _userService.Add(request);
//                return Ok(result);
//            }
//            catch (ValidationException ex)
//            {
//                return BadRequest(new ReturnModel<UserResponseDto?>
//                {
//                    Success = false,
//                    Message = ex.Message,
//                    Data = null,
//                    StatusCode = 400
//                });
//            }
//        }

//        [HttpDelete("delete")]
//        public ActionResult<ReturnModel<UserResponseDto>> Delete([FromRoute] long id)
//        {
//            try
//            {
//                var result = _userService.Remove(id);
//                return Ok(result);
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(new ReturnModel<UserResponseDto>
//                {
//                    Success = false,
//                    Message = ex.Message,
//                    Data = null,
//                    StatusCode = 404
//                });
//            }
//        }

//        [HttpGet("getauthorwithposts")]
//        public ActionResult<ReturnModel<List<UserWithPostsResponseDto>>> GetAuthorWithPosts()
//        {
//            var result = _userService.GetAuthorWithPosts();
//            return Ok(result);
//        }


//        [HttpGet("{userId}/posts")]
//        public IActionResult GetAuthorWithPostsById(long userId)
//        {
//            try
//            {
//                var result = _userService.GetAuthorWithPostsById(userId);
//                return Ok(result);
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(new { message = "User not Found" });
//            }
//        }

//        [HttpGet("getuserwithcomments")]
//        public ActionResult<ReturnModel<List<UserWithPostsResponseDto>>> GetUserWithComments()
//        {
//            var result = _userService.GetUserWithComments();
//            return Ok(result);
//        }


//        [HttpGet("{userId}/comments")]
//        public IActionResult GetUserWithCommentsById(long userId)
//        {
//            try
//            {
//                var result = _userService.GetUserWithCommentsById(userId);
//                return Ok(result);
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(new { message = "User not Found" });
//            }
//        }
//    }
//}
