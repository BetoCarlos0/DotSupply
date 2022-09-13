CREATE TABLE [Mercadoria] (
    [MercadoriaId] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [NumRegistro] int NOT NULL,
    [Fabricante] varchar(50) NOT NULL,
    [Tipo] varchar(50) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    CONSTRAINT [PK_Mercadoria] PRIMARY KEY ([MercadoriaId])
);
CREATE TABLE [EntradaMercadoria] (
    [Id] int NOT NULL IDENTITY,
    [Quantidade] int NOT NULL,
    [Data] datetime2 NOT NULL,
    [Local] varchar(50) NOT NULL,
    [MercadoriaId] int NOT NULL,
    CONSTRAINT [PK_EntradaMercadoria] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntradaMercadoria_Mercadoria_MercadoriaId] FOREIGN KEY ([MercadoriaId]) REFERENCES [Mercadoria] ([MercadoriaId]) ON DELETE CASCADE
);
CREATE TABLE [SaidaMercadoria] (
    [Id] int NOT NULL IDENTITY,
    [Quantidade] int NOT NULL,
    [Data] datetime2 NOT NULL,
    [Local] varchar(50) NOT NULL,
    [MercadoriaId] int NOT NULL,
    CONSTRAINT [PK_SaidaMercadoria] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SaidaMercadoria_Mercadoria_MercadoriaId] FOREIGN KEY ([MercadoriaId]) REFERENCES [Mercadoria] ([MercadoriaId]) ON DELETE CASCADE
);