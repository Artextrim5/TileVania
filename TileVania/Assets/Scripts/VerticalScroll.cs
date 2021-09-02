using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{

    [Tooltip ("Game Units per second")]
    [SerializeField] float scrollRate = 0.2f;

    private void Update()
    {
        transform.Translate(new Vector2(0f, scrollRate * Time.deltaTime));
    }

}
