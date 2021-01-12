import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class BusquedaService {
  constructor(private http:HttpClient) {
 
  }
  API_URI='https://localhost:44351/api/Busquedas';
  MostrarBusqueda(ParametroBusqueda:string,TipoBusqueda:number){
    console.log("Buscando..")
    console.log("Parametro Busqueda->" + ParametroBusqueda);
    return this.http.post(`${this.API_URI}`,{ TipoBusqueda: TipoBusqueda,Codigo_Sucursal: 1,ParametroBusqueda:ParametroBusqueda});
  }
}
