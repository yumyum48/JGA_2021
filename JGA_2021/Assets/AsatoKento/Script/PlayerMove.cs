using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float jumpPower = 2;
    [SerializeField] private float MoveSpeed = 5;
    private float MovePosition;
    private CharacterController ch;
    private Vector3 vc3;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        ch = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (ch.isGrounded)
        {
            if (Input.GetKeyDown("space"))
            {
                //rb.AddForce(Vector3.up * 200);
                //ch.SimpleMove(new Vector3(0,100,0));
                vc3.y = jumpPower;
            }

            MovePosition = Input.GetAxis("Horizontal");

            vc3.x = MoveSpeed * MovePosition;

        }

        vc3.y += Physics.gravity.y * Time.deltaTime; //常にY座標の分だけ動かす(重力処理)
        ch.Move(vc3 * Time.deltaTime);
        anim.SetFloat("MoveSpeed", vc3.x);
        anim.SetFloat("BackSpeed", -vc3.x);
    }

}