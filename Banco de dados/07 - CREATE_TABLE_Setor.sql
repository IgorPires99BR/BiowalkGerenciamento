USE Biowalk
-- Verifica se a tabela 'Setor' já existe no banco de dados.
-- O bloco 'BEGIN...END' só será executado se a tabela não existir,
-- tornando o script idempotente.
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setor]') AND type in (N'U'))
BEGIN
    -- Cria a tabela 'Setor'.
    CREATE TABLE [dbo].[Setor](
        [IdSetor] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [NomeSetor] VARCHAR(255) NOT NULL

        CONSTRAINT [PK_Setor] PRIMARY KEY CLUSTERED ([IdSetor] ASC)
    );

    -- Mensagem de confirmação para quando a tabela é criada.
    PRINT 'Tabela Setor criada com sucesso.';
END
ELSE
BEGIN
    -- Mensagem de confirmação para quando a tabela já existe.
    PRINT 'Tabela Setor já existe.';
END
