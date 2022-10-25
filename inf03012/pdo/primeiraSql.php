<?php

/************************************
 * PHP Data Objects (PDO)
 ************************************/

const HOST      = "localhost";
const PORT      = "3306";
const DBNAME    = "bdensino";
const USERNAME  = "root";
const PASSWORD  = "if@2022";

try {  
    $conexao = new PDO("mysql:host=".HOST.";port=".PORT.";dbname=".DBNAME, USERNAME, PASSWORD);
    $conexao->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        
    # DEFINE O SCRIPT SQL A SER EXECUTADO
    $sql = "SELECT * FROM tbCurso WHERE idCurso = 5";
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

// Ver mais sobre PDO em: https://www.php.net/manual/pt_BR/book.pdo.php