using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Infrastructure.Persistences.Contexts;
using POS.Infrastructure.Persistences.Interfaces;

namespace POS.Infrastructure.Persistences.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{

    public CategoryRepository(DbposContext context) : base(context) { }

    public async Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters)
    {
        var response = new BaseEntityResponse<Category>();

        var categories = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null);

        if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
        {
            switch (filters.NumFilter)
            {
                case 1:
                    categories = categories.Where(x => x.Name!.Contains(filters.TextFilter));
                    break;
                case 2:
                    categories = categories.Where(x => x.Description!.Contains(filters.TextFilter));
                    break;
            }
        }

        if (filters.StateFilter is not null)
        {
            categories = categories.Where(x => x.State.Equals(filters.StateFilter));
        }

        if (!string.IsNullOrEmpty(filters.StarDate) && !string.IsNullOrEmpty(filters.EndDate))
        {
            categories = categories.Where(x => x.AuditCreateDate >= Convert.ToDateTime(filters.StarDate) && x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
        }

        // Usando asignacion compuesta
        filters.Sort ??= "Id";

        // Asi es el habitual
        //if (filters.Sort is null) filters.Sort = "Id";

        response.TotalRecords = await categories.CountAsync();
        response.Items = await Ordering(filters, categories, !(bool)filters.Download!).ToListAsync();

        return response;
    }


}
