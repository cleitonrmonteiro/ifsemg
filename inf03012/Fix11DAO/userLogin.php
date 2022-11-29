<?php

/**********************************************
 * ARQUIVO INTERMEDIÁRIO P. TRATAR O LOGIN
 **********************************************/

# Inclui os arquivos necessários para uso das classes "User" e "UserDAO"
include_once 'User.php';
include_once 'UserDAO.php';

# Recebe os dados de "frmUserLogin.html" para validação
$nmUser = filter_input(INPUT_POST, "nmUser");
$pw = filter_input(INPUT_POST, "pw");

# Instancia a classe "User"
$user = new User();

# "SETA" os atributos considerando os dados recebidos
$user->setNmUser($nmUser);
$user->setPw($pw);

# Instancia a classe "UserDAO"
$userDAO = new UserDAO();

# Aciona o método para validação (passando um objeto de USER) e gera o feedback
if ($userDAO->login($user)) {
    header("location:cursoSelectAll.php");
} else {
    echo 'Dado(s) inválido(s).';
}
