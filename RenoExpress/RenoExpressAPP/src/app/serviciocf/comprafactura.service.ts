import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ComprafacturaService {

  constructor(private http:HttpClient) { }
  //PROCESO DE COMPRA
  API_URI='https://localhost:44351/api/Factura';
  API_URI2='https://localhost:44351/api/Compras';

  
  CrearFactura(){
    console.log("Factura..")
    var ProductosVenta= "[{\"Codigo_Cliente\": 1,\"Codigo_Producto\": 1,\"Codigo_Sucursal\": 1,\"Cantidad\":4},{\"Codigo_Cliente\": 1,\"Codigo_Producto\": 2,\"Codigo_Sucursal\": 1,\"Cantidad\": 5},{\"Codigo_Cliente\": 1,\"Codigo_Producto\": 3,\"Codigo_Sucursal\": 1,\"Cantidad\": 6}]"
    var entrada = JSON.parse(ProductosVenta);
    console.log(entrada);
    return this.http.post(`${this.API_URI}`,entrada);
  }
  CrearCompra(){
    console.log("Compra..")
    var ProductosCompra = "[{\"Codigo_Producto\": 1,\"Codigo_Sucursal\": 1,\"Cantidad\":4},{\"Codigo_Producto\": 2,\"Codigo_Sucursal\": 1,\"Cantidad\": 5},{\"Codigo_Producto\": 3,\"Codigo_Sucursal\": 1,\"Cantidad\": 6}]";
    var entrada = JSON.parse(ProductosCompra);
    console.log(entrada);
    return this.http.post(`${this.API_URI2}`,entrada);
  }
}
