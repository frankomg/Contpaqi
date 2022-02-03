USE [EXAMEN]
GO
/****** Object:  Table [dbo].[empleados]    Script Date: 03/02/2022 03:09:31 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](250) NULL,
	[puesto] [nvarchar](50) NULL,
	[salario] [money] NULL,
 CONSTRAINT [PK_empleados] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Empleados]    Script Date: 03/02/2022 03:09:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	Consulta listado de Empleados
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Empleados]
AS
BEGIN
	SET NOCOUNT ON;	
	
	SELECT [id]
		  ,[nombre]	 
		  ,[puesto]
		  ,[salario]
	FROM [dbo].[empleados]

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Empleado]    Script Date: 03/02/2022 03:09:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	Inserta Empleado 
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_Empleado]
@nombre nvarchar(250),
@puesto nvarchar(50),
@salario money

AS
BEGIN

	INSERT INTO [dbo].[empleados]
           ([nombre]          
           ,[puesto]
           ,[salario])
     VALUES
           (@nombre           
           ,@puesto
           ,@salario)

END
GO
