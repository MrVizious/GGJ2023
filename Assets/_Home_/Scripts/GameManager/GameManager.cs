using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using RuntimeSets;

public sealed class GameManager : Singleton<GameManager>
{
    public RuntimeSetCharacterController availableCharacters;
    public PlayerController player1, player2;
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

    private void Update()
    {
        CheckGameOver();
    }

    public void NextAge()
    {
        currentPortraitCreatorIndex++;
        if (currentPortraitCreatorIndex >= portraitCreators.Count)
        {
            currentPortraitCreatorIndex = 0;
        }
    }

    private void CheckGameOver()
    {
        if (AreAllDead()) GameOver();
    }

    private bool AreAllDead()
    {
        if (player1.leftCharacter != null) return false;
        if (player1.rightCharacter != null) return false;

        if (player2.leftCharacter != null) return false;
        if (player2.rightCharacter != null) return false;

        if (availableCharacters.Items.Count > 0) return false;

        return true;
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
