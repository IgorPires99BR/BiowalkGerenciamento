USE Biowalk
-- Verifica se a tabela 'EquipamentoMontagem' já existe no banco de dados.
-- O bloco 'BEGIN...END' só é executado se a tabela não existir.
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EquipamentoMontagem]') AND type in (N'U'))
BEGIN
    -- Cria a tabela 'EquipamentoMontagem'
    CREATE TABLE [dbo].[EquipamentoMontagem](
        -- Chave primária da tabela, mapeando o Guid do C#.
        -- O DEFAULT NEWID() garante que um GUID seja gerado automaticamente.
        [IdEquipamentoMontagem] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

        -- Chave estrangeira para a tabela de Setores.
        [IdSetor] UNIQUEIDENTIFIER NOT NULL,

        -- Chave estrangeira para a tabela de Equipamentos.
        [IdEquipamento] UNIQUEIDENTIFIER NOT NULL,

        -- Coluna para a data de lançamento. DATETIME2 é uma boa escolha
        -- para precisão de data e hora.
        [DataLancamento] DATETIME NOT NULL,
		[DataFechamentoCorte] DATETIME NULL,
		[DataFechamentoSolda] DATETIME NULL,
		[DataFechamentoPintura] DATETIME NULL,
		[DataFechamentoMontagem] DATETIME NULL,
        -- Coluna para o status do equipamento.
        [status] INT NOT NULL,
		[Etapa] INT NOT NULL
        -- Define a chave primária da tabela.
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
