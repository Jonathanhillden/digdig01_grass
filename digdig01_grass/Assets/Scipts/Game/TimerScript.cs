using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public static float timerValue = 0;
    Text timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timerValue += 1 * Time.deltaTime;
        timer.text = "Time: " + timerValue.ToString ("0");
    }

}