<?php

/************************************
 * CLASSE DE DOMÍNIO "Curso"
 ************************************/

class Curso {
    
    # Atributos referentes à tabela "tbCurso" na base de dados
    private $idCurso;
    private $nmCurso;
    private $idArea;
    private $idModal;
    
    # Getters e Setters ********************************************************
    public function getIdCurso() {
        return $this->idCurso;
    }

    public function getNmCurso() {
        return $this->nmCurso;
    }

    public function getIdArea() {
        return $this->idArea;
    }

    public function getIdModal() {
        return $this->idModal;
    }

    public function setIdCurso($idCurso): void {
        $this->idCurso = $idCurso;
    }

    public function setNmCurso($nmCurso): void {
        $this->nmCurso = $nmCurso;
    }

    public function setIdArea($idArea): void {
        $this->idArea = $idArea;
    }

    public function setIdModal($idModal): void {
        $this->idModal = $idModal;
    }
    # **************************************************************************
}
