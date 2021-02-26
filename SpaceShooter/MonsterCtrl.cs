using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
        //몬스터의 상태
        public enum State
        {
                IDLE,
                TRACE,
                ATTACK,
                DIE
        }

        //몬스터의 상태를 저장할 변수
        public State state = State.IDLE;

        public float attackDist = 2.0f;
        public float traceDist = 10.0f;
        public bool isDie = false;


        private WaitForSeconds ws;

        private Transform monsterTr;
        private Transform playerTr;
        private NavMeshAgent agent;
        private Animator monsterAni;


        //hashtable에서 미리 파라메터값을 검색 <- 퍼포먼스에 도움
        private int hashTrace = Animator.StringToHash("isTrace");
        private int hashAttack = Animator.StringToHash("isAttack");
        private int hashDie = Animator.StringToHash("Die");
        private int hashHit = Animator.StringToHash("Hit");

        public float hp = 100.0f;



        void OnEnable()
        {
                //이벤트에 연결(PlayerCtrl)
                PlayerCtrl.OnPlayerDie += this.PlayerDie;
        }


        void OnDisable()
        {
                //이벤트의 연결 해지(메모리 누수 방지)
                PlayerCtrl.OnPlayerDie -= this.PlayerDie;
        }




        void Start()
        {

                ws = new WaitForSeconds(0.3f);

                agent = GetComponent<NavMeshAgent>();
                monsterTr = GetComponent<Transform>();
                monsterAni = GetComponent<Animator>();
                playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
                StartCoroutine(CheckMonsterState());
                StartCoroutine(MonsterAction());
        }

        //몬스터의 상태만 체크
        IEnumerator CheckMonsterState()
        {
                while (!isDie)
                {
                        yield return ws;

                        float dist = Vector3.Distance(monsterTr.position, playerTr.position);
                        //몬스터와 주인공간의 거리가 공격사정거리 이내인 경우
                        if (dist <= attackDist)
                        {
                                state = State.ATTACK;
                        }
                        //공격사정거리보다 크고 추적사정거리 이내인 경우
                        else if (dist <= traceDist)
                        {
                                state = State.TRACE;
                        }
                        else
                        {
                                state = State.IDLE;
                        }
                }
        }




        IEnumerator MonsterAction()
        {
                while(!isDie)
                {
                        switch(state)
                        {
                                case State.IDLE:
                                        agent.isStopped = true;
                                        monsterAni.SetBool(hashTrace, false);
                                        
                                        break;


                                case State.TRACE:
                                        agent.SetDestination(playerTr.position);
                                        agent.isStopped = false;
                                        monsterAni.SetBool(hashTrace, true);
                                        monsterAni.SetBool(hashAttack, false);

                                        break;

                                case State.ATTACK:

                                        monsterAni.SetBool(hashAttack, true);
                                        break;

                                case State.DIE:
                                        break;


                        }
                        yield return ws;


                }

        }

        void OnCollisionEnter(Collision collision)
        {
                if (collision.collider.CompareTag("BULLET"))
                {
                        /*
                        monsterAni.SetTrigger(hashHit);
                        hp -= 20.0f;


                        if (hp <= 0.0f)
                        {
                                MonsterDie();
                        }
                        */
                }
                
        }



        void MonsterDie()
        {

                StopAllCoroutines();
                agent.isStopped = true;
                GetComponent<CapsuleCollider>().enabled = false;
                isDie = true;
                monsterAni.SetTrigger(hashDie);
        }


        public void PlayerDie()
        {
                StopAllCoroutines();
                agent.isStopped = true;
                monsterAni.SetTrigger("PlayerDie");
        }

        public void Damage(float damage)
        {
                monsterAni.SetTrigger(hashHit);
                hp -= damage;


                if (hp <= 0.0f)
                {
                        MonsterDie();
                }
        }

        void OnTriggerEnter(Collider other)
        {
                //Debug.Log(other.name);        
        }
}