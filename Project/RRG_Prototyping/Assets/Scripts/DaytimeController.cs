using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DaytimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nighTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;

    [SerializeField] Text text;
    [SerializeField] Light2D globalLight;
    float time;
    [SerializeField] float timeScale;
    private int days;

    float hours 
    {
        get { return time / 3600; }
    }

    float minutes 
    {
        get { return time % 3600 / 60f; }
    }

    private void Update()
    {
        int hh = (int)hours;
        int mm = (int)minutes;
        time += Time.deltaTime *timeScale;

        text.text = hh.ToString("00") + ":" + mm.ToString("00");
        float v = nighTimeCurve.Evaluate(hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;

        if (time > secondsInDay) { NextDay(); }
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
