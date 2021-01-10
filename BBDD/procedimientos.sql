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
CREATE PROCEDURE CrearFactura   
    @Total int,   
    @Fecha date,
	@Codigo_Cliente int
AS   
	INSERT INTO Factura (Total,Fecha,Codigo_Cliente) VALUES (@Total,@Fecha,@Codigo_Cliente);
	SELECT TOP 1 Codigo_Factura FROM Factura ORDER BY Codigo_Factura DESC
GO
CREATE PROCEDURE RegistrarVenta
	@Codigo_Factura int,
    @Codigo_Producto int,   
    @Codigo_Sucursal int,
	@Cantidad int,
	@Ultima_Cantidad int,
	@Fecha_Adquisicion date 
AS   
	INSERT INTO Venta(Codigo_Factura,Codigo_Producto,Codigo_Sucursal,Cantidad,Ultima_Cantidad,Fecha_Adquisicion) 
		VALUES (@Codigo_Factura,@Codigo_Producto,@Codigo_Sucursal,@Cantidad,@Ultima_Cantidad,@Fecha_Adquisicion) ;
	UPDATE Producto_Sucursal SET Cantidad=Cantidad  - @Cantidad  
		WHERE Codigo_Producto=@Codigo_Producto AND Codigo_Sucursal = @Codigo_Sucursal; 
		
GO
CREATE PROCEDURE TotalFactura
	@Codigo_Factura int,
	@Codigo_Producto int,
	@Cantidad int
AS   

	UPDATE Factura SET Total=Total + ((SELECT Precio_Venta FROM Producto WHERE Codigo_Producto = @Codigo_Producto) * @Cantidad)
		WHERE Codigo_Factura = @Codigo_Factura; 
		
GO
CREATE PROCEDURE CatalogoSucursal
	@Codigo_Sucursal int
AS   

	SELECT T.Nombre, T.Descripcion,T.Categoria, T.Codigo_Producto, T.Precio_Venta, PS.Cantidad AS Stock,
	PS.Fecha_Adquisicion AS Abastecimiento, PS.Ultima_Cantidad AS Recarga FROM Producto T, Producto_Sucursal PS
		WHERE (T.Codigo_Producto = PS.Codigo_Producto) AND (PS.Codigo_Sucursal = @Codigo_Sucursal); 
		
GO
CREATE PROCEDURE ProductosPorCategoria
	@Codigo_Sucursal int,
	@Categoria varchar(50)
AS   

	SELECT T.Nombre, T.Descripcion,T.Categoria, T.Codigo_Producto, T.Precio_Venta, PS.Cantidad AS Stock,
	PS.Fecha_Adquisicion AS Abastecimiento, PS.Ultima_Cantidad AS Recarga FROM Producto T, Producto_Sucursal PS
		WHERE (T.Codigo_Producto = PS.Codigo_Producto) AND (PS.Codigo_Sucursal = @Codigo_Sucursal)AND (T.Categoria = @Categoria);
		
GO
CREATE PROCEDURE ProductosPorNombre
	@Codigo_Sucursal int,
	@Nombre varchar(50)
AS   

	SELECT T.Nombre, T.Descripcion,T.Categoria, T.Codigo_Producto, T.Precio_Venta, PS.Cantidad AS Stock,
	PS.Fecha_Adquisicion AS Abastecimiento, PS.Ultima_Cantidad AS Recarga FROM Producto T, Producto_Sucursal PS
		WHERE (T.Codigo_Producto = PS.Codigo_Producto) AND (PS.Codigo_Sucursal = @Codigo_Sucursal)AND (T.Nombre = @Nombre);
		
GO
CREATE PROCEDURE ProductosPorCodigo
	@Codigo_Sucursal int,
	@Codigo int
AS   

	SELECT T.Nombre, T.Descripcion,T.Categoria, T.Codigo_Producto, T.Precio_Venta, PS.Cantidad AS Stock,
	PS.Fecha_Adquisicion AS Abastecimiento, PS.Ultima_Cantidad AS Recarga FROM Producto T, Producto_Sucursal PS
		WHERE (T.Codigo_Producto = PS.Codigo_Producto) AND (PS.Codigo_Sucursal = @Codigo_Sucursal)AND (T.Codigo_Producto = @Codigo);
		
GO
CREATE PROCEDURE TotalJuguetes
	@Codigo_Sucursal int
AS   

	SELECT SUM(Cantidad) AS Total_Juguetes FROM Producto_Sucursal WHERE Codigo_Sucursal = @Codigo_Sucursal ;
GO
CREATE PROCEDURE Promedio
	@Codigo_Sucursal int
AS   

	SELECT AVG(P.Precio_Venta) AS Promedio FROM Producto P, Producto_Sucursal PS 
	WHERE P.Codigo_Producto = PS.Codigo_Producto AND (PS.Codigo_Sucursal = @Codigo_Sucursal);
GO