using Synovian_Character_Maker.DataClasses.Instanced;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    public partial class HardcorePointsMenu : Form
    {
        CharacterSheet sheet = null;

        public HardcorePointsMenu()
        {
            InitializeComponent();

            SkillNumericValue.Maximum = (decimal)Program._statRules.MaxObtainableHCM[StatRules.HCM_Types.SkillPoint];
            FeatNumericValue.Maximum = (decimal)Program._statRules.MaxObtainableHCM[StatRules.HCM_Types.FeatPoint];
            ExtraDroidNumericValue.Maximum = (decimal)Program._statRules.MaxObtainableHCM[StatRules.HCM_Types.ExtraDroid];
            SpecNumericValue.Maximum = (decimal)Program._statRules.MaxObtainableHCM[StatRules.HCM_Types.Specialization];
        }

        private void HardcorePointsMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                sheet.AddHardcoreValues((int)SkillNumericValue.Value, (int)FeatNumericValue.Value, (int)MasteryNumericValue.Value,(int)ExtraDroidNumericValue.Value, (int)SpecNumericValue.Value);
                e.Cancel = true;
                Hide();
            }
        }

        private void SkillNumericValue_Click(object sender, EventArgs e)
        {
        }

        public void LinkCharacterSheet(ref CharacterSheet linkSheet)
        {
            sheet = linkSheet;

            SkillNumericValue.Value = sheet.additionalSkillPoints;
            FeatNumericValue.Value = sheet.additionalFeetPoints;
            MasteryNumericValue.Value = sheet.additionalMasteryPoints;
            ExtraDroidNumericValue.Value = sheet.additionalDroidSlot;
            SpecNumericValue.Value = sheet.additionalSpecialization;
        }
        
    }
}
