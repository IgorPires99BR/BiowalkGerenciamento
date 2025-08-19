USE Biowalk

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cluster]') AND type in (N'U'))
BEGIN
    -- Cria a tabela '[Cluster]'.
    CREATE TABLE [dbo].[Cluster](
        [IdCluster] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [NomeCluster] NVARCHAR(255) NOT NULL,
        CONSTRAINT [PK_Cluster] PRIMARY KEY CLUSTERED ([IdCluster] ASC)
    );

    -- Mensagem de confirmação para quando a tabela é criada.
    PRINT 'Tabela Cluster criada com sucesso.';
END
ELSE
BEGIN
    -- Mensagem de confirmação para quando a tabela já existe.
    PRINT 'Tabela Cluster já existe.';
END
