create table tblProduto (
id int primary key not null,
Nome varchar(250) not null,
Descricao varchar(250) not null,
Ativo bit not null, 
Perecivel bit not null,
CategoriaID int not null
);

create table tblCategoriaProduto(
id int primary key not null,
nome varchar(250) not null,
Descricao varchar(250) not null,
Ativo bit not null
);

Alter table tblProduto 
ADD CONSTRAINT FK_CATEGORIA
FOREIGN KEY (CategoriaID) REFERENCES tblCategoriaProduto(id);

CREATE SEQUENCE SQ_CATEGORIA_ID
START WITH 1
INCREMENT BY 1
MAXVALUE 9999999
no cycle;

CREATE SEQUENCE SQ_PRODUTO_ID
START WITH 1
INCREMENT BY 1
MAXVALUE 9999999
no cycle;


INSERT INTO tblCategoriaProduto (id, Nome, Descricao, Ativo)values (NEXT VALUE FOR SQ_CATEGORIA_ID, 'Eletrônico', 'Eletrodomésticos', 1);
INSERT INTO tblCategoriaProduto (id, Nome, Descricao, Ativo)values (NEXT VALUE FOR SQ_CATEGORIA_ID, 'Informática', 'Produtos para Informática', 1);
INSERT INTO tblCategoriaProduto (id, Nome, Descricao, Ativo)values (NEXT VALUE FOR SQ_CATEGORIA_ID, 'Celulares', 'Aparelhos e acessórios', 1);
INSERT INTO tblCategoriaProduto (id, Nome, Descricao, Ativo)values (NEXT VALUE FOR SQ_CATEGORIA_ID, 'Moda', ' Artigos para vestuário em geral', 1);
INSERT INTO tblCategoriaProduto (id, Nome, Descricao, Ativo)values (NEXT VALUE FOR SQ_CATEGORIA_ID, 'Livros', 'Livros ', 1);


go

--Select Produtos with categoria
CREATE PROCEDURE SelectProdutoCategoria
as
begin

SELECT P.id, P.Nome, P.Descricao, P.Ativo, P.Perecivel, P.CategoriaID, C.nome  FROM tblProduto P INNER JOIN tblCategoriaProduto C ON P.CategoriaID = C.id WHERE P.Ativo=1;
end
go


--Select Categoria
CREATE PROCEDURE SelectCategoria 
as 
BEGIN
SELECT * FROM tblCategoriaProduto;
END
go


--Insert and Update Produtos
CREATE PROCEDURE UpdateProduto (
@id int,
@Nome varchar(250),
@Descricao varchar(250),
@Ativo bit,
@Perecivel bit,
@CategoriaID int)
AS 
BEGIN
	UPDATE tblProduto
	SET Nome = @Nome,
	Descricao = @Descricao,
	Ativo = @Ativo,
	Perecivel = @Perecivel,
	CategoriaID = @CategoriaID
	WHERE id = @id;
END
go



-- Delete Produto
CREATE PROCEDURE DeleteProduto (@Id int)
AS 
	BEGIN
		UPDATE tblProduto
		SET Ativo = 0
		WHERE id = @Id;
	END
GO


--Insert Produto
CREATE PROCEDURE InsertProduto (
@Nome varchar(250),
@Descricao varchar(250),
@Ativo bit,
@Perecivel bit,
@CategoriaID int)
AS 
BEGIN 
	INSERT INTO tblProduto
				(id,
				Nome, 
				Descricao,
				Ativo,
				Perecivel,
				CategoriaID)
	VALUES	(NEXT VALUE FOR SQ_PRODUTO_ID,
					 @Nome,
					 @Descricao,
					 @Ativo,
					 @Perecivel,
					 @CategoriaID);
END
go