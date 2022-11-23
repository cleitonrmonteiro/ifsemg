<?php

/**********************************************
 * ARQUIVO INTERMEDIÁRIO P. TRATAR A ALTERAÇÃO
 **********************************************/

# Inclui os arquivos necessários para uso das classes "Curso" e "CursoDAO"
include_once 'Curso.php';
include_once 'CursoDAO.php';

# Recebe os dados de "frmCursoInsert.html" para alteração
$idCurso = filter_input(INPUT_GET, "idCurso");
$nmCurso = filter_input(INPUT_GET, "nmCurso");
$idArea = filter_input(INPUT_GET, "idArea");
$idModal = filter_input(INPUT_GET, "idModal");

# Instancia a classe "Curso"
$curso = new Curso();

# "SETA" os atributos considerando os dados recebidos
$curso->setIdCurso($idCurso);
$curso->setNmCurso($nmCurso);
$curso->setIdArea($idArea);
$curso->setIdModal($idModal);

# Instancia a classe "CursoDAO"
$cursoDAO = new CursoDAO();

# Aciona o método para alteração (passando um objeto de CURSO) e gera o feedback
if ($cursoDAO->update($curso)) {
    echo 'Operação realizada com sucesso.';
} else {
    echo 'Falha na operação.';
}

echo "<br><a href='frmCursoInsert.html'>Incluir Curso";
echo "<br><a href='cursoSelectAll.php'>Listar Cursos";
