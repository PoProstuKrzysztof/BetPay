using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await FindAll()
            .Result
            .OrderBy(x => x.CategoryId)
            .ToListAsync();
    }
}