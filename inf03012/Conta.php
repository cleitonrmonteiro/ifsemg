<?php

# Classe ABSTRATA que define as propriedades básicas de uma conta bancária
abstract class Conta {
    
    protected $numAg = "012";
    protected $numConta = "3456789";
    protected $saldo = 500;
    
    public function getNumAg() {
        return $this->numAg;
    }

    public function getNumConta() {
        return $this->numConta;
    }

    public function getSaldo() {
        return $this->saldo;
    }

    # Recebe USUÁRIO e SENHA informados e retorna TRUE ou FALSE caso estejam corretos ou não.
    public function depositar($valor) {
        $this->saldo += $valor;
    }
    
    abstract public function sacar($valor);
}
