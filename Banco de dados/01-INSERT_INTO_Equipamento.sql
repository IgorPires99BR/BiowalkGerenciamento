USE Biowalk
-- Verifica a existência e insere o equipamento 'Esteira' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Equipamento] WHERE Nome = 'Esteira')
BEGIN
    INSERT INTO [dbo].[Equipamento] ([IdEquipamento], [Nome])
    VALUES (NEWID(), 'Esteira');
    PRINT 'Equipamento Esteira inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Equipamento Esteira já existe.';
END

-- Verifica a existência e insere o equipamento 'Bicicleta' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Equipamento] WHERE Nome = 'Bicicleta')
BEGIN
    INSERT INTO [dbo].[Equipamento] ([IdEquipamento], [Nome])
    VALUES (NEWID(), 'Bicicleta');
    PRINT 'Equipamento Bicicleta inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Equipamento Bicicleta já existe.';
END

-- Verifica a existência e insere o equipamento 'Escada' se ele ainda não existir.
IF NOT EXISTS (SELECT 1 FROM [dbo].[Equipamento] WHERE Nome = 'Escada')
BEGIN
    INSERT INTO [dbo].[Equipamento] ([IdEquipamento], [Nome])
    VALUES (NEWID(), 'Escada');
    PRINT 'Equipamento Escada inserido com sucesso.';
END
ELSE
BEGIN
    PRINT 'Equipamento Escada já existe.';
END
