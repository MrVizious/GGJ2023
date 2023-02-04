using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Portraits/Portrait Creator")]
/// <summary>
/// This scriptable object should be instanced and given a series of PortraitElementVariations instances.
/// The name for each instance should reflect the time period it represents (i.e. Portrait Creator Medieval)
/// </summary>
public class PortraitCreator : ScriptableObject
{
    [SerializeField] private PortraitElementVariations backgroundVariations, bodyVariations, eyesVariations, noseVariations, clothesVariations, hairVariations, mouthVariations, complementVariations;
    [SerializeField] private Sprite coloredBorderSprite, frameSprite;

    public Sprite GetBackground()
    {
        return backgroundVariations.GetRandom();
    }
    public Sprite GetBody()
    {
        return bodyVariations.GetRandom();
    }
    public Sprite GetEyes()
    {
        return bodyVariations.GetRandom();
    }
    public Sprite GetNose()
    {
        return noseVariations.GetRandom();
    }
    public Sprite GetClothes()
    {
        return clothesVariations.GetRandom();
    }
    public Sprite GetHair()
    {
        return hairVariations.GetRandom();
    }
    public Sprite GetMouth()
    {
        return mouthVariations.GetRandom();
    }
    public Sprite GetComplement()
    {
        return complementVariations.GetRandom();
    }
    public Sprite GetFrame()
    {
        return frameSprite;
    }
    public Sprite GetColoredBorder()
    {
        return coloredBorderSprite;
    }
}
