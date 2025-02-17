using AutoMapper;
using CodeAgenda.Application.Projects.Commands.CreateNotification;
using CodeAgenda.Application.Projects.Commands.DeleteNotification;
using CodeAgenda.Application.Projects.Commands.UpdateNotification;
using CodeAgenda.Application.Projects.Queries.GetAllNotifications;
using CodeAgenda.Application.Projects.Queries.GetNotificationById;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.DTO.Projects;
using CodeAgenda.Services.Interfaces.Projects;
using CodeAgenda.Utility.Response;
using Microsoft.AspNetCore.Mvc;

namespace CodeAgenda.Web.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IProjectService projectService, IMapper mapper)
        {
            _notificationService = notificationService;
            _projectService = projectService;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rsp = new Response<List<NotificationDTO>>();

            try
            {
                var query = new GetAllNotificationsQuery();
                var notifications = await _notificationService.GetAll(query);

                rsp.status = true;
                rsp.value = notifications;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpGet]
        [Route("GetById/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rsp = new Response<NotificationDTO?>();

            try
            {
                var query = new GetNotificationByIdQuery(id);
                var notificationDto = await _notificationService.GetById(query);

                rsp.status = true;
                rsp.value = notificationDto;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] NotificationDTO notificationDto)
        {
            var rsp = new Response<NotificationDTO>();
            try
            {
                var project = await _projectService.GetProjectById(notificationDto.ProjectId);

                if (project == null)
                {
                    rsp.status = false;
                    rsp.message = "Project not found";
                    return NotFound(rsp);
                }

                var notification = _mapper.Map<Notification>(notificationDto);
                var command = new CreateNotificationCommand(notification.Message, notification.ReminderDate, notification.IsRead, project);

                rsp.status = true;
                rsp.value = await _notificationService.Create(command);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] NotificationDTO notificationDto)
        {
            var rsp = new Response<bool>();

            try
            {
                var project = await _projectService.GetProjectById(notificationDto.ProjectId);

                var notification = _mapper.Map<Notification>(notificationDto);
                var command = new UpdateNotificationCommand(notification);

                rsp.status = true;
                await _notificationService.Update(command);
                rsp.value = true;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                var command = new DeleteNotificationCommand(id);
                await _notificationService.Delete(command);
                rsp.value = true;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }
    }
}
