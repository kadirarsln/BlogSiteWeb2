//using AutoMapper;
//using BlogSite.DataAccess.Abstracts;
//using BlogSite.Models.Dtos.Users.Requests;
//using BlogSite.Models.Dtos.Users.Responses;
//using BlogSite.Models.Entities;
//using BlogSite.Service.Abstracts;
//using Core.Exceptions;
//using Core.Responses;

//namespace BlogSite.Service.Concretes;

//public class UserService : IUserService
//{
//    private readonly IUserRepository _userRepository;
//    private readonly IMapper _mapper;

//    public UserService(IUserRepository userRepository, IMapper mapper)
//    {
//        _userRepository = userRepository;
//        _mapper = mapper;
//    }

//    public ReturnModel<List<UserResponseDto>> GetAll()
//    {
//        List<User> users = _userRepository.GetAll();
//        List<UserResponseDto> responses = _mapper.Map<List<UserResponseDto>>(users);

//        return new ReturnModel<List<UserResponseDto>>
//        {
//            Data = responses,
//            Message = string.Empty,
//            StatusCode = 200,
//            Success = true,
//        };
//    }

//    public ReturnModel<UserResponseDto> GetById(long id)
//    {
//        var user = _userRepository.GetById(id);
//        if (user == null)
//        {
//            throw new NotFoundException("User not found.");
//        }
//        var response = _mapper.Map<UserResponseDto>(user);
//        return new ReturnModel<UserResponseDto>
//        {
//            Data = response,
//            Success = true,
//            Message = "User is found",
//            StatusCode = 200
//        };
//    }

//    public ReturnModel<UserResponseDto> Add(CreateUserRequest createdUser)
//    {
//        if (string.IsNullOrEmpty(createdUser.FirstName))
//        {
//            throw new ValidationException("First name cannot be empty.");
//        }

//        if (string.IsNullOrEmpty(createdUser.LastName))
//        {
//            throw new ValidationException("Last name cannot be empty.");
//        }

//        if (string.IsNullOrEmpty(createdUser.Password))
//        {
//            throw new ValidationException("Password cannot be empty.");
//        }

//        if (string.IsNullOrEmpty(createdUser.Username))
//        {
//            throw new ValidationException("Username cannot be empty.");
//        }

//        User user = _mapper.Map<User>(createdUser);
//        _userRepository.Add(user);

//        UserResponseDto response = _mapper.Map<UserResponseDto>(user);
//        return new ReturnModel<UserResponseDto>
//        {
//            Data = response,
//            Message = "User Added",
//            StatusCode = 201,
//            Success = true,
//        };
//    }
//    public ReturnModel<UserResponseDto> Remove(long id)
//    {
//        User user = _userRepository.GetById(id);
//        if (user == null)
//        {
//            throw new NotFoundException("User not found.");
//        }
//        User deletedUser = _userRepository.Remove(user);

//        UserResponseDto response = _mapper.Map<UserResponseDto>(deletedUser);
//        return new ReturnModel<UserResponseDto>
//        {
//            Data = response,
//            Message = "User Deleted",
//            StatusCode = 200,
//            Success = true,
//        };
//    }

//    public ReturnModel<UserResponseDto> Update(UpdateUserRequest updatedUser)
//    {
//        throw new NotImplementedException();
//    }
//    public ReturnModel<List<UserWithPostsResponseDto>> GetAuthorWithPosts()
//    {
//        var user = _userRepository.GetAuthorWithPosts().ToList();
//        var userDto = _mapper.Map<List<UserWithPostsResponseDto>>(user);

//        return new ReturnModel<List<UserWithPostsResponseDto>>
//        {
//            Success = true,
//            Data = userDto,
//            Message = "User with posts are listed.",
//            StatusCode = 200
//        };
//    }

//    public UserWithPostsResponseDto GetAuthorWithPostsById(long userId)
//    {
//        var user = _userRepository.GetAuthorWithPostsById(userId);

//        if (user == null)
//        {
//            throw new NotFoundException("User not found.");
//        }
//        var userDto = _mapper.Map<UserWithPostsResponseDto>(user);
//        return userDto;
//    }

//    public ReturnModel<List<UserWithCommentsResponseDto>> GetUserWithComments()
//    {
//        var user = _userRepository.GetUserWithComments().ToList();
//        var userDto = _mapper.Map<List<UserWithCommentsResponseDto>>(user);

//        return new ReturnModel<List<UserWithCommentsResponseDto>>
//        {
//            Success = true,
//            Data = userDto,
//            Message = "User with comments are listed.",
//            StatusCode = 200
//        };
//    }

//    public UserWithCommentsResponseDto GetUserWithCommentsById(long userId)
//    {
//        var user = _userRepository.GetUserWithCommentsById(userId);

//        if (user == null)
//        {
//            throw new NotFoundException("User not found.");
//        }
//        var userDto = _mapper.Map<UserWithCommentsResponseDto>(user);
//        return userDto;
//    }
//}
