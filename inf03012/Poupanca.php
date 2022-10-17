<?php

# Inclui o arquivo PHP onde está definida a CLASSE "Conta" que será herdada
include_once 'Conta.php';

class Poupanca extends Conta {
    
    public function sacar($valor) {
        if ($this->saldo >= $valor) {
            $this->saldo -= $valor;
            return true;
        }
        return false;    
    }
}
