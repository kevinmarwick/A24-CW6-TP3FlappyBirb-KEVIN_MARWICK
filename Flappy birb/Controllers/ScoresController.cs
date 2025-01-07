using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flappy_Birb.Data;
using Flappy_Birb.Models;
using Microsoft.AspNetCore.Authorization;

namespace Flappy_Birb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoresController : Controller
    {
        private readonly FlappyBirbContext _context;

        public ScoresController(FlappyBirbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> PostScore(Score score)
        {
            if (ModelState.IsValid)
            {
                _context.Add(score);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(score);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMyScores(string userId)
        { 
            var userScores = await _context.Score.Where(s => s.User.Id == userId).OrderByDescending(s => s.Points).Take(10).ToListAsync();
            return Ok(userScores);                                                  
        }

        [HttpGet]
        public async Task<IActionResult> GetPublicScores()
        {
            var top10Scores = await _context.Score.OrderByDescending(s => s.Points).Take(10).ToListAsync();
            return Ok(top10Scores);
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> ChangeScoreVisibility(int id)
        {
            var score = await _context.Score.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            score.IsVisible = !score.IsVisible;
            await _context.SaveChangesAsync();
            return Ok(score);
        }
    }
}
