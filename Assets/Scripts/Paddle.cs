using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX=15f;
    //camera size:6(half) 12*4/3 =16 
    [SerializeField] float screenWidthInUnits = 16f;

    // Update is called once per frame
    void Update()
    {

        float mouse = (Input.mousePosition.x / Screen.width * 16f);
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        //mathf.clamp ile kısıtladık normal şartlarda -2 -16 arası gidiyordu buda paddle'nin kaybolmasına neden oluyordu bu yüzden kısıtladık
        paddlePos.x = Mathf.Clamp(mouse, minX, maxX);
        transform.position = paddlePos;
    }
}
