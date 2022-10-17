<?php

# Inclui o arquivo PHP onde está definida a CLASSE "Conta" que será herdada
include_once 'Conta.php';

class Corrente extends Conta {
   
    private $limite = 500;
    
    # Implementação do método ABSTRATO "sacar" de "Conta"
    # Aqui, para efetivação do saque é considerado o valor LIMITE
    public function sacar($valor) {
        if ($this->saldo + $this->limite >= $valor) {
            $this->saldo -= $valor;
            return true;
        }
        return false;
    }
}
