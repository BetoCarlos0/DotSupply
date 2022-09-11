CREATE TABLE [Mercadoria] (
    [MercadoriaId] int NOT NULL IDENTITY,
    [Nome] varchar(100) NOT NULL,
    [NumRegistro] int NOT NULL,
    [Fabricante] varchar(50) NOT NULL,
    [Tipo] varchar(50) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    CONSTRAINT [PK_Mercadoria] PRIMARY KEY ([MercadoriaId])
);
CREATE TABLE [entradaSaidaMercadorias] (
    [Id] int NOT NULL IDENTITY,
    [InfoCadastro] varchar(10) NOT NULL,
    [Quantidade] int NOT NULL,
    [Data] datetime2 NOT NULL,
    [Local] varchar(50) NOT NULL,
    [MercadoriaId] int NOT NULL,
    CONSTRAINT [PK_entradaSaidaMercadorias] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_entradaSaidaMercadorias_Mercadoria_MercadoriaId] FOREIGN KEY ([MercadoriaId]) REFERENCES [Mercadoria] ([MercadoriaId]) ON DELETE CASCADE
);
CREATE UNIQUE INDEX [IX_entradaSaidaMercadorias_MercadoriaId] ON [entradaSaidaMercadorias] ([MercadoriaId]);