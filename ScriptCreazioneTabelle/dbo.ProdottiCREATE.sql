SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodotti](
	[IdProdotto] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NOT NULL,
	[Brand] [nvarchar](255) NOT NULL,
	[Dettagli] [nvarchar](500) NOT NULL,
	[ImgUrl] [nvarchar](500) NOT NULL,
	[Prezzo] [decimal](10, 2) NOT NULL,
	[Rating] [decimal](2, 1) NOT NULL,
	[Categoria] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Prodotti] ADD  CONSTRAINT [PK_Prodotti] PRIMARY KEY CLUSTERED 
(
	[IdProdotto] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Prodotti]  WITH CHECK ADD  CONSTRAINT [FK_Prodotti_CategoriaProdotti] FOREIGN KEY([Categoria])
REFERENCES [dbo].[CategoriaProdotti] ([ID])
GO
ALTER TABLE [dbo].[Prodotti] CHECK CONSTRAINT [FK_Prodotti_CategoriaProdotti]
GO