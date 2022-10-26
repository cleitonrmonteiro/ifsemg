<?php

/************************************
 * PHP Data Objects (PDO)
 ************************************/

# BLOCO (try_catch) PARA TRATAMENTO DE EXCEÇÕES
const HOST      = "localhost";
const PORT      = "3306";
const DBNAME    = "bdensino";
const USERNAME  = "root";
const PASSWORD  = "if@2022";

try {  
    
    # CRIA UM NOVO "OBJETO DE CONEXÃO" DA CLASSE PDO
    $conexao = new PDO("mysql:host=".HOST.";port=".PORT.";dbname=".DBNAME, USERNAME, PASSWORD);
    
    # DEFINE A ESTRATÉGIA PARA CONTROLE DE ERROS (ver opções abaixo)
    $conexao->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        
    # DEFINE O SCRIPT SQL A SER EXECUTADO
    $sql = "SELECT * FROM tbCurso WHERE idCurso = :idCurso";
    
    # PREPARA A EXECUÇÃO
    $stm = $conexao->prepare($sql);
    
    # DEFININDO PARÂMETROS COM 'bindParam' (ou 'bindValue')
    $idCurso = 1;
    $stm->bindParam(":idCurso", $idCurso);
    
    # EXECUTA O SCRIPT DEFINIDO, RETORNANDO UM ARRAY
    $stm->execute();

    # GERA UM ARRAY COM TODOS OS RESULTADOS (permite usar 'foreach')
    $resultado = $stm->fetchAll();
    
    # VERIFICA SE ALGUMA LINHA FOI RETORNADA ('count')
    if (count($resultado) > 0) {
        foreach ($resultado as $curso) {
            echo "$curso[1]<br>";
        }
    } else {
        echo 'Nenhum registro encontrado.';
    }
    
} catch (Exception $ex) {
    echo 'Falha na conexão: '.$ex->getMessage();
}

// Veja mais em: https://www.php.net/manual/pt_BR/book.pdo.php