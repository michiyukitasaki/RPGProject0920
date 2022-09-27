using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{

    private NavMeshAgent nav;
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;

    private float x;
    private float z;
    private float velocitySpeed;

    CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 pos;
    private Vector3 currPos;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currPos = ct.m_FollowOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //移動速度の計算
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;

        //マウス位置取得
        pos = Input.mousePosition;
        //視点のオフセット指定
        ct.m_FollowOffset = currPos;

        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                nav.destination = hit.point;
            }
        }

        //アイドル⇄スプリント
        if(velocitySpeed != 0)
        {
            anim.SetBool("sprinting", true);
        }
        if (velocitySpeed == 0)
        {
            anim.SetBool("sprinting", false);
        }

        //右クリックで視点オフセットを更新
        if(Input.GetMouseButton(1))
        {
            if(pos.x != currPos.x || pos.z != currPos.z)
            {
                currPos = pos / 200;
            }
        }
    }
}
