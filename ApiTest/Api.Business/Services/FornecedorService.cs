using Api.Business.Interfaces;
using Api.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorService(IFornecedorService fornecedorService,
                                 INotificador notificador):base(notificador)
        {
            _fornecedorService = fornecedorService;
        }
        public Task<bool> Adicionar(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
