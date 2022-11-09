<?php

include_once 'UniversalConnect.php';

class Curso {
    
    private $link;
    
    public function __construct() {
        $this->link = UniversalConnect::doConnect();
    }
    
    public function mostrarCursos() {
        $sql = "SELECT * FROM tbCurso";    
        $stm = $this->link->prepare($sql);   
        $stm->execute();
        
        if ($stm->rowCount() > 0) {
            return $stm->fetchAll(PDO::FETCH_OBJ);
        } else {
            return false;
        }
        
        #return $stm->fetchAll();
        #return $stm->fetch(PDO::FETCH_OBJ);
    }
}
