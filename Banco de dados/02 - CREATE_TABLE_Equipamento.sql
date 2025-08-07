USE Biowalk
-- Verifica se a tabela 'Equipamento' já existe no banco de dados.
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Equipamento]') AND type in (N'U'))
BEGIN
    -- Cria a tabela 'Equipamento'
    CREATE TABLE [dbo].[Equipamento](
        -- Coluna de ID, usada como chave primária.
        -- UNIQUEIDENTIFIER é o tipo SQL para o Guid do C#.
        [IdEquipamento] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

        -- Coluna para o nome do equipamento. NVARCHAR(255) é um bom tipo para strings.
        [Nome] NVARCHAR(255) NOT NULL,

        -- Define a chave primária da tabela.
        CONSTRAINT [PK_Equipamento] PRIMARY KEY CLUSTERED ([IdEquipamento] ASC)
    );

    -- Mensagem opcional para confirmar a criação da tabela
    PRINT 'Tabela Equipamento criada com sucesso.';
END
ELSE
BEGIN
    -- Mensagem opcional se a tabela já existir
    PRINT 'Tabela Equipamento já existe.';
END
