CREATE TABLE Proveedor (
	Codigo_Proveedor INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	NIT VARCHAR(50) NOT NULL,
	Direccion VARCHAR(150) NOT NULL
);

CREATE TABLE Sucursal (
	Codigo_Sucursal INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Direccion VARCHAR(150) NOT NULL
);

CREATE TABLE Producto (
	Codigo_Producto INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Nombre VARCHAR(150) NOT NULL,
	Marca VARCHAR(150) NOT NULL,
	Descripcion VARCHAR(150) NOT NULL,
	Categoria VARCHAR(150) NOT NULL,
	Precio_Venta DECIMAL(4,2) NOT NULL,
	Codigo_Proveedor INT NOT NULL,
	CONSTRAINT fk_Proveedor FOREIGN KEY (Codigo_Proveedor) REFERENCES Proveedor (Codigo_Proveedor)
);

CREATE TABLE Producto_Sucursal (
	Codigo_Producto INT NOT NULL,
	Codigo_Sucursal INT NOT NULL,
	Cantidad INT NOT NULL,
	Ultima_Cantidad INT NOT NULL,
	Fecha_Adquisicion DATE NOT NULL,
	CONSTRAINT fk_Producto FOREIGN KEY (Codigo_Producto) REFERENCES Producto (Codigo_Producto),
	CONSTRAINT fk_Sucursal FOREIGN KEY (Codigo_Sucursal) REFERENCES Sucursal (Codigo_Sucursal),
	PRIMARY KEY(Codigo_Producto,Codigo_Sucursal)
);

CREATE TABLE Compra (
	Codigo_Compra INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Total DECIMAL(6,2),
	Fecha DATE NOT NULL
);

CREATE TABLE Detalle_Compra (
	Codigo_Compra INT NOT NULL,
	Codigo_Producto INT NOT NULL,
	Codigo_Sucursal INT NOT NULL,
	Cantidad INT NOT NULL,
	Ultima_Cantidad INT NOT NULL,
	Fecha_Adquisicion DATE NOT NULL,
	CONSTRAINT fk_Producto_Sucursal FOREIGN KEY (Codigo_Producto,Codigo_Sucursal) REFERENCES Producto_Sucursal (Codigo_Producto,Codigo_Sucursal),
	CONSTRAINT fk_Compra FOREIGN KEY (Codigo_Compra) REFERENCES Compra (Codigo_Compra),
	PRIMARY KEY(Codigo_Compra,Codigo_Producto,Codigo_Sucursal)
);

CREATE TABLE Cliente(
	Codigo_Cliente INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	NIT VARCHAR(50) NOT NULL,
	Direccion VARCHAR(150) NOT NULL
);

CREATE TABLE Factura (
	Codigo_Factura INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Total DECIMAL(6,2),
	Fecha DATE NOT NULL,
	Codigo_Cliente INT NOT NULL,
	CONSTRAINT fk_Cliente FOREIGN KEY (Codigo_Cliente) REFERENCES Cliente (Codigo_Cliente)
);

CREATE TABLE Venta (
	Codigo_Factura INT NOT NULL,
	Codigo_Producto INT NOT NULL,
	Codigo_Sucursal INT NOT NULL,
	Cantidad INT NOT NULL,
	Ultima_Cantidad INT NOT NULL,
	Fecha_Adquisicion DATE NOT NULL,
	CONSTRAINT fk_Producto_Sucursal_2 FOREIGN KEY (Codigo_Producto,Codigo_Sucursal) REFERENCES Producto_Sucursal (Codigo_Producto,Codigo_Sucursal),
	CONSTRAINT fk_Factura FOREIGN KEY (Codigo_Factura ) REFERENCES Factura (Codigo_Factura),
	PRIMARY KEY(Codigo_Factura ,Codigo_Producto,Codigo_Sucursal)
);