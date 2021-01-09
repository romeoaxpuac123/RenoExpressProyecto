USE RenoExpressDB;  
GO  
CREATE PROCEDURE CrearCompra   
    @Total int,   
    @Fecha date   
AS   
	INSERT INTO Compra (Total,Fecha) VALUES (@Total,@Fecha);
	SELECT TOP 1 Codigo_Compra  FROM Compra ORDER BY Codigo_Compra DESC
GO

USE RenoExpressDB;  
GO  
CREATE PROCEDURE RegistrarDetalleCompra
	@Codigo_Compra int,
    @Codigo_Producto int,   
    @Codigo_Sucursal int,
	@Cantidad int,
	@Ultima_Cantidad int,
	@Fecha_Adquisicion date 
AS   
	INSERT INTO Detalle_Compra(Codigo_Compra,Codigo_Producto,Codigo_Sucursal,Cantidad,Ultima_Cantidad,Fecha_Adquisicion) 
		VALUES (@Codigo_Compra,@Codigo_Producto,@Codigo_Sucursal,@Cantidad,@Ultima_Cantidad,@Fecha_Adquisicion) ;
	UPDATE Producto_Sucursal SET Cantidad=Cantidad +@Cantidad , Ultima_Cantidad= @Ultima_Cantidad, Fecha_Adquisicion = @Fecha_Adquisicion 
		WHERE Codigo_Producto=@Codigo_Producto AND Codigo_Sucursal = @Codigo_Sucursal; 
	
GO

GO  
CREATE PROCEDURE TotalCompra
	@Codigo_Compra int,
	@Codigo_Producto int,
	@Cantidad int
AS   

	UPDATE Compra SET Total=Total + ((SELECT Precio_Venta FROM Producto WHERE Codigo_Producto = @Codigo_Producto) * @Cantidad)
		WHERE Codigo_Compra = @Codigo_Compra; 
		
GO