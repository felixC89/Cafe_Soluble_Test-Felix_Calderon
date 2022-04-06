USE [Productos]
GO

INSERT INTO [dbo].[Autenticacion]
           ([Usuario]
           ,[Password]
           ,[Activo]
           ,[Token])
     VALUES
           (<Usuario, varchar(50),>
           ,<Password, varchar(50),>
           ,<Activo, varchar(50),>
           ,<Token, varchar(50),>)
GO

