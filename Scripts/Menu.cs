using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button[] Buttons;
    
    public float CurLvl;
    void Start()
    {
        LoadProgress();
        ButtonStatus();
    }

    public void LevelSelect(Text LevelText)
    {
        if (CurLvl >= int.Parse(LevelText.text))
        {
            PlayerPrefs.SetFloat("SelLevel",float.Parse(LevelText.text));
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void SbrosButton()
    {
        PlayerPrefs.DeleteKey("LvlComp");
        PlayerPrefs.Save();
        LoadProgress();
        ButtonStatus();
    }

    private void ButtonStatus()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (int.Parse(Buttons[i].transform.GetChild(1).GetComponent<Text>().text) < CurLvl)
            {
                Buttons[i].transform.GetChild(2).GetComponent<Text>().text = "Пройдено";
            }
            if (int.Parse(Buttons[i].transform.GetChild(1).GetComponent<Text>().text) == CurLvl)
            {
                Buttons[i].transform.GetChild(2).GetComponent<Text>().text = "Открыто";
            }
            if (int.Parse(Buttons[i].transform.GetChild(1).GetComponent<Text>().text) > CurLvl)
            {
                Buttons[i].transform.GetChild(2).GetComponent<Text>().text = "Закрыто";
            }
        }
    }
    
    private void LoadProgress()
    {
        if (PlayerPrefs.HasKey("LvlComp"))
        {
            CurLvl = PlayerPrefs.GetFloat("LvlComp");
        }
        else
        {
            PlayerPrefs.SetFloat("LvlComp",1);
            CurLvl = PlayerPrefs.GetFloat("LvlComp");
            PlayerPrefs.Save();
        }
    }
}
