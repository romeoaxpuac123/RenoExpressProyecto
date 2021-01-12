import { Component, OnInit } from '@angular/core';
import { InventarioService } from './services/inventario.service';
import { BusquedaService } from './servicioBusqueda/busqueda.service';
import { ComprafacturaService } from './serviciocf/comprafactura.service';
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
  public TipoBusqueda1:boolean;
  public TipoBusqueda2:boolean;
  public TipoBusqueda3:boolean;
  public ParametroBusqueda2:string = "";
  public Compra:boolean = false;
  public Venta:boolean = false;
  public Cliente:string = "";
  public NITC:string = "";
  public Direccion:string = "";
  public Productos = 
    [
      {
        "Codigo_Producto": 1,
        "Codigo_Sucursal": 1,
        "Cantidad":4
      },
      {
        "Codigo_Producto": 2,
        "Codigo_Sucursal": 1,
        "Cantidad": 5
      },
      {
        "Codigo_Producto": 3,
        "Codigo_Sucursal": 1,
        "Cantidad": 6
      }
    ]
 
  //public user:string="";
  public PromedioProductos:number = 0.0;
  constructor(
    private inventarioService:InventarioService,
    private busquedaService:BusquedaService,
    private comprafacturaService:ComprafacturaService
    ){
      this.inventarioService.MostrarInventario().subscribe((resp:any)=>{
        this.TotalProductos = resp.Total;
        this.PromedioProductos = resp.Promedio;
        this.productosInventario = resp.Productos;
        console.log(this.TotalProductos)
      });
      
    }    

  ObtenerBusqueda(){
    console.log(this.TipoBusqueda1);
    console.log(this.TipoBusqueda2);
    console.log(this.TipoBusqueda3);
    var TotalDeBusquedas:number = 0;
    var TipoBusqueda = 0;
    if(this.TipoBusqueda1 == true){
      TotalDeBusquedas++;
      TipoBusqueda = 1;
    }if(this.TipoBusqueda2 == true){
      TotalDeBusquedas++;
      TipoBusqueda = 2;
    }
    if(this.TipoBusqueda3 == true){
      TotalDeBusquedas++;
      TipoBusqueda = 3;
    }
    if(TotalDeBusquedas>1){
      confirm('Parametros de Busqueda incorrectos')
    }else{
      this.busquedaService.MostrarBusqueda(this.ParametroBusqueda2,TipoBusqueda).subscribe((resp:any)=>{
        this.productosBusqueda = resp.Productos;
        console.log(resp);
      });
    }
    //var Busqueda = this.ParametroBusqueda2;
    
  }
  
  RegistrarMovimiento(){
    if((this.Cliente == "" || this.Cliente != "Romeo") || this.Direccion == "" || (this.NITC == "" || this.NITC != "123123-k") ){
      confirm('Datos de orden incompletos')
    }else{
      if((this.Compra == true && this.Venta == true) || (this.Compra == false && this.Venta == false) ){
        confirm('Parametros Seleccione unicamente una opcion')
       }else if(this.Compra == true){
        this.comprafacturaService.CrearCompra().subscribe((resp:any)=>{
          console.log("Compra realizada" + resp);
          confirm('Compra Exitosa realizada a Proveedor:')
          window.location.reload()
        });
       }else if (this.Venta == true){
        this.comprafacturaService.CrearFactura().subscribe((resp:any)=>{
          console.log("Factura realizada" + resp);
          confirm('Venta Exitosa realizada a Cliente:')
          window.location.reload()
        });
       }
    }
   
  }
}
