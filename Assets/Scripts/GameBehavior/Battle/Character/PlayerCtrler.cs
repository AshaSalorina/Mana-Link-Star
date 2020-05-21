using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrler : MonoBehaviour
{
    public GameObject Charactor;

    public Animator CharactorAnimator;

    private float speed = 1;


    void Start()
    {
        charactorX = Charactor.transform.right;
        charactorZ = Charactor.transform.forward;
    }

    private Vector3 charactorX;
    private Vector3 charactorZ;

    public float Speed { get => speed; set => speed = value; }

    private void FixedUpdate()
    {

        var isMove = false;
        var highSpeed = false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            highSpeed = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Charactor.transform.localPosition += charactorZ * Time.fixedDeltaTime * (highSpeed ? 2f : 1) * speed;
            isMove = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Charactor.transform.localPosition += -charactorX * Time.fixedDeltaTime * (highSpeed ? 2f : 1) * speed;
            isMove = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Charactor.transform.localPosition += -charactorZ * Time.fixedDeltaTime * (highSpeed ? 2f : 1) * speed;
            isMove = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Charactor.transform.localPosition += charactorX * Time.fixedDeltaTime * (highSpeed ? 2f : 1) * speed;
            isMove = true;
        }
        CharactorAnimator.SetBool("inmove", isMove);
    }

}
