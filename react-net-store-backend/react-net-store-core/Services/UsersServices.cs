using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using react_net_store_core.DTO;
using react_net_store_core.Exceptions;
using react_net_store_core.Utilities;
using react_net_store_database.Classes;
using react_net_store_database;

namespace react_net_store_core.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public bool HasAdminRights(User user)
        {
            return _context.Admins
                .Include(a => a.User)
                .Any(a =>
                a.User.Username == user.Username);
        }

        public UsersServices(AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDTO> SignIn(User user)
        {
            var dbUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username);

            if (dbUser == null || dbUser.Password == null || _passwordHasher.VerifyHashedPassword(dbUser, dbUser.Password, user.Password) == PasswordVerificationResult.Failed)
            {
                throw new InvalidLoginCredentialsException("Invalid login credentials");
            }

            return new UserDTO()
            {
                Username = user.Username,
                Token = TokenGenerator.GenerateAuthToken(user.Username),
                IsAdmin = HasAdminRights(user)
            };
        }

        public async Task<UserDTO> ExternalSignIn(User user)
        {
            var dbUser = await _context.Users
            .FirstOrDefaultAsync(u => u.ExternalId.Equals(user.ExternalId) && u.ExternalType.Equals(user.ExternalType));

            if (dbUser == null)
            {
                user.Username = CreateUniqueUsernameFromEmail(user.Email);
                return await SignUp(user);
            }

            return new UserDTO()
            {
                Username = dbUser.Username,
                Token = TokenGenerator.GenerateAuthToken(dbUser.Username),
                IsAdmin = HasAdminRights(user)
            };
        }

        public async Task<UserDTO> SignUp(User user)
        {
            var checkUsername = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.Equals(user.Username));

            if (checkUsername != null)
            {
                throw new UsernameTakenException("Username taken");
            }

            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = _passwordHasher.HashPassword(user, user.Password);
            }

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Username = user.Username,
                Token = TokenGenerator.GenerateAuthToken(user.Username),
                IsAdmin = false
            };
        }

        private string CreateUniqueUsernameFromEmail(string email)
        {
            var emailSplit = email.Split('@').First();
            var random = new Random();
            var username = emailSplit;

            while (_context.Users.Any(u => u.Username.Equals(username)))
            {
                username = emailSplit + random.Next(10000);
            }

            return username;
        }

        public UserDTO GetUserById(long id)
        {
            var dbUser = _context.Users
                .First(u => u.Id == id);
            return (UserDTO)dbUser;
        }
    }

}
