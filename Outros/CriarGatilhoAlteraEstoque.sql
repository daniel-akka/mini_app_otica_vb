--CRIA A FUNCAO:
CREATE OR REPLACE FUNCTION altera_estoque_produto()
RETURNS trigger AS $BODY$
BEGIN
-- Aqui temos um bloco IF que confirmará o tipo de operação.
IF (new.estipo = 'E') THEN
	UPDATE produto SET pestoque = pestoque + new.esquantidade WHERE pid = new.esprodutoid;
RETURN NEW;
-- Aqui temos um bloco IF que confirmará o tipo de operação UPDATE.
ELSIF (new.estipo = 'S') THEN
	UPDATE produto SET pestoque = pestoque - new.esquantidade WHERE pid = new.esprodutoid;	
RETURN NEW;
END IF;
RETURN NULL;
END;
$BODY$
LANGUAGE plpgsql;

--CRIA O GATILHO
CREATE TRIGGER dispara_func_altera_estoque
AFTER INSERT ON entrada_saida
FOR EACH ROW
EXECUTE PROCEDURE altera_estoque_produto();






--CRIA A FUNCAO:
CREATE OR REPLACE FUNCTION altera_estoque_produto_del()
RETURNS trigger AS $BODY$
BEGIN

IF (old.estipo = 'E') THEN
	UPDATE produto SET pestoque = pestoque - old.esquantidade WHERE pid = old.esprodutoid;
RETURN NEW;
-- Aqui temos um bloco IF que confirmará o tipo de operação UPDATE.
ELSIF (old.estipo = 'S') THEN
	UPDATE produto SET pestoque = pestoque + old.esquantidade WHERE pid = old.esprodutoid;	
RETURN NEW;
END IF;
RETURN NULL;
END;
$BODY$
LANGUAGE plpgsql;

--CRIA O GATILHO
CREATE TRIGGER dispara_func_altera_estoque_del
AFTER DELETE ON entrada_saida
FOR EACH ROW
EXECUTE PROCEDURE altera_estoque_produto_del();
