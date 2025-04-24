<?php
require "../config.php";

// Helper to get API data
function fetchData($endpoint)
{
    global $api_url;

    $url = $api_url . "/$endpoint"; // replace with your API base URL
    $response = @file_get_contents($url);
    return $response ? json_decode($response, true) : [];
}
