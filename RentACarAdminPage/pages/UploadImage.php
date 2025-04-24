<?php
require_once "../config.php";
require_once "../includes/check_login.php";
session_start();
check_login();

$file = $_FILES["file"];
$carId = $_GET["carId"];

$url = "$api_url/images";

// Read file contents
$fileContents = file_get_contents($file["tmp_name"]);
$filename = basename($file["name"]);
$mimeType = mime_content_type($file["tmp_name"]);

// Generate a boundary string
$boundary = uniqid();

// Build the multipart body
$body = "";
$eol = "\r\n";

// Add carId field
$body .= "--$boundary$eol";
$body .= 'Content-Disposition: form-data; name="carId"' . $eol . $eol;
$body .= $carId . $eol;

// Add file field
$body .= "--$boundary$eol";
$body .= 'Content-Disposition: form-data; name="image"; filename="' . $filename . "\"$eol";
$body .= "Content-Type: $mimeType$eol$eol";
$body .= $fileContents . $eol;

// End boundary
$body .= "--$boundary--$eol";
$options = [
    "http" => [
        "method" => "POST",
        "header" => [
            "x-api-key: " . $api_key,
            "Content-Type: multipart/form-data; boundary=$boundary",
            "Content-Length: " . strlen($body),
        ],
        "content" => $body,
    ],
];

$context = stream_context_create($options);
$result = file_get_contents($url, false, $context);


header("Location: EditImages.php?id=$carId");
exit;