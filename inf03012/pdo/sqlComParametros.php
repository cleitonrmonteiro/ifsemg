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
        
    $sql = "SELECT * FROM tbCurso WHERE idCurso = :idCurso";
    $stm = $conexao->prepare($sql);
    
    # DEFININDO PARÂMETROS COM 'bindParam' (ou 'bindValue')
    $idCurso = 1;
    $stm->bindParam(":idCurso", $idCurso);
    $stm->execute();

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