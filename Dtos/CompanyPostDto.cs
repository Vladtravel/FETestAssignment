using FETestAssignment.Models;

namespace FETestAssignment.Dtos
{
    public class CompanyPostDto
    {
        protected CompanyPostDto(Company company)
        {
            RegistryCode = company.RegistryCode;
        }

        public CompanyPostDto()
        {
            
        }

        public string RegistryCode { get; set; }
    }
}