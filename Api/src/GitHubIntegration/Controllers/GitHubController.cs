using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using GithubIntegration.Facades.Github.Interfaces;

namespace GithubIntegration.Controllers
{

    /// <summary>
    /// Github Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]

    public class GitHubController : ControllerBase
    {
        private readonly IGithubFacade _githubFacade;

        /// <summary>
        /// Construction class
        /// </summary>
        public GitHubController(IGithubFacade githubFacade)
        {
            _githubFacade = githubFacade;
        }

        /// <summary>
        /// Request repository list  
        /// </summary>
        /// <returns>
        /// <param name="user"></param>
        /// <param name="quantity"></param>
        /// <param name="sort"></param>
        /// <param name="direction"></param>
        /// </returns>
        [HttpGet("repositories")]
        public async Task<IActionResult> RepositoryList([Required(AllowEmptyStrings = true)] string user, [Required(AllowEmptyStrings = true)] int quantity, [Required(AllowEmptyStrings = true)] string sort, [Required(AllowEmptyStrings = true)] string direction)
        {
            var value = await _githubFacade.RepositoryList(user, quantity, sort, direction);
            return Ok(value);
        }

    }
}
