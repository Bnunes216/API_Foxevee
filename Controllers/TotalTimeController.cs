using ApiJogo.Data;
using ApiJogo.Modal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace ApiJogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalTimeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TotalTimeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/registros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TotalTimeRegistro>>> GetRegistros()
        {
            return await _context.TotalTimeRegistro.ToListAsync();
        }

        // GET: api/registros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TotalTimeRegistro>> GetRegistro(int id)
        {
            var registro = await _context.TotalTimeRegistro.FindAsync(id);

            if (registro == null)
            {
                return NotFound();
            }

            return registro;
        }

        // POST: api/registros
        [HttpPost]
        public async Task<ActionResult<TotalTimeRegistro>> PostRegistro(TotalTimeRegistro TotalTime)
        {
            _context.TotalTimeRegistro.Add(TotalTime);
            await _context.SaveChangesAsync();

            // Retorna o recurso criado com o 'id' gerado
            return CreatedAtAction(nameof(GetRegistro), new { id = TotalTime.id }, TotalTime);

        }

        // PUT: api/registros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro(int id, TotalTimeRegistro TotalTime)
        {
            var registro = await _context.TotalTimeRegistro.FindAsync(id);

            if (registro == null)
            {
                return NotFound();
            }

            // Atualize apenas as propriedades necessárias
            registro.nome = TotalTime.nome;
            registro.total_time = TotalTime.total_time;
            registro.data_cadastro = TotalTime.data_cadastro;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TotalTimeRegistro.Any(e => e.id == id))
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

        // DELETE: api/registros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro(int id)
        {
            var totalTime = await _context.TotalTimeRegistro.FindAsync(id);
            if (totalTime == null)
            {
                return NotFound();
            }

            _context.TotalTimeRegistro.Remove(totalTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
