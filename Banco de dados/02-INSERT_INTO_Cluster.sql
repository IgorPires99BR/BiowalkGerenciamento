USE Biowalk

-- Verifica a existência e insere o setor 'Produção' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Cluster] WHERE NomeCluster = 'Produção')
BEGIN
    INSERT INTO [dbo].[Cluster] ([IdCluster], [NomeCluster])
    VALUES (NEWID(), 'Produção');
    PRINT 'Cluster Produção inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Cluster Produção já existe.';
END

-- Verifica a existência e insere o setor 'Solda' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Cluster] WHERE NomeCluster = 'Solda')
BEGIN
    INSERT INTO [dbo].[Cluster] ([IdCluster], [NomeCluster])
    VALUES (NEWID(), 'Solda');
    PRINT 'Cluster Solda inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Cluster Solda já existe.';
END

-- Verifica a existência e insere o setor 'Pintura' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Cluster] WHERE NomeCluster = 'Pintura')
BEGIN
    INSERT INTO [dbo].[Cluster] ([IdCluster], [NomeCluster])
    VALUES (NEWID(), 'Pintura');
    PRINT 'Cluster Pintura inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Setor Pintura já existe.';
END

-- Verifica a existência e insere o setor 'Montagem' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Cluster] WHERE NomeCluster = 'Montagem')
BEGIN
    INSERT INTO [dbo].[Cluster] ([IdCluster], [NomeCluster])
    VALUES (NEWID(), 'Montagem');
    PRINT 'Cluster Montagem inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Cluster Montagem já existe.';
END
