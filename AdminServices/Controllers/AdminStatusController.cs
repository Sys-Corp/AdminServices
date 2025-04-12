using AdminService.Application.DTO;
using AdminService.Application.Services;
using AdminService.Domain.Entities;
using AdminService.Utility.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AdminService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminStatusController : Controller
    {
        private readonly AdminStatusService _adminStatusService;
        public AdminStatusController(AdminStatusService adminStatusService)
        {
            _adminStatusService = adminStatusService;
        }

        [HttpGet]
        [Route("GetAdmminStatusAll")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAdmminStatusAll()
        {
            try
            {
                List<AdminStatus> adminStatuses = await _adminStatusService.GetAdminStatusAll();

                if (adminStatuses.Count == 0)
                    return NotFound(new ApiResponse(404, "No data found.", null));

                return Ok(new ApiResponse(200, "Success.", adminStatuses));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, null));
            }
        }
        [HttpGet]
        [Route("GetAdminStatusById")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAdminStatusById([FromQuery] int id)
        {
            try
            {
                AdminStatus adminStatuses = await _adminStatusService.GetAdminStatusById(id);

                if (adminStatuses == null)
                    return NotFound(new ApiResponse(404, "No data found", null));

                return Ok(new ApiResponse(200, "Success.", adminStatuses));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, null));
            }
        }

        [HttpGet]
        [Route("GetAdminStatusByFilter")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAdminStatusByFilter([FromQuery] int? id,
            [FromQuery] string? description,
            [FromQuery] DateTime? createdAt,
            [FromQuery] DateTime? updatedAt)
        {
            try
            {
                List<AdminStatus> adminStatuses = await _adminStatusService.GetAdminStatusByFilter(id, description, createdAt, updatedAt);

                if (adminStatuses.Count == 0)
                    return NotFound(new ApiResponse(404, "No data found.", null));

                return Ok(new ApiResponse(200, "Success.", adminStatuses));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, null));
            }
        }

        [HttpPost]
        [Route("CreateAdminStatus")]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateAdminStatus([FromBody, Required] AdminStatusCreateDTO model)
        {
            try
            {
                AdminStatus adminStatus = new AdminStatus
                {
                    description = model.description
                };

                var createdAdminStatus = await _adminStatusService.CreateAdminStatus(adminStatus);

                if (createdAdminStatus == null)
                    return Conflict(new ApiResponse(409, "Description is already Exsits", null));

                return Ok(new ApiResponse(201, $"{model.description} is successfully created.", createdAdminStatus));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, null));
            }
        }

        [HttpPut]
        [Route("UpdateAdminStatus")]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateAdminStatus([FromBody, Required] AdminStatusUpdateDTO model)
        {
            try
            {
                AdminStatus adminStatus = new AdminStatus
                {
                    id = model.id,
                    description = model.description
                };

                var updatedAdminStatus = await _adminStatusService.UpdateAdminStatus(adminStatus);

                return Ok(new ApiResponse(200, $"Id:{model.id} is successfully updated.", updatedAdminStatus));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse(404, ex.Message, null));
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ApiResponse(409, ex.Message, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, null));
            }
        }

        [HttpDelete]
        [Route("DeleteAdminStatus")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteAdminStatus([FromQuery, Required] int id)
        {
            try
            {
                bool deletedAdminStatus = await _adminStatusService.DeleteAdminStatus(id);

                if (!deletedAdminStatus) return NotFound(new ApiResponse(404, $"Id:{id} is not exists.", null));

                return Ok(new ApiResponse(200,$"Id:{id} is successfully deleted",new {id = id}));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, ex.Message, null));
            }
        }
    }
}
