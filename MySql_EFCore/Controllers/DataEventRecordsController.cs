using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql_EFCore.Data.Entities;

namespace MySql_EFCore.Controllers
{
    [Produces("application/json")]
    [Route("api/DataEventRecords")]
    public class DataEventRecordsController : Controller
    {
        private readonly MySqlDbContext _context;

        public DataEventRecordsController(MySqlDbContext context)
        {
            _context = context;
        }

        // GET: api/DataEventRecords
        [HttpGet]
        public IEnumerable<DataEventRecord> GetDataEventRecords()
        {
            return _context.DataEventRecords;
        }

        // GET: api/DataEventRecords/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDataEventRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dataEventRecord = await _context.DataEventRecords.SingleOrDefaultAsync(m => m.DataEventRecordId == id);

            if (dataEventRecord == null)
            {
                return NotFound();
            }

            return Ok(dataEventRecord);
        }

        // PUT: api/DataEventRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataEventRecord([FromRoute] int id, [FromBody] DataEventRecord dataEventRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dataEventRecord.DataEventRecordId)
            {
                return BadRequest();
            }

            _context.Entry(dataEventRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataEventRecordExists(id))
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

        // POST: api/DataEventRecords
        [HttpPost]
        public async Task<IActionResult> PostDataEventRecord([FromBody] DataEventRecord dataEventRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DataEventRecords.Add(dataEventRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataEventRecord", new { id = dataEventRecord.DataEventRecordId }, dataEventRecord);
        }

        // DELETE: api/DataEventRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataEventRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dataEventRecord = await _context.DataEventRecords.SingleOrDefaultAsync(m => m.DataEventRecordId == id);
            if (dataEventRecord == null)
            {
                return NotFound();
            }

            _context.DataEventRecords.Remove(dataEventRecord);
            await _context.SaveChangesAsync();

            return Ok(dataEventRecord);
        }

        private bool DataEventRecordExists(int id)
        {
            return _context.DataEventRecords.Any(e => e.DataEventRecordId == id);
        }
    }
}