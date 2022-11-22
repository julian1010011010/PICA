import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PagoService {

  private urlApi = `${ environment.apiUrl }/Ocelot/Pago/`;

  constructor(private http: HttpClient) { }

  getPagos(): Observable<any[]> {
    return this.http.get<any[]>(`${ this.urlApi }/GetList`);
  }

  getPagoById(pId: number): Observable<any[]>
  {
    return this.http.get<any[]>(`${ this.urlApi }/${pId}`);
  }

  getListPagos(): Observable<any[]> {
    return this.http.get<any[]>(`${ this.urlApi }/GetListPagos`);
  }

  createPago( project: any ){
    return this.http.post(`${ this.urlApi }/CreatePago`, project );
  }


}
