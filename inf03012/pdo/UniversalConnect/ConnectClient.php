<?php

include_once 'UniversalConnect.php';

class ConnectClient {
    
    private $link;
    
    public function __construct() {
        $this->link = UniversalConnect::doConnect();
    }   
}

$worker = new ConnectClient();
