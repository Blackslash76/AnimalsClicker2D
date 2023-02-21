using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SpritesToPrefabs : Editor
{


    [MenuItem("GameObject/Automation/Sprites to Prefab")]
    private static void spritesToPrefabs()
    {
        int i = 0;
        GameObject originalPrefab = (GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/DefaultEnemy.prefab");
        object[] loadedPokemon = Resources.LoadAll("Pokemon", typeof(Sprite)) ;
        EnemyManager enemyManager = FindFirstObjectByType<EnemyManager>();
        Debug.Log(enemyManager.enemyPrefabs);

        enemyManager.enemyPrefabs = new GameObject[loadedPokemon.Length];

        foreach (Sprite sprite in loadedPokemon)
        {

            GameObject objSource = PrefabUtility.InstantiatePrefab(originalPrefab)as GameObject; 
            
            //Randomize values
            Enemy enemy = objSource.GetComponent<Enemy>();
            enemy.monsterSprite.sprite = sprite;
            enemy.maxHp = Random.Range(5, 25);
            enemy.curHp = enemy.maxHp;
            
            string filename = "Assets/Prefabs/Generated/EnemyG_" + i + ".prefab";
            GameObject obj = PrefabUtility.SaveAsPrefabAsset(objSource,filename);
            enemyManager.enemyPrefabs[i] = obj;
            
            GameObject.DestroyImmediate(objSource);
            
            i++;
        }
    }

}
