<!DOCTYPE html>

<?php
# Trecho PHP para "pegar" os dados enviados com "GET" para uso no form. HTML
$idCurso = filter_input(INPUT_GET, "idCurso");
$nmCurso = filter_input(INPUT_GET, "nmCurso");
$idArea = filter_input(INPUT_GET, "idArea");
$idModal = filter_input(INPUT_GET, "idModal");
?>

<html>
    <head>
        <title>TODO supply a title</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
    </head>
    <body>
        <div>
            <h2>Curso: update</h2>
            <form method="get" action="cursoUpdate.php">
                ID do Curso = <?php echo $idCurso;?><br><br>
                <input type="hidden" name="idCurso" value="<?php echo $idCurso;?>">
                Nome do curso<br>
                <input type="text" name="nmCurso" value="<?php echo $nmCurso;?>"><br>
                ID da Área<br>
                <input type="text" name="idArea" value="<?php echo $idArea;?>"><br>
                ID da Modalidade<br>
                <input type="text" name="idModal" value="<?php echo $idModal;?>"><br>
                <input type="submit" value="Submeter">
            </form>
            <a href='cursoSelectAll.php'>Listar Cursos
        </div>
    </body>
</html>
