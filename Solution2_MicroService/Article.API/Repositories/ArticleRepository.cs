using Article.API.Models;
using Article.API.Repositories.Data;
using Article.API.Repositories.Interfaces;
using Article.API.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Article.API.Repositories
{
    public class ArticleRepository : IArticleRepository // : List<ArticleModel>,
    {
        private static List<ArticleModel> articles = PopulateArticles();
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        private static List<ArticleModel> PopulateArticles()
        {
            var articleList = new List<ArticleModel>()
            {
                new ArticleModel()
                {
                    Id=1,
                    Title="Makale 1",
                    WriterId=1,
                    LastUpdate=DateTime.Now
                },new ArticleModel()
                {
                    Id=2,
                    Title="Makale 2",
                    WriterId=2,
                    LastUpdate=DateTime.Now
                },new ArticleModel()
                {
                    Id=3,
                    Title="Makale 3",
                    WriterId=3,
                    LastUpdate=DateTime.Now
                }
            };
            return articleList;
        }

        public IQueryable<ArticleModel> GetAll()
        {
            //if (_context.Article.Any()) return articles;

            return _context.Article;
        }

        public async Task<ArticleModel?> GetByIdAsync(int id)
        {
            //if (_context.Article.Any()) return articles.FirstOrDefault(x => x.Id == id);

            return await _context.Article.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(ArticleModel entity)
        {
            await _context.Article.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(ArticleModel entity)
        {
            var editArticle = await _context.Article.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (editArticle != null)
            {
                editArticle.Title = entity.Title;
                editArticle.LastUpdate = DateTime.Now;
                editArticle.WriterId = entity.WriterId;
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteAsync(ArticleModel entity)
        {
            #region
            //if (_appDbContext.Article.Any())
            //{
            //    var findDelete = articles.FirstOrDefault(x => x.Id == id);
            //    if (findDelete != null)
            //    {
            //        articles.Remove(findDelete);
            //    }
            //    return findDelete?.Id ?? 0;
            //}
            #endregion

            _context.Remove(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}