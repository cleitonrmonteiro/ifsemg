<?php

/**********************************************
 * ARQUIVO INTERMEDIÁRIO P. TRATAR A EXCLUSÃO
 **********************************************/

# Inclui os arquivos necessários para uso das classes "Curso" e "CursoDAO"
include_once 'Curso.php';
include_once 'CursoDAO.php';

# Recebe o "idCurso" de "cursoSelectAll" para exclusão
$idCurso = filter_input(INPUT_GET, "idCurso");

# Instancia a classe "Curso"
$curso = new Curso();

# "SETA" o atributo "idCurso" (neste caso, vindo do link em "cursoSelectAll.php"
$curso->setIdCurso($idCurso);

# Instancia a classe "CursoDAO"
$cursoDAO = new CursoDAO();

# Aciona o método para exclusão (passando um objeto de CURSO) e gera o feedback
if ($cursoDAO->delete($curso)) {
    echo 'Operação realizada com sucesso.';
} else {
    echo 'Falha na operação.';
}

echo "<br><a href='frmCursoInsert.html'>Incluir Curso";
echo "<br><a href='cursoSelectAll.php'>Listar Cursos";
