import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class InventarioService {
constructor(private http:HttpClient) {
 
}

API_URI='https://localhost:44351/api/Inventario';

MostrarInventario(){
  return this.http.post(`${this.API_URI}`,{Codigo_Sucursal: 1});
}
}
