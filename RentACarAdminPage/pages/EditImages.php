<?php
require_once "../includes/fetch.php";
require_once "../includes/check_login.php";
session_start();
check_login();

$carId = $_GET['id'] ?? null;

$all_images = fetchData("images/");
$images = [];

foreach ($all_images as $image)
{
    if ($carId == (int)$image['carId'])
    {
        array_push($images, $image);
    }
}
?>

<!doctype html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Edit Images</title>
    <link rel="stylesheet" href="../css/style.css">
</head>
<body>

    <a href="List.php?type=cars">← Back to cars list</a>

    <form action="UploadImage.php?carId=<?= $carId ?>" method="post" enctype="multipart/form-data">
        <input type="submit" name="upload" value="Upload Image" class="button submit">
        <input type="file" name="file">
    </form>

    <table>
        <th>Image</th>
        <th>Upload Date</th>
        <th>Actions</th>

    <?php foreach ($images as $image): ?>
    <tr>
        <td>
            <image src="<?php echo $image_url . "/" . $image['imagePath'] ?>" style="width: 20vw; height: 15vw"></image>
        </td>
        <td>
            <?php echo $image['uploadDate'] ?>
        </td>
        <td>
            <form action="DeleteImage.php?carId=<?= $carId ?>" method="post" onsubmit="return confirm('Delete this entry?')">
                <input type="hidden" name="id" value="<?= $image["id"] ?>">
                <input type="submit" value="Delete" class="button delete">
            </form>
        </td>
    </tr>
    <?php endforeach; ?>
    </table>
</body>
</html>