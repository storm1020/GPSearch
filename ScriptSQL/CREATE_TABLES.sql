/**
Dados retirados do site da receita.
**/
CREATE TABLE gps_tbl_empresa
(
Id INT IDENTITY NOT NULL PRIMARY KEY,
Nome VARCHAR(250) NOT NULL,
Cnpj VARCHAR(14) NOT NULL,
TipoEmpresa NUMERIC(1),
CapitalSocial VARCHAR(30),
Procura VARCHAR(20),
Socios VARCHAR(10),
DataAbertura DATE NOT NULL
);

CREATE TABLE gps_tbl_endereco
(
Id INT IDENTITY NOT NULL PRIMARY KEY,
Endereco VARCHAR(250) NOT NULL,
Numero VARCHAR(15) NOT NULL,
Cep VARCHAR(5),
Bairro VARCHAR(50),
Uf VARCHAR(2),
IdEmpresa INT FOREIGN KEY REFERENCES gps_tbl_empresa(Id)
);

CREATE TABLE gps_tbl_contato_empresa
(
Id INT IDENTITY NOT NULL PRIMARY KEY,
Telefone VARCHAR(25),
Telefone2 VARCHAR(25),
Email VARCHAR(120),
IdEmpresa INT FOREIGN KEY REFERENCES gps_tbl_empresa(Id)
);
