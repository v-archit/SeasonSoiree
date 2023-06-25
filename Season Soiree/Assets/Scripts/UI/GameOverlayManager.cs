using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverlayManager : MonoBehaviour
{
    [SerializeField] private Sprite waterSprite;
    [SerializeField] private Sprite iceSprite;
    [SerializeField] private Sprite healthyTreeSprite;
    [SerializeField] private Sprite mehTreeSprite;
    [SerializeField] private Sprite deadTreeSprite;

    [SerializeField] private GameObject playerIcon;
    [SerializeField] private GameObject treeIcon;

    private Image playerImage;
    private Image treeImage;

    // Start is called before the first frame update
    void Start()
    {
        playerImage = playerIcon.GetComponent<UnityEngine.UI.Image>();
        treeImage = treeIcon.GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeTreeIcon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeTreeIcon(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeTreeIcon(3);
        }
    }

    /// <summary>
    /// Change the player icon according to the season
    /// </summary>
    /// <param name="season">The current season</param>
    public void ChangePlayerIcon(SeasonType season)
    {
        switch (season)
        {
            case SeasonType.Summer:
                playerImage.sprite = waterSprite;
                break;
            case SeasonType.Winter:
                playerImage.sprite = iceSprite;
                break;
        }
    }

    // Change tree icon with numbers FOR TESTING
    public void ChangeTreeIcon(int k)
    {
        switch (k)
        {
            case 1:
                treeImage.sprite = healthyTreeSprite;
                break;
            case 2:
                treeImage.sprite = mehTreeSprite;
                break;
            case 3:
                treeImage.sprite = deadTreeSprite;
                break;

        } 
    }
}
