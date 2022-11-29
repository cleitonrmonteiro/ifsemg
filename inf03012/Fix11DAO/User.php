<?php

/************************************
 * CLASSE DE DOMÍNIO "User"
 ************************************/

class User {
    
    # Atributos referentes à tabela "tbUser" na base de dados
    private $idUser;
    private $nmUser;
    private $pw;
    
    # Getters e Setters ********************************************************
    public function getIdUser() {
        return $this->idUser;
    }

    public function getNmUser() {
        return $this->nmUser;
    }

    public function getPw() {
        return $this->pw;
    }

    public function setIdUser($idUser): void {
        $this->idUser = $idUser;
    }

    public function setNmUser($nmUser): void {
        $this->nmUser = $nmUser;
    }

    public function setPw($pw): void {
        $this->pw = $pw;
    }
    # **************************************************************************
}
