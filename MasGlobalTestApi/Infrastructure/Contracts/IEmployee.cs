using System;
namespace Infrastrucutre
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        string ContractTypeName { get; set; }
        int RoleId { get; set; }
        string RoleName { get; set; }
        string RoleDescription { get; set; }
        Int64 HourlySalary { get; set; }
        Int64 MonthlySalary { get; set; }
        Int64 AnualSalary { get;}
    }
}
