import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from './services/employee.service';
import { Token } from './models/token';
import { Employee } from './models/employee';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'masglobal-test-front';
  displayedColumns: string[] = ['id', 'name', 'contractTypeName', 'roleId', 'roleName', 'roleDescription', 'hourlySalary','monthlySalary','anualSalary'];
  employees: Employee[];
  employeesDataSource = new MatTableDataSource<Employee>(this.employees);
  form: FormGroup;
  token: string;

  constructor(private employeeService : EmployeeService) {
    
  }
  ngOnInit() {
    this.form = new FormGroup({
      employeeId: new FormControl()
    });
    this.employeeService.getToken().subscribe((tokenResponse: Token)=>{
      this.token =tokenResponse.access_token;
    });
  }
 
  send() {
    var id = this.form.controls["employeeId"].value;
    if(id && id>0)
    {
      this.employeeService.getEmployeeById(id,this.token).subscribe((employeeResponse: Employee)=>{
        this.employees = [];
        this.employees.push(employeeResponse);
      });
    }
    else{
      this.employeeService.getEmployees(this.token).subscribe((employeesResponse: Employee[])=>{
        this.employees = employeesResponse;
      });
    }
  }
}
