using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BasketballTradingCards
{
    public partial class Form1 : Form
    {
        private BindingList<Player> players;

        public Form1()
        {
            InitializeComponent();
            InitializePlayers();
        }

        public void BindPlayer(Player player)
        {
            lblName.DataBindings.Add("Text", player, "Name");
            lblTeam.DataBindings.Add("Text", player, "Team");
            lblPosition.DataBindings.Add("Text", player, "Position");
            lblMatchesPlayed.DataBindings.Add("Text", player, "MatchesPlayed");
            lblPoints.DataBindings.Add("Text", player, "Points");
            lblAssists.DataBindings.Add("Text", player, "Assists");

            // Dynamic visual updates
            lblPoints.ForeColor = player.Points > 900 ? Color.Green : Color.Red;
            lblAssists.ForeColor = player.Assists > 30 ? Color.Green : Color.Red;

            // Update the picture dynamically
            if (!string.IsNullOrEmpty(player.PhotoPath) && File.Exists(player.PhotoPath))
            {
                picPlayerPhoto.Image = Image.FromFile(player.PhotoPath);
            }

            //    // Background color based on team
            //    this.BackColor = player.Team switch
            //    {
            //        "Inter Miami" => Color.Pink,
            //        "Al-Nassr" => Color.Yellow,
            //        "Manchester City" => Color.LightBlue,
            //        _ => SystemColors.Control
            //    };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the list display using LINQ to sort players by name
            if (players != null && players.Count > 0)
            {
                lstPlayers.DataSource = players.OrderBy(p => p.Name).ToList(); // Sorting players by name
                lstPlayers.DisplayMember = "Name"; // Display player names
            }
            else
            {
                MessageBox.Show("No players loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Ensure visibility settings
            lstPlayers.Visible = true;
            btnAddPlayer.Visible = true;
            pnlPlayerDetails.Visible = false;
            btnBack.Visible = false;
            btnRemovePlayer.Visible = false;
        }

        private void InitializePlayers()
        {
            players = new BindingList<Player>
            {
                new Player { Name = "Russell Bill", Team = "LA Lakers", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\bill.jpeg", Position = "Point Guard", MatchesPlayed = 85, Points = 1200, Assists = 400, Rebounds = 250, Nationality = "American", Age = 30 },
new Player { Name = "Delonte West", Team = "Dallas Mavericks", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\delontewest.jpeg", Position = "Shooting Guard", MatchesPlayed = 90, Points = 1500, Assists = 350, Rebounds = 200, Nationality = "American", Age = 31 },
new Player { Name = "Giannis Antetokounmpo", Team = "Dallas Mavericks", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\giannis.jpeg", Position = "Power Forward", MatchesPlayed = 120, Points = 2400, Assists = 600, Rebounds = 1200, Nationality = "Greek", Age = 29 },
new Player { Name = "Ja Morant", Team = "Memphis Grizzlies", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\ja.jpeg", Position = "Point Guard", MatchesPlayed = 110, Points = 2200, Assists = 800, Rebounds = 500, Nationality = "American", Age = 24 },
new Player { Name = "Kobe Bryant", Team = "LA Lakers", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\kobe.jpeg", Position = "Shooting Guard", MatchesPlayed = 1340, Points = 33643, Assists = 6306, Rebounds = 7047, Nationality = "American", Age = 41 },
new Player { Name = "LeBron James", Team = "LA Lakers", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\lebron.jpeg", Position = "Small Forward", MatchesPlayed = 1410, Points = 38732, Assists = 10254, Rebounds = 10567, Nationality = "American", Age = 39 },
new Player { Name = "Michael Jordan", Team = "Dallas Mavericks", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\michaeljordan.jpeg", Position = "Shooting Guard", MatchesPlayed = 1072, Points = 32292, Assists = 5633, Rebounds = 6672, Nationality = "American", Age = 60 },
new Player { Name = "Shaquille O'Neal", Team = "LA Lakers", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\shaq.jpeg", Position = "Center", MatchesPlayed = 1207, Points = 28596, Assists = 3026, Rebounds = 13099, Nationality = "American", Age = 51 },
new Player { Name = "Stephen Curry", Team = "Memphis Grizzlies", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\steph.jpeg", Position = "Point Guard", MatchesPlayed = 882, Points = 21402, Assists = 5702, Rebounds = 4407, Nationality = "American", Age = 35 },
new Player { Name = "Zach LaVine", Team = "Memphis Grizzlies", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\zach.jpeg", Position = "Shooting Guard", MatchesPlayed = 510, Points = 10500, Assists = 2000, Rebounds = 2000, Nationality = "American", Age = 28 },
new Player { Name = "Aaron Gordon", Team = "Memphis Grizzlies", PhotoPath = @"B:\S# rapid application\BasketballTradingCards\images\aaron.jpeg", Position = "Power Forward", MatchesPlayed = 600, Points = 12000, Assists = 3000, Rebounds = 4000, Nationality = "American", Age = 28 },

            };
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItem is Player selectedPlayer)
            {
                DisplayPlayerDetails(selectedPlayer);
            }
        }

        private void DisplayPlayerDetails(Player selectedPlayer)
        {
            // Update labels with player details
            lblName.Text = selectedPlayer.Name;
            lblTeam.Text = $"Team: {selectedPlayer.Team}";
            lblPosition.Text = $"Position: {selectedPlayer.Position}";
            lblMatchesPlayed.Text = $"Matches Played: {selectedPlayer.MatchesPlayed}";
            lblPoints.Text = $"Points: {selectedPlayer.Points}";
            lblAssists.Text = $"Assists: {selectedPlayer.Assists}";
            lblNationality.Text = $"Nationality: {selectedPlayer.Nationality}";
            lblAge.Text = $"Age: {selectedPlayer.Age}";

            // Apply dynamic colors for Points and Assists
            lblPoints.ForeColor = selectedPlayer.Points > 1000 ? Color.DarkGreen : Color.DarkRed;
            lblAssists.ForeColor = selectedPlayer.Assists > 50 ? Color.Teal : Color.OrangeRed;

            // Check if the photo path is valid
            if (!string.IsNullOrEmpty(selectedPlayer.PhotoPath) && File.Exists(selectedPlayer.PhotoPath))
            {
                picPlayerPhoto.Image = Image.FromFile(selectedPlayer.PhotoPath);
            }
            else
            {
                picPlayerPhoto.Image = Image.FromFile(@"B:\S# rapid application\BasketballTradingCards\images\default.jpeg");
            }

            // Set team-specific card theme
            Color cardBackground;
            Color textColor;
            Color borderColor;

            switch (selectedPlayer.Team)
            {
                case "Memphis Grizzlies":
                    cardBackground = Color.FromArgb(52, 152, 219); // Light Blue
                    textColor = Color.White;
                    borderColor = Color.FromArgb(41, 128, 185); // Darker Blue
                    break;
                case "LA Lakers":
                    cardBackground = Color.FromArgb(241, 196, 15); // Yellow
                    textColor = Color.DarkSlateGray;
                    borderColor = Color.FromArgb(243, 156, 18); // Golden
                    break;
                case "Dallas Mavericks":
                    cardBackground = Color.FromArgb(155, 89, 182); // Purple
                    textColor = Color.White;
                    borderColor = Color.FromArgb(142, 68, 173); // Darker Purple
                    break;
                default:
                    cardBackground = Color.LightGray;
                    textColor = Color.Black;
                    borderColor = Color.DarkGray;
                    break;
            }

            // Apply styles to the card
            pnlPlayerDetails.BackColor = cardBackground;
            pnlPlayerDetails.ForeColor = textColor;
            pnlPlayerDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayerDetails.Padding = new Padding(10);

            // Update Player Details Panel styles
            lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTeam.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblPosition.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblMatchesPlayed.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblPoints.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblAssists.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblNationality.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblAge.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            pnlPlayerDetails.Visible = true;
            btnBack.Visible = true;
            lstPlayers.Visible = false;
            btnAddPlayer.Visible = false;
            btnRemovePlayer.Visible = true;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlPlayerDetails.Visible = false;
            btnBack.Visible = false;
            lstPlayers.Visible = true;
            btnAddPlayer.Visible = true;
            btnRemovePlayer.Visible = false;
        }

        private void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            if (lstPlayers.SelectedItem is Player selectedPlayer)
            {
                var result = MessageBox.Show($"Are you sure you want to remove {selectedPlayer.Name}?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Remove player from the list
                    players.Remove(selectedPlayer);

                    // Clear the player card or any other detailed display
                    ClearPlayerDetails();

                    // Rebind the ListBox to show the updated list of players
                    lstPlayers.DataSource = null;  // Clear the existing data source
                    lstPlayers.DataSource = players.OrderBy(p => p.Name).ToList();  // Rebind with the updated list
                    lstPlayers.DisplayMember = "Name";  // Display the player's name in the list

                    pnlPlayerDetails.Visible = false;
                    btnBack.Visible = false;
                    lstPlayers.Visible = true;
                    btnAddPlayer.Visible = true;
                    btnRemovePlayer.Visible = false;

                    // Check if the ListBox is empty
                    if (players.Count == 0)
                    {
                        MessageBox.Show("No players left to display.", "List Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"{selectedPlayer.Name} has been removed.", "Player Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void ClearPlayerDetails()
        {
            lblName.Text = "Name";
            lblTeam.Text = "Team";
            lblPosition.Text = "Position";
            lblMatchesPlayed.Text = "Matches Played";
            lblPoints.Text = "Points";
            lblAssists.Text = "Assists";
            lblNationality.Text = "Nationality";
            lblAge.Text = "Age";
            picPlayerPhoto.Image = null;  // Clear the image
        }


        private void btnBack_Click_1(object sender, EventArgs e)
        {
            // Hide the player details panel and back button
            pnlPlayerDetails.Visible = false;
            btnBack.Visible = false;

            // Show the players list and add player button
            lstPlayers.Visible = true;
            btnAddPlayer.Visible = true;

            // Hide the remove player button
            btnRemovePlayer.Visible = false;

            // Reset colors to default (example)
            Color BorderColor = SystemColors.Control; // Reset form background color to default

            // Reset button colors to default
            btnBack.BackColor = SystemColors.Control;
            btnAddPlayer.BackColor = SystemColors.Control;
            btnRemovePlayer.BackColor = SystemColors.Control;
        }
        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            using (AddPlayerForm addPlayerForm = new AddPlayerForm())
            {
                if (addPlayerForm.ShowDialog() == DialogResult.OK)
                {
                    Player newPlayer = addPlayerForm.NewPlayer;
                    players.Add(newPlayer); // Add new player to the list

                    // Rebind the ListBox to ensure the new player is displayed
                    lstPlayers.DataSource = null;
                    lstPlayers.DataSource = players.OrderBy(p => p.Name).ToList(); // Sorting players by name
                    lstPlayers.DisplayMember = "Name"; // Display player names

                    MessageBox.Show($"{newPlayer.Name} has been added.", "Player Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
    public class AddPlayerForm : Form
    {
        public Player NewPlayer { get; private set; }

        private TextBox txtName, txtTeam, txtPosition, txtPoints, txtAssists, txtNationality, txtAge, txtPhotoPath;
        private Button btnSave, btnCancel;

        public AddPlayerForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Form Properties
            this.Text = "Add New Player";
            this.Size = new Size(300, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            // Name Label and TextBox
            var lblName = new Label { Text = "Name", Location = new Point(10, 10), Width = 80 };
            txtName = new TextBox { Location = new Point(100, 10), Width = 150 };

            // Team Label and TextBox
            var lblTeam = new Label { Text = "Team", Location = new Point(10, 40), Width = 80 };
            txtTeam = new TextBox { Location = new Point(100, 40), Width = 150 };

            // Position Label and TextBox
            var lblPosition = new Label { Text = "Position", Location = new Point(10, 70), Width = 80 };
            txtPosition = new TextBox { Location = new Point(100, 70), Width = 150 };

            // Points Label and TextBox
            var lblPoints = new Label { Text = "Points", Location = new Point(10, 100), Width = 80 };
            txtPoints = new TextBox { Location = new Point(100, 100), Width = 150 };

            // Assists Label and TextBox
            var lblAssists = new Label { Text = "Assists", Location = new Point(10, 130), Width = 80 };
            txtAssists = new TextBox { Location = new Point(100, 130), Width = 150 };

            // Nationality Label and TextBox
            var lblNationality = new Label { Text = "Nationality", Location = new Point(10, 160), Width = 80 };
            txtNationality = new TextBox { Location = new Point(100, 160), Width = 150 };

            // Age Label and TextBox
            var lblAge = new Label { Text = "Age", Location = new Point(10, 190), Width = 80 };
            txtAge = new TextBox { Location = new Point(100, 190), Width = 150 };

            // Photo Path Label and TextBox (Optional)
            var lblPhotoPath = new Label { Text = "Photo Path", Location = new Point(10, 220), Width = 80 };
            txtPhotoPath = new TextBox { Location = new Point(100, 220), Width = 150 };

            // Save Button
            btnSave = new Button { Text = "Save", Location = new Point(40, 260), Width = 80 };
            btnSave.Click += BtnSave_Click;

            // Cancel Button
            btnCancel = new Button { Text = "Cancel", Location = new Point(140, 260), Width = 80 };
            btnCancel.Click += BtnCancel_Click;

            // Add controls to the form
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblTeam);
            this.Controls.Add(txtTeam);
            this.Controls.Add(lblPosition);
            this.Controls.Add(txtPosition);
            this.Controls.Add(lblPoints);
            this.Controls.Add(txtPoints);
            this.Controls.Add(lblAssists);
            this.Controls.Add(txtAssists);
            this.Controls.Add(lblNationality);
            this.Controls.Add(txtNationality);
            this.Controls.Add(lblAge);
            this.Controls.Add(txtAge);
            this.Controls.Add(lblPhotoPath);
            this.Controls.Add(txtPhotoPath);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtTeam.Text) ||
                string.IsNullOrWhiteSpace(txtPosition.Text) ||
                !int.TryParse(txtPoints.Text, out int points) ||
                !int.TryParse(txtAssists.Text, out int assists) ||
                string.IsNullOrWhiteSpace(txtNationality.Text) ||
                !int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create the new player
            NewPlayer = new Player
            {
                Name = txtName.Text,
                Team = txtTeam.Text,
                Position = txtPosition.Text,
                Points = points,
                Assists = assists,
                Nationality = txtNationality.Text,
                Age = age,
                PhotoPath = txtPhotoPath.Text // Optional: can be left empty if no photo is provided
            };

            // Close the form and return the new player
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
