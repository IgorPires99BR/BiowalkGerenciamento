USE Biowalk

-- Verifica a existência e insere o setor 'Produção' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Setor] WHERE NomeSetor = 'Produção')
BEGIN
    INSERT INTO [dbo].[Setor] ([IdSetor], [NomeSetor])
    VALUES (NEWID(), 'Produção');
    PRINT 'Setor Produção inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Setor Produção já existe.';
END

-- Verifica a existência e insere o setor 'Solda' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Setor] WHERE NomeSetor = 'Solda')
BEGIN
    INSERT INTO [dbo].[Setor] ([IdSetor], [NomeSetor])
    VALUES (NEWID(), 'Solda');
    PRINT 'Setor Solda inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Setor Solda já existe.';
END

-- Verifica a existência e insere o setor 'Pintura' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Setor] WHERE NomeSetor = 'Pintura')
BEGIN
    INSERT INTO [dbo].[Setor] ([IdSetor], [NomeSetor])
    VALUES (NEWID(), 'Pintura');
    PRINT 'Setor Pintura inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Setor Pintura já existe.';
END

-- Verifica a existência e insere o setor 'Montagem' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Setor] WHERE NomeSetor = 'Montagem')
BEGIN
    INSERT INTO [dbo].[Setor] ([IdSetor], [NomeSetor])
    VALUES (NEWID(), 'Montagem');
    PRINT 'Setor Montagem inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Setor Montagem já existe.';
END
