namespace Api1.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api1.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a controller for retrieving information from the API.
    /// </summary>
    [Route("api/energy_data")]
    [ApiController]
    public class EnergyDataController : ControllerBase
    {
        private readonly EnergyDataDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyDataController"/> class.
        /// </summary>
        /// <param name="context">The database context used for accessing information.</param>
        public EnergyDataController(EnergyDataDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Retrieves all company energy data.
        /// </summary>
        /// <returns>A collection of company energy data.</returns>
        // GET: api/energy_data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyData>>> GetCompanyEnergyData()
        {
            return await context.CompanyEnergyData.ToListAsync();
        }

        /// <summary>
        /// Retrieves the energyData table for a specific ID.
        /// </summary>
        /// <param name="id">The ID of the energyData table.</param>
        /// <returns>The energyData table associated with the given ID.</returns>
        // GET: api/energy_data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyData>> GetEnergyData(int id)
        {
            var energyData = await context.CompanyEnergyData.FindAsync(id);

            if (energyData == null)
            {
                return NotFound();
            }

            return energyData;
        }

        /// <summary>
        /// Retrieves the energyData table for a specific ID.
        /// </summary>
        /// <param name="id">The ID of the energyData table.</param>
        /// <returns>The energyData table associated with the given ID.</returns>
        // GET: api/energy_data/5
        [HttpGet("security/getMessage")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EnergyData>>> GetMessage()
        {
            return await context.CompanyEnergyData.ToListAsync();
        }

        /// <summary>
        /// Checks if an energyData table with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the energyData table.</param>
        /// <returns>True if an energyData table with the specified ID exists; otherwise, false.</returns>
        private bool EnergyDataExists(int id)
        {
            return context.CompanyEnergyData.Any(e => e.Id == id);
        }
    }
}
