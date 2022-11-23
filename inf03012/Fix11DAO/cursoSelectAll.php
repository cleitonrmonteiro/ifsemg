<?php

/**********************************************
 * ARQUIVO INTERMEDIÁRIO P. TRATAR A SELEÇÃO
 **********************************************/

# Inclui os arquivos necessários para uso das classes "Curso" e "CursoDAO"
include_once 'Curso.php';
include_once 'CursoDAO.php';

# Instancia a classe "Curso"
$curso = new Curso();

# Instancia a classe "CursoDAO"
$cursoDAO = new CursoDAO();

# Aciona o método para seleção e gera o feedback (desenho da tabela de dados)
$result = $cursoDAO->selectAll();

if ($result) {
    
    echo "<table border=1";
    echo "<tr>";
    echo "<td>ID</td><td>Nome</td><td>Área</td><td>Modalidade</td><td colspan=2>Ação</td>";
    echo "</tr>";
    
    foreach ($result as $curso) {
        echo "<tr>";
        echo "<td>$curso->idCurso</td>";
        echo "<td>$curso->nmCurso</td>";
        echo "<td>$curso->nmArea</td>";
        echo "<td>$curso->nmModal</td>";
        
        echo "<td><a href='frmCursoUpdate.php?"
            . "idCurso=$curso->idCurso&"
            . "nmCurso=$curso->nmCurso&"
            . "idArea=$curso->idArea&"
            . "idModal=$curso->idModal'>Alterar</td>";
        
        echo "<td><a href='cursoDelete.php?idCurso=$curso->idCurso'>Excluir</td>";
        echo "</tr>";
    }
    echo "</table>";
} else {
    echo 'Nenhum registro retornado.';
}

echo "<a href='frmCursoInsert.html'>Incluir Curso";
