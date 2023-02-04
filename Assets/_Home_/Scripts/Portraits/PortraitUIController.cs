using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitUIController : MonoBehaviour
{
    [SerializeField]
    private Image backgroundRenderer, bodyRenderer, eyesRenderer, noseRenderer, clothesRenderer, hairRenderer, mouthRenderer, complementRenderer, frameRenderer, coloredBorderRenderer;
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

    private void Render()
    {
        backgroundRenderer.sprite = currentPortrait.backgroundSprite;
        bodyRenderer.sprite = currentPortrait.bodySprite;
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
}
