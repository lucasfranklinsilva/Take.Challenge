using System.Collections.Generic;
using System.Threading.Tasks;
using GithubIntegration.Models.Github;

namespace GithubIntegration.Facades.Github.Interfaces
{
    public interface IGithubFacade
    {
        /// <summary>
        /// Repositories Request
        /// </summary>
        /// <param name="user"></param>
        /// <param name="quantity"></param>
        /// <param name="sort"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        Task<IEnumerable<RepositoriesDto>> RepositoryList(string user, int quantity, string sort, string direction);
    }
}
