using dotNetRestApi.Data;
using dotNetRestApi.Data.Repositories;
using dotNetRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRestApi.Domain.Services
{
    public class MensagemService
    {
        private readonly MensagemRepository _mensagemRepository;

        public MensagemService(MensagemRepository mensagemRepository)
        {
            this._mensagemRepository = mensagemRepository;
        }


        public async Task<List<Mensagem>> ListaTodasMensagem()
        {
            List<Mensagem> listaTodasMensagem = await _mensagemRepository.ListaTodasMensagemAsync();

            return listaTodasMensagem;
        }
        public async Task<Mensagem> FindMensagemById([FromQuery] int id)
        {
            Mensagem findMensagemById = await _mensagemRepository.FindMensagemByIdAsync(id);

            if (findMensagemById == null)
            {
                throw new ArgumentNullException($"Não foi encontrada nenhuma mensagem com o ID '{id}'. Tente novamente.");
            }

            return findMensagemById;
        }
        public async Task<Mensagem> RegistrarNovaMensagem([FromBody] Mensagem mensagem)
        {
            Mensagem registrarNovaMensagem = await _mensagemRepository.RegistrarNovaMensagemAsync(mensagem);

            return registrarNovaMensagem;
        }

        public async Task<Mensagem> AleterarMensagem(Mensagem mensagem)
        {
            Mensagem aleterarMensagem = await _mensagemRepository.AleterarMensagemAsync(mensagem);
            mensagem.Data = DateTime.Now;
            if (aleterarMensagem == null)
            {
                throw new ArgumentException("Mensagem não encontrada");
            }

            return aleterarMensagem;
        }

        public async Task<Mensagem> DeleteMensagem(int id)
        {
            Mensagem deletemensagem = await _mensagemRepository.DeleteMensagem(id);

            if (deletemensagem == null)
                throw new ArgumentException($"Não foi possível encontrar a mensagem '{id}'. ");

            return deletemensagem;
        }


    }


}
