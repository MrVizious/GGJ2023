using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using RuntimeSet;

public class PlayerController : MonoBehaviour
{
    //TODO: Character class and its subsequent CharacterRuntimeSet SO class
    //[SerializeField] private Character leftCharacter, rightCharacter;
    //public CharacterRuntimeSet availableCharacters;
    public int playerNumber = 0;

    [SerializeField]
    Color leftColor, rightColor;

    [SerializeField] private PortraitGameController portraitController;
    public void MoveLeftCharacter(InputAction.CallbackContext context)
    {
        Vector2 v = context.ReadValue<Vector2>();
        Debug.Log(playerNumber + ": " + v);
    }

    public void MoveRightCharacter(InputAction.CallbackContext context)
    {
        Vector2 v = context.ReadValue<Vector2>();
        Debug.Log(playerNumber + ": " + v);
    }

    public void ChangeLeftCharacterForward(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Changing left character forward");
    }

    public void ChangeLeftCharacterBackward(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Changing left character backward");
    }

    public void ChangeRightCharacterForward(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Changing right character forward");
    }

    public void ChangeRightCharacterBackward(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Changing right character backward");
    }
}
