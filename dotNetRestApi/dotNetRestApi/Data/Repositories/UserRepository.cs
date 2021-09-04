using dotNetRestApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRestApi.Data.Repositories
{
    public class UserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> ListarTodosUsuariosAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<ApplicationUser> FindUserByIdAsync(string userid)
        {
            return await _context.User.FindAsync(userid);
        }

        public async Task<ApplicationUser> RegistrarNovoUsuarioAsync( ApplicationUser user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<ApplicationUser> AleterarUsuarioAsync(ApplicationUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return _context.Entry(user).Entity;
        }

        public async Task<ApplicationUser> DeletarUsuarioAsync(string userid)
        {
            var user = await _context.User.FindAsync(userid);

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }



    }
}
