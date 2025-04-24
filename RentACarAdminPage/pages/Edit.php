<?php
require_once "../includes/fetch.php";
require_once "../config.php";
require_once "../includes/check_login.php";
session_start();
check_login();

$type = $_GET['type'] ?? 'cars';
$id = $_GET['id'] ?? null;
$isEdit = $id !== null;

// Initial data for editing
$data = [];
if ($isEdit) {
    $response = @file_get_contents("$api_url/$type/$id");
    $data = $response ? json_decode($response, true) : [];
}

// For cars: fetch related options
$models = $manufacturers = $fuelTypes = $categories = [];
if ($type === 'cars') {
    $models = fetchData('models');
    $fuelTypes = fetchData('fuel_types');
    $categories = fetchData('categories');
} elseif ($type === 'models') {
    $manufacturers = fetchData('manufacturers');
}

// Handle submit
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // --- 1. Prepare car data ---
    $payload = [];

    if ($type === 'cars') {
        $payload = [
            "modelId" => (int)$_POST['modelId'],
            "fuelTypeId" => (int)$_POST['fuelTypeId'],
            "categoryId" => (int)$_POST['categoryId'],
            "km" => (int)$_POST['km'],
            "pricePerKm" => (int)$_POST['pricePerKm'],
            "year" => (int)$_POST['year'],
            "horsePower" => (int)$_POST['horsePower'],
            "description" => $_POST['description']
        ];
    } elseif ($type === 'models') {
        $payload = [
            "manufacturerId" => (int)$_POST['manufacturerId'],
            "name" => $_POST['name']
        ];
    } elseif (in_array($type, ['manufacturers', 'categories', 'fuel_types'])) {
        $payload = ["name" => $_POST['name']];
    }

    // --- 2. Send PUT or POST to /cars or other type ---
    $json = json_encode($payload);
    $method = $isEdit ? "PUT" : "POST";
    $url = "$api_url/$type" . ($isEdit ? "/$id" : '');

    $opts = [
        "http" => [
            "method" => $method,
            "header" => [
                "Content-Type: application/json",
                "x-api-key: " . $api_key
            ],
            "content" => $json,
            "ignore_errors" => true
        ]
    ];

    $context = stream_context_create($opts);
    $response = file_get_contents($url, false, $context);

    // If we're adding a car, get the returned ID from the response
    if (!$isEdit && $type === 'cars') {
        $savedCar = json_decode($response, true);
        $id = $savedCar['id'] ?? null;
    }

    header("Location: List.php");
    exit;
}
?>

<!DOCTYPE html>
<html>
<head>
    <title><?= $isEdit ? "Edit" : "Add" ?> <?= ucfirst($type) ?></title>
    <link rel="stylesheet" href="../css/style.css">

    <style>
        input, select, textarea {
            width: 100%;
            padding: 8px;
            margin-top: 5px;
        }
    </style>
</head>
<body>
<h1><?= $isEdit ? "Edit" : "Add" ?> <?= ucfirst($type) ?></h1>

<form method="post">
    <?php if ($type === 'cars'): ?>
        <label>Model:</label>
        <select name="modelId" required>
            <?php foreach ($models as $model): ?>
                <option value="<?= $model['id'] ?>" <?= ($data['modelId'] ?? '') == $model['id'] ? 'selected' : '' ?>>
                    <?= htmlspecialchars($model['name']) ?>
                </option>
            <?php endforeach; ?>
        </select>

        <label>Fuel Type:</label>
        <select name="fuelTypeId" required>
            <?php foreach ($fuelTypes as $fuel): ?>
                <option value="<?= $fuel['id'] ?>" <?= ($data['fuelTypeId'] ?? '') == $fuel['id'] ? 'selected' : '' ?>>
                    <?= htmlspecialchars($fuel['name']) ?>
                </option>
            <?php endforeach; ?>
        </select>

        <label>Category:</label>
        <select name="categoryId" required>
            <?php foreach ($categories as $cat): ?>
                <option value="<?= $cat['id'] ?>" <?= ($data['categoryId'] ?? '') == $cat['id'] ? 'selected' : '' ?>>
                    <?= htmlspecialchars($cat['name']) ?>
                </option>
            <?php endforeach; ?>
        </select>

        <label>Kilometers (km):</label>
        <input type="number" name="km" value="<?= $data['km'] ?? '' ?>" required>

        <label>Price Per KM:</label>
        <input type="number" name="pricePerKm" value="<?= $data['pricePerKm'] ?? '' ?>" required>

        <label>Year:</label>
        <input type="number" name="year" value="<?= $data['year'] ?? '' ?>" required>

        <label>Horse Power:</label>
        <input type="number" name="horsePower" value="<?= $data['horsePower'] ?? '' ?>" required>

        <label>Description:</label>
        <textarea name="description" required><?= $data['description'] ?? '' ?></textarea>

    <?php elseif ($type === 'models'): ?>
        <label>Manufacturer:</label>
        <select name="manufacturerId" required>
            <?php foreach ($manufacturers as $m): ?>
                <option value="<?= $m['id'] ?>" <?= ($data['manufacturerId'] ?? '') == $m['id'] ? 'selected' : '' ?>>
                    <?= htmlspecialchars($m['name']) ?>
                </option>
            <?php endforeach; ?>
        </select>

        <label>Model Name:</label>
        <textarea name="name" required><?= $data['name'] ?? '' ?></textarea>

    <?php elseif (in_array($type, ['categories', 'fuel_types', 'manufacturers'])): ?>
        <label>Name:</label>
        <input type="text" name="name" value="<?= $data['name'] ?? '' ?>" required>
    <?php else: ?>
        <p>Unsupported type.</p>
    <?php endif; ?>

    <button type="submit"><?= $isEdit ? "Update" : "Add" ?></button>
</form>

<a class="back" href="List.php?type=<?= $type ?>">← Back to <?= ucfirst($type) ?> List</a>
</body>
</html>
