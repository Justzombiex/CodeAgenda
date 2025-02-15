﻿using AutoMapper;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.DTO.Assignments;
using CodeAgenda.DTO.Common;
using CodeAgenda.DTO.Projects;
using CodeAgenda.DTO.Users;

namespace CodeAgenda.Web.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            #region User
            CreateMap<User, UserDTO>().ReverseMap();
            #endregion User

            #region Project
            CreateMap<Project, ProjectDTO>().ReverseMap();
            #endregion Project

            #region Category
            CreateMap<Category, CategoryDTO>().ReverseMap();
            #endregion Category

            #region Notification
            CreateMap<Notification, NotificationDTO>().ReverseMap();
            #endregion Notification

            #region NoteProject
            CreateMap<NoteProject, NoteProjectDTO>().ReverseMap();
            #endregion NoteProject

            #region NoteAssignment
            CreateMap<NoteAssignment, NoteAssignmentDTO>().ReverseMap();
            #endregion NoteAssignment

            #region Assignment
            CreateMap<Assignment, AssignmentDTO>().ReverseMap();
            #endregion Assignment

            #region TagAssignment
            CreateMap<TagAssignment, TagAssignmentDTO>().ReverseMap();
            #endregion TagAssignment

            #region TagProject
            CreateMap<TagProject, TagProjectDTO>().ReverseMap();
            #endregion TagProject
        }
    }
}
