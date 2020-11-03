﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommandsReminder.Database;
using CommandsReminder.Models;
using CommandsReminder.DTO;
using AutoMapper;

namespace CommandsReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly CommandsDbContext _context;
        private readonly IMapper _mapper;

        public PlatformsController(CommandsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Platforms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformReadDTO>>> GetPlatforms()
        {
            var platforms = await _context.Platforms
                .Include(p => p.Commands)
                .ThenInclude(c => c.Parameters)
                .ToListAsync();

            if(platforms != null)
            {
                return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platforms));
            }

            return NotFound();
        }

        // GET: api/Platforms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlatformReadDTO>> GetPlatform(int id)
        {
            var platform = await _context.Platforms
                .Include(p => p.Commands)
                .ThenInclude(c => c.Parameters)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (platform != null)
            {
                return Ok(_mapper.Map<PlatformReadDTO>(platform));
            }

            return NotFound();
        }

        // PUT: api/Platforms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatform(int id, Platform platform)
        {
            if (id != platform.Id)
            {
                return BadRequest();
            }

            _context.Entry(platform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformExists(id))
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

        // POST: api/Platforms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Platform>> PostPlatform(Platform platform)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatform", new { id = platform.Id }, platform);
        }

        // DELETE: api/Platforms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Platform>> DeletePlatform(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            if (platform == null)
            {
                return NotFound();
            }

            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();

            return platform;
        }

        private bool PlatformExists(int id)
        {
            return _context.Platforms.Any(e => e.Id == id);
        }
    }
}
