﻿using AutoMapper;
using web2server.Dtos;
using web2server.Infrastructure;
using web2server.Interfaces;
using web2server.Models;

namespace web2server.Services
{
    public class UserService : IUserService
    {
        private readonly WebshopDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(WebshopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<UserDto> GetAllUsers()
        {
            return _mapper.Map<List<UserDto>>(_dbContext.Users.ToList());
        }

        public UserDto GetUserById(long id)
        {
            return _mapper.Map<UserDto>(_dbContext.Users.Find(id));
        }

        public UserDto RegisterUser(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return _mapper.Map<UserDto>(user);
        }

        public UserDto UpdateUser(long id, UserDto userDto)
        {
            User user = _dbContext.Users.Find(id);
            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Birthdate = userDto.Birthdate;
            user.Address = userDto.Address;

            _dbContext.SaveChanges();

            return _mapper.Map<UserDto>(user);
        }
    }
}
