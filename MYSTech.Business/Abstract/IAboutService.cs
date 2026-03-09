using MYSTech.DTO.DTOs.AboutDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.Business.Abstract
{
    public interface IAboutService
        : IGenericService<About, ResultAboutDto, CreateAboutDto, UpdateAboutDto>
    {
        Task<ResultAboutDto> TGetFirstAsync();
    }
}
