using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitGameController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer backgroundRenderer, neckRenderer, headRenderer, eyesRenderer, noseRenderer, clothesRenderer, hairRenderer, mouthRenderer, complementRenderer, frameRenderer, coloredBorderRenderer;
    private PortraitData _currentPortrait;
    public PortraitData currentPortrait
    {
        private get
        {
            return _currentPortrait;
        }
        set
        {
            if (value == null)
            {
                Debug.LogError("Null can't be a value for currentPortrait");
                return;
            }

            _currentPortrait = value;
            Render();
        }
    }
    public Material sepiaMaterial;

    private void Render()
    {
        backgroundRenderer.sprite = currentPortrait.backgroundSprite;
        headRenderer.sprite = currentPortrait.bodySprite;
        eyesRenderer.sprite = currentPortrait.eyesSprite;
        noseRenderer.sprite = currentPortrait.noseSprite;
        clothesRenderer.sprite = currentPortrait.clothesSprite;
        hairRenderer.sprite = currentPortrait.hairSprite;
        mouthRenderer.sprite = currentPortrait.mouthSprite;
        complementRenderer.sprite = currentPortrait.complementSprite;
        frameRenderer.sprite = currentPortrait.frameSprite;
        coloredBorderRenderer.sprite = currentPortrait.coloredBorderSprite;
    }

    public void SetColor(Color newColor)
    {
        coloredBorderRenderer.color = newColor;
    }

    public void SetToSepia()
    {
        backgroundRenderer.material = sepiaMaterial;
        headRenderer.material = sepiaMaterial;
        eyesRenderer.material = sepiaMaterial;
        noseRenderer.material = sepiaMaterial;
        clothesRenderer.material = sepiaMaterial;
        hairRenderer.material = sepiaMaterial;
        mouthRenderer.material = sepiaMaterial;
        complementRenderer.material = sepiaMaterial;
        frameRenderer.material = sepiaMaterial;
        coloredBorderRenderer.material = sepiaMaterial;
        neckRenderer.material = sepiaMaterial;
    }
}
