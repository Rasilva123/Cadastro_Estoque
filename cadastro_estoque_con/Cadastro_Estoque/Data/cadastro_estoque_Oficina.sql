CREATE DATABASE IF NOT EXISTS CadastroEstoqueOficina;

USE CadastroEstoqueOficina;

CREATE TABLE IF NOT EXISTS Itens (
    id_item INT AUTO_INCREMENT PRIMARY KEY,
    nome_item VARCHAR(255) NOT NULL,
    descricao_item VARCHAR(255) NOT NULL,
    preco_item VARCHAR(255) NOT NULL,
    quantidade 
);
