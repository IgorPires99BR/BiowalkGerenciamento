USE Biowalk

IF NOT EXISTS (SELECT 1 FROM [dbo].[Setor] WHERE NomeSetor = 'Administrativo')
BEGIN
    INSERT INTO [dbo].[Setor] ([IdSetor], [NomeSetor])
    VALUES (NEWID(), 'Administrativo');
    PRINT 'Setor Administrativo inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Setor Administrativo já existe.';
END


-- Verifica se o setor 'Corte' já existe antes de inserir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Setor] WHERE NomeSetor = 'Corte')
BEGIN
    INSERT INTO [dbo].[Setor] ([IdSetor], [NomeSetor])
    VALUES (NEWID(), 'Corte');
    PRINT 'Setor Corte inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Setor Corte já existe.';
END

-- Verifica se o setor 'Solda' já existe antes de inserir.
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

-- Verifica se o setor 'Pintura' já existe antes de inserir.
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

-- Verifica se o setor 'Montagem' já existe antes de inserir.
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