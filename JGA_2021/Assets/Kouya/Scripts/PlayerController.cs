using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    float xSpeed = 0.0f;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xSpeed = speed;
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));


        //最初の移動から一定速度
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            transform.position = new Vector3(
            transform.position.x + Input.GetAxis("Horizontal") * xSpeed,
            transform.position.y,
            transform.position.z);
        }

        //Debug.Log(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))

        //現在の遷移がAttackじゃない時移動アニメーション  
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            //スティックがニュートラルの時以外走る
            if (Input.GetAxis("Horizontal") != 0)
            {
                animator.SetBool("Move", true);
            }
            else
            {
                animator.SetBool("Move", false);
            }

            //左に入力したら180度回転
            if (Input.GetAxis("Horizontal") < 0)
            {
                // ローカル座標を基準に、回転を取得
                Vector3 localAngle = transform.localEulerAngles;
                localAngle.y = 270.0f; // ローカル座標を基準に、y軸を軸にした回転を270度に変更
                transform.localEulerAngles = localAngle; // 回転角度を設定
            }
            //右に入力したら180度回転
            if (Input.GetAxis("Horizontal") > 0)
            {
                // ローカル座標を基準に、回転を取得
                Vector3 localAngle = transform.localEulerAngles;
                localAngle.y = 90.0f; // ローカル座標を基準に、y軸を軸にした回転を-90度に変更
                transform.localEulerAngles = localAngle; // 回転角度を設定
            }
        }

        //R1を押すと攻撃
        if (Input.GetButtonDown("R1")
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("Attack");
        }
    }
}
