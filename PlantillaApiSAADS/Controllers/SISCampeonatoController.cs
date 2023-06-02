using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantillaApiSAADS.DTOs;
using PlantillaApiSAADS.Models.RNDS;

namespace PlantillaApiSAADS.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SISCampeonatoController : ControllerBase
    {
        //
        private readonly SistemaCampeonatoContext context;
        private readonly IMapper mapper;

        public SISCampeonatoController(SistemaCampeonatoContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("jugador")]
        public async Task<ActionResult> getJugadores()
        {
            var listJugadores = await context.Jugador.Include(x => x.persona).Include(x=>x.equipo).ToListAsync();
            return Ok(mapper.Map<List<PerosnaWithJugador>>(listJugadores));
        }

        [HttpGet("jugador/{id:int}")]
        public async Task<ActionResult> getJugadores(int id)
        {
            var listJugadores = await context.Jugador.Include(x => x.persona).Include(x => x.equipo).FirstOrDefaultAsync(x=>x.persona.persona_id == id);
            return Ok(mapper.Map<personaADD>(listJugadores));
        }


        [HttpPost("jugador")]
        public async Task<ActionResult> setJugadores(personaADD jugador)
        {
            personaDTO PersonaInsertar = jugador.persona;
            if (jugador.persona is not null)
                await context.Persona.AddAsync(mapper.Map<Persona>(PersonaInsertar));
            await context.SaveChangesAsync();

            var idPersona = context.Persona.OrderBy(x=>x.persona_id).LastOrDefaultAsync().Result?.persona_id;
            
            var jugadorInsert = new jugadorDTO()
            {
                altura = jugador.altura,
                equipoId = jugador.equipoId,
                estadisticas = jugador.estadisticas,
                habilidades = jugador.habilidades,
                jugadorid = jugador.jugadorid,
                lesiones = jugador.lesiones,
                numero_camiseta = jugador.numero_camiseta,
                personaId = idPersona,
                posicion = jugador.posicion,
                peso = jugador.peso,
            };

           
            if (jugador != null)
                await context.Jugador.AddAsync(mapper.Map<Jugador>(jugadorInsert));
            await context.SaveChangesAsync();

            return Ok(jugador);
        }

        [HttpDelete("jugador")]
        public async Task<ActionResult> delJugador(int id)
        {
            var ljugador  = await context.Jugador.FirstOrDefaultAsync(x=>x.personaId == id);

            if (ljugador != null)
                 context.Jugador.Remove(ljugador);
            await context.SaveChangesAsync();

            var lpersona = await context.Persona.FirstOrDefaultAsync(x => x.persona_id == id);
   
            if (lpersona != null)
                context.Persona.Remove(lpersona);
            await context.SaveChangesAsync();
            return Ok(ljugador);
        }

        [HttpPut("jugador")]
        public async Task<ActionResult> updJugador(PerosnaWithJugador jugador)
        {
            personaDTO PersonaInsertar = jugador.persona;
            if (jugador.persona is not null)
                 context.Persona.Update(mapper.Map<Persona>(PersonaInsertar));
            await context.SaveChangesAsync();

            

            var jugadorInsert = new jugadorDTO()
            {
                altura = jugador.altura,
                equipoId = jugador.equipoId,
                estadisticas = jugador.estadisticas,
                habilidades = jugador.habilidades,
                jugadorid = jugador.jugadorid,
                lesiones = jugador.lesiones,
                numero_camiseta = jugador.numero_camiseta,
                posicion = jugador.posicion,
                personaId = jugador.personaId,
                peso = jugador.peso,
            };


            if (jugador != null)
                 context.Jugador.Update(mapper.Map<Jugador>(jugadorInsert));
            await context.SaveChangesAsync();

            return Ok(jugador);
        }

        [HttpGet("equipo")]
        public ActionResult getEquipo()
        {
            var listJugadores = context.Equipo.ToList();
            return Ok(listJugadores);
        }



    }
}
