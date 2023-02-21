using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int gold;
    public TextMeshProUGUI goldText;

    public Sprite[] backgrounds;

    private int curBackground;
    private int enemiesUntilBackgroundChange = 5;
    public Image backgroundImage;



    private void Awake()
    {
        if (instance == null || instance!=this)
        {
            instance = this;
        }
    }

    public void AddGold ( int amount)
    {
        gold += amount;
        goldText.text = "Gold: " + gold.ToString();
    }

    public void TakeGold(int amount)
    {
        gold -= amount;
        goldText.text = "Gold: " + gold.ToString();
    }

    public void BackgroundCheck()
    {
        enemiesUntilBackgroundChange--;
        if (enemiesUntilBackgroundChange == 0)
        {
            curBackground++;
            enemiesUntilBackgroundChange = 5;
            //If there is no more background left in the array, reset curBackground.
            if (curBackground == backgrounds.Length)
            {
                curBackground = 0;
            }
            //Update backgroundImage to curBackground.
            backgroundImage.sprite = backgrounds[curBackground];
        }
    }
}
