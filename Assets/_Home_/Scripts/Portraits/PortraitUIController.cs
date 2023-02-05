using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitUIController : MonoBehaviour
{
    [SerializeField]
    private Image backgroundRenderer, bodyRenderer, eyesRenderer, noseRenderer, clothesRenderer, hairRenderer, mouthRenderer, complementRenderer, frameRenderer, coloredBorderRenderer;
    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private Image bloodBarA, bloodBarB, bloodBarC, bloodBarD;
    private CharacterController _currentCharacter;
    public CharacterController currentCharacter
    {
        private get
        {
            return _currentCharacter;
        }
        set
        {
            if (value == null)
            {
                Debug.LogError("Null can't be a value for currentPortrait");
                return;
            }

            _currentCharacter = value;
            Render();
        }
    }

    private void Update()
    {
        lifeBar.fillAmount = currentCharacter.lifePercentage;
    }

    private void Render()
    {
        PortraitData portraitData = currentCharacter.portraitData;
        backgroundRenderer.sprite = portraitData.backgroundSprite;
        bodyRenderer.sprite = portraitData.bodySprite;
        eyesRenderer.sprite = portraitData.eyesSprite;
        noseRenderer.sprite = portraitData.noseSprite;
        clothesRenderer.sprite = portraitData.clothesSprite;
        hairRenderer.sprite = portraitData.hairSprite;
        mouthRenderer.sprite = portraitData.mouthSprite;
        complementRenderer.sprite = portraitData.complementSprite;
        frameRenderer.sprite = portraitData.frameSprite;
        coloredBorderRenderer.sprite = portraitData.coloredBorderSprite;

        bloodBarA.fillAmount = currentCharacter.bloodPercentages[0];
        bloodBarB.fillAmount = currentCharacter.bloodPercentages[1];
        bloodBarC.fillAmount = currentCharacter.bloodPercentages[2];
        bloodBarD.fillAmount = currentCharacter.bloodPercentages[3];
    }



    public void SetColor(Color newColor)
    {
        coloredBorderRenderer.color = newColor;
    }
}
