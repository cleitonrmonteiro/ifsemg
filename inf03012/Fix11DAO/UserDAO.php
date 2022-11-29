<?php

/**************************************
 * CLASSE DE ACESSO A DADOS "UserDAO" 
 **************************************/

# Inclui o arquivo necessário para uso da classe "UniversalConnect"
include_once 'UniversalConnect.php';

class UserDAO {
    
    # Atributo usado para "guardar" a conexão
    private $link;
    
    # CONSTRUTOR (aqui é realizada a conexão com o banco de dados)
    public function __construct() {
        $this->link = UniversalConnect::doConnect();
    }
    
    /***************************************************************************
    * Abaixo, os metódos para "Login", "CReate" e "Update"
    * Similar ao que ocorre em CursoDAO, aqui os métodos recebem um objeto USER
    ****************************************************************************/

    # LOGIN
    public function login(User $user) {
        try {
            $sql = "SELECT * FROM tbUser WHERE nmUser = :nmUser and pw = :pw";
            $stm = $this->link->prepare($sql);
            
            $stm->bindValue(":nmUser", $user->getNmUser());
            $stm->bindValue(":pw", $user->getPw());
            
            $stm->execute(); 
            if ($stm->rowCount() > 0) {
                return true;
            } else {
                return false;
            }
            
        } catch (Exception $ex) {
            echo "$ex";
        }
    }
    
     # INCLUSÃO
    public function insert(User $user) { 
        try {
            $sql = "INSERT INTO tbUser VALUES(:idUser, :nmUser, :pw)";     
            $stm = $this->link->prepare($sql);   
        
            $stm->bindValue(":idUser", $user->getIdUser());
            $stm->bindValue(":nmUser", $user->getNmUser());
            $stm->bindValue(":pw", $user->getPw());
            
            $stm->execute();
            return true;
            
        } catch (Exception $ex) {
            #echo "$ex";
            return false;
        }
    }

    # ALTERAÇÃO DE SENHA
    public function update(User $user, $pwNew) {
        try {
            $sql = "UPDATE tbUser SET pw = :pwNew "
                    . "WHERE nmUser = :nmUser and pw = :pw";     
            $stm = $this->link->prepare($sql);   
        
            $stm->bindValue(":nmUser", $user->getNmUser());
            $stm->bindValue(":pw", $user->getPw());
            $stm->bindValue(":pwNew", $pwNew);
            
            $stm->execute(); 
            if ($stm->rowCount() > 0) {
                return true;
            } else {
                return false;
            }
            
        } catch (Exception $ex) {
            echo "$ex";
        }
    }
}
