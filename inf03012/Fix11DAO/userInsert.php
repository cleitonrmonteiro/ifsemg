<?php

/**********************************************
 * ARQUIVO INTERMEDIÁRIO P. NOVO USUÁRIO
 **********************************************/

# Inclui os arquivos necessários para uso das classes "User" e "UserDAO"
include_once 'User.php';
include_once 'UserDAO.php';

# Recebe os dados de "frmUserInsert.html" para inclusão
$idUser = filter_input(INPUT_POST, "idUser");
$nmUser = filter_input(INPUT_POST, "nmUser");
$pw = filter_input(INPUT_POST, "pw");

# Instancia a classe "User"
$user = new User();

# "SETA" os atributos considerando os dados recebidos
$user->setIdUser($idUser);
$user->setNmUser($nmUser);
$user->setPw($pw);

# Instancia a classe "UserDAO"
$userDAO = new UserDAO();

# Aciona o método para inclusão (passando um objeto de USER) e gera o feedback
if ($userDAO->insert($user)) {
    echo 'Operação realizada com sucesso.';
} else {
    echo 'Falha na operação.';
}

echo "<br><a href='frmUserLogin.html'>Login";
echo "<br><a href='frmUserInsert.html'>Novo usuário";
