export class Employee {
    
    static mapFromResponse(data: any): Employee {
        return new Employee(
            data.Id,
            data.Name,
            data.ContractTypeName,
            data.RoleId,
            data.RoleName,
            data.RoleDescription,
            data.HourlySalary,
            data.MonthlySalary,
            data.AnualSalary
        );
    }

    static mapListFromResponse(item: any[]): Employee[] {
        if (item == null) {
          return null;
        }
        return item.map(
          data =>
            new Employee(
                data.Id,
                data.Name,
                data.ContractTypeName,
                data.RoleId,
                data.RoleName,
                data.RoleDescription,
                data.HourlySalary,
                data.MonthlySalary,
                data.AnualSalary
            )
        );
      }

    constructor(
        public id: number,
        public name: string,
        public contractTypeName: string,
        public roleId: number,
        public roleName: string,
        public roleDescription: string,
        public hourlySalary: number,
        public monthlySalary: number,
        public anualSalary: number,
    ) { }
}
