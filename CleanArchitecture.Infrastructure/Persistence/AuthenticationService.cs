
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Helpers;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;


        public AuthenticationService(IPasswordHasher<User> passwordHasher, JwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }


        public async Task<AuthenticationResultDto> AuthenticateUser(string email, string password)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Kullanıcı bulunamadı.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed) { 
            
            throw new UnauthorizedAccessException("şifre yanlış.");
            
            }
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.UserName);

            return new AuthenticationResultDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60)  // Örneğin, 60 dakika geçerli
            };
        }

        public async Task<string> RegisterAsync(RegisterRequestDto dto)
          
        {
            var existingUser = await _unitOfWork.UserRepository.GetUserByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Bu e-posta adresi zaten kullanılıyor.");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = dto.UserName,
                Email = dto.Email
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();  // Değişiklikleri kaydet

            return user.Id.ToString();
        }

    }
    }

