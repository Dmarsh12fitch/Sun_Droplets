using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float holding = 0;
    public float holdingCap = 3;
    public GameObject GameController;
    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (holding > holdingCap) { holding = holdingCap; }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0)) //move left or right based on mouse/tap position
        {
            if (Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition).x > 0)
            {
                this.transform.position = new Vector2(this.transform.position.x + speed, this.transform.position.y);
            }
            else
            {
                this.transform.position = new Vector2(this.transform.position.x - speed, this.transform.position.y);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Cart")
        {
            GameController.GetComponent<GameController>().cartHolding += holding;
            holding = 0;
        }

        if (coll.gameObject.tag == "Rain")
        {
            Destroy(coll.gameObject);
            holding += 1;
        }
    }
}
