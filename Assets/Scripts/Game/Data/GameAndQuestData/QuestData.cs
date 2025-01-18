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
            0, false, false, 1, new List<SubQuest>
            {
                new SubQuest(
                    1, false, false, 0, "Spróbuj podejść do szafki w lewym górnym rogu pokoju."
                ),
                new SubQuest(
                    2, false, false, 0, "Spróbuj podnieść szalik naciskając na przycisk na środku ekranu."
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
                    1, false, false, 1, "Podejdź do Polarnych."
                ),
                new SubQuest(
                    2, false, false, 1, "Znajdź i zabierz ze sobą miskę."
                ),
                new SubQuest(
                    3, false, false, 1, "Przynieś miskę Polarnym w kuchni, klikając na przycisk na środku ekranu."
                ), 
                new SubQuest(
                    4, false, false, 1, "Znajdź i zabierz ze sobą klucz do spiżarni."
                ),
                new SubQuest(
                    5, false, false, 1, "Spróbuj teraz wejść do spiżarni."
                ),
                new SubQuest(
                    6, false, false, 1, "Weź miskę ze stołu."
                ),
                new SubQuest(
                    7, false, false, 1, "Otwórz szafkę ponownie."
                ),
                //Teraz jest mini-gra
                //Potem dostajemy miskę ze składnikami do eq
                new SubQuest(
                    8, false, false, 1, "Przynieś gotowe składniki Polarnym."
                )
            }
        ),

        new Act(
            2, false, false, 1, new List<SubQuest>
            {
                new SubQuest(
                    1, false, false, 1, ""
                )
            }
        ),
    };
}
