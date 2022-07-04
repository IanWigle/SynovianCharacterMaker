using Parse;
using System.Resources;
using System.Text;
using System.Windows;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

using Synovian_Character_Maker.DataClasses.Instanced;

namespace Synovian_Character_Maker.Networking
{
    

    public static class Back4App
    {
        static public void Test()
        {
            Initialize();
            SendData();
            GetData();
            CreateRange();
            GetRange();
        }

        static void Initialize()
        {
            ParseClient.Initialize(new ParseClient.Configuration
            {
                ApplicationId = Resources.Resource1.back4app_app_id,
                WindowsKey = Resources.Resource1.back4app_dotnet_key,
                Server = Resources.Resource1.back4app_server_url
            });            
        }

        static async void SendData()
        {
            ParseObject person = new ParseObject("Person");
            person["name"] = "John Snow";
            person["age"] = 27;
            await person.SaveAsync();
        }

        static async void GetData()
        {
            ParseQuery<ParseObject> person = ParseObject.GetQuery("Person");
            ParseObject query = await person.GetAsync("vXMH7N28xm");

            string name = query.Get<string>("name");
            int age = query.Get<int>("age");
        }

        static async void CreateRange()
        {
            

            string[] names = { "A. Wed", "B. Wed", "C. Wed", "D. Wed", "E. Wed", "F. Wed", "G. Wed", "H. Wed", "I. Wed", "J. Wed" };

            for(int i = 0; i < 10; i++)
            {
                ParseObject soccerPlayers = new ParseObject("SoccerPlayers");
                soccerPlayers["playerName"] = names[i];
                soccerPlayers["yearOfBirth"] = (1997 + i);
                soccerPlayers["emailContact"] = $"{names[i].Remove(2,1).ToLower()}@email.io";
                soccerPlayers.AddRangeUniqueToList("attributes", new[] { "fast", "good conditioning" });
                await soccerPlayers.SaveAsync();
            }
        }

        static async void GetRange()
        {
            ParseQuery<ParseObject> soccerPlayers = ParseObject.GetQuery("SoccerPlayers");

            IEnumerable<ParseObject> results = await soccerPlayers.FindAsync();

            foreach(ParseObject soccerPlayer in results)
            {
                string name = soccerPlayer.Get<string>("playerName");
                Debug.WriteLine(name);
            }
        }

        static public async Task UploadAbilityList(AbilityLibrary library)
        {
            foreach(Ability ability in library.GetAbilities())
            {
                ParseObject abilities = new ParseObject("Abilities");
                abilities["abilityName"] = ability.Name;
                abilities["ID"] = ability.ID;
                abilities["skillCost"] = ability.skillCostOverride;
                abilities["Rank"] = ability.s_rank;
                abilities["School"] = ability.s_ability_School;
                abilities["Alignment"] = ability.s_alignment;
                abilities["Description"] = ability.description;
                abilities["Prereqs"] = ability.sql_prepres;
                abilities["isFeat"] = ability.isFeat;
                await abilities.SaveAsync();
            }
        }
    }
}