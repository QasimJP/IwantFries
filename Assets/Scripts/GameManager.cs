using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject DollarInstant, DollarInstantParent;
    public ParticleSystem CashSplash;
    public CoinsAnimation coinsAnimation;
    public Player player;
    public UIManager uiManager;
    public VibrationManager vibrationManager;
    public bool isPickedUp,scaleMotion;

    public int levelPoints = 1;
    public TextMeshPro levelPointsText;
    public int selledPoints;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        levelPointsText.text = levelPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!scaleMotion)
        {
            if (isPickedUp)
            {
                StartCoroutine(ScaleMotion());

            }

        }
    }

    IEnumerator ScaleMotion()
    {
        scaleMotion = true;
        yield return new WaitForSeconds(0.05f);
        for (int i = player.stackList.Count - 1; i >= 0; i--)
        {
            player.stackList[i].transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(0.1f);
        }
        isPickedUp = false;
        scaleMotion = false;
    }

    public void ResetStack()
    {
        player.stackList.Clear();
        foreach (Transform child in player.playerStack.transform)
        {
            child.transform.localPosition = new Vector3(child.transform.localPosition.x, child.transform.localPosition.y, 1 + (player.stackList.Count * 0.15f));

        }
    }

    public void AddPoints(int i)
    {
        levelPoints += i;
        levelPointsText.text = levelPoints.ToString();
    }


    public void Restartlevel() 
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
