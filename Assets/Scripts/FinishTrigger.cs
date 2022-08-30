using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public Finish finish;
    public bool left, right;
    public ParticleSystem Confetti;
    [SerializeField] float value =0.75f;

    // Start is called before the first frame update
    void Start()
    {
        finish = transform.parent.parent.GetComponent<Finish>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (transform.name.Equals("FinishFlag"))
        {
            //GameManager.Instance.player.playerState = PlayerState.Stop;
            //GameManager.Instance.player.camera.transform.SetParent(null);
            GameManager.Instance.player.playerPrice.SetActive(false);
            GameManager.Instance.player.isfinished = true;
            GameManager.Instance.player.camera.transform.DOLocalMoveY(1.75f, 1f);
            GameManager.Instance.player.camera.transform.DOLocalMoveX(0f, 1f);
            GameManager.Instance.player.camera.transform.DOLocalMoveZ(-2.599F, 1f);
            GameManager.Instance.player.playerGameObject.transform.DOLocalMoveX(0, 0.025f);
            other.transform.DOLocalMoveY(value, 1f).SetDelay(0.25f).SetRelative(true);

            if (other.name.Equals("PlayerHand"))
            {
                GameManager.Instance.coinsAnimation.AddCoins(GameManager.Instance.coinsAnimation.moneyAnimationSources[1].position, GameManager.Instance.levelPoints);
                GameManager.Instance.vibrationManager.TransientHaptics(0.5f, 0.5f);

            }

        }
        else if (transform.name.Equals("EndTrigger"))
        {
            if (other.name.Equals("PlayerHand"))
            {
                GameManager.Instance.player.playerState = PlayerState.Stop;
                StartCoroutine(MoneyStack());
                GameManager.Instance.vibrationManager.TransientHaptics(0.3f, 0.3f);

            }
        }
        else
        {
            if (!other.name.Equals("PlayerHand"))
            {
                //+finish.characters[transform.GetSiblingIndex()].GetComponent<Animator>().SetTrigger("VictoryTrigger");
                GameManager.Instance.player.stackList.Remove(other.gameObject);
                other.transform.SetParent(null);
                GetComponent<BoxCollider>().enabled = false;
                other.transform.DOJump(finish.targetPositions[transform.GetSiblingIndex()].position, 0.5f,1,0.5f);
               // other.transform.parent = finish.targetPositions[transform.GetSiblingIndex()].GetChild(0).transform;

                //ResetPos(other.transform);
                //Transform Temp = other.transform;
               // other.transform.localPosition = Vector3.zero;
                
                finish.finishCounter++;
                GameManager.Instance.levelPoints += finish.finishCounter;
                GameManager.Instance.coinsAnimation.AddCoins(GameManager.Instance.coinsAnimation.moneyAnimationSources[1].position,finish.finishCounter);
                //PlayerPrefs.SetInt("TOTALCOINS", PlayerPrefs.GetInt("TOTALCOINS") + finish.finishCounter);
                SoundManager.Instance.PlaySound(5);
                GameManager.Instance.vibrationManager.TransientHaptics(0.3f, 0.3f);

                StartCoroutine(ResetPos(finish.targetPositions[transform.GetSiblingIndex()]));
                Confetti.Play();
            }
        }
        
    }

    IEnumerator MoneyStack()
    {
        //for (int i = 0; i < finish.finishCounter; i++)
        //{
        //    finish.moneys[i].SetActive(true);

        //    yield return new WaitForSeconds(0.2f);
        //    SoundManager.Instance.PlaySound(6);
        //    GameManager.Instance.vibrationManager.TransientHaptics(0.3f, 0.3f);


        //}
        finish.moneys[0].SetActive(true);
        finish.moneys[0].transform.DOLocalMoveY(finish.moneys[0].transform.localPosition.y+finish.finishCounter, 2);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.uiManager.InitFinishPanel();
        SoundManager.Instance.PlaySound(8);
        GameManager.Instance.vibrationManager.TransientHaptics(0.3f, 0.3f);
        //AdsManager.Instance.ShowInterstitial();
    }

    IEnumerator ResetPos(Transform GO)
    {
        yield return new WaitForSecondsRealtime(0.3f);
        if (left)
            GO.DOMoveX(-1, 0.5f);
        else
            GO.DOMoveX(1, 0.5f);

    }
}
