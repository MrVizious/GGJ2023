using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using RuntimeSets;

public class PlayerController : MonoBehaviour
{
    //TODO: Character class and its subsequent CharacterRuntimeSet SO class
    [SerializeField] private CharacterController leftCharacter, rightCharacter;
    public RuntimeSetCharacterController availableCharacters;
    public int playerNumber = 0;
    private int availableCharacterIndex = 0;

    private void Start()
    {
        leftPortraitController.currentCharacter = leftCharacter;
        rightPortraitController.currentCharacter = rightCharacter;
    }

    [SerializeField] private PortraitUIController leftPortraitController, rightPortraitController;
    public void MoveLeftCharacter(InputAction.CallbackContext context)
    {
        Vector2 v = context.ReadValue<Vector2>();
        Debug.Log(playerNumber + " left: " + v);
        leftCharacter?.SetMoveVector(v);
    }

    public void MoveRightCharacter(InputAction.CallbackContext context)
    {
        Vector2 v = context.ReadValue<Vector2>();
        Debug.Log(playerNumber + "right: " + v);
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