using System.Runtime.InteropServices;
using AutoMapper;
using Orbital_Africa_Backend_Recon.Models;
namespace Orbital_Africa_Backend_Recon.Modal.Helper
{
    public class AutoMapperHandler:Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<TblUser, UserModal>().ForMember(
            dest => dest.statusname,
            opt => opt.MapFrom(
                src => (src.Isactive != null) ? "Active" : "In active")).ReverseMap();
           
        }
    }
}
