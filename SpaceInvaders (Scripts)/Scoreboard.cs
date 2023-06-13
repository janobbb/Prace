using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TMP_Text[] texts;
    public List<int> scores;
    
   
    void Start()
    {
        scores = LoadList();
        for (int i = 0; i < texts.Length; i++)
        {

            texts[i].text = $"{i + 1,2}. Gracz.....{scores[i],-5} ";
        }
    }



    public List<int> LoadList()
    {
        scores.Clear();
        for (int i = 0; i < texts.Length; i++)
        {
            if (i == 0)
            {
                scores.Add(PlayerPrefs.GetInt("SavedHighScore"));
                scores[0] = (PlayerPrefs.GetInt("SavedHighScore"));
                Debug.Log(scores[0]);
            }
            else
            {
                scores.Add(0);

            }
             
        }
        return scores;
        
    }
}
