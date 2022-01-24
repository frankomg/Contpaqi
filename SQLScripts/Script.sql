USE [EXAMEN]
GO

/****** Object:  Table [dbo].[empleados]    Script Date: 22/01/2022 05:06:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido_paterno] [nvarchar](50) NOT NULL,
	[apellido_materno] [nvarchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[genero] [char](1) NOT NULL,
	[estado_civil] [nvarchar](50) NOT NULL,
	[rfc] [nvarchar](13) NOT NULL,
	[direccion] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](10) NOT NULL,
	[puesto] [nvarchar](50) NOT NULL,
	[fecha_alta] [date] NOT NULL,
	[fecha_baja] [date] NULL,
 CONSTRAINT [PK_empleados] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Buscar_Empleados]    Script Date: 22/01/2022 05:06:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	Busca Empleados por criterios
-- =============================================
CREATE PROCEDURE [dbo].[sp_Buscar_Empleados]
	@nombre VARCHAR(50) = '',
	@rfc VARCHAR(13) = '',
	@estatus CHAR(1) = '',
	@fecha_actual DATE
AS
BEGIN
	SET NOCOUNT ON;	

	DECLARE @sql NVARCHAR(MAX)
	
	SET @sql = 'SELECT [id]
					  ,[nombre] + '' '' + [apellido_paterno] + '' '' + [apellido_materno] as nombre_completo		 
					  ,[email]
					  ,[puesto]
					  ,[rfc]
					  ,[fecha_alta]
				FROM [dbo].[empleados]
				WHERE 1=1 '

	IF (@nombre <> '')
	BEGIN
		SET @sql += ' and ([nombre] + '' '' + [apellido_paterno] + '' '' + [apellido_materno]) like ''%'' + @nombre + ''%'''
	END

	IF (@rfc <> '')
	BEGIN
		SET @sql += ' and [rfc] = @rfc'
	END

	IF (@estatus = 'A')
	BEGIN
		SET @sql += ' and ([fecha_baja] > @fecha_actual or ISNULL([fecha_baja],'''') = '''')'
	END

	IF (@estatus = 'B')
	BEGIN
		SET @sql += ' and [fecha_baja] <= @fecha_actual'
	END

	print(@sql)

	EXEC sp_executesql @sql, N'@nombre VARCHAR(50), @rfc VARCHAR(13), @estatus CHAR(1), @fecha_actual DATE', @nombre, @rfc, @estatus, @fecha_actual;
	

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_Empleado]    Script Date: 22/01/2022 05:06:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	Elimina Empleado por ID
-- =============================================
CREATE PROCEDURE [dbo].[sp_Delete_Empleado]
	@id INT,
	@fecha_baja DATE
AS
BEGIN
	SET NOCOUNT ON;	
	
	UPDATE [dbo].[empleados]
	 SET fecha_baja = @fecha_baja
	WHERE id = @id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Empleado]    Script Date: 22/01/2022 05:06:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	Consulta Empleado por ID
-- =============================================
CREATE PROCEDURE [dbo].[sp_Get_Empleado]
	@id INT
AS
BEGIN
	SET NOCOUNT ON;	
	
	SET DATEFORMAT YMD
	SELECT [id]
		  ,[nombre]
		  ,[apellido_paterno]
		  ,[apellido_materno]
		  ,[edad]
		  ,[fecha_nacimiento]
		  ,[genero]
		  ,[estado_civil]
		  ,[rfc]
		  ,[direccion]
		  ,[email]
		  ,[telefono]
		  ,[puesto]
		  ,[fecha_alta]
		  ,[fecha_baja]
	FROM [dbo].[empleados]
	WHERE id = @id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Empleados]    Script Date: 22/01/2022 05:06:05 p. m. ******/
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
		  ,[nombre] + ' ' + [apellido_paterno] + ' ' + [apellido_materno] as nombre_completo		 
		  ,[email]
		  ,[puesto]
		  ,[rfc]
		  ,[fecha_alta]
	FROM [dbo].[empleados]

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Empleado]    Script Date: 22/01/2022 05:06:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	Inserta Empleado 
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_Empleado]
@nombre nvarchar(50),
@apellido_paterno nvarchar(50),
@apellido_materno nvarchar(50),
@edad int,
@fecha_nacimiento date,
@genero char(1),
@estado_civil nvarchar(50),
@rfc nvarchar(13),
@direccion nvarchar(50),
@email nvarchar(50),
@telefono nvarchar(10),
@puesto nvarchar(50),
@fecha_alta date,
@fecha_baja date

AS
BEGIN

	IF @fecha_baja = ''
		SET @fecha_baja = NULL

	INSERT INTO [dbo].[empleados]
           ([nombre]
           ,[apellido_paterno]
           ,[apellido_materno]
           ,[edad]
           ,[fecha_nacimiento]
           ,[genero]
           ,[estado_civil]
           ,[rfc]
           ,[direccion]
           ,[email]
           ,[telefono]
           ,[puesto]
           ,[fecha_alta]
           ,[fecha_baja])
     VALUES
           (@nombre
           ,@apellido_paterno
           ,@apellido_materno
           ,@edad
           ,@fecha_nacimiento
           ,@genero
           ,@estado_civil
           ,@rfc
           ,@direccion
           ,@email
           ,@telefono
           ,@puesto
           ,@fecha_alta
           ,@fecha_baja)

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Empleado]    Script Date: 22/01/2022 05:06:05 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Description:	Modifica Empleado por ID
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_Empleado]
	@id int,
	@estado_civil nvarchar(50),
	@direccion nvarchar(50),
	@email nvarchar(50),
	@telefono nvarchar(10),
	@puesto nvarchar(50),
	@fecha_baja date
AS
BEGIN

	IF @fecha_baja = ''
		SET @fecha_baja = NULL

	UPDATE [dbo].[empleados]
	   SET [estado_civil] = @estado_civil
		  ,[direccion] = @direccion 
		  ,[email] = @email
		  ,[telefono] = @telefono
		  ,[puesto] = @puesto
		  ,[fecha_baja] = @fecha_baja
	WHERE id = @id

END
GO
