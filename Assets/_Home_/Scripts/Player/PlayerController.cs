using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RuntimeSet;

public class PlayerController : MonoBehaviour
{
    //TODO: Character class and its subsequent CharacterRuntimeSet SO class
    //[SerializeField] private Character leftCharacter, rightCharacter;
    //public CharacterRuntimeSet availableCharacters;
    [SerializeField]
    Color leftColor, rightColor;

    [SerializeField] private PortraitGameController portraitController;
}
