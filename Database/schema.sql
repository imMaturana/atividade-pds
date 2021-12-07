DROP DATABASE bd_system;
CREATE DATABASE bd_system;
USE bd_system;

CREATE TABLE sexo (
  cod_sex INT NOT NULL AUTO_INCREMENT,
  nome_sex VARCHAR(100) NOT NULL,
  PRIMARY KEY (cod_sex)
);

INSERT INTO sexo VALUES (null, 'Masculino');
INSERT INTO sexo VALUES (null, 'Feminino');

CREATE TABLE endereco (
  cod_end INT NOT NULL AUTO_INCREMENT,
  rua_end VARCHAR(300) NULL DEFAULT NULL,
  numero_end INT NULL DEFAULT NULL,
  bairro_end VARCHAR(100) NULL DEFAULT NULL,
  cidade_end VARCHAR(100) NULL DEFAULT NULL,
  estado_end VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (cod_end)
);

INSERT INTO endereco  VALUES (null, 'Rua Rio Grande do Norte', '5573', 'Setor 2', 'Jaru', 'Rondônia');
INSERT INTO endereco VALUES (null, 'Av. Padre Adolpho Rolh', '1223', 'Setor 4', 'Jaru', 'Rondônia');
INSERT INTO endereco VALUES (null, 'Av. Rio Branco', '3864', 'Setor 1', 'Jaru', 'Rondônia');
INSERT INTO endereco VALUES (null, 'Rua  Florianópolis', '3062', 'Setor 1', 'Jaru', 'Rondônia');
INSERT INTO endereco VALUES (null, 'Rua 7 de Setembro', '4501', 'Jardim dos Estados', 'Jaru', 'Rondônia');
INSERT INTO endereco VALUES (null, 'Rua Ceará', '1563', 'Setor 3', 'Jaru', 'Rondônia');
INSERT INTO endereco VALUES (null, 'Avenida JK 2048', '5663', 'Centro', 'Jaru', 'Rondônia');

CREATE TABLE funcionario (
  cod_func INT NOT NULL AUTO_INCREMENT,
  nome_func VARCHAR(200) NOT NULL,
  cpf_func VARCHAR(20) NOT NULL,
  rg_func VARCHAR(20) NULL DEFAULT NULL,
  datanasc_func DATE NULL DEFAULT NULL,
  telefone_func VARCHAR(50) NULL DEFAULT NULL,
  email_func VARCHAR(200) NULL DEFAULT NULL,
  celular_func VARCHAR(50) NULL DEFAULT NULL,
  funcao_func VARCHAR(50) NULL DEFAULT NULL,
  salario_func DOUBLE NULL DEFAULT NULL,
  cod_sex_fk INT NULL DEFAULT NULL,
  cod_end_fk INT NULL DEFAULT NULL,
  PRIMARY KEY (cod_func),
  INDEX cod_sex_fk (cod_sex_fk ASC) VISIBLE,
  INDEX cod_end_fk (cod_end_fk ASC) VISIBLE,
  CONSTRAINT funcionario_ibfk_1
    FOREIGN KEY (cod_sex_fk)
    REFERENCES sexo (cod_sex),
  CONSTRAINT funcionario_ibfk_2
    FOREIGN KEY (cod_end_fk)
    REFERENCES endereco (cod_end)
);

INSERT INTO funcionario VALUES (null, 'Gustavo Henrique dos Santos', '12345678910', '1020304050', '1999-05-17', '111222333', 'gustavo.henrique@gmail.com', '6969696969', 'Vendedor', '1780.00', 1, 1);
INSERT INTO funcionario VALUES (null, 'Ana Gabrielly de Souza', '01200340056', '1122334455', '2001-10-27', '102030405', 'anagaby.za@disroot.org', '112033405560', 'Vendedor', '1822.10', 2, 2);
INSERT INTO funcionario VALUES (null, 'Davi Gomes Soares', '01020304079', '1111111111', '2003-07-09', '9090909090', 'davigomer@outlook.com', '455667788990', 'Vendedor', '1678.26', 1, 3);

CREATE TABLE cliente (
  cod_cli INT NOT NULL AUTO_INCREMENT,
  nome_cli VARCHAR(200) NOT NULL,
  cpf_cli VARCHAR(20) NOT NULL,
  rg_cli VARCHAR(20) NULL DEFAULT NULL,
  datanasc_cli DATE NULL DEFAULT NULL,
  telefone_fixo_cli VARCHAR(50) NULL DEFAULT NULL,
  telefone_celular_cli VARCHAR(50) NULL DEFAULT NULL,
  email_cli VARCHAR(200) NULL DEFAULT NULL,
  cod_sex_fk INT NULL DEFAULT NULL,
  cod_end_fk INT NULL DEFAULT NULL,
  PRIMARY KEY (cod_cli),
  INDEX cod_sex_fk (cod_sex_fk ASC) VISIBLE,
  INDEX cod_end_fk (cod_end_fk ASC) VISIBLE,
  CONSTRAINT cliente_ibfk_1
    FOREIGN KEY (cod_sex_fk)
    REFERENCES sexo (cod_sex),
  CONSTRAINT cliente_ibfk_2
    FOREIGN KEY (cod_end_fk)
    REFERENCES endereco (cod_end)
);

CREATE TABLE produto (
  cod_prod INT NOT NULL AUTO_INCREMENT,
  nome_prod VARCHAR(100) NOT NULL,
  descricao_prod VARCHAR(200) NULL DEFAULT NULL,
  marca_prod VARCHAR(100) NULL DEFAULT NULL,
  valor_venda_prod DOUBLE NULL DEFAULT NULL,
  PRIMARY KEY (cod_prod)
);

CREATE TABLE venda (
  cod_vend INT NOT NULL AUTO_INCREMENT,
  cod_func_fk INT NULL DEFAULT NULL,
  cod_cli_fk INT NULL DEFAULT NULL,
  data_vend DATE NULL DEFAULT NULL,
  forma_pagamento_vend VARCHAR(100) NULL DEFAULT NULL,
  valor_total_vend DOUBLE NULL DEFAULT NULL,
  PRIMARY KEY (cod_vend),
  INDEX cod_func_fk (cod_func_fk ASC) VISIBLE,
  INDEX cod_cli_fk (cod_cli_fk ASC) VISIBLE,
  CONSTRAINT compra_ibfk_1
    FOREIGN KEY (cod_func_fk)
    REFERENCES funcionario (cod_func),
  CONSTRAINT compra_ibfk_2
    FOREIGN KEY (cod_cli_fk)
    REFERENCES cliente (cod_cli)
  );

CREATE TABLE venda_itens (
  cod_itenv INT NOT NULL AUTO_INCREMENT,
  quantidade_itenv INT NOT NULL,
  valor_itenv FLOAT NOT NULL,
  valor_total_itenv FLOAT NOT NULL,
  cod_prod_fk INT NOT NULL,
  cod_vend_fk INT NOT NULL,
  PRIMARY KEY (cod_itenv),
  INDEX cod_prod_fk (cod_prod_fk ASC) VISIBLE,
  INDEX cod_vend_fk (cod_vend_fk ASC) VISIBLE,
  CONSTRAINT itens_compra_ibfk_1
    FOREIGN KEY (cod_prod_fk)
    REFERENCES produto (cod_prod),
  CONSTRAINT itens_compra_ibfk_2
    FOREIGN KEY (cod_vend_fk)
    REFERENCES venda (cod_vend)
);

CREATE TABLE usuario (
  cod_usu INT NOT NULL AUTO_INCREMENT,
  usuario_usu VARCHAR(100) NOT NULL,
  senha_usu TEXT NOT NULL,
  cod_func_fk INT NOT NULL,
  PRIMARY KEY (cod_usu),
  INDEX cod_func_fk_idx (cod_func_fk ASC) VISIBLE,
  CONSTRAINT cod_func_fk
    FOREIGN KEY (cod_func_fk)
    REFERENCES funcionario (cod_func)
);
