<?php

# Inclui os arquivos PHP onde estão definidas as CLASSES "Corrente" e "Poupanca"
include_once 'Corrente.php';
include_once 'Poupanca.php';

# Recebe os dados submetidos pelo FORMULÁRIO em "frmPix.html"
$numAg = filter_input(INPUT_GET, "numAg");
$numConta = filter_input(INPUT_GET, "numConta");
$tpConta = filter_input(INPUT_GET, "tpConta");
$chavePix = filter_input(INPUT_GET, "chavePix");
$valor = filter_input(INPUT_GET, "valor");

# Verifica o TIPO DE CONTA da ORIGEM do PIX e instancia a classe correspondente
if ($tpConta == "cc") {
    $contaOrigem = new Corrente();
} else {
    $contaOrigem = new Poupanca();
}

# Compara os dados recebidos com os dados da conta (agência e conta)
if (!$contaOrigem->validarAcesso($numAg, $numConta)) {
    echo 'Agência/Conta inválida.';
} else { # Se os dados estiverem CORRETOS ...
    
    # --- PIX ---     
    
    # Instancia a conta DESTINO (aqui, aplica-se Corrente ou Poupanca)
    $contaDestino = new Corrente();
    $contaDestino->setChavePix($chavePix);
    
    # Guarda o SALDO ATUAL das contas de origem e destino
    # Este saldo será usado posteriormente como saldo ANTERIOR
    $saldoAnteriorOrigem = $contaOrigem->getSaldo();
    $saldoAnteriorDestino = $contaDestino->getSaldo();
    
    # Aciona a operação PIX verificando se há valor suficiente em conta
    if ($contaOrigem->efetuarPix($contaDestino, $valor) == false) {
        echo 'Limite insuficiente.';

    # Se a movimentação puder ser efetivada ...    
    } else {
        echo '---------------------------------------------';
        echo '<br>OPERAÇÃO REALIZADA<br>';
        echo '---------------------------------------------';
        echo '<br>Ag.: '.$contaOrigem->getNumAg();
        echo ' - Conta: '.$contaOrigem->getNumConta().' - '.$tpConta;
        echo "<br>Saldo anterior: $saldoAnteriorOrigem";
        echo '<br>Saldo atual: '.$contaOrigem->getSaldo();
        echo '<br>---------------------------------------------<br>';
        echo 'PIX efetuado para a CHAVE: '.$contaDestino->getChavePix();
        echo "<br>Saldo anterior: $saldoAnteriorDestino";
        echo '<br>Saldo atual: '.$contaDestino->getSaldo();
        echo '<br>---------------------------------------------<br>';
        echo 'IFSEMG - SI - INF03012 - P1';
    }
}
