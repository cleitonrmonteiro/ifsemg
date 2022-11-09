<?php

interface IConnectInfo {
    
    const HOST      = "localhost";
    const PORT      = "3306";
    const DBNAME    = "bdensino";
    const USERNAME  = "root";
    const PASSWORD  = "root";
    
    public function doConnect();
}
