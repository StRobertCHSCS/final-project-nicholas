using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite damageSprite;
    public int hitPoints = 4;

    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        spriteR.sprite = damageSprite;
        hitPoints -= loss;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
