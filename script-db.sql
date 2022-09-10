CREATE TABLE [entradaSaidaMercadorias] (
    [Id] int NOT NULL IDENTITY,
    [InfoCadastro] varchar(10) NOT NULL,
    [Quantidade] int NOT NULL,
    [Data] datetime2 NOT NULL,
    [Local] varchar(50) NOT NULL,
    CONSTRAINT [PK_entradaSaidaMercadorias] PRIMARY KEY ([Id])
);

CREATE TABLE [Mercadoria] (
    [MercadoriaId] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [NumRegistro] int NOT NULL,
    [Fabricante] varchar(50) NOT NULL,
    [Tipo] varchar(50) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [EntradaSaidaMercadoriaId] int NULL,
    CONSTRAINT [PK_Mercadoria] PRIMARY KEY ([MercadoriaId]),
    CONSTRAINT [FK_Mercadoria_entradaSaidaMercadorias_EntradaSaidaMercadoriaId] FOREIGN KEY ([EntradaSaidaMercadoriaId]) REFERENCES [entradaSaidaMercadorias] ([Id])
);

CREATE INDEX [IX_Mercadoria_EntradaSaidaMercadoriaId] ON [Mercadoria] ([EntradaSaidaMercadoriaId]);