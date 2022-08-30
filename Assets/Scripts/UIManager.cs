using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Tabtale.TTPlugins;


public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    public LevelManager LvlManager;
    public GameObject startPanel,levelCompletedPanel;
    public TextMeshProUGUI levelCompletedScore, levelcompeletedRewardedScore;


    public void StartGame()
    {

        gameManager.player.playerState = PlayerState.Move;
        startPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
       // ByteBrew.InitializeByteBrew();
        gameManager=GameManager.Instance;
        // ByteBrew.NewProgressionEvent(ByteBrewProgressionTypes.Started, "Level_Start","Level"+ LvlManager.currentLevel.ToString()); 
        //TTPAppsFlyer.LogEvent("Level Progression",)
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InitFinishPanel()
    {
        levelCompletedPanel.SetActive(true);
        levelCompletedScore.text = (gameManager.selledPoints+gameManager.levelPoints).ToString()+" $";
        levelcompeletedRewardedScore.text =(5* (gameManager.levelPoints+ gameManager.selledPoints)).ToString()+" $";

        //ByteBrew.NewProgressionEvent(ByteBrewProgressionTypes.Started, "Level_Complete", "Level" + LvlManager.currentLevel.ToString());

    }

    //public void Rewarded()
    //{
    //    PlayerPrefs.SetInt("TOTALCOINS",PlayerPrefs.GetInt("TOTALCOINS")+ (5 * gameManager.levelPoints)+gameManager.selledPoints);
    //    PlayerPrefs.SetInt("CURRENTLEVEL", PlayerPrefs.GetInt("CURRENTLEVEL")+1);
    //    SceneManager.LoadScene(0);
    //}

    public void NoThanks()
    {
        PlayerPrefs.SetInt("TOTALCOINS", PlayerPrefs.GetInt("TOTALCOINS") + (gameManager.levelPoints) + gameManager.selledPoints);
        PlayerPrefs.SetInt("CURRENTLEVEL", PlayerPrefs.GetInt("CURRENTLEVEL") + 1);
        SceneManager.LoadScene(0);
    }
}
