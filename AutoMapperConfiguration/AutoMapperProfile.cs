using AutoMapper;
using Contact_Management_Web_App.ViewModels;

namespace Contact_Management_Web_App.AutoMapperConfiguration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Contact, ContactViewModel>().ReverseMap();
        }
    }
}
