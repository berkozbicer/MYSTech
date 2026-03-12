using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.ProjectDTOs;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProjectsController(IProjectService _projectService) : ControllerBase
    {
        /// <summary>Tüm projeleri getirir.</summary>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProjectDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var projects = await _projectService.TGetListAsync();
            return Ok(ApiResponse<List<ResultProjectDto>>.SuccessResponse(projects));
        }

        /// <summary>ID'ye göre proje getirir.</summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultProjectDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectService.TGetByIdAsync(id);
            if (project == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultProjectDto>.SuccessResponse(project));
        }

        /// <summary>Proje detayını getirir.</summary>
        [HttpGet("{id}/detail")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultProjectDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetail(int id)
        {
            var project = await _projectService.TGetDetailAsync(id);
            if (project == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultProjectDetailDto>.SuccessResponse(project));
        }

        /// <summary>Slug'a göre proje detayını getirir.</summary>
        [HttpGet("slug/{slug}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultProjectDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var project = await _projectService.TGetDetailBySlugAsync(slug);
            if (project == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultProjectDetailDto>.SuccessResponse(project));
        }

        /// <summary>Aktif projeleri sıralı getirir.</summary>
        [HttpGet("active")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProjectDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActive()
        {
            var projects = await _projectService.TGetActiveProjectsAsync();
            return Ok(ApiResponse<List<ResultProjectDto>>.SuccessResponse(projects));
        }

        /// <summary>Kategoriye göre projeleri getirir.</summary>
        [HttpGet("category/{category}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProjectDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var projects = await _projectService.TGetByCategoryAsync(category);
            return Ok(ApiResponse<List<ResultProjectDto>>.SuccessResponse(projects));
        }

        /// <summary>Yeni proje oluşturur.</summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProjectDto createProjectDto)
        {
            await _projectService.TCreateAsync(createProjectDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Proje oluşturuldu."));
        }

        /// <summary>Proje günceller.</summary>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateProjectDto updateProjectDto)
        {
            await _projectService.TUpdateAsync(updateProjectDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Proje güncellendi."));
        }

        /// <summary>Proje siler.</summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Proje silindi."));
        }
    }
}
