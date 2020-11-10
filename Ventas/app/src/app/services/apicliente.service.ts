import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../models/response';
import { Cliente } from '../models/cliente';

const httpOption = {
  headers: new HttpHeaders({
    'Contend-Type': 'applicaton/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiclienteService {

  url: string = 'https://localhost:44385/api/cliente';
  constructor(
    private _http: HttpClient
  ) { }

    getClientes(): Observable<Response>{
      return this._http.get<Response>(this.url);

    }
    add(Cliente: Cliente):Observable<Response>{
      return this._http.post<Response>(this.url, Cliente, httpOption);

    }
  }
  
