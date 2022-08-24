using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineSlide : StateMachineBase
{
    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;
    private float _animationTime;
    private float _animationTimer;
    private Vector2 _colOffsetOrigin;
    private Vector2 _colSizeOrigin;
    private Vector2 _colOffsetCrouch = new Vector2(0.0f, 0.075f);
    private Vector2 _colSizeCrouch = new Vector2(0.15f, 0.15f);
    public StateMachineSlide(StateMachineManager.State machineState,
                             StateMachineManager manager,
                             AnimationManager animationManager) 
        : base(machineState, manager, animationManager)
    {
        shortKey = KeyCode.X;
        _rb = manager.GetComponent<Rigidbody2D>();
        _col = manager.GetComponent<CapsuleCollider2D>();
        _animationTime = animationManager.GetAnimationTime("Slide");
    }

    public override void Execute()
    {
        
    }

    public override void FIxedUpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override void ForceStop()
    {
        throw new System.NotImplementedException();
    }

    public override bool IsExecuteOK()
    {
        throw new System.NotImplementedException();
    }

    public override StateMachineManager.State UpdateState()
    {
        throw new System.NotImplementedException();
    }
}
