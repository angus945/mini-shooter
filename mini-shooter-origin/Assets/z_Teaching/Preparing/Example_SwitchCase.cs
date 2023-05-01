using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teaching.Preparing
{
    public class Example_SwitchCase : MonoBehaviour
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
        }
        void State_Tracing()
        {
            renderer.color = Color.yellow;
        }
        void State_Attack()
        {
            renderer.color = Color.red;
        }
        void State_Run()
        {
            renderer.color = Color.blue;
        }
    }
}