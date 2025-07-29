using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RewardManger : MonoBehaviour
{

    // Coins Parent  => Empty Game Object with Children of 10
    [SerializeField] private GameObject CoinsParent;

    // Text value of coins
    [SerializeField] private Text coinsText;

    // Initial Position of coins
   [SerializeField] private Vector3[] InitialPos;

    //  // Initial Rotation of coins
    [SerializeField]private Quaternion[] InitialRotation;

    // no of coins
    [SerializeField] private int noofCoin;





    private void Start()
    {
        // create array of initail position & rotation wich store value for both after the loop
        InitialPos = new Vector3[noofCoin];
        InitialRotation = new Quaternion[noofCoin];


        //// Loop through coins parent to get all child save initial position or rotaion
        for (int i = 0; i < CoinsParent.transform.childCount; i++)
        {


            InitialPos[i] = CoinsParent.transform.GetChild(i).position;
            InitialRotation[i] = CoinsParent.transform.GetChild(i).rotation;
        }

       
    }


    private void reset()
    {
        // restore to its orginal position

        for(int i = 0; i < CoinsParent.transform.childCount; i++)
        {
            CoinsParent.transform.GetChild(i).position = InitialPos[i];
            CoinsParent.transform.GetChild(i).rotation = InitialRotation[i];
        }
        
    }


    public void CoinsReward(int noCoins)
    {
        reset();

        // delay  for coins to spawn

        var CoinsDelay = 0f;


        CoinsParent.SetActive(true);

        // loop through all child

        for(int i = 0; i < CoinsParent.transform.childCount; i++)
        {

            // every child scale goes 0 to 1 in 0.3 second /  setdaly use to scale coins after one coins scale turn to 1/ add easeing 
            CoinsParent.transform.GetChild(i).DOScale(1f, 0.3f).SetDelay(CoinsDelay).SetEase(Ease.OutBack);

            // coins final position / when coin reach its position then coin txt increase

            CoinsParent.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(new Vector2(361f, 890f), 0.5f).SetDelay(CoinsDelay +0.8f).SetEase(Ease.InBack).OnComplete(CountCoins);

            // coins rotation goes to 0
            CoinsParent.transform.GetChild(i).DORotate(Vector3.zero, 0.5f).SetDelay(CoinsDelay + 0.5f).SetEase(Ease.Flash);
            // coins scale goes to 0 after reaching its position
            CoinsParent.transform.GetChild(i).DOScale(0f, 0.3f).SetDelay(CoinsDelay + 1.8f).SetEase(Ease.OutBack);

            // increase delay after every coins animation works
            CoinsDelay += 0.1f;

        }
        //StartCoroutine(CountCoins(10));

    }


    private void CountCoins()
    {

        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);

           coinsText.text= PlayerPrefs.GetInt("coin").ToString();
    }



}
