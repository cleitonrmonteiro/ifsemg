<?php

/**************************************
 * CLASSE DE ACESSO A DADOS "CursoDAO" 
 **************************************/

# Inclui o arquivo necessário para uso da classe "UniversalConnect"
include_once 'UniversalConnect.php';

class CursoDAO {
    
    # Atributo usado para "guardar" a conexão
    private $link;
    
    # CONSTRUTOR (aqui é realizada a conexão com o banco de dados)
    public function __construct() {
        $this->link = UniversalConnect::doConnect();
    }
    
    /***************************************************************************
    * Abaixo, os metódos para seleção e "CRUD" => "CReate", "Update" e "Delete"
    * Repare que estes métodos do CRUD agora recebem um objeto da classe CURSO
    ****************************************************************************/

    # SELEÇÃO
    public function selectAll() {
        try {
            $sql = "SELECT * "
                    . "FROM tbCurso "
                    . "INNER JOIN tbArea USING (idArea) "
                    . "INNER JOIN tbModalidade USING (idMOdal) "
                    . "ORDER BY idCurso";
            
            $stm = $this->link->prepare($sql);
            $stm->execute(); 
            
            if ($stm->rowCount() > 0) {
            return $stm->fetchAll(PDO::FETCH_OBJ);
            } else {
                return false;
            }
            
        } catch (Exception $ex) {
            echo "$ex";
        }
    }
    
    # INCLUSÃO
    public function insert(Curso $curso) { 
        try {
            $sql = "INSERT INTO tbCurso VALUES(:idCurso, :nmCurso, :idArea, :idModal)";     
            $stm = $this->link->prepare($sql);   
        
            $stm->bindValue(":idCurso", $curso->getIdCurso());
            $stm->bindValue(":nmCurso", $curso->getNmCurso());
            $stm->bindValue(":idArea", $curso->getIdArea());
            $stm->bindValue(":idModal", $curso->getIdModal());
            
            $stm->execute();
            return true;
            
        } catch (Exception $ex) {
            #echo "$ex";
            return false;
        }
    }
    
    # ALTERAÇÃO/ATUALIZAÇÃO
    public function update(Curso $curso) { 
        try {
            $sql = "UPDATE tbCurso SET nmCurso = :nmCurso, idArea = :idArea, idModal = :idModal "
                    . "WHERE idCurso = :idCurso";     
            $stm = $this->link->prepare($sql);   
        
            $stm->bindValue(":idCurso", $curso->getIdCurso());
            $stm->bindValue(":nmCurso", $curso->getNmCurso());
            $stm->bindValue(":idArea", $curso->getIdArea());
            $stm->bindValue(":idModal", $curso->getIdModal());
            
            $stm->execute();
            return true;
            
        } catch (Exception $ex) {
            #echo "$ex";
            return false;
        }
    }
    
    # EXCLUSÃO
    public function delete(Curso $curso) { 
        try {
            $sql = "DELETE FROM tbCurso WHERE idCurso = :idCurso";     
            $stm = $this->link->prepare($sql);   
        
            $stm->bindValue(":idCurso", $curso->getIdCurso());
            
            $stm->execute();
            return true;
            
        } catch (Exception $ex) {
            #echo "$ex";
            return false;
        }
    }
}
