import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class BusquedaService {
  constructor(private http:HttpClient) {
 
  }
  API_URI='https://localhost:44351/api/Busquedas';

  MostrarBusqueda(){
    console.log("Buscando..")
    let ParametroBusqueda:string;
    ParametroBusqueda = document.getElementById("search").value;
    var checkboxes = document.getElementsByName("Metodo_Busqueda");
    let TipoBusqueda:number;
    if(checkboxes[0].checked) {
      TipoBusqueda = 1;
    } 
    else if(checkboxes[1].checked) {
      TipoBusqueda = 2;
    }
    else if(checkboxes[2].checked) {
      TipoBusqueda = 3;
    }
    console.log("Tipo Busqueda");
    console.log(TipoBusqueda);
    return this.http.post(`${this.API_URI}`,{ TipoBusqueda: TipoBusqueda,Codigo_Sucursal: 1,ParametroBusqueda:ParametroBusqueda});
  }
}
