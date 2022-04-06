USE [Productos]
GO

INSERT INTO [dbo].[Stock]
           ([Nombre_Producto]
           ,[Tipo_Producto]
           ,[Codigo_producto]
           ,[Precio_Unitario])
     VALUES
           (<Nombre_Producto, varchar(50),>
           ,<Tipo_Producto, varchar(50),>
           ,<Codigo_producto, varchar(50),>
           ,<Precio_Unitario, int,>)
GO

