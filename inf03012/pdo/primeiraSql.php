<?php

/************************************
 * PHP Data Objects (PDO)
 ************************************/

# DADOS DA CONEXÃO
const HOST      = "localhost";
const PORT      = "3306";
const DBNAME    = "bdensino";
const USERNAME  = "root";
const PASSWORD  = "if@2022";

# BLOCO (try_catch) PARA TRATAMENTO DE EXCEÇÕES
try {  
    
    # CRIA UM NOVO "OBJETO DE CONEXÃO" DA CLASSE PDO
    $conexao = new PDO("mysql:host=".HOST.";port=".PORT.";dbname=".DBNAME, USERNAME, PASSWORD);
    
    # DEFINE A ESTRATÉGIA PARA CONTROLE DE ERROS (ver opções abaixo)
    $conexao->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        
    # DEFINE O SCRIPT SQL A SER EXECUTADO
    $sql = "SELECT * FROM tbCurso WHERE idCurso";
    
    # EXECUTA O SCRIPT DEFINIDO, RETORNANDO UM ARRAY
    $dados = $conexao->query($sql);

    # IMPRIME LINHA A LINHA OS DADOS DO ARRAY GERADO
    foreach ($dados as $curso) {
        /*print_r($curso);
        echo '<br>';*/
        echo "$curso[1]<br>";
    }
    
} catch (Exception $ex) {
    echo 'Falha na conexão: '.$ex->getMessage();
}

/************************************
 * CONTROLE DE ERROS DO PDO
 ************************************/

/* A classe PDO permite modificar a estratégia para controle de erros através do
 * método setAttribute(), onde é informado o valor do atributo PDO::ATTR_ERRMODE
 * entre os seguintes
 * 
 * 1. PDO::ERRMODE_SILENT:      permite obter os erros via errorCode e errorInfo;
 * 2. PDO::ERRMODE_WARNING:     permite emitir WARNING;
 * 3. PDO::ERRMODE_EXCEPTION:   permite emitir exceções (PDOEexception).
 */

// Ver mais sobre PDO em: https://www.php.net/manual/pt_BR/book.pdo.php