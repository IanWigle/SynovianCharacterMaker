using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Data.SQLite;

using Synovian_Character_Maker.DataClasses.Instanced;

namespace Synovian_Character_Maker
{
    static public class SQL
    {
        static public void ExportLibrary(ref AbilityLibrary abilityLibrary)
        {
            string cs = $"URI=file:{Directory.GetCurrentDirectory()}\\AbilityLibrary.db";

            SQLiteConnection con = new SQLiteConnection(cs);
            con.Open();

            SQLiteCommand cmd = new SQLiteCommand(con);

            cmd.CommandText = "DROP TABLE IF EXISTS abilities";
            cmd.ExecuteNonQuery();

            //cmd.CommandText = "CREATE TABLE abilities(id INTEGER PRIMARY KEY, abilityName TEXT, abilityDescription TEXT, abilityID INT, abilityAlignment INT, abilityRank INT, abilitySchool INT, abilityCost INT, abilityPrereqs TEXT, abilityFeat BOOL)";
            cmd.CommandText = "CREATE TABLE abilities(id INTEGER PRIMARY KEY, abilityName TEXT)";
            cmd.ExecuteNonQuery();


            foreach (Ability ability in abilityLibrary.GetAbilities())
            {
                string s_pre = "";
                foreach (int pre in ability.prereqs)
                {
                    s_pre += int.Parse(pre.ToString());
                }

                //string commandText = $"INSERT INTO abilities(abilityName,abilityDescription,abilityID,abilityAlignment,abilityRank,abilitySchool,abilityCost,abilityPrereqs,abilityFeat) " +
                //                     $"VALUES('{ability.Name.Replace("'","''")}','{ability.description.Replace("'", "''")}',{ability.ID},{(int)ability.alignment},{(int)ability.Rank},{(int)ability.ability_School},{ability.skillCostOverride},'{s_pre}',{ability.isFeat})";
                string commandText = $"INSERT INTO abilities(abilityName) VALUES('{ability.Name.Replace("'","''")}')";
                cmd.CommandText = commandText;
                cmd.ExecuteNonQuery();
            }
        }

        static public void ImportLibrary(ref AbilityLibrary abilityLibrary)
        {
            string cs = $"URI=file:{Directory.GetCurrentDirectory()}\\Data\\AbilityLibrary.db";

            var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM abilities";

            var cmd = new SQLiteCommand(stm, con);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                int id = 0;
                string name = "";
                string description = "";
                Ability_Alignment ability_Alignment = Ability_Alignment.Ability_Invalid;
                Ability_Schools ability_Schools = Ability_Schools.Ability_Invalid;
                Rank rank = Rank.Invalid;
                int skillCostOverride = 0;
                bool isFeat = false;
                string s_pre = "";
                
                id = reader.GetInt32(0);
                name = reader.GetString(1);
                description = reader.GetString(2);
                ability_Alignment = (Ability_Alignment)reader.GetInt32(3);
                ability_Schools = (Ability_Schools)reader.GetInt32(4);
                rank = (Rank)reader.GetInt32(5);
                skillCostOverride = reader.GetInt32(6);
                isFeat = reader.GetBoolean(7);
                s_pre = reader.GetString(8);
                List<int> list = new List<int>();
                if (s_pre != "")
                {
                    string[] split = s_pre.Split(',');
                    foreach (string s in split)
                    {
                        if (s == "") continue;
                        list.Add(int.Parse(s));
                    }
                }
                Ability ability = new Ability(name, description, id, ability_Alignment, rank, ability_Schools, list, skillCostOverride, isFeat);
                abilityLibrary.AddNewAbility(ability);
            }
        }
    }
}

