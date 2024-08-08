

<?php

$dbhost = "localhost";
$dbuser = "root";
$dbpassword = "";
$dbname = "alarm_systeme";
$port = 3306;
$connexion = mysqli_connect($dbhost, $dbuser, $dbpassword, $dbname, $port);
if (!$connexion) {
    die("Echec de la connexion à la base de données : " . mysqli_connect_error());
}
else {
    echo "Connexion à la base de données réussie";
}
$z1= htmlspecialchars($_GET["Zone1"]);
$z2 = htmlspecialchars($_GET["Zone2"]);
$z3 = htmlspecialchars($_GET["Zone3"]);
$z4 = htmlspecialchars($_GET["Zone4"]);
$status=htmlspecialchars($_GET["Status"]);

// Requête SQL de mise à jour pour mettre à jour les valeurs dans la table etat_zones
$sql = "UPDATE etat_zones SET Z1='$z1', Z2='$z2', Z3='$z3', Z4='$z4',Status='$status'";

// Exécution de la requête de mise à jour
$resultat = mysqli_query($connexion, $sql);

if ($resultat) {
    echo "Mise à jour réussie des données dans la table etat_zones.";
} else {
    // Gérer les erreurs si la requête échoue
    echo "Erreur de requête : " . mysqli_error($connexion);
}

// Fermer la connexion à la base de données
mysqli_close($connexion);

?>


