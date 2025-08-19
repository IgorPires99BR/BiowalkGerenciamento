USE Biowalk

-- Insere um usuário para o setor 'Corte'
IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE NomeUsuario = 'Usuario_Corte')
BEGIN
    INSERT INTO [dbo].[Usuario] ([IdSetor], [NomeUsuario])
    VALUES ('E8D94A48-42F3-40CB-8670-AAC95A93145F', 'Usuario_Corte');
    PRINT 'Usuário para o setor Corte inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Usuário para o setor Corte já existe.';
END

-- Insere um usuário para o setor 'Solda'
IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE NomeUsuario = 'Usuario_Solda')
BEGIN
    INSERT INTO [dbo].[Usuario] ([IdSetor], [NomeUsuario])
    VALUES ('5ED680C2-91CF-4C3E-9E39-4C6E2E614B6D', 'Usuario_Solda');
    PRINT 'Usuário para o setor Solda inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Usuário para o setor Solda já existe.';
END

-- Insere um usuário para o setor 'Pintura'
IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE NomeUsuario = 'Usuario_Pintura')
BEGIN
    INSERT INTO [dbo].[Usuario] ([IdSetor], [NomeUsuario])
    VALUES ('1F0F21B2-436A-4ABF-920D-268344BEF919', 'Usuario_Pintura');
    PRINT 'Usuário para o setor Pintura inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Usuário para o setor Pintura já existe.';
END

-- Insere um usuário para o setor 'Montagem'
IF NOT EXISTS (SELECT 1 FROM [dbo].[Usuario] WHERE NomeUsuario = 'Usuario_Montagem')
BEGIN
    INSERT INTO [dbo].[Usuario] ([IdSetor], [NomeUsuario])
    VALUES ('183E5A49-C651-4BA9-92E5-4A2F8BC18D58', 'Usuario_Montagem');
    PRINT 'Usuário para o setor Montagem inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Usuário para o setor Montagem já existe.';
END