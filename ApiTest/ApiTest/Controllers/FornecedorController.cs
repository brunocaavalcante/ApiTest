using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest.Models;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public FornecedorController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Fornecedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorModel>>> GetFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        // GET: api/Fornecedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorModel>> GetFornecedorModel(Guid id)
        {
            var fornecedorModel = await _context.Fornecedores.FindAsync(id);

            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return fornecedorModel;
        }

        // PUT: api/Fornecedor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedorModel(Guid id, FornecedorModel fornecedorModel)
        {
            if (id != fornecedorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(fornecedorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorModelExists(id))
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
        public async Task<ActionResult<FornecedorModel>> PostFornecedorModel(FornecedorModel fornecedorModel)
        {
            _context.Fornecedores.Add(fornecedorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedorModel", new { id = fornecedorModel.Id }, fornecedorModel);
        }

        // DELETE: api/Fornecedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FornecedorModel>> DeleteFornecedorModel(Guid id)
        {
            var fornecedorModel = await _context.Fornecedores.FindAsync(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(fornecedorModel);
            await _context.SaveChangesAsync();

            return fornecedorModel;
        }

        private bool FornecedorModelExists(Guid id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
