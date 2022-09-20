using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField]
    private Difficulty diff;

    private AudioSource audioSrc;

    [SerializeField]
    private float force = 3500f;

    Rigidbody rb;
    [SerializeField]
    CapsuleCollider normalColl, jumpColl;
    [SerializeField]
    private float leftright_speed;

    private Animator anim;

    private int laneNumber = 1, lanesCount = 2;

    [SerializeField]
    private float FirstLanePos, LaneDistance, SideSpeed;

    private void Awake()
    {
        normalColl.enabled = true;
        jumpColl.enabled = false;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SideSpeed = diff.SideSpeed;
        //if (Input.GetKeyDown(KeyCode.D))
        //    ChangeLine(1);

        //if (Input.GetKeyDown(KeyCode.A))
        //    ChangeLine(-1);

        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Lerp(playerPos.x, FirstLanePos + (laneNumber * LaneDistance), Time.deltaTime * SideSpeed);
        transform.position = playerPos;

        


        //bool is_ground = Ground.Is_ground;
        //if (Input.GetKeyDown(KeyCode.Space) && (is_ground))
        //{
        //    StartCoroutine(DoJump());
        //}
    }

    public void ChangeLine(int direction)
    { 

            laneNumber += direction;
            laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);
    }


    public IEnumerator DoJump()
    {
        anim.SetBool("jump", true);

        rb.AddForce(Vector3.up * force);
        audioSrc.Play();
        //поменять коллайдеры
        jumpColl.enabled = true;
        yield return new WaitForSeconds(0.2f);//решение конфликта с OnCollisionExit
        normalColl.enabled = false;

        yield return new WaitForSeconds(0.5f);
        jumpColl.enabled = false;
        normalColl.enabled = true;
        anim.SetBool("jump", false);
        yield break;
    }

}
