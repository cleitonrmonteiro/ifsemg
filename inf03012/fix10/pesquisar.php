<?php

# INCLUI O ARQUIVO ONDE ESTÁ DECLARADA A CLASSE "Curso"
include_once 'Curso.php';

# RECEBE O NOME DO CURSO PARA PESQUISA, EM "frmPesquisa.html"
$nmCurso = filter_input(INPUT_GET, "nmCurso");

# INSTANCIA A CLASSE "Curso" E ACIONA O MÉTODO PARA PESQUISA
$curso = new Curso();
$dados = $curso->pesquisarCursos($nmCurso);

# PERCORRE O ARRAY GERADO COM OS DADOS DA PESQUISA
foreach ($dados as $curso) {
    echo "$curso[1]<br>";
}
