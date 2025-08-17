using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CoinAnimation2 : MonoBehaviour
{


    public GameObject coinPrefab;   
    public Transform spawnPoint;    
    public Transform target;        
    public int coinCount = 10;      
    public float flyDuration = 0.5f;

    public void CollectCoins()
    {
        for (int i = 0; i < coinCount; i++)
        {
            int index = i; 

     
            GameObject coin = Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);

            coin.transform.DOMove(target.position, flyDuration)
                .SetEase(Ease.InQuad)
                .SetDelay(index * 0.25f) 
                .OnComplete(() => Destroy(coin));
        }
    }
}
