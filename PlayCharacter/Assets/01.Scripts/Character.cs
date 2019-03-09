using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{

    // 캐릭터컨트롤러를 _animator에 세팅 

    [SerializeField] AnimationController _animationController;
    private void Awake()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {


        _stateDic.Add(eState.IDLE, new IdleState());
        _stateDic.Add(eState.WAIT, new WaitState());
        _stateDic.Add(eState.KICK, new KickState());
        _stateDic.Add(eState.WALK, new WalkState());

        for (int i = 0; i < _stateDic.Count; i++)
        {
            eState state = (eState)i;
            _stateDic[state].SetCharacter(this);
        }

        ChangeState(eState.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
        UpDateMove();

    }

    //상태(State)

    Dictionary<eState, State> _stateDic = new Dictionary<eState, State>();

    State _state = null;


    public enum eState
    {
        IDLE,
        WAIT,
        KICK,
        WALK,
    }

    public void ChangeState(eState state)
    {

        _state = _stateDic[state];
        _state.Start();
 
    }

    void UpdateState()
    {
        UpDateMove();
    }

    //Animation

    public void PlayAnimation(string trigger, System.Action endCallBack)
    {
        _animationController.Play(trigger, endCallBack);
    }

    CharacterController _characterController;
    float _moveSpeed = 0.0f;
    //Movement

    void UpDateMove()
    {
        Vector3 moveDirection = Vector3.zero;
        _moveSpeed = 0.5f;

        Vector3 moveVelocity = moveDirection * _moveSpeed;
        Vector3 gravityVelocity = Vector3.down * 9.8f;
        Vector3 finalVelocity = (moveVelocity + gravityVelocity) * Time.deltaTime;

        _characterController.Move(finalVelocity);

    }

    void StartWalk(float speed)
    {
        _moveSpeed = speed;

    }

}
