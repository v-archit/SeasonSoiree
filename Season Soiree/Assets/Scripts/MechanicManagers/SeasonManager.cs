using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SeasonType
{
    Summer,
    Winter
}

public class SeasonManager : MonoBehaviour
{
    [SerializeField] private SeasonType startingSeason;
    public SeasonType CurrentSeason { get; private set; }

    public GameEvent ChangeToWinter;
    public GameEvent ChangeToSummer;

    [SerializeField] private GameObject gameOverlayManager;

    private void Awake()
    {
        CurrentSeason = startingSeason;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentSeason == SeasonType.Summer)
            {
                ChangeSeason(SeasonType.Winter);
                gameOverlayManager.GetComponent<GameOverlayManager>().ChangePlayerIcon(SeasonType.Winter);
                ChangeToWinter.Raise();
            }
            else if (CurrentSeason == SeasonType.Winter)
            {
                ChangeSeason(SeasonType.Summer);
                gameOverlayManager.GetComponent<GameOverlayManager>().ChangePlayerIcon(SeasonType.Summer);
                ChangeToSummer.Raise();
            }
        }
    }

    public void ChangeSeason(SeasonType newSeason)
    {
        if (newSeason == CurrentSeason)
        {
            Debug.Log($"SeasonManager: Current season is already {newSeason}, no need to change it!");
        }

        CurrentSeason = newSeason;
    }
}
