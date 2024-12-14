using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Mappers
{
    public static class CompanyMappers
    {
        public static CompanyDTO ToCompanyDTO(this Company CompanyModel)
        {
            return new CompanyDTO
            {
                FullName = CompanyModel.FullName,
                ShortName = CompanyModel.ShortName,
                RegAddress = CompanyModel.RegAddress,
                CurrAddress = CompanyModel.CurrAddress,
                PhoneNumber = CompanyModel.PhoneNumber,
                INN = CompanyModel.INN,
                KPP = CompanyModel.KPP,
                OGRN = CompanyModel.OGRN,
                Director = CompanyModel.Director,
                LineOfWork = CompanyModel.LineOfWork,
            };
        }

        public static Company ToCompanyFromCreateDTO(this CreateCompanyRequestDTO CompanyDTO)
        {
            return new Company
            {
                FullName = CompanyDTO.FullName,
                ShortName = CompanyDTO.ShortName,
                RegAddress = CompanyDTO.RegAddress,
                CurrAddress = CompanyDTO.CurrAddress,
                PhoneNumber = CompanyDTO.PhoneNumber,
                INN = CompanyDTO.INN,
                KPP = CompanyDTO.KPP,
                OGRN = CompanyDTO.OGRN,
                Director = CompanyDTO.Director,
                LineOfWork = CompanyDTO.LineOfWork,
            };
        }
    }
}
