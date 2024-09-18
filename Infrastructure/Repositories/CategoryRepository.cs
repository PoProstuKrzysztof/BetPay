using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {

        try
        {
            return await FindAll()
              .Result
              .OrderBy(x => x.CategoryId)
              .ToListAsync();
        }
        catch (Exception ex)
        {

            throw new RetrieveException("Failed to retrieve categories.",nameof(Category),ex);
        }
    }
}