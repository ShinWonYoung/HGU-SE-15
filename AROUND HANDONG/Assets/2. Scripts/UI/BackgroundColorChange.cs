﻿using UnityEngine;
using System.Collections;

public class BackgroundColorChange : MonoBehaviour {

    private Camera _camera;

    private Color[] _color = new Color[4];

    private int[,] rgbValues = new int[4, 4] { { 171, 236, 236, 5 }, { 0xF1, 0xBC, 0xBC, 0x00 }, { 0xAB, 0xEC, 0xEC, 0x05 }, { 0xF9, 0xC3, 0x92, 0x00 } };
    private float _timer = 0.0f;

    private float timeValue = 15.0f;

    private int _currColor = 0;

    void Start()
    {
        for( int i = 0; i < 4; i++ )
        {
            _color[i] = new Color(rgbValues[i, 0] / 255.0f, rgbValues[i, 1] / 255.0f, rgbValues[i, 2] / 255.0f, rgbValues[i, 3] / 255.0f);
        }
        _currColor = 0;
        _camera = GetComponent<Camera>();
        _camera.backgroundColor = _color[_currColor];
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (timeValue < _timer)
        {
            Color color1 = _color[_currColor];
            _currColor = (_currColor + 1) % 4;
            Color color2 = _color[_currColor];
            _camera.backgroundColor = Color.Lerp(color1, color2, 3.0f);
            timeValue += 15.0f;
        }
    }
}