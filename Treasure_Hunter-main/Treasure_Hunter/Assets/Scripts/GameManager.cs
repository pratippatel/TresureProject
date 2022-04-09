using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI[] GemScoreText;
    public int[] GemScoreValue= {0};
    public AudioSource GemCollectSound;
    
    public static GameManager gm;

    // Start is called before the first frame update

    private void Awake()
    {
        gm = this;
    }
    void Start()
    {
        for(int i = 0; i< GemScoreText.Length; i++)
        {
            GemScoreText[i].text = GemScoreValue[i].ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGemScore(int val)
    { // i = 0 is Blue, 1 is Red, 2 is Green
        
        
            GemScoreValue[val] += 1;
            GemScoreText[val].text = GemScoreValue[val].ToString();
        //GemScoreText[0].text = GemScoreValue.ToString();
    } //comments 

}
