CREATE DATABASE estoque;
USE estoque;

CREATE TABLE itens(
id_itens INT PRIMARY KEY AUTO_INCREMENT,
nome VARCHAR(255),
modelo VARCHAR(250),
tipo VARCHAR(100),
dataEntrada date,
dataSaida date,
valor double
);

select * from itens;