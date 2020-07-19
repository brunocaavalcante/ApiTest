using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data.Context;
using Api.Business.Models;
using ApiTest.ViewModels;
using AutoMapper;
using Api.Business.Interfaces;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(MyDbContext context,
                                    IMapper mapper,
                                    IFornecedorRepository fornecedorRepository)
        {
            _context = context;
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
        }

        // GET: api/Fornecedores
        [HttpGet]
        public async Task<IEnumerable<FornecedorViewModel>> GetFornecedores()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
        }

        // GET: api/Fornecedor/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> GetFornecedor(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorViewModel == null)
                return NotFound();

            return Ok(fornecedorViewModel);
        }

        // PUT: api/Fornecedor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(Guid id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fornecedor
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            if (!ModelState.IsValid) return BadRequest();

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
        }

        // DELETE: api/Fornecedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fornecedor>> DeleteFornecedor(Guid id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return fornecedor;
        }

        private bool FornecedorExists(Guid id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
    }
}
