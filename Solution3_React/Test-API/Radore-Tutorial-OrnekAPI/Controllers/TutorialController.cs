using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Radore_Tutorial_OrnekAPI.Data;

namespace Radore_Tutorial_OrnekAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        private readonly TutorialData _tutorialData;

        public TutorialController(TutorialData tutorialData)
        {
            _tutorialData = tutorialData;
        }

        [HttpGet]
        public IActionResult GetTuturials()
        {
            return Ok(_tutorialData.GetAllTutorials());
        }

        [HttpGet("{id}")]
        public IActionResult GetTuturials(int id)
        {
            var tutorial = _tutorialData.GetTutorialById(id);
            if (tutorial == null)
            {
                return NotFound();
            }

            return Ok(tutorial);
        }
    }
}