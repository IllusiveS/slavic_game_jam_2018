﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public float time_limit_seconds;

    public Waiter[] waiters;
    public Text[] waiters_points_view;
    public Text timer_view;

    public GameObject ending_handler;

    static private int[] m_results;

    private float current_time;
    private bool reached_end;

    public GameState() : base()
    {
      m_results = new int[4];
    }

    // Use this for initialization
    void Start()
    {
        Debug.Assert(waiters.Length == waiters_points_view.Length);

        for (int i = 0; i < m_results.Length; ++i) {
            m_results[i] = 0;
        }

        current_time = time_limit_seconds;
        ending_handler.SetActive(false);
        reached_end = false;

    }
	// Update is called once per frame
	void Update() {
    if (reached_end)
      return;

    current_time -= Time.deltaTime;

    if (current_time <= 0) {
      current_time = 0;
      ending_handler.SetActive(true);
      EndingScreen.SetResults(new int[]{
        waiters[0].collectedTip, 
        waiters[1].collectedTip,
        waiters[2].collectedTip,
        waiters[3].collectedTip});
      reached_end = true;
    }
	}

  private void OnGUI()
  {
    for (int i = 0; i < waiters_points_view.Length; ++i) {
      waiters_points_view[i].text = waiters[i].collectedTip.ToString();
    }

    timer_view.text = FormatTime(current_time);
  }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time) / 60;
        int seconds = Mathf.FloorToInt(time);
        int miliseconds = Mathf.FloorToInt((time - (float)seconds) * 1000);

        seconds %= 60;

        return string.Format("{0:00}:{1:00}.{2:000}",
          minutes, seconds, miliseconds);
    }
}