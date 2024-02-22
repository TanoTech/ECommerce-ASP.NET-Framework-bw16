SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrello](
	[IdCarrello] [int] IDENTITY(1,1) NOT NULL,
	[IdUtente] [int] NOT NULL,
	[IdProdotto] [int] NOT NULL,
	[Quantità] [tinyint] NOT NULL,
	[PrezzoTotProdotto] [decimal](20, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrello] ADD  CONSTRAINT [PK_Carrello] PRIMARY KEY CLUSTERED 
(
	[IdCarrello] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrello]  WITH CHECK ADD  CONSTRAINT [FK_Carrello_ListaUtenti] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[ListaUtenti] ([IdUtente])
GO
ALTER TABLE [dbo].[Carrello] CHECK CONSTRAINT [FK_Carrello_ListaUtenti]
GO
ALTER TABLE [dbo].[Carrello]  WITH CHECK ADD  CONSTRAINT [FK_Carrello_Prodotti] FOREIGN KEY([IdProdotto])
REFERENCES [dbo].[Prodotti] ([IdProdotto])
GO
ALTER TABLE [dbo].[Carrello] CHECK CONSTRAINT [FK_Carrello_Prodotti]
GO
