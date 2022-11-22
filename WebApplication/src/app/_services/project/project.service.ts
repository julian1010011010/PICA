import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private urlApi = `${ environment.apiUrl }/Ocelot/Proyecto/`;

  constructor(private http: HttpClient) { }

  getProjects(): Observable<any[]> {
    return this.http.get<any[]>(`${ this.urlApi }/GetList`);
  }
 

  getProjectById(pId: number): Observable<any[]>
  {
    return this.http.get<any[]>(`${ this.urlApi }/GetProjectby/pId=${pId}`);
  }

  getProjectsV2(): Observable<any[]> {
    return this.http.get<any[]>(`${ this.urlApi }/GetListProyect`);
  }


  createProject( project: any ){
    return this.http.post(`${ this.urlApi }/CreateProyect`, project );
  }


}
