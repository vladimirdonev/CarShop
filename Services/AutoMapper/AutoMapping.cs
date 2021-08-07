using AutoMapper;
using CarShop.Models;
using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;
using CarShop.ViewModels.UserRoles;
using Microsoft.AspNetCore.Identity;

namespace CarShop.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateCarViewModel, Car>();
            CreateMap<Car, AllCarsViewModel>();
            CreateMap<CreateIssueViewModel, Issue>();
            CreateMap<Issue, AllIssuesViewModel>()
                .ForMember(x => x.CarModelName, opt => opt.MapFrom(x => x.Car.Model));
            CreateMap<IdentityRole, AllRolesViewModel>()
                .ForMember(x => x.RoleId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.RoleName, opt => opt.MapFrom(x => x.Name));
        }
    }
}
