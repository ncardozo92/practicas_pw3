use [PW3_20172C_TP_Turismo]
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Email], [Contrasenia], [Admin], [Nombre], [Apellido]) VALUES (1, N'admin@turismo.com', N'1234', 1, N'Despegar', N'Puntocom')
INSERT [dbo].[Usuario] ([Id], [Email], [Contrasenia], [Admin], [Nombre], [Apellido]) VALUES (2, N'usuario1@gmail.com', N'1234', 0, N'Viaja', N'Solari')
INSERT [dbo].[Usuario] ([Id], [Email], [Contrasenia], [Admin], [Nombre], [Apellido]) VALUES (4, N'usuario2@gmail.com', N'1234', 0, N'Viaja', N'EnFamilia')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET IDENTITY_INSERT [dbo].[Paquete] ON 

INSERT [dbo].[Paquete] ([Id], [Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (1, N'Cancun', N'7 dias 6 noches en Hotel 4 estreallas ALL INCLUSIVE', N'cancun.jpg', CAST(N'2018-07-01 00:00:00.000' AS DateTime), CAST(N'2017-10-10 00:00:00.000' AS DateTime), 1, 10, 10000)
INSERT [dbo].[Paquete] ([Id], [Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (4, N'Bariloche', N'6 dias 5 noches en Hotel 3 estrellas con media pensión', N'bariloche.jpg', CAST(N'2018-03-10 00:00:00.000' AS DateTime), CAST(N'2018-03-16 00:00:00.000' AS DateTime), 1, 30, 4000)
INSERT [dbo].[Paquete] ([Id], [Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (5, N'Mundial Rusia 2018', N'Te vas a perder el mundial?!', N'mundial.jpg', CAST(N'2018-06-01 00:00:00.000' AS DateTime), CAST(N'2018-06-25 00:00:00.000' AS DateTime), 1, 100, 20000)
INSERT [dbo].[Paquete] ([Id], [Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (6, N'JJOO Tokio 2020', N'Paquete 1 - Basket, Handball, Voley', N'jjoo.jpg', CAST(N'2018-08-01 00:00:00.000' AS DateTime), CAST(N'2020-08-10 00:00:00.000' AS DateTime), 1, 20, 18000)
INSERT [dbo].[Paquete] ([Id], [Nombre], [Descripcion], [Foto], [FechaInicio], [FechaFin], [Destacado], [LugaresDisponibles], [PrecioPorPersona]) VALUES (7, N'Mar del Plata - Semana Santa ', N'3 dias 4 noches', N'123.jpg', CAST(N'2018-04-01 00:00:00.000' AS DateTime), CAST(N'2018-04-05 00:00:00.000' AS DateTime), 0, 8, 2500)
SET IDENTITY_INSERT [dbo].[Paquete] OFF
SET IDENTITY_INSERT [dbo].[Reserva] ON 

INSERT [dbo].[Reserva] ([Id], [CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (1, 1, CAST(N'2017-03-02 00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Reserva] ([Id], [CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (3, 4, CAST(N'2017-03-02 00:00:00.000' AS DateTime), 1, 4)
INSERT [dbo].[Reserva] ([Id], [CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (4, 10, CAST(N'2017-04-03 00:00:00.000' AS DateTime), 5, 4)
INSERT [dbo].[Reserva] ([Id], [CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (5, 10, CAST(N'2017-03-02 00:00:00.000' AS DateTime), 6, 4)
INSERT [dbo].[Reserva] ([Id], [CantPersonas], [FechaCreacion], [IdPaquete], [IdUsuario]) VALUES (7, 1, CAST(N'2017-03-02 00:00:00.000' AS DateTime), 6, 2)
SET IDENTITY_INSERT [dbo].[Reserva] OFF
