<?php
session_start();

if (!isset($_SESSION["logged_in"]))
{
    header("location: pages/Login.php");
    exit;
}

header("location: pages/List.php");