using System.Collections.Generic;
using UnityEngine;

//Klasa w ktorej ustalamy poczatkowe wartosci dla wszystkich aktow i questow
[System.Serializable]
public class QuestData
{
    public static List<Act> allActs = new()
    {
        //Samouczkowy akt
        new Act(
            0, false, false, 0, new List<SubQuest>
            {
                new SubQuest(
                    1, false, false, 0, "Spróbuj podejść do szafki w lewym górnym rogu pokoju."
                ),
                new SubQuest(
                    2, false, false, 0, "Spróbuj podnieść szalik naciskając dwukrotnie na ekran."
                ),
                new SubQuest(
                    3, false, false, 0, "Powieś szalik na wieszaku."
                ),
                new SubQuest(
                    4, false, false, 0, "Poszukaj dźwięku salonu. Zbliż się do drzwi prowadzących do salonu, aby przejść dalej."
                ),
                new SubQuest(
                    5, false, false, 0, "Kliknij przycisk 'W jakim pokoju jestem?' i usłysz kwestię jeszcze raz."
                ),
                new SubQuest(
                    6, false, false, 0, "Przejdź do kuchni."
                )
            }
        ),
        
        //"Prawdziwe" akty
        new Act(
            1, false, false, 1, new List<SubQuest>
            {
                new SubQuest(
                    1, false, false, 1, "Przejdź do kuchni"
                ),
                new SubQuest(
                    2, false, false, 1, "Przynies telefon Treflikowi"
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
