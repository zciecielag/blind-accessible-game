using System.Collections.Generic;
using UnityEngine;

//Klasa w ktorej ustalamy poczatkowe wartosci dla wszystkich aktow i questow
public class QuestData
{
    public static List<Act> allActs = new()
    {
        new Act(
            1, false, false, 1, new List<SubQuest>
            {
                new SubQuest(
                    1, false, false, 1, "Schowaj telefon do ekwipunku"
                ),
                new SubQuest(
                    2, false, false, 1, ""
                )
            }
        ),

        new Act(
            2, false, false, 1, new List<SubQuest>
            {
                new SubQuest(
                    1, false, false, 2, ""
                ),
                new SubQuest(
                    2, false, false, 2, ""
                )
            }
        )
    };
}
