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
    $sql = "SELECT * FROM tbCurso";
    
    # PREPARA A EXECUÇÃO
    $stm = $conexao->prepare($sql);
    
    # EXECUTA O SCRIPT DEFINIDO, RETORNANDO UM ARRAY
    $stm->execute();

    # GERA UM ARRAY COM TODOS OS RESULTADOS (permite usar 'foreach')
    /*$resultado = $stm->fetchAll();
    foreach ($resultado as $curso) {
        echo "$curso[1]<br>";
    }*/

    # OUTRA FORMA DE RECEBER OS DADOS (via 'fetch')
    while($curso = $stm->fetch(PDO::FETCH_OBJ)) {
        echo $curso->nmCurso."<br>";
    }
    
    # PDO::FETCH_ASSOC: retorna um array numérico no qual as chaves serão os nomes das colunas selecionadas (padrão);
    # PDO::FETCH_NUM: retorna um array numérico no qual as chaves serão os índicesdas colunas selecionadas;
    # PDO::FETCH_BOTH: combinação de PDO::FETCH_ASSOC e PDO::FETCH_NUM;
    # PDO::FETCH_OBJ: retorna um objeto cujos atributos são as colunas selecionadas.
    // Veja mais em: https://www.php.net/manual/pt_BR/book.pdo.php
    
} catch (Exception $ex) {
    echo 'Falha na conexão: '.$ex->getMessage();
}
