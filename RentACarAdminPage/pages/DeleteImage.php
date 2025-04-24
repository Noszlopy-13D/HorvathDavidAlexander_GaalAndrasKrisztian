<?php
require_once "../config.php";
require_once "../includes/check_login.php";
session_start();
check_login();

global $api_url, $api_key;

$id = $_POST["id"];
$carId = $_GET["carId"];

if (!$id)
{
    die("Invalid request");
}

$url = "$api_url/images/$id";

$options = [
    "http" => [
        "method" => "DELETE",
        "header" => [
            "x-api-key: " . $api_key,
        ],
        "ignore_errors" => true,
    ],
];

$context = stream_context_create($options);
$result = file_get_contents($url, false, $context);

header("Location: EditImages.php?id=$carId");
exit;