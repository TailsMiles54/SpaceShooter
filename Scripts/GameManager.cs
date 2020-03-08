using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject[] Waypoints,Enemy;
    public GameObject PanelLose,Bullet;
    public Text PlayerHP,Text, Counter;
    
    public float spawnspeed, playerHP, playerspeed, CurDif, EnemyCol, EtecCol = 0, EnmOst;
    private int i,l,j;
    public void Start()
    {
        EnmOst = EnemyCol;
        CurDif = PlayerPrefs.GetFloat("SelLevel");
        i = Random.Range(0, 2);
        Counter.text = "Осталось врагов: " + EnemyCol;
        COUT();
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        for (j = 0; j < EnemyCol; j++)
        {
            EtecCol += 1;
            l = Random.Range(0, 7);
            GameObject enm = Instantiate(Enemy[i],Waypoints[l].transform.position,Quaternion.identity);
            enm.AddComponent<Enemy>();
            yield return new WaitForSeconds(spawnspeed);
        }
    }

    public void COUT()
    {
        PlayerHP.text = "Здоровье: " + playerHP;
        if (playerHP <= 0)
        {
            PanelLose.SetActive(true);
            Invoke("GoToMenu",2f);
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Count()
    {
        EtecCol = EtecCol - 1;
        EnmOst = EnmOst - 1;
        Counter.text = "Осталось врагов: " +  EnmOst;
        if (EtecCol <= 0 && j == EnemyCol)
        {
            PanelLose.SetActive(true);
            Text.text = "Вы победили";
            if (CurDif == PlayerPrefs.GetFloat("LvlComp"))
            {
                PlayerPrefs.SetFloat("LvlComp", CurDif + 1);
                PlayerPrefs.Save();
            }
            Invoke("GoToMenu", 2f);
        }
    }
}
