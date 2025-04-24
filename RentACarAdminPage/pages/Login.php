<?php
require_once "../config.php";
session_start();

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    if ($_POST["username"] == $username && $_POST["password"] == $password)
    {
        $_SESSION["logged_in"] = true;
        header("location: ../Index.php");
        exit;
    }
    $error = "Bejelentkezés sikertelen";
}

?>


<!doctype html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login</title>

    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .centered {
            text-align: center;
            padding: 10px;
        }

        * {
            margin: 5px;
        }
    </style>
</head>
<body>
<div class="centered">
    <h1>Rent A Car Adminisztrációs felület</h1>
    <form action="#" method="post">
        <label for="username">Felhasználónév</label><br>
        <input type="text" name="username" required><br>
        <label for="password">Jelszó</label><br>
        <input type="password" name="password" required><br>
        <input type="submit" name="submit" value="Bejelentkezés"><br>
    </form>
    <?php
    if (isset($error))
    {
        echo $error;
    }
    ?>
</div>
</body>
</html>