using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OldWoodenCabin.Environments;
using OldWoodenCabin.Items;
using OldWoodenCabin.Objects;

namespace OldWoodenCabin
{
    public partial class Form1 : Form
    {
        GameManager gameManager = new GameManager();

        public Form1()
        {
            InitializeComponent();
            gameManager.CreateNewGame();
            RefreshScreen();
        }

        public void RefreshScreen()
        {
            lblFood.Text = gameManager.CurrentFood.ToString();
            lblHeat.Text = gameManager.CurrentHeat.ToString();
            lblMood.Text = gameManager.CurrentMood.ToString();
            lblCurrentEnvironment.Text = "None";

            lblFoodMod.Text = gameManager.CurrentFoodModifier.ToString();
            lblHeatMod.Text = gameManager.CurrentHeatModifier.ToString();
            lblMoodMod.Text = gameManager.CurrentMoodModifier.ToString();

            listEnv.Items.Clear();
            listInv.Items.Clear();
            listObjects.Items.Clear();

            listEnv.DisplayMember = "Name";
            listInv.DisplayMember = "Name";
            listObjects.DisplayMember = "Name";
            listEnv.ValueMember = "Name";
            listInv.ValueMember = "Name";
            listObjects.ValueMember = "Name";

            listInv.Items.AddRange(gameManager.Inventory.ToArray());

            if (gameManager.CurrentEnvironment != null)
            {
                lblCurrentEnvironment.Text = gameManager.CurrentEnvironment.Name;
                listEnv.Items.AddRange(gameManager.CurrentEnvironment.Items.ToArray());
                listObjects.Items.AddRange(gameManager.CurrentEnvironment.Objects.ToArray());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameManager.CurrentEnvironment = gameManager.Environments.FirstOrDefault(env => env.Name == "Cabin");
            RefreshScreen();
        }

        private void btnOC_Click(object sender, EventArgs e)
        {
            gameManager.CurrentEnvironment = gameManager.Environments.FirstOrDefault(env => env.Name == "Cabin Outside");
            RefreshScreen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listEnv.SelectedItem != null)
            {
                gameManager.MoveItemFromEnvToInv(((Item)listEnv.SelectedItem).Name);
            }
            RefreshScreen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listInv.SelectedItem != null && gameManager.CurrentEnvironment != null)
            {
                gameManager.MoveItemFromInvToEnv(((Item)listInv.SelectedItem).Name);
            }
            RefreshScreen();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listInv.SelectedItem != null)
            {
                gameManager.UseItem(((Item)listInv.SelectedItem).Name);
            }
            RefreshScreen();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listInv.SelectedItems.Count > 0)
            {
                gameManager.ApplyItems(listInv.SelectedItems.Cast<Item>(), (StaticObject)listObjects.SelectedItem );
                RefreshScreen();
            }
        }
    }
}
