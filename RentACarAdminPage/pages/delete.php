<?php
require_once "../config.php";
require_once "../includes/check_login.php";
session_start();
check_login();

$type = $_POST['type'] ?? '';
$id = $_POST['id'] ?? '';

if (!$type || !$id) {
    die("Invalid request");
}

$url = "$api_url/$type/$id";

$options = [
    'http' => [
        'method' => 'DELETE',
        'header' => [
            'x-api-key: ' . $api_key
        ],
        'ignore_errors' => true
    ]
];

$context = stream_context_create($options);
$response = file_get_contents($url, false, $context);

header("Location: List.php?type=$type");
exit;
