using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class Drink : MonoBehaviour
{
    private GameManager gameManager;

    public DrinkType drinkType;

    //[SerializeField] private GameObject liquid;
    //[SerializeField] private GameObject straw;

    //[SerializeField] private List<GameObject> fruits = new List<GameObject>();

    public List<DrinkProperties> drinkProperties = new List<DrinkProperties>();
    [SerializeField]
    ParticleSystem DestroyParticl;
    public int drinkLevel=0;

    [SerializeField]
    private int _coins;
    public int coins
    {
        get { return _coins; }
        set { _coins += value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameManager.Instance;
        coins = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void AddValue(int value) 
    {
        GameObject Dollar = Instantiate(GameManager.Instance.DollarInstant, GameManager.Instance.DollarInstantParent.transform) as GameObject;
        Dollar.transform.GetChild(0).GetComponent<TextMeshPro>().text = value.ToString();
        Dollar.SetActive(true);
        GameManager.Instance.DollarInstantParent.transform.DOPunchScale(Vector3.zero, 0.1f);
        GameManager.Instance.CashSplash.Play();
        SoundManager.Instance.PlayCashSound();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Drink>()?.drinkType == DrinkType.outsideStack)
        {
            other.transform.SetParent(gameManager.player.playerStack.transform);
            other.transform.localPosition = new Vector3(other.transform.localPosition.x, other.transform.localPosition.y, 1 + (gameManager.player.stackList.Count * 0.28f));
            gameManager.player.stackList.Add(other.transform.gameObject);
            other.GetComponent<Drink>().drinkType = DrinkType.inStack;
            gameManager.isPickedUp = true;
            AddValue(1);
            gameManager.AddPoints(1);
            //drinkPoints = 1;

            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(0);
        }

        if (other.CompareTag("Cheez"))
        {
            drinkProperties[drinkLevel].Cheese.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(2);
            coins = 4;
            AddValue(4);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(1);

        }

          

        else if (other.CompareTag("Baking"))
        {
            drinkProperties[drinkLevel].MeltCheese.SetActive(true);
            drinkProperties[drinkLevel].BakedFries.SetActive(true);
            drinkProperties[drinkLevel].Cheese.SetActive(false);
            drinkProperties[drinkLevel].Fires.SetActive(false);

            transform.DOScale(1.3f, 0.1f).SetLoops(2, LoopType.Yoyo);
            //drinkProperties[drinkLevel].Fires.GetComponent<Renderer>().material.mainTexture = drinkProperties[drinkLevel].FiresBackTexture;
            gameManager.AddPoints(3);
            coins = 5;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("Fries"))
        {
            drinkProperties[drinkLevel].Fires.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            //Debug.LogError("Other Collider Name "+ other.name);
            gameManager.AddPoints(3);
            coins = 2;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("Mayo"))
        {
            drinkProperties[drinkLevel].Mayo.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 3;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("Katchup"))
        {
            drinkProperties[drinkLevel].Katchup.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 3;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("Flies"))
        {
            drinkProperties[drinkLevel].Flies.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 3;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("MacBucket"))
        {
            drinkProperties[drinkLevel].MacBucket.SetActive(true);
            drinkProperties[drinkLevel].PlainBucket.SetActive(false);
            drinkProperties[drinkLevel].BurnedBucket.SetActive(false);
            drinkProperties[drinkLevel].LoadedBucket.SetActive(false);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 3;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("LoadedBucket"))
        {
            drinkProperties[drinkLevel].MacBucket.SetActive(false);
            drinkProperties[drinkLevel].PlainBucket.SetActive(false);
            drinkProperties[drinkLevel].BurnedBucket.SetActive(false);
            drinkProperties[drinkLevel].LoadedBucket.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 3;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("BurnedBucket"))
        {
            drinkProperties[drinkLevel].MacBucket.SetActive(false);
            drinkProperties[drinkLevel].PlainBucket.SetActive(false);
            drinkProperties[drinkLevel].BurnedBucket.SetActive(true);
            drinkProperties[drinkLevel].LoadedBucket.SetActive(false);
            drinkProperties[drinkLevel].BakedFries.SetActive(false);
            drinkProperties[drinkLevel].Fires.SetActive(false);
            drinkProperties[drinkLevel].Cheese.SetActive(false);
            drinkProperties[drinkLevel].MeltCheese.SetActive(false);
            drinkProperties[drinkLevel].Jalypeno.SetActive(false);
            drinkProperties[drinkLevel].Mayo.SetActive(false);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 3;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("Jalypenos"))
        {
            drinkProperties[drinkLevel].Jalypeno.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 4;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("Lizard"))
        {
            drinkProperties[drinkLevel].Lizards.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 3;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("cockroch"))
        {
            drinkProperties[drinkLevel].Cockroch.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 3;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.CompareTag("Olives"))
        {
            drinkProperties[drinkLevel].Olives.SetActive(true);
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            gameManager.AddPoints(3);
            coins = 3;
            AddValue(3);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(2);

        }
        else if (other.name.Equals("OrangeFruitTriger"))
        {
            drinkProperties[drinkLevel].fruits.ForEach(x=>x.SetActive(false));
            transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            drinkProperties[drinkLevel].fruits[0].SetActive(true);
            gameManager.AddPoints(4);
            coins = 4;
            AddValue(4);
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(3);

        }
        else if (other.name.Equals("StrawberryFruitTriger"))
        {
            drinkProperties[drinkLevel].fruits.ForEach(x => x.SetActive(false));
            drinkProperties[drinkLevel].fruits[1].SetActive(true);
            gameManager.AddPoints(4);
            coins = 4;

            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(3);

        }
        else if (other.name.Equals("ChangerTrigger"))
        {
            ChangeLevel();
            gameManager.AddPoints(5);
            coins = 5;

            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
            SoundManager.Instance.PlaySound(4);

        }
        else if (other.name.Equals("SellTriggerRight"))
        {
            //transform.DOKill();
            //transform.SetParent(null);
            //gameManager.player.stackList.RemoveAt(gameManager.player.stackList.IndexOf(gameObject));
            //transform.DOMoveX(1f, 1f).SetRelative(true).SetEase(Ease.Linear);

            //gameManager.player.stackList[gameManager.player.stackList.Count-1].transform.DOKill();
            //gameManager.player.stackList[gameManager.player.stackList.Count-1].transform.SetParent(null);
            //gameManager.player.stackList[gameManager.player.stackList.Count-1].transform.position=other.transform.position;
            //gameManager.player.stackList[gameManager.player.stackList.Count-1].transform.DOMoveX(1f, 1f).SetRelative(true).SetEase(Ease.Linear);
            //gameManager.player.stackList.RemoveAt(gameManager.player.stackList.IndexOf(gameManager.player.stackList[gameManager.player.stackList.Count - 1]));

            //gameManager.AddPoints(6);

            var selledObject = gameManager.player.stackList[gameManager.player.stackList.Count - 1].transform;
            selledObject.DOKill();
            selledObject.SetParent(null);
            selledObject.position = other.transform.parent.GetComponent<SellMachine>().selledPosition.position;
            selledObject.DOMoveX(1f, 1f).SetRelative(true).SetEase(Ease.Linear);
            gameManager.player.stackList.RemoveAt(gameManager.player.stackList.IndexOf(selledObject.gameObject));
            gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);

            gameManager.selledPoints += coins;
            gameManager.coinsAnimation.AddCoins(GameManager.Instance.coinsAnimation.moneyAnimationSources[2].position, coins);
            gameManager.levelPoints -= coins;
            gameManager.levelPointsText.text = gameManager.levelPoints.ToString();
            SoundManager.Instance.PlaySound(5);

        }
        else if (other.name.Equals("PlayerHand"))
        {
            if (gameManager.player.stackList.Count == 0)
            {
                if (GetComponent<Drink>()?.drinkType == DrinkType.outsideStack)
                {
                    transform.SetParent(gameManager.player.playerStack.transform);
                    transform.localPosition = new Vector3(0, transform.localPosition.y, 1 + (gameManager.player.stackList.Count * 0.15f));
                    gameManager.player.stackList.Add(transform.gameObject);
                    GetComponent<Drink>().drinkType = DrinkType.inStack;
                    gameManager.isPickedUp = true;
                    gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);

                }
            }
        }

    }

    IEnumerator ScaleMotion()
    {
        yield return new WaitForSeconds(0.05f);
        for (int i = gameManager.player.stackList.Count - 1; i >= 0; i--)
        {
            gameManager.player.stackList[i].transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
            yield return new WaitForSeconds(0.1f);
        }
        //isPickedUp = true;

    }

    void ChangeLevel()
    {
        drinkProperties[drinkLevel].type.SetActive(false);

        drinkLevel++;
        drinkProperties[drinkLevel].type.SetActive(true);
        transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo);
    }

    public void DestroyObj() 
    {
        transform.parent = null;
        drinkProperties[drinkLevel].type.SetActive(false);
        DestroyParticl.gameObject.SetActive(true);
        DestroyParticl.Play();
        Destroy(this.gameObject, 1.5f);
    }
}

public enum DrinkType
{
    inStack,
    outsideStack
}

[Serializable]
public class DrinkProperties
{
    public GameObject type;
    public GameObject PlainBucket, MacBucket, LoadedBucket, BurnedBucket;
    public GameObject Cheese;
    public GameObject MeltCheese;
    public GameObject Fires;
    public GameObject BakedFries;
    public GameObject Jalypeno;
    public GameObject Olives;
    public GameObject Mayo, Katchup;
    public GameObject Lizards, Cockroch, Flies;

    //public Texture FiresBackTexture;


    public List<GameObject> fruits = new List<GameObject>();
}