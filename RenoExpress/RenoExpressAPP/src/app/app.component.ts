import { Component, OnInit } from '@angular/core';
import { InventarioService } from './services/inventario.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'RenoExpressAPP';
  public productosInventario: Array<any> = [];
  constructor(
    private inventarioService:InventarioService 
    ){
      this.inventarioService.MostrarInventario().subscribe((resp:any)=>{
        
        this.productosInventario = resp.Productos;
        console.log(this.productosInventario)
      });
    }
}
