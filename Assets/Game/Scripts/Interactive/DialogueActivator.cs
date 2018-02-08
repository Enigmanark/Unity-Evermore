using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogueActivator : MonoBehaviour {
    private Flowchart flowChart;
    private bool onDelay = false;
    private float delayTimer = 0f;

	// Use this for initialization
	void Start () {
        flowChart = GetComponent<Flowchart>();
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!onDelay)
            {
                if (Input.GetButton("Fire1"))
                {
                    flowChart.ExecuteBlock("Start");
                }
            }
        }
    }

    public void Delay()
    {
        onDelay = true;
    }

    // Update is called once per frame
    void Update () {
		if(onDelay)
        {
            delayTimer += Time.deltaTime;
            if(delayTimer >= 0.5f)
            {
                onDelay = false;
                delayTimer = 0f;
            }
        }
	}
}
