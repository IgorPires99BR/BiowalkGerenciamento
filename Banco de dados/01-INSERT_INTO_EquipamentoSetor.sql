USE Biowalk

-- Declaração de variáveis para armazenar os IDs dos equipamentos
DECLARE @idEsteira UNIQUEIDENTIFIER;
DECLARE @idBicicleta UNIQUEIDENTIFIER;
DECLARE @idEscada UNIQUEIDENTIFIER;

-- Declaração de variáveis para armazenar os IDs dos setores
DECLARE @idProducao UNIQUEIDENTIFIER;
DECLARE @idSolda UNIQUEIDENTIFIER;
DECLARE @idPintura UNIQUEIDENTIFIER;
DECLARE @idMontagem UNIQUEIDENTIFIER;

-- Recupera os IDs dos equipamentos da tabela Equipamento
SELECT @idEsteira = IdEquipamento FROM [dbo].[Equipamento] WHERE Nome = 'Esteira';
SELECT @idBicicleta = IdEquipamento FROM [dbo].[Equipamento] WHERE Nome = 'Bicicleta';
SELECT @idEscada = IdEquipamento FROM [dbo].[Equipamento] WHERE Nome = 'Escada';

-- Recupera os IDs dos setores da tabela Setor
SELECT @idProducao = IdSetor FROM [dbo].[Setor] WHERE NomeSetor = 'Produção';
SELECT @idSolda = IdSetor FROM [dbo].[Setor] WHERE NomeSetor = 'Solda';
SELECT @idPintura = IdSetor FROM [dbo].[Setor] WHERE NomeSetor = 'Pintura';
SELECT @idMontagem = IdSetor FROM [dbo].[Setor] WHERE NomeSetor = 'Montagem';

-- Verifica e insere a relação entre os setores e os equipamentos.
-- Ordem 1: Produção
IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idProducao AND IdEquipamento = @idEsteira)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idProducao, @idEsteira, 1);
    PRINT 'Relação Produção/Esteira inserida com sucesso.';
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idProducao AND IdEquipamento = @idBicicleta)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idProducao, @idBicicleta, 1);
    PRINT 'Relação Produção/Bicicleta inserida com sucesso.';
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idProducao AND IdEquipamento = @idEscada)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idProducao, @idEscada, 1);
    PRINT 'Relação Produção/Escada inserida com sucesso.';
END

-- Ordem 2: Solda
IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idSolda AND IdEquipamento = @idEsteira)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idSolda, @idEsteira, 2);
    PRINT 'Relação Solda/Esteira inserida com sucesso.';
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idSolda AND IdEquipamento = @idBicicleta)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idSolda, @idBicicleta, 2);
    PRINT 'Relação Solda/Bicicleta inserida com sucesso.';
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idSolda AND IdEquipamento = @idEscada)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idSolda, @idEscada, 2);
    PRINT 'Relação Solda/Escada inserida com sucesso.';
END

-- Ordem 3: Pintura
IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idPintura AND IdEquipamento = @idEsteira)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idPintura, @idEsteira, 3);
    PRINT 'Relação Pintura/Esteira inserida com sucesso.';
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idPintura AND IdEquipamento = @idBicicleta)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idPintura, @idBicicleta, 3);
    PRINT 'Relação Pintura/Bicicleta inserida com sucesso.';
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idPintura AND IdEquipamento = @idEscada)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idPintura, @idEscada, 3);
    PRINT 'Relação Pintura/Escada inserida com sucesso.';
END

-- Ordem 4: Montagem
IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idMontagem AND IdEquipamento = @idEsteira)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idMontagem, @idEsteira, 4);
    PRINT 'Relação Montagem/Esteira inserida com sucesso.';
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idMontagem AND IdEquipamento = @idBicicleta)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idMontagem, @idBicicleta, 4);
    PRINT 'Relação Montagem/Bicicleta inserida com sucesso.';
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoSetor] WHERE IdSetor = @idMontagem AND IdEquipamento = @idEscada)
BEGIN
    INSERT INTO [dbo].[EquipamentoSetor] ([IdEquipamentoSetor], [IdSetor], [IdEquipamento], [Ordem])
    VALUES (NEWID(), @idMontagem, @idEscada, 4);
    PRINT 'Relação Montagem/Escada inserida com sucesso.';
END
