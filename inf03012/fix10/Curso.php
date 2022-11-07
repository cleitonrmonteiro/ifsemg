<?php

class Curso {
    
    public function pesquisarCursos($nmCurso) {
        /************************************
         * PHP Data Objects (PDO)
         ************************************/

        # DADOS DA CONEXÃO
        $host      = "localhost";
        $port      = "8889";
        $dbname    = "bdensino";
        $username  = "root";
        $password  = "root";

        # BLOCO (try_catch) PARA TRATAMENTO DE EXCEÇÕES
        try {  

            # CRIA UM NOVO "OBJETO DE CONEXÃO" DA CLASSE PDO
            $conexao = new PDO("mysql:host=".$host.";port=".$port.";dbname=".$dbname, $username, $password);

            # DEFINE A ESTRATÉGIA PARA CONTROLE DE ERROS (ver opções abaixo)
            $conexao->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

            # DEFINE O SCRIPT SQL A SER EXECUTADO
            $sql = "SELECT * FROM tbCurso WHERE nmCurso LIKE '$nmCurso%'";

            # EXECUTA O SCRIPT DEFINIDO, RETORNANDO UM ARRAY
            return $conexao->query($sql);
        } catch (Exception $ex) {
            echo 'Falha na conexão: '.$ex->getMessage();
        }
    }
}
