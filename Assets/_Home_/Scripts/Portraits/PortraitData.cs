using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitData
{
    public Sprite backgroundSprite, bodySprite, eyesSprite, noseSprite, clothesSprite, hairSprite, mouthSprite, complementSprite, frameSprite, coloredBorderSprite;
    public PortraitData(PortraitCreator portraitCreator)
    {
        //backgroundSprite = portraitCreator.GetBackground();
        bodySprite = portraitCreator.GetHead();
        eyesSprite = portraitCreator.GetEyes();
        noseSprite = portraitCreator.GetNose();
        clothesSprite = portraitCreator.GetClothes();
        hairSprite = portraitCreator.GetHair();
        mouthSprite = portraitCreator.GetMouth();
        complementSprite = portraitCreator.GetComplement();
        frameSprite = portraitCreator.GetFrame();
        coloredBorderSprite = portraitCreator.GetColoredBorder();
    }
}
