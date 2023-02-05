using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtensionMethods;

public class PortraitUIController : MonoBehaviour
{
    [SerializeField]
    private Image backgroundRenderer, neckRenderer, headRenderer, eyesRenderer, noseRenderer, clothesRenderer, hairRenderer, mouthRenderer, complementRenderer, frameRenderer, coloredBorderRenderer;
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

            if (_currentCharacter != null)
            {
                _currentCharacter.onDestroy.RemoveListener(SetToSepia);
            }

            SetToNormalShader();

            _currentCharacter = value;
            _currentCharacter.onDestroy.AddListener(SetToSepia);
            Render();
        }
    }

    public Material sepiaMaterial;
    private Material originalMaterial;

    private void Start()
    {
        originalMaterial = headRenderer.material;
    }

    private void Update()
    {
        lifeBar.fillAmount = currentCharacter.lifePercentage;
    }


    private void Render()
    {
        PortraitData portraitData = currentCharacter.portraitData;
        headRenderer.sprite = portraitData.headSprite;
        eyesRenderer.sprite = portraitData.eyesSprite;
        noseRenderer.sprite = portraitData.noseSprite;
        clothesRenderer.sprite = portraitData.clothesSprite;
        hairRenderer.sprite = portraitData.hairSprite;
        mouthRenderer.sprite = portraitData.mouthSprite;
        complementRenderer.sprite = portraitData.complementSprite;
        if (complementRenderer.sprite == null) complementRenderer.color = new Color(0, 0, 0, 0);
        else complementRenderer.color = Color.white;
        frameRenderer.sprite = portraitData.frameSprite;
        coloredBorderRenderer.sprite = portraitData.coloredBorderSprite;

        bloodBarA.fillAmount = currentCharacter.bloodPercentages[0];
        bloodBarB.fillAmount = currentCharacter.bloodPercentages[1];
        bloodBarC.fillAmount = currentCharacter.bloodPercentages[2];
        bloodBarD.fillAmount = currentCharacter.bloodPercentages[3];
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

    public void SetToNormalShader()
    {

        backgroundRenderer.material = originalMaterial;
        headRenderer.material = originalMaterial;
        eyesRenderer.material = originalMaterial;
        noseRenderer.material = originalMaterial;
        clothesRenderer.material = originalMaterial;
        hairRenderer.material = originalMaterial;
        mouthRenderer.material = originalMaterial;
        complementRenderer.material = originalMaterial;
        frameRenderer.material = originalMaterial;
        coloredBorderRenderer.material = originalMaterial;
        neckRenderer.material = originalMaterial;
    }

    public void SetColor(Color newColor)
    {
        coloredBorderRenderer.color = newColor;
    }
}