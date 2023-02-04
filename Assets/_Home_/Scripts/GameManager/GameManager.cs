using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;

public sealed class GameManager : Singleton<GameManager>
{
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
}
