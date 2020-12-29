using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoadingScript : MonoBehaviour
{
    public Transform midPoint;
    public float bottomOfImgY;
    private SpriteRenderer spriteRenderer;

    private float maxLoadHeight = 0.58f;

    private float loadVal = 0f; public void setLoadVal(float v) { loadVal = v; }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loadVal > 0f)
        {
            gameObject.transform.localPosition.Set(gameObject.transform.localPosition.x
                , midPoint.localPosition.y + ((bottomOfImgY - midPoint.localPosition.y) * loadVal)
                , gameObject.transform.localPosition.z);

            spriteRenderer.size.Set(0.27f, (1f / maxLoadHeight) * loadVal);

            //gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
