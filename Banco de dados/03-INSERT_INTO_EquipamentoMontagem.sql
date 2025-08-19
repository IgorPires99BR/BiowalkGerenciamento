USE Biowalk

-- Define os valores para o novo registro
DECLARE @equipamentoId UNIQUEIDENTIFIER = 'BC495898-67F0-40F6-B80B-067DF1EF8918';
DECLARE @etapa INT = 1;
DECLARE @status INT = 1;

-- Verifica se o registro já existe antes de inserir
IF NOT EXISTS (SELECT 1 FROM [dbo].[EquipamentoMontagem] WHERE IdEquipamento = @equipamentoId AND Etapa = @etapa AND Status = @status)
BEGIN
    -- Insere o novo registro
    INSERT INTO [dbo].[EquipamentoMontagem] ([IdEquipamento], [DataLancamento], [Status], [Etapa])
    VALUES (@equipamentoId, GETDATE(), @status, @etapa);
    
    PRINT 'Registro inserido com sucesso para o Equipamento ' + CONVERT(NVARCHAR(36), @equipamentoId) + ' na Etapa 1.';
END
ELSE
BEGIN
    PRINT 'O registro para o Equipamento ' + CONVERT(NVARCHAR(36), @equipamentoId) + ' na Etapa 1 já existe. Nenhuma alteração foi feita.';
END