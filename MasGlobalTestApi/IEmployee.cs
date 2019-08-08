using System;

public interface IEmployee
{
    int Id;
    string Name;
    ContractType ContractTypeName;
    int RoleId;
    string RoleName;
    string RoleDescription;
    Int64 HourlySalary;
    Int64 MonthlySalary;
    Int64 CalculateSalary();
}
