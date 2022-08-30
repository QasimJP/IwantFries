using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{

    private GameManager gameManager;

    public ObstacleType obstacleType;

    public bool isCatch;

    [Header("Hand Obstacle")] [SerializeField]
    private Transform drinkPosition;
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameManager.Instance;

        switch (obstacleType)
        {
            case ObstacleType.HandRight:
                transform.DOMoveX(-0.8f, 0.5f).SetLoops(-1,LoopType.Yoyo).SetRelative(true);
                break;
            case ObstacleType.TurningPlatformLeft:
                break;
            case ObstacleType.TurningPlatformRight:
                break;
            case ObstacleType.DownFall:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCatch)
        {
            if (!other.name.Equals("PlayerHand"))
            {
                var catchedIndex = gameManager.player.stackList.IndexOf(other.gameObject);

                switch (obstacleType)
                {
                    case ObstacleType.HandRight:
                        GetComponentInChildren<Animator>().SetTrigger("HandCatchTrigger");
                        other.transform.DOKill();
                        other.transform.SetParent(drinkPosition);
                        other.transform.localPosition = new Vector3(0, 0, 0);
                        transform.DOKill();
                        transform.DOMoveX(1, 0.5f).SetRelative(true);
                        break;
                    case ObstacleType.DownFall:

                        //other.transform.DOKill();
                        //other.transform.SetParent(null);
                        //other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                        //Destroy(other.gameObject,1.2f);
                        //gameManager.player.stackList.RemoveAt(catchedIndex);
                        DownFall(other.gameObject,catchedIndex);
                        
                        // other.GetComponent<Drink>().DestroyObj();
                        break;
                    case ObstacleType.TurningPlatformLeft:
                        //transform.DOLocalMoveY(-0.8f, 0.5f).SetRelative(true);
                        //Destroy(other.gameObject);

                        other.GetComponent<Drink>().DestroyObj();
                        break;
                    case ObstacleType.TurningPlatformRight:
                        transform.DOLocalMoveX(0.8f, 0.5f).SetRelative(true);
                        //Destroy(other.gameObject);
                        other.GetComponent<Drink>().DestroyObj();

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                if (obstacleType != ObstacleType.DownFall)
                {
                    Catched(other.gameObject, catchedIndex);
                    isCatch = true;
                }
                gameManager.vibrationManager.TransientHaptics(0.3f, 0.3f);
                SoundManager.Instance.PlaySound(7);

            }
        }
    }
    void DownFall(GameObject other,int catchedIndex) 
    {
        if (catchedIndex == 0 && gameManager.player.stackList.Count != 0)
        {
            if (catchedIndex == 0)
            {
                gameManager.player.stackList.RemoveAt(0);

            }
            else
            {
                gameManager.player.stackList.RemoveAt(gameManager.player.stackList.IndexOf(other.gameObject));

            }
            StartCoroutine(AfterCatched(gameManager.player.stackList[0]));
            //return;
            Debug.LogError("in If Statment");
            //gameManager.player.stackList.RemoveAt(catchedIndex);
        }
        else
        {
            other.transform.DOKill();
            other.transform.SetParent(null);
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameManager.player.stackList.RemoveAt(catchedIndex);
            Destroy(other.gameObject, 1.2f);
            Debug.LogError("in ELse Statement");
        }
    }
    public void Catched(GameObject catched,int catchedIndex)
    {
        if (catchedIndex == 0)
        {
            gameManager.player.stackList.RemoveAt(0);

        }
        else
        {
            gameManager.player.stackList.RemoveAt(gameManager.player.stackList.IndexOf(catched.gameObject));

        }



        if (catchedIndex == 0 && gameManager.player.stackList.Count==0)
        {
            StartCoroutine(AfterOneCatched());
            //return;
        }
        else if (catchedIndex == 0 && gameManager.player.stackList.Count != 0)
        {
            StartCoroutine(AfterCatched(gameManager.player.stackList[0]));
            //return;
        }
        else if (catchedIndex!= gameManager.player.stackList.Count)
        {
            StartCoroutine(AfterCatched(gameManager.player.stackList[catchedIndex-1]));

        }
        else if (catchedIndex == gameManager.player.stackList.Count)
        {
            StartCoroutine(AfterCatched(gameManager.player.stackList[catchedIndex-1]));

        }



    }

    public IEnumerator AfterOneCatched()
    {
        gameManager.player.playerState = PlayerState.Stop;
        gameManager.player.transform.DOMoveZ(-1, 1, false).SetRelative(true);

        yield return new WaitForSeconds(1);

        gameManager.player.playerState = PlayerState.Move;

    }

    public IEnumerator AfterCatched(GameObject catched)
    {
        gameManager.player.playerState = PlayerState.Stop;
        gameManager.player.transform.DOMoveZ(-1, 1, false).SetRelative(true);
        List<GameObject> catchedObjects = new List<GameObject>();
        var stackLimit = gameManager.player.stackList.Count;

        if (gameManager.player.stackList!=null)
        {
            if (gameManager.player.stackList.IndexOf(catched) != stackLimit - 1)
            {
                for (int j = gameManager.player.stackList.IndexOf(catched); j < stackLimit; j++)
                {
                    var outsideObject = gameManager.player.stackList.Last();
                    gameManager.player.stackList.Remove(gameManager.player.stackList.Last());
                    catchedObjects.Add(outsideObject);
                    outsideObject.transform.SetParent(null);
                    outsideObject.transform.DOMoveX(Random.Range(-0.35f, 0.35f), 0.5f).SetEase(Ease.OutQuad);
                    outsideObject.transform.DOMoveZ(Random.Range(-0.35f, 0.35f), 0.5f).SetRelative(true).SetEase(Ease.OutQuad);
                }
            }
        }





        yield return new WaitForSeconds(1);

        gameManager.player.playerState = PlayerState.Move;
        catchedObjects.ForEach(x => x.GetComponent<Drink>().drinkType = DrinkType.outsideStack);

    }
}

public enum ObstacleType
{
    HandRight,
    TurningPlatformLeft,
    TurningPlatformRight,
    DownFall
}