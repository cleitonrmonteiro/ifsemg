<?php

# Inclui o arquivo PHP onde está definida a CLASSE "Conta" que será herdada
include_once 'Conta.php';

class Corrente extends Conta {
   
    private $limite = 500;
        
    # Implementação do método ABSTRATO "efetuarPix" de "Conta"
    # Aqui, para efetivação do pix considera-se o SALDO + LIMITE
    public function efetuarPix(Conta $conta, $valor) {
        if ($this->saldo + $this->limite >= $valor) {
            $this->saldo -= $valor;
            $conta->receberPix($valor);
            return true;
        }
        return false;
    }    
}
