using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float cartCap = 10;
    public float cartHolding = 0;
    public float minDelay = 1;
    public float maxDelay = 2;
    public GameObject Player;
    public GameObject rainPre;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(randomRain());
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (cartHolding > cartCap) { cartHolding = cartCap; }
    }

    public IEnumerator randomRain()
    {
        Instantiate(rainPre, new Vector2(Random.Range(-8.5f, 8.5f), 8), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        StartCoroutine(randomRain());
    }
}