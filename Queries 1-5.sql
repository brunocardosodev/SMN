--> 1
DECLARE 
	@dtInicial DATE,
	@dtFinal DATE
SELECT
	MIN(P.nmProduto)	AS nmProduto,
	COUNT(*)			AS qtVendas,
	SUM(P.vrProduto)	AS vrVendas
FROM 
	dbo.Produto AS P
	LEFT JOIN dbo.Venda AS V
		ON V.idProduto = P.idProduto
WHERE
	V.dtVenda BETWEEN @dtInicial AND @dtFinal
GROUP BY p.idProduto
ORDER BY qtVendas DESC
GO

--> 2
DECLARE 
	@dtInicial DATE,
	@dtFinal DATE
SELECT
	P.nmProduto,
	V.dtVenda,
	P.vrProduto	AS vrVenda
FROM 
	dbo.Venda AS V
	INNER JOIN dbo.Produto AS P
		ON V.idProduto = P.idProduto
WHERE
	BETWEEN @dtInicial AND @dtFinal
ORDER BY 
	P.nmProduto, V.dtVenda DESC
GO

--> 3 - não será possivel ordenar por nome do produto, uma vez que ele não faz parte do grupo de campos a serem informados. Para isso o relatório deveria ser analítico e não um consolidado
DECLARE @dtAno SMALLINT = NULL

select
	YEAR(V.dtVenda)		AS ano,
	MONTH(V.dtVenda)	AS mes,
	COUNT(*)			AS qtVendas,
	SUM(P.vrProduto)	AS vrVendas
FROM
	dbo.Venda AS v
	INNER JOIN dbo.Produto AS p
		ON V.idProduto = P.idProduto
WHERE
	(@dtAno IS NOT NULL AND V.dtVenda BETWEEN DATEFROMPARTS(@dtAno, 1, 1) AND DATEFROMPARTS(@dtAno, 12, 31))
	OR @dtAno IS NULL
GROUP BY YEAR(V.dtVenda), MONTH(V.dtVenda)
ORDER BY YEAR(V.dtVenda) DESC, MONTH(V.dtVenda) DESC
GO

--> 4 - Não há informações de estoque (nem dados ou estrutura de tabela)

--> 5
DECLARE @idCNPJCliente BIGINT = NULL

SELECT DISTINCT
		V.idCNPJCliente, -- Como o nome é obtido através da API da receita, usamos o CNPJ.
						 -- Para obtermos o nome, precisariamos de uma tabela de clientes
						 -- ou a criação de uma função CLR que consultasse essa API.
		P.nmProduto,
		P.vrProduto,
		TC.qtProdutosCompradosClientes,
		TC.vrProdutosCompradosClientes
FROM 
	dbo.Venda as V
	INNER JOIN DBO.Produto AS P
		ON v.idProduto = p.idProduto
	INNER JOIN
		(SELECT idCNPJCliente,
		COUNT(*)			AS qtProdutosCompradosClientes,
		SUM(P.vrProduto)	AS vrProdutosCompradosClientes
		FROM dbo.Venda AS V
		INNER JOIN dbo.Produto AS P
		ON V.idProduto = P.idProduto
		GROUP BY v.idCNPJCliente
		) AS TC
		ON TC.idCNPJCliente = V.idCNPJCliente
WHERE
	(@idCNPJCliente IS NOT NULL AND V.idCNPJCliente = @idCNPJCliente)
	OR @idCNPJCliente IS NULL
ORDER BY V.idCNPJCliente, P.nmProduto
GO