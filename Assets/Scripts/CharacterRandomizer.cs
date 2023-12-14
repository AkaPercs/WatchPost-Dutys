using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRandomizer : MonoBehaviour
{
    public string eyesFolder = "Eyes";
    public string bodyFolder = "Body";
    public string hairFolder = "Hair";
    public string mouthFolder = "Mouth";

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
        GameObject[] Eyes = LoadAssets(eyesFolder);
        GameObject[] Body = LoadAssets(bodyFolder);
        GameObject[] Hair = LoadAssets(hairFolder);
        GameObject[] Mouth = LoadAssets(mouthFolder);

        int EyesIndex = Random.Range(0, Eyes.Length);
        int BodyIndex = Random.Range(0, Body.Length);
        int HairIndex = Random.Range(0, Hair.Length);
        int MouthIndex = Random.Range(0, Mouth.Length);

        Color randomColor = new Color(Random.value, Random.value, Random.value);

        // Instantiate the randomized parts into the corresponding containers
        GameObject eyesObject = Instantiate(Eyes[EyesIndex], EyesContainer);
        SetRandomColor(eyesObject, randomColor);

        GameObject bodyObject = Instantiate(Body[BodyIndex], BodyContainer);
        SetRandomColor(bodyObject, randomColor);

        GameObject hairObject = Instantiate(Hair[HairIndex], HairContainer);
        SetRandomColor(hairObject, randomColor);

        GameObject mouthObject = Instantiate(Mouth[MouthIndex], MouthContainer);
        SetRandomColor(mouthObject, randomColor);
    }

    void SetRandomColor(GameObject obj, Color color)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    GameObject[] LoadAssets(string folderPath)
    {
        Object[] loadedObjects = Resources.LoadAll(folderPath, typeof(GameObject));
        GameObject[] typedObjects = new GameObject[loadedObjects.Length];

        for (int i = 0; i < loadedObjects.Length; i++)
        {
            typedObjects[i] = (GameObject)loadedObjects[i];
        }

        return typedObjects;
    }
}
