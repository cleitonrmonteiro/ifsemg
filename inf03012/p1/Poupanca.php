<?php

# Inclui o arquivo PHP onde está definida a CLASSE "Conta" que será herdada
include_once 'Conta.php';

class Poupanca extends Conta {
   
    # Implementação do método ABSTRATO "efetuarPix" de "Conta"
    # Aqui, para efetivação do pix considera-se APENAS o SALDO
    public function efetuarPix(Conta $conta, $valor) {
        if ($this->saldo >= $valor) {
            $this->saldo -= $valor;
            $conta->receberPix($valor);
            return true;
        }
        return false;
    }
}
