using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRandomizer : MonoBehaviour
{
    public GameObject[] Eyes;
    public GameObject[] Body;
    public GameObject[] Hair;
    public GameObject[] Mouth;

    public Transform EyesContainer;
    public Transform BodyContainer;
    public Transform HairContainer;
    public Transform MouthContainer;

    void Awake()
    {
        RandomizeCharacter();
    }

    void RandomizeCharacter()
    {
        int EyesIndex = Random.Range(0, Eyes.Length);
        int BodyIndex = Random.Range(0, Body.Length);
        int HairIndex = Random.Range(0, Hair.Length);
        int MouthIndex = Random.Range(0, Mouth.Length);

        // Instantiate the randomized parts into the corresponding containers
        Instantiate(Eyes[EyesIndex], EyesContainer);
        Instantiate(Body[BodyIndex], BodyContainer);
        Instantiate(Hair[HairIndex], HairContainer);
        Instantiate(Mouth[MouthIndex], MouthContainer);
    }
}


