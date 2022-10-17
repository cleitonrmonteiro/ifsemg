<?php

# Inclui os arquivos PHP onde estão definidas as CLASSES "Corrente" e "Poupanca"
include_once 'Corrente.php';
include_once 'Poupanca.php';

# Recebe os dados submetidos pelo FORMULÁRIO em "frmCaixa.html"
$numAg = filter_input(INPUT_GET, "numAg");
$numConta = filter_input(INPUT_GET, "numConta");
$tpConta = filter_input(INPUT_GET, "tpConta");
$op = filter_input(INPUT_GET, "op");
$valor = filter_input(INPUT_GET, "valor");

# Verifica o TIPO DE CONTA e instancia a classe correspondente
if ($tpConta == "cc") {
    $conta = new Corrente();
} else {
    $conta = new Poupanca();
}

# Compara os dados recebidos com os dados da conta - "numAg" e "numConta"
if ($numAg != $conta->getNumAg() || $numConta != $conta->getNumConta()) {
    echo 'Agência/Conta inválida.';
} else {
    # Guarda o SALDO ANTERIOR p. exibição ao final da movimentação
    $saldoAnterior = $conta->getSaldo();
    
    # Para DEPÓSITO ...
    if ($op == "dep") {
        $conta->depositar($valor);
        echo '--- Operação realizada ---';
        echo "<br>Saldo anterior: $saldoAnterior";
        echo '<br>Novo saldo: '.$conta->getSaldo();
    
    # Para SAQUE ...    
    } else {
        # Se não haja valor suficiente ...
        if ($conta->sacar($valor) == false) {
            echo 'Limite insuficiente.';
        
        # Se a movimentação puder ser efetivada ...    
        } else {
            echo '--- Operação realizada ---';
            echo "<br>Saldo anterior: $saldoAnterior";
            echo '<br>Novo saldo: '.$conta->getSaldo();
        }
    }
}
