using ExpensesBackend.DatabaseContext;
using ExpensesBackend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesBackend.Controllers
{
    [EnableCors("AllowAllOrigins")]

    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        [HttpGet(Name = "GetEntries")]
        public IActionResult GetEntries()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var entries = context.Entries.ToList();
                    return Ok(entries);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}", Name = "GetEntry")]
        public IActionResult GetEntry(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var entry = context.Entries.FirstOrDefault(e => e.Id == id);
                    if (entry == null)
                    {
                        return NotFound();

                    }
                    return Ok(entry);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]

        public ActionResult PostEntry([FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                using (var context = new AppDbContext())
                {

                    context.Entries.Add(entry);
                    context.SaveChanges();
                    return Ok(new { message = "Entry was created", entry });

                }

            }
            catch (Exception ex)
            {

                return BadRequest(new { error = ex.Message });
            }


        }

        [HttpPut("{id}")]
        public IActionResult UpdateEntry(int id, [FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != entry.Id)
            {
                return BadRequest();
            }
            try
            {
                using (var context = new AppDbContext())
                {
                    var oldEntry = context.Entries.FirstOrDefault(e => e.Id == id);
                    if (oldEntry == null)
                    {
                        return NotFound();
                    }
                    oldEntry.Description = entry.Description;
                    oldEntry.IsExpense = entry.IsExpense;
                    oldEntry.Value = entry.Value;
                    context.SaveChanges();
                    return Ok(new { message = "Entry was updated", entry });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEntry(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var entry = context.Entries.FirstOrDefault(e => e.Id == id);
                    if (entry == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        context.Entries.Remove(entry);
                        context.SaveChanges();
                        return Ok(new { message = "Entry removed successfully" });
                    }

                }
            }
            catch(Exception ex)
            {
                return BadRequest(new {messgae = ex.Message});
            }

        }
    }

}
