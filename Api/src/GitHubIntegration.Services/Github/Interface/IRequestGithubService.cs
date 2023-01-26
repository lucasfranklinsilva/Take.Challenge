using System.Collections.Generic;
using System.Threading.Tasks;
using GithubIntegration.Models.Github;
using RestEase;

namespace GithubIntegration.Services.Atlassian.Interface
{
    [Header("Content-Type", "application/json")]
    [Header("User-Agent", "GithubIntegration")]
    public interface IRequestGithubService
    {
        [Get("/users/{user}/repos{query}")]
        Task<List<Repositories>> RepositoriesList([Path(UrlEncode = false)] string user, [Path(UrlEncode = false)] string query);
    }
}
