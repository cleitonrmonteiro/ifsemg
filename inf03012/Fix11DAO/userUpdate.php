<?php

/**********************************************
 * ARQUIVO INTERMEDIÁRIO P. TROCAR A SENHA
 **********************************************/

# Inclui os arquivos necessários para uso das classes "User" e "UserDAO"
include_once 'User.php';
include_once 'UserDAO.php';

# Recebe os dados de "frmUserUpdate.html" para alteração
$nmUser = filter_input(INPUT_POST, "nmUser");
$pw = filter_input(INPUT_POST, "pw");
$pwNew = filter_input(INPUT_POST, "pwNew");

# Instancia a classe "User"
$user = new User();

# "SETA" os atributos considerando os dados recebidos
$user->setNmUser($nmUser);
$user->setPw($pw);

# Instancia a classe "UserDAO"
$userDAO = new UserDAO();

# Aciona o método para alteração (passando um objeto de USER + nova senha) e gera o feedback
if ($userDAO->update($user, $pwNew)) {
    header("location:frmUserLogin.html");
} else {
    echo 'Falha na operação.';
}
