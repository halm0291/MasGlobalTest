import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { map } from "rxjs/operators";
import { Token } from '../models/token';
@Injectable({
    providedIn: 'root'
  })
  export class EmployeeService {
    private getTokenUrl : string = 'http://localhost:53736/oauth/token';
    private getEmployeesUrl : string = 'http://localhost:53736/GetEmployees';
    private getEmployeeByIdUrl : string = 'http://localhost:53736/GetEmployeeById/Id';
    constructor(private http: HttpClient) {

        
    }
    getToken(): Observable<Token>{
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/x-www-form-urlencoded'               
            })
          };
          const body = new HttpParams()
          .set("grant_type", "client_credentials")
          .set("client_id", "1235")
          .set("client_secret", "6779ef20e75817b79602")
        return this.http.post(this.getTokenUrl,body, httpOptions).pipe(
            map((data) => Token.mapFromResponse(data))
        );
    }
    getEmployeeById(employeeId :number,token: string): Observable<Employee>{
        const httpOptions = {
            headers: new HttpHeaders({
                "Authorization":`Bearer ${token}`
            })
          };
        return this.http.get(`${this.getEmployeeByIdUrl}/${employeeId}`, httpOptions).pipe(
            map((data) => Employee.mapFromResponse(data))
        );
    }
    getEmployees(token: string): Observable<Employee[]>{
        const httpOptions = {
            headers: new HttpHeaders({
                "Authorization":`Bearer ${token}`
            })
          };
        return this.http.get(this.getEmployeesUrl, httpOptions).pipe(
            map((data: any[]) => Employee.mapListFromResponse(data))
        );
    }
  }