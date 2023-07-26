using POS.Application.Commons.Base;
using POS.Application.DTOs.Request;
using POS.Application.DTOs.Response;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;

namespace POS.Application.Interfaces;

public interface ICategoryApplication
{
    Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters);
    Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories();
    Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId);
    Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);
    Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);
    Task<BaseResponse<bool>> RemoveCategory(int categoryId);
}
