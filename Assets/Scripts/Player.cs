//using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerState playerState;

    [SerializeField] public bool isTouching;

    [SerializeField] private float controlSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float touchPosX;

    public GameObject playerGameObject;
    public GameObject playerStack;
    public GameObject playerPrice;
    public GameObject camera;

    public List<GameObject> stackList = new List<GameObject>();

    public bool isfinished;


    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        controlSpeed = 2;
#endif
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();
        MoveWavely();
        
    }

    private void FixedUpdate()
    {
        if (playerState==PlayerState.Move)
        {
            transform.localPosition += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
            if (isTouching && !isfinished)
            {

                touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
                playerGameObject.transform.localPosition = new Vector3(Mathf.Clamp(touchPosX,-0.335f,0.392f), playerGameObject.transform.localPosition.y, playerGameObject.transform.localPosition.z);

            }
        }

        

        
    }

    void GetInput()
    {

        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }

    void MoveWavely()
    {
        if (stackList != null)
        {
            for (int i = stackList.Count - 1; i >= 1; i--)
            {
                stackList[i].transform.DOMoveX(stackList[i - 1].transform.position.x, 0.1f);
            }
        }
    }
}

public enum PlayerState
{
    Stop,
    Move
}