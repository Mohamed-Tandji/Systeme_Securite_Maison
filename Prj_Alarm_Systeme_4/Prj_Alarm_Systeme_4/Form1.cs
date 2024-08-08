//ajout de la librairie mysql
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Bzip2;

namespace Prj_Alarm_Systeme_4
{
    public partial class Form1 : Form
    {
        private string z1 = "off";
        private string z2 = "off";
        private string z3 = "off";
        private string z4 = "off";
        private string status = "deactivate";
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection connexion = new MySqlConnection("database=alarm_systeme; server=localhost; user id=root; pwd=");
            try
            {
                connexion.Open();
                // Requête SQL à exécuter
                string query = "SELECT Z1, Z2, Z3, Z4, Status FROM etat_zones";

                // Créer une commande MySQL
                MySqlCommand command = new MySqlCommand(query, connexion);

                // Exécuter la commande et obtenir un lecteur de données
                MySqlDataReader reader = command.ExecuteReader();

                // Parcourir les lignes de résultats
                while (reader.Read())
                {
                    // Accéder aux colonnes par leur nom ou leur index
                    z1 = reader["Z1"].ToString();
                    z2 = reader["Z2"].ToString();
                    z3 = reader["Z3"].ToString();
                    z4 = reader["Z4"].ToString();
                    status = reader["Status"].ToString();


                }
                if (status == "Activate" || status == "activate")
                {
                    if (z1 == "Off" || z1 == "off")
                    {
                        BtnZone1.BackColor = Color.Green;
                    }
                    else
                    {
                        BtnZone1.BackColor = Color.Red;

                    }

                    if (z2 == "Off" || z2 == "off")
                    {
                        BtnZone2.BackColor = Color.Green;
                    }
                    else
                    {
                        BtnZone2.BackColor = Color.Red;

                    }
                    if (z3 == "Off" || z3 == "off")
                    {
                        BtnZone3.BackColor = Color.Green;
                    }
                    else
                    {
                        BtnZone3.BackColor = Color.Red;

                    }
                    if (z4 == "Off" || z4 == "off")
                    {
                        BtnZone4.BackColor = Color.Green;
                    }
                    else
                    {
                        BtnZone4.BackColor = Color.Red;

                    }

                    lblStatus.Text = "Status :" + status;

                }
                else if (status == "Deactivate" || status == "deactivate")
                {

                    lblStatus.Text = "Status :" + status;

                }


                // Fermer le lecteur de données
                reader.Close();
                //MessageBox.Show("Connexion Reussie !!!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Connexion echouer !!! " + ex);

            }
            finally
            {
                connexion.Close();
            }
        }

        private void BtnActivate_Click(object sender, EventArgs e)
        {
            if (status == "Deactivate" || status == "deactivate")
            {
                status = "Activate";
                UpdateStatusInDatabase(status);
                RefreshUI();

            }
        }

        private void BtnDeactivate_Click(object sender, EventArgs e)
        {
            if (status == "Activate" || status == "activate")
            {
                status = "Deactivate";
                UpdateStatusInDatabase(status);
                RefreshUI();


            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            status = "Deactivate";
            z1 = "Off";
            z2 = "Off";
            z3 = "Off";
            z4 = "Off";
            UpdateZonesInDatabase(z1, z2, z3, z4);
            UpdateStatusInDatabase(status);
            RefreshUI();


        }

        private void BtnZone1_Click(object sender, EventArgs e)
        {
            if (status == "Activate" || status == "activate")
            {
                if (z1 == "Off" || z1 == "off")
                {
                    
                    BtnZone1.BackColor = Color.Red;
                }
                else
                {
                    BtnZone1.BackColor = Color.Green;

                }
                UpdateZonesInDatabase(z1, z2, z3, z4);
                RefreshUI();
            }
        }

        private void BtnZone2_Click(object sender, EventArgs e)
        {
            if (status == "Activate" || status == "activate")
            {
                if (z2 == "Off" || z2 == "off")
                {
                    BtnZone2.BackColor = Color.Red;
                }
                else
                {
                    BtnZone2.BackColor = Color.Green;

                }
                UpdateZonesInDatabase(z1, z2, z3, z4);
                RefreshUI();
            }
        }

        private void BtnZone3_Click(object sender, EventArgs e)
        {
            if (status == "Activate" || status == "activate")
            {
                if (z3 == "Off" || z3 == "off")
                {
                    BtnZone3.BackColor = Color.Red;
                }
                else
                {
                    BtnZone3.BackColor = Color.Green;

                }
                UpdateZonesInDatabase(z1, z2, z3, z4);
                RefreshUI();
            }
        }

        private void BtnZone4_Click(object sender, EventArgs e)
        {
            if (status == "Activate" || status == "activate")
            {
                if (z4 == "Off" || z4 == "off")
                {
                    
                    BtnZone4.BackColor = Color.Red;
                }
                else
                {
                    
                    BtnZone4.BackColor = Color.Green;

                }
                UpdateZonesInDatabase(z1, z2, z3, z4);
                RefreshUI();
            }
        }

        private void RefreshUI()
        {

            if (status == "Activate" || status == "activate")
            {
                BtnZone1.BackColor = (z1 == "On") ? Color.Red : Color.Green;
                BtnZone2.BackColor = (z2 == "On") ? Color.Red : Color.Green;
                BtnZone3.BackColor = (z3 == "On") ? Color.Red : Color.Green;
                BtnZone4.BackColor = (z4 == "On") ? Color.Red : Color.Green;
            }
            else
            {
                BtnZone1.BackColor = Color.White;
                BtnZone2.BackColor = Color.White;
                BtnZone3.BackColor = Color.White;
                BtnZone4.BackColor = Color.White;
            }
            

            // Mettez à jour le texte de lblStatus
            lblStatus.Text = "Status: " + status;
        }
        private void UpdateStatusInDatabase(string newStatus)
        {
            // Connexion à la base de données
            MySqlConnection connexion = new MySqlConnection("database=alarm_systeme; server=localhost; user id=root; pwd=");

            try
            {
                connexion.Open();

                // Requête SQL pour mettre à jour le statut
                string query = $"UPDATE etat_zones SET Status = '{newStatus}'";

                // Créer une commande MySQL
                MySqlCommand command = new MySqlCommand(query, connexion);

                // Exécuter la commande
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du statut dans la base de données : " + ex.Message);
            }
            finally
            {
                // Fermer la connexion
                connexion.Close();
            }
        }

        private void UpdateZonesInDatabase(string z1, string z2, string z3, string z4)
        {
            // Connexion à la base de données
            MySqlConnection connexion = new MySqlConnection("database=alarm_systeme; server=localhost; user id=root; pwd=");

            try
            {
                connexion.Open();

                // Requête SQL pour mettre à jour le statut
                string query = $"UPDATE etat_zones SET Z1 = '{z1}' ,Z2 = '{z2}', Z3 = '{z3}', Z4 = '{z4}'";

                // Créer une commande MySQL
                MySqlCommand command = new MySqlCommand(query, connexion);

                // Exécuter la commande
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour du statut des zones dans la base de données : " + ex.Message);
            }
            finally
            {
                // Fermer la connexion
                connexion.Close();
            }
        }
    }
}