USE Biowalk
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EquipamentoMontagem]') AND type in (N'U'))
BEGIN
    -- Cria a tabela 'EquipamentoMontagem'
    CREATE TABLE [dbo].[EquipamentoMontagem](
        [IdEquipamentoMontagem] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
        [IdEquipamento] UNIQUEIDENTIFIER NOT NULL,
        [DataLancamento] DATETIME NOT NULL,
		[DataFechamentoCorte] DATETIME NULL,
		[DataFechamentoSolda] DATETIME NULL,
		[DataFechamentoPintura] DATETIME NULL,
		[DataFechamentoMontagem] DATETIME NULL,
        [Status] INT NOT NULL,
		[Etapa] INT NOT NULL
        CONSTRAINT [PK_EquipamentoMontagem] PRIMARY KEY CLUSTERED ([IdEquipamentoMontagem] ASC)
    );

    -- Mensagem opcional para confirmar a criação da tabela.
    PRINT 'Tabela EquipamentoMontagem criada com sucesso.';
END
ELSE
BEGIN
    -- Mensagem opcional se a tabela já existir.
    PRINT 'Tabela EquipamentoMontagem já existe.';
END
