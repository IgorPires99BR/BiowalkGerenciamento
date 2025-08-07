USE Biowalk
-- Verifica se a tabela 'Setor' já existe no banco de dados.
-- O bloco 'BEGIN...END' só será executado se a tabela não existir,
-- tornando o script idempotente.
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Setor]') AND type in (N'U'))
BEGIN
    -- Cria a tabela 'Setor'.
    CREATE TABLE [dbo].[Setor](
        -- Coluna para a chave primária, mapeada para o Guid do C#.
        -- O UNIQUEIDENTIFIER é o tipo de dados padrão para GUIDs no SQL Server.
        [IdSetor] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

        -- Coluna para o nome do setor, mapeada para uma string.
        -- NVARCHAR(255) é um tipo de dados comum para nomes e textos curtos.
        [NomeSetor] NVARCHAR(255) NOT NULL,

        -- Define a restrição de chave primária na coluna IdSetor.
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
