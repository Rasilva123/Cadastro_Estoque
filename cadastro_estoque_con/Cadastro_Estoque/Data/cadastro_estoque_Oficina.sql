CREATE DATABASE IF NOT EXISTS CadastroEstoqueOficina;

USE CadastroEstoqueOficina;


-- Tabela Endereco
CREATE TABLE IF NOT EXISTS Endereco (
    id_endereco INT AUTO_INCREMENT PRIMARY KEY,
    logradouro VARCHAR(255),
    numero VARCHAR(50),
    complemento VARCHAR(255),
    bairro VARCHAR(255),
    cidade VARCHAR(255),
    estado VARCHAR(50),
    cep VARCHAR(20)
);

-- Tabela Fornecedores
CREATE TABLE IF NOT EXISTS Fornecedores (
    id_fornecedor INT AUTO_INCREMENT PRIMARY KEY,
    nome_fornecedor VARCHAR(255) NOT NULL,
    telefone_fornecedor VARCHAR(255),
    email_fornecedor VARCHAR(255),
    Fk_id_endereco INT NOT NULL,
    FOREIGN KEY (Fk_id_endereco) REFERENCES Endereco(id_endereco)
);
-- Tabela Clientes
CREATE TABLE IF NOT EXISTS Clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,  
    nome_cliente VARCHAR(255) NOT NULL,
    telefone_cliente VARCHAR(255) NOT Null,
    email_cliente VARCHAR(255),
    cpf_cliente VARCHAR(255) NOT NULL,
    Fk_id_endereco INT NOT NULL,
    FOREIGN KEY (Fk_id_endereco) REFERENCES Endereco(id_endereco)
);

-- Tabela Funcionarios
CREATE TABLE IF NOT EXISTS Funcionarios (
    id_funcionario INT AUTO_INCREMENT PRIMARY KEY,
    nome_funcionario VARCHAR(255) NOT NULL,
    telefone_funcionario VARCHAR(255),
    email_funcionario VARCHAR(255),
    cargo_funcionario VARCHAR(255), 
    Fk_id_endereco INT NOT NULL,
    FOREIGN KEY (Fk_id_endereco) REFERENCES Endereco(id_endereco)
    );


-- Tabela Itens
CREATE TABLE IF NOT EXISTS Itens (
 id_item INT AUTO_INCREMENT PRIMARY KEY,
 nome_item VARCHAR(255) NOT NULL,
 descricao_item VARCHAR(255) NOT NULL, 
 preco_item VARCHAR(255) NOT NULL, 
 quantidade_estoque INT NOT NULL, 
 tipo_item VARCHAR(255) NOT NULL, 
 data_entrada dateTime
 );
 
 
-- Tabela Marcas
CREATE TABLE IF NOT EXISTS Marcas (
    id_marca  INT AUTO_INCREMENT PRIMARY KEY,
    nome_marca VARCHAR(255)
);

-- Tabela Tipos de Veículos
CREATE TABLE IF NOT EXISTS TiposVeiculos (
    id_tipo_veiculo  INT AUTO_INCREMENT PRIMARY KEY,
    nome_tipo_veiculo VARCHAR(255)
);

-- Tabela Veículos
CREATE TABLE IF NOT EXISTS Veiculos (
    id_veiculo  INT AUTO_INCREMENT PRIMARY KEY,
    modelo_veiculo VARCHAR(255),
    ano_veiculo INT,
    placa_veiculo VARCHAR(255) NOT NULL, 
    Fk_id_marca INT,
    Fk_id_tipo_veiculo INT NOT NULL,
    FOREIGN KEY (Fk_id_marca) REFERENCES Marcas(id_marca),
    FOREIGN KEY (Fk_id_tipo_veiculo) REFERENCES TiposVeiculos(id_tipo_veiculo)
);

-- Tabela Agendamentos
CREATE TABLE IF NOT EXISTS Agendamentos (
    id_agendamento  INT AUTO_INCREMENT PRIMARY KEY,
    data_agendamento DATE NOT NULL,
    hora_agendamento TIME,
    Fk_id_funcionario INT,
    Fk_id_veiculo INT NOT NULL,
    FOREIGN KEY (Fk_id_funcionario) REFERENCES Funcionarios(id_funcionario),
    FOREIGN KEY (Fk_id_veiculo) REFERENCES Veiculos(id_veiculo)
);

-- Tabela Serviços
CREATE TABLE IF NOT EXISTS Servicos (
    id_servico INT AUTO_INCREMENT PRIMARY KEY,
    descricao_servico VARCHAR(255),
    preco_servico DECIMAL(10, 2),
    data_servico DATE,
    hora_servico TIME,
    Fk_id_agendamento INT,
    FOREIGN KEY (Fk_id_agendamento) REFERENCES Agendamentos(id_agendamento)
);

-- Tabela Vendas de Itens
CREATE TABLE IF NOT EXISTS VendasItens (
    id_venda_item  INT AUTO_INCREMENT PRIMARY KEY,
    quantidade_vendida INT,
    preco_venda DECIMAL(10, 2),
    data_venda DATE, 
    Fk_id_servico INT NOT NULL,
    Fk_id_CLiente INT NOT NULL,
    FK_id_funcinario INT NOT NULL,
    FOREIGN KEY (Fk_id_servico) REFERENCES Servicos(id_servico),
	FOREIGN KEY (FK_id_funcinario) REFERENCES Funcionarios(id_funcionario)
);

-- Tabela TipoPagamento
CREATE TABLE IF NOT EXISTS TipoPagamento (
    id_tipo_pagamento INT AUTO_INCREMENT PRIMARY KEY,
    tipo_pagamento VARCHAR(50) NOT NULL,
    Fk_id_venda_item INT NOT NULL,
    FOREIGN KEY (Fk_id_venda_item) REFERENCES VendasItens(id_venda_item)
);

-- Inserir registros na tabela Endereco
INSERT INTO Endereco (logradouro, numero, complemento, bairro, cidade, estado, cep) VALUES 
('Rua A', '123', 'Apto 101', 'Centro', 'Cidade A', 'Estado A', '12345-678'),
('Avenida B', '456', 'Bloco B', 'Bairro B', 'Cidade B', 'Estado B', '23456-789'),
('Praça C', '789', 'Casa 3', 'Bairro C', 'Cidade C', 'Estado C', '34567-890'),
('Rua D', '101', 'Casa 1', 'Bairro D', 'Cidade D', 'Estado D', '45678-901'),
('Avenida E', '202', 'Apto 202', 'Bairro E', 'Cidade E', 'Estado E', '56789-012');

-- Inserir registros na tabela Clientes
INSERT INTO Clientes (nome_cliente, telefone_cliente, email_cliente, cpf_cliente, Fk_id_endereco) VALUES 
('João da Silva', '123456789', 'joao.silva@example.com', '111.222.333-44', 1),
('Maria Oliveira', '987654321', 'maria.oliveira@example.com', '555.666.777-88', 2),
('Pedro Santos', '321654987', 'pedro.santos@example.com', '222.333.444-55', 3),
('Ana Costa', '654321789', 'ana.costa@example.com', '333.444.555-66', 4),
('Lucas Almeida', '987123456', 'lucas.almeida@example.com', '444.555.666-77', 5);

-- Inserir registros na tabela Funcionarios
INSERT INTO Funcionarios (nome_funcionario, telefone_funcionario, email_funcionario, cargo_funcionario, Fk_id_endereco) VALUES 
('Carlos Souza', '543216789', 'carlos.souza@example.com', 'Gerente', 1),
('Ana Lima', '321654987', 'ana.lima@example.com', 'Mecânico', 3),
('Roberto Ferreira', '987654321', 'roberto.ferreira@example.com', 'Atendente', 2),
('Fernanda Ribeiro', '654987321', 'fernanda.ribeiro@example.com', 'Assistente', 4),
('Marcos Paulo', '123789456', 'marcos.paulo@example.com', 'Mecânico', 5);

-- Inserir registros na tabela Fornecedores
INSERT INTO Fornecedores (nome_fornecedor, telefone_fornecedor, email_fornecedor, Fk_id_endereco) VALUES 
('Fornecedor A', '111222333', 'fornecedorA@example.com', 1),
('Fornecedor B', '444555666', 'fornecedorB@example.com', 2),
('Fornecedor C', '777888999', 'fornecedorC@example.com', 3),
('Fornecedor D', '222333444', 'fornecedorD@example.com', 4),
('Fornecedor E', '555666777', 'fornecedorE@example.com', 5);

-- Inserir registros na tabela Itens
INSERT INTO Itens (nome_item, descricao_item, preco_item, quantidade_estoque, tipo_item, data_entrada) VALUES 
('Óleo de Motor', 'Óleo sintético 5W-30', '35.50', 100, 'Peça', '2025-01-15'),
('Filtro de Ar', 'Filtro de ar para motor', '25.00', 50, 'Peça', '2025-02-10'),
('Pastilha de Freio', 'Pastilha de freio dianteira', '80.00', 30, 'Peça', '2025-01-20'),
('Bateria', 'Bateria automotiva 60Ah', '300.00', 20, 'Peça', '2025-01-25'),
('Amortecedor', 'Amortecedor dianteiro', '150.00', 15, 'Peça', '2025-02-05');

-- Inserir registros na tabela Marcas
INSERT INTO Marcas (nome_marca) VALUES 
('Toyota'),
('Honda'),
('Ford'),
('Chevrolet'),
('Nissan');

-- Inserir registros na tabela TiposVeiculos
INSERT INTO TiposVeiculos (nome_tipo_veiculo) VALUES 
('Carro'),
('Moto'),
('Caminhão'),
('Van'),
('SUV');

-- Inserir registros na tabela Veiculos
INSERT INTO Veiculos (modelo_veiculo, ano_veiculo, placa_veiculo, Fk_id_marca, Fk_id_tipo_veiculo) VALUES 
('Corolla', 2020, 'ABC-1234', 1, 1),
('Civic', 2019, 'DEF-5678', 2, 1),
('F-150', 2021, 'GHI-9012', 3, 3),
('S10', 2020, 'JKL-3456', 4, 3),
('Rogue', 2022, 'MNO-7890', 5, 5);

-- Inserir registros na tabela Agendamentos
INSERT INTO Agendamentos (data_agendamento, hora_agendamento, Fk_id_funcionario, Fk_id_veiculo) VALUES 
('2025-03-01', '08:00:00', 1, 1),
('2025-03-05', '09:00:00', 2, 2),
('2025-03-10', '10:00:00', 3, 3),
('2025-03-15', '11:00:00', 4, 4),
('2025-03-20', '12:00:00', 5, 5);

-- Inserir registros na tabela Servicos
INSERT INTO Servicos (descricao_servico, preco_servico, data_servico, hora_servico, Fk_id_agendamento) VALUES 
('Troca de óleo', '50.00', '2025-03-01', '08:30:00', 1),
('Revisão geral', '150.00', '2025-03-05', '10:00:00', 2),
('Alinhamento', '100.00', '2025-03-10', '11:00:00', 3),
('Balanceamento', '80.00', '2025-03-15', '12:00:00', 4),
('Troca de pastilhas', '200.00', '2025-03-20', '13:00:00', 5);

-- Inserir registros na tabela VendasItens
INSERT INTO VendasItens (quantidade_vendida, preco_venda, data_venda, Fk_id_servico, Fk_id_CLiente, FK_id_funcinario) VALUES
(2, '70.00', '2025-03-01', 1, 1, 1),
(1, '25.00', '2025-03-05', 2, 2, 2),
(3, '240.00', '2025-03-10', 3, 3,3),
(1, '300.00', '2025-03-15', 4, 4, 4),
(1, '150.00', '2025-03-20', 5, 5, 5);

-- Inserir dois novos tipos de pagamento
INSERT INTO TipoPagamento (tipo_pagamento, Fk_id_venda_item) VALUES 
('Cartão de Crédito', 1),
('Boleto Bancário', 2),
('Dinheiro', 3),
('Transferência', 4),
('Pix', 5);
