using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teaching.Preparing
{
    public class Example_SwitchState : MonoBehaviour
    {
        public enum EnemyState
        {
            Idle,
            Tracing,
            Attack,
            Run,
        }

        public SpriteRenderer renderer;
        public EnemyState state;

        public Transform target;

        void Update()
        {
            EnemyBehaviour();
        }

        void EnemyBehaviour()
        {
            switch (state)
            {
                case EnemyState.Idle:
                    State_Idle();
                    break;

                case EnemyState.Tracing:
                    State_Tracing();
                    break;

                case EnemyState.Attack:
                    State_Attack();
                    break;

                case EnemyState.Run:
                    State_Run();
                    break;

            }
        }

        void State_Idle()
        {
            renderer.color = Color.gray;

            if (Vector3.Distance(transform.position, target.position) < 5) state = EnemyState.Tracing;
            if (target.localScale.x > 5) state = EnemyState.Run;
        }
        void State_Tracing()
        {
            renderer.color = Color.yellow;

            if (Vector3.Distance(transform.position, target.position) < 3) state = EnemyState.Attack;
            if (Vector3.Distance(transform.position, target.position) > 5) state = EnemyState.Idle;
            if (target.localScale.x > 5) state = EnemyState.Run;
        }
        void State_Attack()
        {
            renderer.color = Color.red;

            if (Vector3.Distance(transform.position, target.position) > 3) state = EnemyState.Tracing;
            if (target.localScale.x > 5) state = EnemyState.Run;
        }
        void State_Run()
        {
            renderer.color = Color.blue;

            if (target.localScale.x < 5) state = EnemyState.Idle;
        }
    }
}