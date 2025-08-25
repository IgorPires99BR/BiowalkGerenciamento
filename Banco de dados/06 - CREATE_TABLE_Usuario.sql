USE Biowalk
GO

-- Adapta o script SQL para corresponder à classe C# 'Usuario'.
-- O bloco 'BEGIN...END' só será executado se a tabela não existir,
-- tornando o script idempotente (pode ser executado várias vezes sem erro).
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
BEGIN
    -- Cria a tabela 'Usuario' com todas as propriedades da classe C#.
    CREATE TABLE [dbo].[Usuario](
        -- 'IdUsuario' corresponde ao Guid 'IdUsuario' na classe.
        [IdUsuario] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

        -- 'IdSetor' corresponde ao Guid 'IdSetor' na classe.
        [IdSetor] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

        -- 'Nome' corresponde à string 'Nome' na classe.
        [Nome] VARCHAR(255) NOT NULL,

        -- 'Login' corresponde à string 'Login' na classe.
        [Login] VARCHAR(255) NOT NULL,

        -- 'Senha' corresponde à string 'Senha' na classe.
        [Senha] VARCHAR(255) NOT NULL,

        -- Define 'IdUsuario' como a chave primária da tabela.
        CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
    );

    -- Mensagem de confirmação para quando a tabela é criada.
    PRINT 'Tabela Usuario criada com sucesso.';
END
ELSE
BEGIN
    -- Mensagem de confirmação para quando a tabela já existe.
    PRINT 'Tabela Usuario já existe.';
END
GO
