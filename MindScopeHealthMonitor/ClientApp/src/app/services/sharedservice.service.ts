import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Config } from '../Models/config';
import { Database } from '../Models/database';
import { DbTable } from '../Models/db-table';
import { DBIdentityReport } from '../Models/dbidentity-report';
import { DBInfo } from '../Models/dbinfo';
import { DBInfoFilterData } from '../Models/dbinfo-filter-data';
import { Login } from '../Models/login';
import { TableColumn } from '../Models/table-column';

@Injectable({
  providedIn: 'root'
})
export class SharedserviceService {

  baseURL!: string;
  isUser: boolean = false;
  isLoggedin: boolean = false;
  name: string = 'kalp';
  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl
  }

  public getDatabases(): Observable<Database[]> {
    return this.http.get<Database[]>(this.baseURL + "databases");
  }

  public postDatabaseId(id: number): Observable<DbTable[]> {
    return this.http.post<DbTable[]>(this.baseURL + "dbtable", id);
  }

  public getColumnList(tableName:string,id:number): Observable<TableColumn[]> {
    return this.http.get<TableColumn[]>(this.baseURL + "tablecolumns?tableName=" + tableName + "&DBID=" + id);
  }

  public postDBIdentityReport(tableColumn: string[], tableName: string, id: number): Observable<DBIdentityReport[]> {

    var dBInfoList: DBInfo = { "DBID": id, "tableName": tableName, "tableColumns": tableColumn };
    return this.http.post<DBIdentityReport[]>(this.baseURL + "DBIdentityReport", dBInfoList);
  }

  public postFilterDataDBIdentityReport(tableColumn: string[], tableName: string, id: number, filterID: number): Observable<DBIdentityReport[]> {

    var FilterdBInfoList: DBInfoFilterData = { "DBID": id, "tableName": tableName, "tableColumns": tableColumn, "filterDataId": filterID };
   // console.log(FilterdBInfoList);
    return this.http.post<DBIdentityReport[]>(this.baseURL + "DBIdentityFilterDataReport", FilterdBInfoList);
  }

  public postExportReport(report: DBIdentityReport[]): Observable<DBIdentityReport[]> {
   // console.log(report);
    return this.http.post<DBIdentityReport[]>(this.baseURL + "ExportDBIdentityReport", report);
  }

  public Login(username:string, password:string): Observable<Login[]> {
    var login: Login = { "UserName": username, "Password": password };
   // console.log(login);
    return this.http.post<Login[]>(this.baseURL + "login", login);
  }



}
