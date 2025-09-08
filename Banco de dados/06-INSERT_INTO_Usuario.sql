USE Biowalk
GO

-- Script de inserção adaptado para a tabela 'Usuario'.
-- As colunas 'Login' e 'Senha' foram adicionadas, e 'NomeUsuario' foi corrigida para 'Nome'.

-- Insere um usuário para o setor 'Corte'
IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE Nome = 'Usuario_Corte')
BEGIN
    -- O nome da coluna foi alterado de 'NomeUsuario' para 'Nome' e as colunas 'Login' e 'Senha' foram adicionadas.
    INSERT INTO [dbo].[Usuario] ([IdSetor], [Nome], [Login], [Senha])
    VALUES ('E8D94A48-42F3-40CB-8670-AAC95A93145F', 'Usuario_Corte', 'corte_login', 'corte_senha');
    PRINT 'Usuário para o setor Corte inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Usuário para o setor Corte já existe.';
END
GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE Nome = 'Lucas')
BEGIN
    -- O nome da coluna foi alterado de 'NomeUsuario' para 'Nome' e as colunas 'Login' e 'Senha' foram adicionadas.
    INSERT INTO [dbo].[Usuario] ([IdSetor], [Nome], [Login], [Senha])
    VALUES ('325D91BC-322B-4CE6-A3BA-2EFDCB462CB9', 'Lucas', 'Lucas', 'Lucas');
    PRINT 'Usuário para o setor Corte inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Usuário para o setor Administrativo já existe.';
END
GO

-- Insere um usuário para o setor 'Solda'
IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE Nome = 'Usuario_Solda')
BEGIN
    -- O nome da coluna foi alterado de 'NomeUsuario' para 'Nome' e as colunas 'Login' e 'Senha' foram adicionadas.
    INSERT INTO [dbo].[Usuario] ([IdSetor], [Nome], [Login], [Senha])
    VALUES ('5ED680C2-91CF-4C3E-9E39-4C6E2E614B6D', 'Usuario_Solda', 'solda_login', 'solda_senha');
    PRINT 'Usuário para o setor Solda inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Usuário para o setor Solda já existe.';
END
GO

-- Insere um usuário para o setor 'Pintura'
IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE Nome = 'Usuario_Pintura')
BEGIN
    -- O nome da coluna foi alterado de 'NomeUsuario' para 'Nome' e as colunas 'Login' e 'Senha' foram adicionadas.
    INSERT INTO [dbo].[Usuario] ([IdSetor], [Nome], [Login], [Senha])
    VALUES ('1F0F21B2-436A-4ABF-920D-268344BEF919', 'Usuario_Pintura', 'pintura_login', 'pintura_senha');
    PRINT 'Usuário para o setor Pintura inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Usuário para o setor Pintura já existe.';
END
GO

-- Insere um usuário para o setor 'Montagem'
IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE Nome = 'Usuario_Montagem')
BEGIN
    -- O nome da coluna foi alterado de 'NomeUsuario' para 'Nome' e as colunas 'Login' e 'Senha' foram adicionadas.
    INSERT INTO [dbo].[Usuario] ([IdSetor], [Nome], [Login], [Senha])
    VALUES ('183E5A49-C651-4BA9-92E5-4A2F8BC18D58', 'Usuario_Montagem', 'montagem_login', 'montagem_senha');
    PRINT 'Usuário para o setor Montagem inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Usuário para o setor Montagem já existe.';
END
GO
