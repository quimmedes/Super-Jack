using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour


{

    private CapsuleCollider2D collider2D;
    public UnityEngine.UI.Text coinScore;
    public Sprite sprite;
    // Start is called before the first frame update
    void Awake()
    {
        collider2D = GetComponent<CapsuleCollider2D>();

        
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            if (coinScore != null)
                coinScore.text = "" + (int.Parse(coinScore.text) + 1);
        }

        if (collision.gameObject.CompareTag("gold"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
