using dotNetRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRestApi.Data.Repositories
{
    public class MensagemRepository
    {
        private readonly MySqlContext _context;

        public MensagemRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<List<Mensagem>> ListarTodasMensagemAsync()
        {
            return await _context.Mensagem.ToListAsync();
        }

        public async Task<Mensagem> FindMensagemByIdAsync(int id)
        {
            return await _context.Mensagem.FindAsync(id);
        }

        public async Task<Mensagem> RegistrarNovaMensagemAsync(Mensagem mensagem)
        {
            _context.Mensagem.Add(mensagem);
            mensagem.Data = DateTime.Now;
            await _context.SaveChangesAsync();

            return mensagem;
        }

        public async Task<Mensagem> AleterarMensagemAsync(Mensagem mensagem)
        {
            _context.Entry(mensagem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return _context.Entry(mensagem).Entity;
        }

        public async Task<Mensagem> DeletarMensagemAsync(int id)
        {
            var mensagem = await _context.Mensagem.FindAsync(id);

            _context.Mensagem.Remove(mensagem);
            await _context.SaveChangesAsync();

            return mensagem;
        }




    }
}