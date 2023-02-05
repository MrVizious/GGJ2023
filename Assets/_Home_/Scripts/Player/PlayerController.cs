using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using RuntimeSets;

public class PlayerController : MonoBehaviour
{
    public Color leftColor, rightColor;
    public CharacterController _leftCharacter, _rightCharacter;
    public CharacterController leftCharacter
    {
        set
        {
            leftCharacter.portraitController.SetColor(Color.white);
            leftPortraitController.currentCharacter = value;
            _leftCharacter = value;
            _rightCharacter.portraitController.SetColor(leftColor);
        }

        get { return _leftCharacter; }
    }
    public CharacterController rightCharacter
    {
        set
        {
            rightCharacter.portraitController.SetColor(Color.white);
            rightPortraitController.currentCharacter = value;
            _rightCharacter = value;
            _rightCharacter.portraitController.SetColor(rightColor);
        }

        get { return _rightCharacter; }
    }
    public RuntimeSetCharacterController availableCharacters;
    public int playerNumber = 0;
    private int availableCharacterIndex = 0;

    private void Start()
    {
        leftPortraitController.currentCharacter = leftCharacter;
        leftPortraitController.SetColor(leftColor);
        rightPortraitController.SetColor(rightColor);
        rightPortraitController.currentCharacter = rightCharacter;
        leftCharacter.portraitController.SetColor(leftColor);
        rightCharacter.portraitController.SetColor(rightColor);

    }

    [SerializeField] private PortraitUIController leftPortraitController, rightPortraitController;
    public void MoveLeftCharacter(InputAction.CallbackContext context)
    {
        Vector2 v = context.ReadValue<Vector2>();
        //Debug.Log(playerNumber + " left: " + v);
        leftCharacter?.SetMoveVector(v);
    }

    public void MoveRightCharacter(InputAction.CallbackContext context)
    {
        Vector2 v = context.ReadValue<Vector2>();
        //Debug.Log(playerNumber + "right: " + v);
        rightCharacter?.SetMoveVector(v);
    }

    public void ChangeLeftCharacterForward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CharacterController newCharacter = availableCharacters.GetItemAt(availableCharacterIndex + 1);
            if (newCharacter == null) return;
            if (leftCharacter != null) availableCharacters.Add(leftCharacter);
            leftCharacter = newCharacter;
            availableCharacterIndex = availableCharacters.IndexOf(leftCharacter);
            availableCharacters.Remove(leftCharacter);
            leftPortraitController.currentCharacter = leftCharacter;
        }
    }

    public void ChangeLeftCharacterBackward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CharacterController newCharacter = availableCharacters.GetItemAt(availableCharacterIndex - 1);
            if (newCharacter == null) return;
            if (leftCharacter != null) availableCharacters.Add(leftCharacter);
            leftCharacter = newCharacter;
            availableCharacterIndex = availableCharacters.IndexOf(leftCharacter);
            availableCharacters.Remove(leftCharacter);
            leftPortraitController.currentCharacter = leftCharacter;
        }
    }

    public void ChangeRightCharacterForward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CharacterController newCharacter = availableCharacters.GetItemAt(availableCharacterIndex + 1);
            if (newCharacter == null) return;
            if (rightCharacter != null) availableCharacters.Add(rightCharacter);
            rightCharacter = newCharacter;
            availableCharacterIndex = availableCharacters.IndexOf(rightCharacter);
            availableCharacters.Remove(rightCharacter);
            rightPortraitController.currentCharacter = rightCharacter;
        }
    }

    public void ChangeRightCharacterBackward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CharacterController newCharacter = availableCharacters.GetItemAt(availableCharacterIndex - 1);
            if (newCharacter == null) return;
            if (rightCharacter != null) availableCharacters.Add(rightCharacter);
            rightCharacter = newCharacter;
            availableCharacterIndex = availableCharacters.IndexOf(rightCharacter);
            availableCharacters.Remove(rightCharacter);
            rightPortraitController.currentCharacter = rightCharacter;
        }
    }
}