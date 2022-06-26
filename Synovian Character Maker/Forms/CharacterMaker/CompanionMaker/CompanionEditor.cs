using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Synovian_Character_Maker.DataClasses.Instanced;

namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    public partial class CompanionEditor : Form
    {
        CompanionSheet companion;
        List<Ability> available_abilities;
        List<Ability> selected_abilities = new List<Ability>();

        const string CompanionNameStr = "Name : ";

        public CompanionEditor(CompanionSheet companionSheet, List<Ability> availableAbilities)
        {
            InitializeComponent();

            companion = companionSheet;

            available_abilities = availableAbilities;

            CompanionName.Text = CompanionNameStr + companionSheet.companionName;

            foreach(int abilityID in companion.abilities)
            {
                selected_abilities.Add(Program.abilityLibrary.GetAbility(abilityID));
            }

            companionDescription.Text = companionSheet.companionHistory;

            CleanLists();
        }

        private void companionDescription_Leave(object sender, EventArgs e)
        {
            companion.SetCompanionHistory(companionDescription.Text);
        }

        private void availableAbilitiesList_DoubleClick(object sender, EventArgs e)
        {
            Ability ability = null;
            string name = availableAbilitiesList.SelectedItems[0].Text;

            if (!Program.abilityLibrary.TryGetAbility(name, out ability))
            {
                return;
            }

            selected_abilities.Add(ability);

            CleanLists();
        }

        private void CleanLists()
        {
            // Available abilities
            availableAbilitiesList.Items.Clear();

            foreach(Ability ability in available_abilities)
            {
                if (selected_abilities.Contains(ability))
                    continue;
                else
                {
                    availableAbilitiesList.Items.Add(new ListViewItem(new string[] { ability.Name }));
                }
            }

            // Learned abilities
            currentAbilitiesList.Items.Clear();

            foreach(Ability ability1 in selected_abilities)
            {
                currentAbilitiesList.Items.Add(new ListViewItem(new string[] { ability1.Name }));
            }
        }

        private void CompanionEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Program.GetOpenedSheet().HasCompanion(companion))
            {
                Program.GetOpenedSheet().companionSheets.Remove(companion);
            }

            foreach (var ability in selected_abilities)
            {
                if(!companion.abilities.Contains(ability.ID))
                {
                    companion.abilities.Add(ability.ID);
                }
            }
            companion.SetCompanionHistory(companionDescription.Text);
            Program.GetOpenedSheet().companionSheets.Add(companion);
        }

        private void currentAbilitiesList_DoubleClick(object sender, EventArgs e)
        {
            Ability ability = null;
            string name = availableAbilitiesList.SelectedItems[0].Text;

            if(Program.abilityLibrary.TryGetAbility(name, out ability))
            {
                selected_abilities.Remove(ability);
            }

            CleanLists();
        }
    }
}
