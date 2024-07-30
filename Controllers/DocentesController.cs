using docentes.Data;
using docentes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace docentes.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DocentesController : ControllerBase
{
    private readonly DocenteContext docenteContext;

    public DocentesController(DocenteContext docenteContext)
    {
        this.docenteContext = docenteContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Docente>>> GetDocentes()
    {
        return await docenteContext.Docentes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Docente>> GetDocente(long id)
    {
        var docente = await docenteContext.Docentes.FindAsync(id);
        return docente == null ? NotFound() : Ok(docente);
    }

    [HttpPost]
    public async Task<ActionResult<Docente>> PostDocente(Docente docente)
    {
        docenteContext.Docentes.Add(docente);
        await docenteContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDocente), new {id = docente.Id}, docente);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutDocente(long id, Docente docente)
    {
        if (id != docente.Id)
        {
            return BadRequest();
        }

        var existe = await docenteContext.Docentes.FindAsync(id);

        if (existe == null)
        {
            return NotFound();
        }

        existe.Id = docente.Id;
        existe.TipoIdentificacion = docente.TipoIdentificacion;
        existe.Nombre = docente.Nombre;
        existe.Apellido = docente.Apellido;
        existe.Email = docente.Email;
        existe.Telefono = docente.Telefono;
        existe.Contrato = docente.Contrato;
        existe.Ciudad = docente.Ciudad;
        existe.EscalafonTecnico = docente.EscalafonTecnico;
        existe.EscalafonExtension = docente.EscalafonExtension;

        await docenteContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDocente(long id)
    {
        var docente = await docenteContext.Docentes.FindAsync(id);

        if (docente == null)
        {
            return NotFound();
        }

        docenteContext.Docentes.Remove(docente);
        await docenteContext.SaveChangesAsync();
        return NoContent();
    }
}
