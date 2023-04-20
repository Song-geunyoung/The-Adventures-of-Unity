using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Animator Song;
    public Rigidbody rbody;

    private float inputH;
    private float inputV;
    private bool run;
    private bool jump;

	// Use this for initialization
	void Start () {
        Song = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        run = false;
        jump = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        Song.SetFloat("inputH", inputH);
        Song.SetFloat("inputV", inputV);
        Song.SetBool("run", run);
        Song.SetBool("jump", jump);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        if (moveZ <= 0f)
        {
            moveX = 0f;
        }

        else if (run)
        {
            moveX *= 5f;
            moveZ *= 5f;
        }

        rbody.velocity = new Vector3(moveX, 0f, moveZ);

        if (Input.GetKey(KeyCode.Space))
            Song.SetBool("jump", true);
        else
            Song.SetBool("jump", false);
    }
}
