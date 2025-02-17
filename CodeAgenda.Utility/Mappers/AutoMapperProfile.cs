﻿using AutoMapper;
using CodeAgenda.Domain.Entities.Assignments;
using CodeAgenda.Domain.Entities.Common;
using CodeAgenda.Domain.Entities.Projects;
using CodeAgenda.Domain.Entities.Users;
using CodeAgenda.DTO.Assignments;
using CodeAgenda.DTO.Common;
using CodeAgenda.DTO.Projects;
using CodeAgenda.DTO.Users;
using System.Drawing;

namespace CodeAgenda.Utility.Mappers
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
            CreateMap<Category, CategoryDTO>()
                   .ForMember(dest => dest.Color, opt => opt.MapFrom(src => GetColorName(src.Color)));

            CreateMap<CategoryDTO, Category>()
                   .ForMember(dest => dest.Color, opt => opt.MapFrom(src => Color.FromName(src.Color)));
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

            CreateMap<TagAssignment, TagAssignmentDTO>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => GetColorName(src.Color)));

            CreateMap<TagAssignmentDTO, TagAssignment>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => Color.FromName(src.Color)));

            #endregion TagAssignment

            #region TagProject

            CreateMap<TagProject, TagProjectDTO>()
                    .ForMember(dest => dest.Color, opt => opt.MapFrom(src => GetColorName(src.Color)));

            CreateMap<TagProjectDTO, TagProject>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => Color.FromName(src.Color)));

            #endregion TagProject

        }

        private string GetColorName(Color color)
        {
            return color.IsKnownColor ? color.Name : $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }

}