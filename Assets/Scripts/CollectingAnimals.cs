using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingAnimals : MonoBehaviour
{
    // Opret en liste for at gemme v�rdier
    private List<int> Animals = new List<int>();

    // Update bliver kaldt en gang per frame
    void Update()
    {
        // Simuler, at du samler et dyr op (du kan �ndre dette efter behov)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Tilf�j et tilf�ldigt tal til listen, der repr�senterer det samlede dyr
            Animals.Add(Random.Range(1, 10));
            Debug.Log("Dyr samlet op! Tilf�jede et tal til listen. Antal elementer i listen: " + Animals.Count);

            // Tjek om der er tre elementer i listen
            if (Animals.Count == 3)
            {
                // G�r noget n�r der er tre elementer i listen
                //DoSomething();

                // Ryd listen
                //minListe.Clear();
            }
        }
    }
}