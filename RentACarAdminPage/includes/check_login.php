<?php
function check_login()
{
    if (!isset($_SESSION["logged_in"]))
    {
        header("location: Login.php");
        exit;
    }
}