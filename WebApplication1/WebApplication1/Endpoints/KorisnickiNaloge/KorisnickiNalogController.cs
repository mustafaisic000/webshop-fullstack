using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Endpoints.KorisnickiNaloge
{
    [ApiController]
    [Route("[controller]")]
    public class KorisnickiNalogController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public KorisnickiNalogController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public class IsActive
        {
            public bool active { get; set; }
        }
        [HttpPost("{id}/update-2fa-active")]
        public IActionResult Update2FAActive(int id, [FromBody] IsActive x)
        {
            var korisnickiNalog = _dbContext.KorisnickiNalog.Find(id);

            if (korisnickiNalog == null)
            {
                return NotFound();
            }

            try
            {
                korisnickiNalog.Is2FActive = x.active;
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
