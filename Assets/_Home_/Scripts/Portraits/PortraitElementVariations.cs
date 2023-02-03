using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

[CreateAssetMenu(menuName = "Portraits/Portrait Element Variations")]
public class PortraitElementVariations : ScriptableObject
{
    public List<Sprite> possibleSprites;

    public Sprite GetRandom()
    {
        return possibleSprites.GetRandomItem<Sprite>();
    }
}
