using Article.API.Models;

namespace Article.API.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        IQueryable<ArticleModel> GetAll();

        Task<ArticleModel?> GetByIdAsync(int id);

        Task AddAsync(ArticleModel entity);

        Task UpdateAsync(ArticleModel entity);

        Task DeleteAsync(ArticleModel entity);
    }
}