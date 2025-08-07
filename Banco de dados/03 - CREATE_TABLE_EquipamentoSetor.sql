USE Biowalk
-- Verifica se a tabela 'EquipamentoSetor' já existe no banco de dados.
-- Se a tabela não existir, o bloco 'BEGIN...END' é executado para criá-la.
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EquipamentoSetor]') AND type in (N'U'))
BEGIN
    -- Cria a tabela 'EquipamentoSetor'
    CREATE TABLE [dbo].[EquipamentoSetor](
        -- Coluna de ID, usada como chave primária.
        -- UNIQUEIDENTIFIER é o tipo SQL que mapeia para o Guid do C#.
        -- DEFAULT NEWID() atribui um novo GUID automaticamente se nenhum for fornecido.
        [IdEquipamentoSetor] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),

        -- Chave estrangeira para a tabela de Setores.
        [IdSetor] UNIQUEIDENTIFIER NOT NULL,

        -- Chave estrangeira para a tabela de Equipamentos.
        [IdEquipamento] UNIQUEIDENTIFIER NOT NULL,

        -- Coluna para a ordem do equipamento, mapeada para 'int' do C#.
        [Ordem] INT NOT NULL,

        -- Define a chave primária da tabela.
        CONSTRAINT [PK_EquipamentoSetor] PRIMARY KEY CLUSTERED ([IdEquipamentoSetor] ASC)
    );

    -- Mensagem opcional para confirmar a criação da tabela
    PRINT 'Tabela EquipamentoSetor criada com sucesso.';
END
ELSE
BEGIN
    -- Mensagem opcional se a tabela já existir
    PRINT 'Tabela EquipamentoSetor já existe.';
END
