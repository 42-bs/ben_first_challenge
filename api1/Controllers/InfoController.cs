namespace Api1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api1.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// .
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly InfoContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoController"/> class.
        /// .
        /// </summary>
        /// <param name="context">cavalinho.</param>
        public InfoController(InfoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns>c.</returns>
        // GET: api/Info
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoTable>>> GetCompany_Energy_Data()
        {
            return await context.Company_Energy_Data.ToListAsync();
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">c.</param>
        /// <returns>C.</returns>
        // GET: api/Info/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoTable>> GetInfoTable(int id)
        {
            var infoTable = await context.Company_Energy_Data.FindAsync(id);

            if (infoTable == null)
            {
                return NotFound();
            }

            return infoTable;
        }

        // // PUT: api/Info/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutInfoTable(int id, InfoTable infoTable)
        // {
        //     if (id != infoTable.Id)
        //     {
        //         return BadRequest();
        //     }
        //     _context.Entry(infoTable).State = EntityState.Modified;
        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!InfoTableExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        //     return NoContent();
        // }

        // POST: api/Info
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<InfoTable>> PostInfoTable(InfoTable infoTable)
        // {
        //     _context.My_Info_Table.Add(infoTable);
        //     await _context.SaveChangesAsync();
        //     return CreatedAtAction("GetInfoTable", new { id = infoTable.Id }, infoTable);
        // }

        // DELETE: api/Info/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteInfoTable(int id)
        // {
        //     var infoTable = await _context.My_Info_Table.FindAsync(id);
        //     if (infoTable == null)
        //     {
        //         return NotFound();
        //     }
        //     _context.My_Info_Table.Remove(infoTable);
        //     await _context.SaveChangesAsync();
        //     return NoContent();
        // }
        private bool InfoTableExists(int id)
        {
            return context.Company_Energy_Data.Any(e => e.Id == id);
        }
    }
}
