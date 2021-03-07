using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorting : MonoBehaviour
{
    private Renderer sRenderer;
    public int sortingOrderBase = 500;
    public int positionOffset;

    // Start is called before the first frame update
    void Start()
    {
        sRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        sRenderer.sortingOrder = (int)(sortingOrderBase - (sRenderer.transform.position.y * 10) - positionOffset);
    }
}
