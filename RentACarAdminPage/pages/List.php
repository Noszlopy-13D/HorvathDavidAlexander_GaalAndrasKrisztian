<?php
require_once "../includes/fetch.php";
require_once "../includes/check_login.php";
session_start();
check_login();


// Allowed types and their endpoints
$allowedTypes = [
    'cars' => 'cars',
    'categories' => 'categories',
    'models' => 'models',
    'manufacturers' => 'manufacturers',
    'fuel_types' => 'fuel_types'
];

$type = $_GET['type'] ?? 'cars';
$endpoint = $allowedTypes[$type] ?? 'cars';


// Main data
$data = fetchData($endpoint);

// For car-related lookups
$models = $fuelTypes = $categories = $manufacturers = [];
if ($type === 'cars') {
    $modelsRaw = fetchData('models');
    $fuelTypesRaw = fetchData('fuel_types');
    $categoriesRaw = fetchData('categories');
    $manufacturersRaw = fetchData('manufacturers');

    // Build model name: "Brand Model"
    foreach ($modelsRaw as $model) {
        $brand = '';
        foreach ($manufacturersRaw as $manu) {
            if ($manu['id'] == $model['manufacturerId']) {
                $brand = $manu['name'];
                break;
            }
        }
        $models[$model['id']] = "$brand " . $model['name'];
    }

    foreach ($fuelTypesRaw as $fuel) {
        $fuelTypes[$fuel['id']] = $fuel['name'];
    }

    foreach ($categoriesRaw as $cat) {
        $categories[$cat['id']] = $cat['name'];
    }
}
?>

<!DOCTYPE html>
<html lang="hu">
<head>
    <title>Admin - <?= ucfirst($type) ?> List</title>
    <link rel="stylesheet" href="../css/style.css">
</head>
<body>
<h1><?= ucfirst($type) ?> List</h1>

<div class="header">
    <div>
        <form method="get" action="" class="to_left">
            <label for="type">Select type:</label>
            <select name="type" id="type" onchange="this.form.submit()">
                <?php foreach ($allowedTypes as $key => $value): ?>
                    <option value="<?= $key ?>" <?= $key === $type ? 'selected' : '' ?>><?= ucfirst($key) ?></option>
                <?php endforeach; ?>
            </select>
        </form>
        <a class="button" href="Edit.php?type=<?= $type ?>">+ Add New <?= ucfirst($type) ?></a>
    </div>
    <a class="button delete" href="Logout.php" style="text-align: right">Logout</a>
</div>

<?php if (is_array($data) && count($data) > 0): ?>
    <table>
        <thead>
        <tr>
            <?php foreach (array_keys($data[0]) as $column): ?>
                <th><?= htmlspecialchars(ucfirst($column)) ?></th>
            <?php endforeach; ?>
            <?php if ($type === 'cars'): ?>
                <th>Actions</th>
            <?php endif; ?>
        </tr>
        </thead>
        <tbody>
        <?php foreach ($data as $item): ?>
            <tr>
                <?php foreach ($item as $key => $value): ?>
                    <td>
                        <?php
                        // Show readable names for cars
                        if ($type === 'cars') {
                            switch ($key) {
                                case 'modelId': echo htmlspecialchars($models[$value] ?? $value); break;
                                case 'fuelTypeId': echo htmlspecialchars($fuelTypes[$value] ?? $value); break;
                                case 'categoryId': echo htmlspecialchars($categories[$value] ?? $value); break;
                                default: echo htmlspecialchars($value); break;
                            }
                        } else {
                            echo htmlspecialchars($value);
                        }
                        ?>
                    </td>
                <?php endforeach; ?>
                <td style="width: 15%">
                    <a class="button" href="Edit.php?type=<?= $type ?>&id=<?= $item['id'] ?>">Edit</a>
                    <?php if ($type === 'cars'): ?>
                    <a class="button" href="EditImages.php?id=<?= $item['id'] ?>">Edit Images</a>
                    <?php endif; ?>
                    <form action="delete.php" method="post" onsubmit="return confirm('Delete this entry?');">
                        <input type="hidden" name="type" value="<?= $type ?>">
                        <input type="hidden" name="id" value="<?= $item['id'] ?>">
                        <input type="submit" value="Delete" class="button delete" >
                    </form>
                </td>
            </tr>
        <?php endforeach; ?>
        </tbody>
    </table>
<?php else: ?>
    <p>No data found or API error.</p>
<?php endif; ?>
</body>
</html>
