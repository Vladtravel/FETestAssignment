using System;
using FETestAssignment.Models;

namespace FETestAssignment.Dtos
{
    public class CompanyDto : CompanyPostDto
    {
        public CompanyDto(Company company) : base(company)
        {
            Id = company.Id;
            Name = company.Name;
            RegistryCode = company.RegistryCode;
        }

        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}