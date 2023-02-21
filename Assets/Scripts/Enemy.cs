using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Enemy : MonoBehaviour
{
    public int curHp;
    public int maxHp;
    public int goldToGive;
    public Image healthBarFill;
    public Image monsterSprite;

    public Animation anim;

    [SerializeField]
    Resistances resistances;

    

    public void Damage()
    {
        curHp--;
        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

        //animation
        anim.Stop();
        anim.Play();

        if (curHp == 0)
        {
            Defeated();
        }
    }

    public void Defeated()
    {
        GameManager.instance.AddGold(goldToGive);
        EnemyManager.instance.DefeatEnemy(gameObject);
    }
}
