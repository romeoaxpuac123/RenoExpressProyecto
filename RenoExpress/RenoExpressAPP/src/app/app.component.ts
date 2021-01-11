import { Component, OnInit } from '@angular/core';
import { InventarioService } from './services/inventario.service';
import { BusquedaService } from './servicioBusqueda/busqueda.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'RenoExpressAPP';
  public productosInventario: Array<any> = [];
  public productosBusqueda: Array<any> = [];
  public TotalProductos:number = 0;
  public PromedioProductos:number = 0.0;
  constructor(
    private inventarioService:InventarioService,
    private busquedaService:BusquedaService  
    ){
      this.inventarioService.MostrarInventario().subscribe((resp:any)=>{
        this.TotalProductos = resp.Total;
        this.PromedioProductos = resp.Promedio;
        this.productosInventario = resp.Productos;
        console.log(this.TotalProductos)
      });
    }    

  ObtenerBusqueda(){
    this.busquedaService.MostrarBusqueda().subscribe((resp:any)=>{
      this.productosBusqueda = resp.Productos;
      console.log(resp);
    });
  }  
}
