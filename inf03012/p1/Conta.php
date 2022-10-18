<?php

# Classe ABSTRATA que define as propriedades básicas de uma conta bancária
abstract class Conta {
    
    protected $numAg = "012"; 
    protected $numConta = "3456789";
    protected $saldo = 500;
    protected $chavePix;
    
    public function getNumAg() {
        return $this->numAg;
    }

    public function getNumConta() {
        return $this->numConta;
    }

    public function getSaldo() {
        return $this->saldo;
    }

    public function getChavePix() {
        return $this->chavePix;
    }

    public function setChavePix($chavePix): void {
        $this->chavePix = $chavePix;
    } 
    
    # VALIDA os dados (agência e conta) para ACESSO ao pix
    public function validarAcesso($numAg, $numConta) {
        return $numAg === $this->numAg && $numConta === $this->numConta ? true : false;
    }
    
    # INCREMENTA o saldo conforme o valor do pix recebido
    public function receberPix($valor) {
        $this->saldo += $valor;
    } 
    
    # Método abstrato para a TRANSFERÊNCIA (pix) dos valores
    abstract public function efetuarPix(Conta $conta, $valor);
}
