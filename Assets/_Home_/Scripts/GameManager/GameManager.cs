using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using RuntimeSets;

public sealed class GameManager : Singleton<GameManager>
{
    public RuntimeSetCharacterController availableCharacters;
    [SerializeField] List<PortraitCreator> portraitCreators = new List<PortraitCreator>();
    private int currentPortraitCreatorIndex = 0;
    public PortraitCreator portraitCreator
    {
        get { return portraitCreators[currentPortraitCreatorIndex]; }
    }

    private void Start()
    {
        currentPortraitCreatorIndex = 0;
    }

    public void NextPortraitCreator()
    {
        currentPortraitCreatorIndex++;
        if (currentPortraitCreatorIndex >= portraitCreators.Count)
        {
            currentPortraitCreatorIndex = 0;
        }
    }

    private void Update()
    {

    }

    private void DeleteUnseenCharacters()
    {
        foreach (CharacterController character in availableCharacters.Items)
        {
            if (!character.rendererComponent.isVisible)
            {
                Destroy(character);
            }
        }
    }
}
