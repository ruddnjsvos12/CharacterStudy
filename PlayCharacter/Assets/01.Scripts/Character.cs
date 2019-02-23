using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    
    // 캐릭터컨트롤러를 _animator에 세팅 
    
    [SerializeField] AnimationController _animationController;

    // Start is called before the first frame update
    void Start()
    {
        //IdleState();

        /*        
         _animationController.AddEndEvent(()=>
        {
            Debug.Log("Animation Test");
            // Idle -> Wait
            // Wait -> Kick
            // Kick -> Idle
            
        });*/
        ChangeState(eState.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //상태
    void IdleState()
    {
        //_animator.SetTrigger("idle1");

        /*
        int randValue = Random.Range(1, 6);
        triggerName = "idle" + randValue;
        _animator.SetTrigger(triggerName);
        */
    }

    void WaitState()
    {
        //_animator.SetTrigger("idle2");
        
    }

    void KickState()
    {
        //_animator.SetTrigger("idle4");   
    }
    enum eState
    {
        IDLE,
        WAIT,
        KICK,
    }

    void ChangeState(eState state)
    {
        switch (state)
        {
            case eState.IDLE:
                IdleState();
                break;
            case eState.WAIT:
                WaitState();
                break;

            case eState.KICK:
                KickState();
                break;
        }
    }
}
