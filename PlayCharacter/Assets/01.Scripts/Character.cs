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
        /*
        IdleState _idleState = new IdleState();
        WaitState _waitState = new WaitState();
        KickState _kickState = new KickState();
        */

        _stateDic.Add(eState.IDLE, new IdleState());
        _stateDic.Add(eState.WAIT, new WaitState());
        _stateDic.Add(eState.KICK, new KickState());

        
        for(int i = 0; i < _stateDic.Count; i++)
        {
            eState state = (eState)i;
            _stateDic[state].SetCharacter(this);
        }
        /*
        _idleState.SetCharacter(this);
        _waitState.SetCharacter(this);
        _kickState.SetCharacter(this);
        */

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
        UpdateState();
    }

    //상태(State)

    Dictionary<eState, State> _stateDic = new Dictionary<eState, State>();

    State _state = null;

    
    /*
    void IdleStart()
    {
        //_idleState.Start();



        //_animator.SetTrigger("idle1");

        //전에하던거
        int randValue = Random.Range(1, 6);
        triggerName = "idle" + randValue;
        _animator.SetTrigger(triggerName);
        
    }
    */


    /*
    void WaitStart()
    {
        
        
        _animationController.Play("idle2", () =>
        {
            ChangeState(eState.WAIT2);
        });
        //_animator.SetTrigger("idle2");
        
    }
    */


        /*
    void Wait2Start()
    {
        _animationController.Play("idle3", () =>
        {
            ChangeState(eState.WAIT3);
        });
    }


    void Wait3Start()
    {
        _animationController.Play("idle4", () =>
        {
            ChangeState(eState.KICK);
        });
    }
    */
    /*
    void KickStart()
    {
        _animationController.Play("idle5", () =>
        {
            ChangeState(eState.IDLE);
        });
    }*/


    public enum eState
    {
        IDLE,
        WAIT,
        KICK,
    }

    public void ChangeState(eState state)
    {

        _state = _stateDic[state];
        _state.Start();
 

        /*
        switch (state)
        {
            case eState.IDLE:
                _state = _idleState;
                break;
            case eState.WAIT:
                _state = _waitState;
                break;
            case eState.WAIT2:
                Wait2Start();
                break;
            case eState.WAIT3:
                Wait3Start();
                break;
            case eState.KICK:
                _state = _kickState;
                break;
        }
        */

    }

    void UpdateState()
    {
        //_state.Update();

    }

    //Animation

    public void PlayAnimation(string trigger, System.Action endCallBack)
    {
        _animationController.Play(trigger, endCallBack);
    }


}
