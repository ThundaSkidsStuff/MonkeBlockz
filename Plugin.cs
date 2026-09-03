using BepInEx;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using static GorillaTag.Cosmetics.ContinuousProperty;

namespace GorillaTagModTemplateProject
{
	[BepInPlugin("Thunda.GorillaPorn", "GorillaPornhub", "1.0.0")]
	public class Plugin : BaseUnityPlugin
	{

        void Start()
		{
            var harmony = Harmony.CreateAndPatchAll(GetType().Assembly, "Thunda.GorillaPorn");
            GorillaTagger.OnPlayerSpawned(OnGameInitialized);
		}

		void OnGameInitialized()
		{
            // got the temp on github
            string[] sets = new string[]
            {
    "BUILD01",
    "BUILD03",
    "BUILD04",
    "BUILD02",
    "LDAAA.",
    "BUILD07",
    "LDAAB.",
    "LDAAC.",
    "LDAAD.",
    "LDAAE.",
    "BUILD05",
    "LDAAF.",
    "LDAAG.",
    "LDAAH.",
    "BUILD08",
    "BUILD09",
    "LDAAI.",
    "LDAAJ.",
    "LDAAK.",
    "LDAAL.",
    "LDAAM.",
    "LDAAN.",
    "LDAAO.",
    "LDAAP.",
    "LDAAQ."
            };

            List<BuilderPieceSet> allSets = BuilderSetManager.instance.GetAllPieceSets();
            List<BuilderPieceSet> unlockedSets = BuilderSetManager.instance.GetUnlockedPieceSets();

            foreach (string setz in sets)
            {
                BuilderPieceSet foundSet = allSets.Find(x => x != null && x.playfabID == setz);

                if (foundSet != null && !unlockedSets.Contains(foundSet))
                {
                    unlockedSets.Add(foundSet);
                }
            }
            // i did use ai to fix some bugs i had cuz it didn't work :Q
            if (BuilderSetManager.instance.OnOwnedSetsUpdated != null)
            {
                BuilderSetManager.instance.OnOwnedSetsUpdated.Invoke();
            }

        }

        void RunIfUpdate()
        {
            // got the temp on github
            string[] sets = new string[] {"BUILD01","BUILD03","BUILD04","BUILD02","LDAAA.","BUILD07","LDAAB.","LDAAC.","LDAAD.","LDAAE.","BUILD05","LDAAF.","LDAAG.","LDAAH.","BUILD08","BUILD09","LDAAI.","LDAAJ.","LDAAK.","LDAAL.","LDAAM.","LDAAN.","LDAAO.","LDAAP.","LDAAQ."};

            List<BuilderPieceSet> kitsthingthing = BuilderSetManager.instance.GetAllPieceSets();
            List<BuilderPieceSet> larphub = BuilderSetManager.instance.GetUnlockedPieceSets();

            foreach (string setz in sets)
            {
                BuilderPieceSet foundSet = kitsthingthing.Find(x => x != null && x.playfabID == setz);
                larphub.Add(foundSet);
            }
            // i did use ai to fix some bugs i had cuz it didn't work :Qa
            
            BuilderSetManager.instance.OnOwnedSetsUpdated.Invoke();
            

        }
        void Update() 
		{
            // u need this cuz every few minutes they run an update 
            RunIfUpdate(); // if you didn't know i suck at optimizing code!

        }
		/*void Update()
		{
			if (NetworkSystem.Instance.InRoom && NetworkSystem.Instance.GameModeString.Contains("MODDED"))
			{
				if (!inRoom)
				{
					inRoom = true;
				}
			}
			else
			{
                if (inRoom)
                {
                    inRoom = false;
                }
            }
		} */
	}
}