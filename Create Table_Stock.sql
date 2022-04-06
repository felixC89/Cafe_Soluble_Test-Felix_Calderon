USE [Productos]
GO

/****** Object:  Table [dbo].[Stock]    Script Date: 6/4/2022 01:49:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stock](
	[Id_producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Producto] [varchar](50) NOT NULL,
	[Tipo_Producto] [varchar](50) NOT NULL,
	[Codigo_producto] [varchar](50) NOT NULL,
	[Precio_Unitario] [int] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

