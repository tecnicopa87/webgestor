USE [gestorFacturas]
GO
/****** Object:  User [AdminControl]    Script Date: 08/09/2021 17:43:59 ******/
CREATE USER [AdminControl] FOR LOGIN [AdminControl] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[VntaTMP]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VntaTMP](
	[no_ticket] [int] NULL,
	[codigo] [varchar](50) NULL,
	[unidad] [nchar](10) NULL,
	[cantidad] [float] NULL,
	[descripcion] [varchar](50) NULL,
	[precio] [decimal](18, 2) NULL,
	[importe] [decimal](18, 2) NULL,
	[tot_may] [smallint] NULL,
	[fecha] [date] NULL,
	[maquina] [varchar](50) NULL,
	[cve_pro] [nchar](5) NULL,
	[descto] [decimal](18, 2) NULL,
	[iva_aplic] [decimal](18, 2) NULL,
	[ieps_aplic] [decimal](18, 2) NULL,
	[ahorro_client] [decimal](18, 2) NULL,
	[edo_fact] [nchar](10) NULL,
	[no_ventas] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [nchar](5) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ventas003]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ventas003](
	[no_ticket] [int] NULL,
	[unidad] [nchar](10) NULL,
	[cantidad] [float] NULL,
	[descripcion] [varchar](50) NULL,
	[precio] [decimal](18, 2) NULL,
	[importe] [decimal](18, 2) NULL,
	[tot_may] [smallint] NULL,
	[fecha] [date] NULL,
	[maquina] [varchar](50) NULL,
	[cve_pro] [nchar](5) NULL,
	[descto] [decimal](18, 2) NULL,
	[iva_aplic] [decimal](18, 2) NULL,
	[ieps_aplic] [decimal](18, 2) NULL,
	[ahorro_client] [decimal](18, 2) NULL,
	[edo_fact] [nchar](10) NULL,
	[no_ventas] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](30) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ventas001         ]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ventas001         ](
	[no_ticket] [int] NULL,
	[unidad] [nchar](10) NULL,
	[cantidad] [float] NULL,
	[descripcion] [varchar](50) NULL,
	[precio] [decimal](18, 2) NULL,
	[importe] [decimal](18, 2) NULL,
	[tot_may] [smallint] NULL,
	[fecha] [date] NULL,
	[maquina] [varchar](50) NULL,
	[cve_pro] [nchar](5) NULL,
	[descto] [decimal](18, 2) NULL,
	[iva_aplic] [decimal](18, 2) NULL,
	[ieps_aplic] [decimal](18, 2) NULL,
	[ahorro_client] [decimal](18, 2) NULL,
	[edo_fact] [nchar](10) NULL,
	[no_ventas] [bigint] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](30) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes003         ]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes003         ](
	[CveCliente] [varchar](50) NULL,
	[Nombre] [varchar](70) NULL,
	[RFC] [char](13) NULL,
	[Regimen] [varchar](50) NULL,
	[Calle] [varchar](50) NULL,
	[noExt] [nchar](10) NULL,
	[noInt] [nchar](10) NULL,
	[Colonia] [varchar](50) NULL,
	[Municipio] [varchar](50) NULL,
	[Pais] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[CP] [char](10) NULL,
	[email] [varchar](60) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes001         ]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes001         ](
	[CveCliente] [varchar](50) NULL,
	[Nombre] [varchar](70) NULL,
	[RFC] [char](13) NULL,
	[Regimen] [varchar](50) NULL,
	[Calle] [varchar](50) NULL,
	[noExt] [nchar](10) NULL,
	[noInt] [nchar](10) NULL,
	[Colonia] [varchar](50) NULL,
	[Municipio] [varchar](50) NULL,
	[Pais] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[CP] [char](10) NULL,
	[email] [varchar](60) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombreCatagoria] [varchar](200) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Applications]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationName] [nvarchar](235) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos003         ]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos003         ](
	[codigo] [varchar](15) NOT NULL,
	[producto] [varchar](50) NULL,
	[precio] [real] NULL,
	[precio2] [real] NULL,
	[Cve_Pro] [nchar](10) NULL,
	[a_granel] [bit] NULL,
	[costo] [real] NULL,
	[ganancia] [real] NULL,
	[iva] [money] NULL,
	[ieps] [money] NULL,
	[fechmov] [datetime] NULL,
	[marcamov] [char](12) NULL,
	[unidad] [varchar](30) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Productos001         ]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos001         ](
	[codigo] [varchar](15) NOT NULL,
	[producto] [varchar](50) NULL,
	[precio] [real] NULL,
	[precio2] [real] NULL,
	[Cve_Pro] [nchar](10) NULL,
	[a_granel] [bit] NULL,
	[costo] [real] NULL,
	[ganancia] [real] NULL,
	[iva] [money] NULL,
	[ieps] [money] NULL,
	[fechmov] [datetime] NULL,
	[marcamov] [char](12) NULL,
	[unidad] [varchar](30) NULL,
 CONSTRAINT [PK_Productos001         ] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MisClientes]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MisClientes](
	[idCliente] [nchar](5) NOT NULL,
	[Titulo] [varchar](50) NULL,
	[seudonimo] [varchar](50) NULL,
	[Regimen] [varchar](70) NULL,
	[RFC] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[Pasword] [varchar](20) NULL,
	[fechAlta] [date] NULL,
	[CFDIs] [int] NULL,
	[Dircalle] [varchar](50) NULL,
	[noExt] [nchar](10) NULL,
	[CP] [nchar](10) NULL,
	[Municipio] [varchar](50) NULL,
	[Colonia] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[cadenaConect] [varchar](50) NULL,
	[Edo_App] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Facturas003         ]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Facturas003         ](
	[folio] [nchar](10) NULL,
	[serie] [nchar](10) NULL,
	[fechaEmision] [datetime] NULL,
	[monto] [decimal](18, 2) NULL,
	[condiciones] [nchar](10) NULL,
	[fol_Autoriz] [int] NULL,
	[TpoCmpvte] [varchar](12) NULL,
	[FolVenta] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Facturas001         ]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Facturas001         ](
	[folio] [nchar](10) NULL,
	[serie] [nchar](10) NULL,
	[fechaEmision] [datetime] NULL,
	[monto] [decimal](18, 2) NULL,
	[condiciones] [nchar](10) NULL,
	[fol_Autoriz] [int] NULL,
	[TpoCmpvte] [varchar](12) NULL,
	[FolVenta] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Facturas000]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Facturas000](
	[folio] [nchar](10) NULL,
	[serie] [nchar](10) NULL,
	[fecha] [datetime] NULL,
	[monto] [decimal](18, 2) NULL,
	[condiciones] [nchar](10) NULL,
	[fol_Autoriz] [int] NULL,
	[TpoCmpvte] [varchar](12) NULL,
	[FolVenta] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Domicilio]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Domicilio](
	[CP] [int] NOT NULL,
	[Colonia] [varchar](50) NULL,
	[Municipio] [varchar](50) NULL,
 CONSTRAINT [PK_Domicilio] PRIMARY KEY CLUSTERED 
(
	[CP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cortes003         ]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cortes003         ](
	[no_corte] [smallint] NULL,
	[folVenta] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[concepto] [nchar](10) NULL,
	[usuario] [nchar](20) NULL,
	[fecha] [datetime] NULL,
	[entrada] [decimal](18, 0) NULL,
	[salida] [nchar](10) NULL,
	[totiva] [decimal](18, 2) NULL,
	[totieps] [decimal](18, 2) NULL,
	[folFactura] [varchar](50) NULL,
	[ventas] [real] NULL,
	[utilidad] [real] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cortes001         ]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cortes001         ](
	[no_corte] [smallint] NULL,
	[folVenta] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[concepto] [nchar](10) NULL,
	[usuario] [nchar](20) NULL,
	[fecha] [datetime] NULL,
	[entrada] [decimal](18, 0) NULL,
	[salida] [nchar](10) NULL,
	[totiva] [decimal](18, 2) NULL,
	[totieps] [decimal](18, 2) NULL,
	[folFactura] [varchar](50) NULL,
	[utilidad] [decimal](18, 2) NULL,
	[ventas] [real] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cortes000]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cortes000](
	[no_corte] [smallint] NULL,
	[folVenta] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[concepto] [nchar](10) NULL,
	[usuario] [nchar](20) NULL,
	[fecha] [datetime] NULL,
	[entrada] [decimal](18, 0) NULL,
	[salida] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientsMVC]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientsMVC](
	[IDCliente] [nchar](5) NOT NULL,
	[email] [varchar](30) NULL,
	[seudonimo] [varchar](50) NOT NULL,
	[pasword] [varchar](30) NOT NULL,
	[guid] [int] IDENTITY(1,1) NOT NULL,
	[idCP] [int] NULL,
 CONSTRAINT [PK_ClientsMVC] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersInRoles]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [nvarchar](4000) NOT NULL,
	[PropertyValueStrings] [nvarchar](4000) NOT NULL,
	[PropertyValueBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Memberships]    Script Date: 08/09/2021 17:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memberships](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowsStart] [datetime] NOT NULL,
	[Comment] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK__ClientsMVC__idCP__47DBAE45]    Script Date: 08/09/2021 17:43:59 ******/
ALTER TABLE [dbo].[ClientsMVC]  WITH CHECK ADD  CONSTRAINT [FK__ClientsMVC__idCP__47DBAE45] FOREIGN KEY([idCP])
REFERENCES [dbo].[Domicilio] ([CP])
GO
ALTER TABLE [dbo].[ClientsMVC] CHECK CONSTRAINT [FK__ClientsMVC__idCP__47DBAE45]
GO
/****** Object:  ForeignKey [MembershipApplication]    Script Date: 08/09/2021 17:43:59 ******/
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipApplication]
GO
/****** Object:  ForeignKey [MembershipUser]    Script Date: 08/09/2021 17:43:59 ******/
ALTER TABLE [dbo].[Memberships]  WITH CHECK ADD  CONSTRAINT [MembershipUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Memberships] CHECK CONSTRAINT [MembershipUser]
GO
/****** Object:  ForeignKey [UserProfile]    Script Date: 08/09/2021 17:43:59 ******/
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [UserProfile]
GO
/****** Object:  ForeignKey [RoleApplication]    Script Date: 08/09/2021 17:43:59 ******/
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [RoleApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [RoleApplication]
GO
/****** Object:  ForeignKey [UserApplication]    Script Date: 08/09/2021 17:43:59 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [UserApplication] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [UserApplication]
GO
/****** Object:  ForeignKey [UsersInRoleRole]    Script Date: 08/09/2021 17:43:59 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleRole]
GO
/****** Object:  ForeignKey [UsersInRoleUser]    Script Date: 08/09/2021 17:43:59 ******/
ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [UsersInRoleUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [UsersInRoleUser]
GO
