using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite damageSprite;
    public int hitPoints = 4;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        if (hitPoints == 2)
        {
            spriteRenderer.sprite = damageSprite;
        }
        hitPoints -= loss;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
