using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommandsReminder.Database;
using CommandsReminder.Models;

namespace CommandsReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandsDbContext _context;

        public CommandsController(CommandsDbContext context)
        {
            _context = context;
        }

        // GET: api/Commands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Command>>> GetCommands()
        {
            return await _context.Commands.ToListAsync();
        }

        // GET: api/Commands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Command>> GetCommand(int id)
        {
            var command = await _context.Commands.FindAsync(id);

            if (command == null)
            {
                return NotFound();
            }

            return command;
        }

        // PUT: api/Commands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommand(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandExists(id))
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

        // POST: api/Commands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Command>> PostCommand(Command command)
        {
            _context.Commands.Add(command);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommand", new { id = command.Id }, command);
        }

        // DELETE: api/Commands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Command>> DeleteCommand(int id)
        {
            var command = await _context.Commands.FindAsync(id);
            if (command == null)
            {
                return NotFound();
            }

            _context.Commands.Remove(command);
            await _context.SaveChangesAsync();

            return command;
        }

        private bool CommandExists(int id)
        {
            return _context.Commands.Any(e => e.Id == id);
        }
    }
}
