using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        [ValidationAspect(typeof(ChangePasswordValidator))]
        public IResult ChangePassword(ChangePasswordModel updatedUser)
        {
            UserForLoginDto checkedUser = new()
            {
                Email = updatedUser.Email,
                Password = updatedUser.OldPassword
            };
            var loginResult = Login(checkedUser);
            if (loginResult.Success)
            {
                var user = loginResult.Data;
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(updatedUser.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                _userService.Update(user);
                return new SuccessResult(Messages.PasswordIsChanged);
            }

            return new ErrorResult(loginResult.Message);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user,claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenIsCreated);
        }

        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetUserByMail(userForLoginDto.Email);
            if (userToCheck.Data==null)
            {
                return new ErrorDataResult<User>(Messages.UserIsNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data,Messages.LoginIsSuccessful);
        }

        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt);
            var user = new User 
            {
                Email=userForRegisterDto.Email,
                FirstName=userForRegisterDto.FirstName,
                LastName=userForRegisterDto.LastName,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt,
                Status=true

            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserIsRegitered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetUserByMail(email).Data!=null)
            {
                return new ErrorResult(Messages.UserIsAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
