<?php

/************************************
 * CLASSE UNIVERSAL DE CONEXÃO
 * Implementa "IConnectInfo"
 ************************************/

# Inclui o arquivo necessário para implementação da interface
include_once 'IConnectInfo.php';

class UniversalConnect implements IConnectInfo {
    
    # Recebe os dados para conexão definidos em "IConnectInfo"
    private static $host        = IConnectInfo::HOST;
    private static $port        = IConnectInfo::PORT;
    private static $dbName      = IConnectInfo::DBNAME;
    private static $userName    = IConnectInfo::USERNAME;
    private static $passWord    = IConnectInfo::PASSWORD;
    
    # Atributo usado para "guardar" a conexão estabelecida
    private static $link;
    
    # Implementa o método "doConnect" declarado em "IConnectInfo"
    public static function doConnect() {
        try {
    
            # Estabelece a conexão
            self::$link = new PDO("mysql:host=".self::$host.";port=".self::$port.";dbname=".self::$dbName,
                    self::$userName, self::$passWord);
            
            # Configura o controle de erro
            self::$link->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

            # Retorna a conexão
            return self::$link;

        } catch (Exception $ex) {         
            echo 'Falha na conexão: '.$ex->getMessage();
        }
    }
}
