using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_WebAPI.Data;
using Teste_WebAPI.Models;

namespace Teste_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly Teste_WebAPIContext _context;

        public FuncionariosController(Teste_WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionario()
        {
          if (_context.Funcionario == null)
          {
              return NotFound();
          }
            return await _context.Funcionario.Include(a => a.endereco).ToListAsync();
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> GetFuncionario(int id)
        {
          if (_context.Funcionario == null)
          {
              return NotFound();
          }
            var funcionario = await _context.Funcionario.Include(a => a.endereco).FirstOrDefaultAsync(m => m.id == id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        // PUT: api/Funcionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario(int id, Funcionario funcionario)
        {
            if (id != funcionario.id)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST: api/Funcionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario funcionario)
        {
          if (_context.Funcionario == null)
          {
              return Problem("Entity set 'Teste_WebAPIContext.Funcionario'  is null.");
          }
            _context.Funcionario.Add(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id = funcionario.id }, funcionario);
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            if (_context.Funcionario == null)
            {
                return NotFound();
            }
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionarioExists(int id)
        {
            return (_context.Funcionario?.Any(e => e.id == id)).GetValueOrDefault();
        }

        [HttpPost]
        [Route("endereco/{id}")]
        public async Task<ActionResult<Funcionario>> AlterarEndereco(int id, EnderecoFuncionario endereco)
        {
            Funcionario funcionario = _context.Funcionario.Find(id);
            funcionario.endereco = endereco;
            funcionario.dataAlteracao = DateTime.Now;
            _context.Funcionario.Update(funcionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncionario", new { id }, funcionario);
        }
    }
}
