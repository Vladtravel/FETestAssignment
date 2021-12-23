using System;

namespace FETestAssignment.Models
{
    public class Company
    {
        public Guid? Id { get; set; }
        
        public string Name { get; set; }
        
        public string RegistryCode { get; set; }
    }
}