<?php

include_once 'Curso.php';

$curso = new Curso();
$resultado = $curso->mostrarCursos();

if ($resultado) {
    foreach ($resultado as $curso) {
        echo $curso->nmCurso."<br>";
    }
} else {
    echo 'Nenhum retorno.';
}
