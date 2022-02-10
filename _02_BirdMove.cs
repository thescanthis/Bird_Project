using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


//새가 움직이는 정보만 가지고있음 죽는 정보 맞았을때 목숨이 까이는건없음. 02.02
//현재 새가 움직이는정보,게임이끝나는것 유니티 스크립트에 새의 충돌에 대한 함수가 있음.
namespace __HorzTools
{
    public class _02_BirdMove : _01_GameManager
    {
        private Rigidbody2D _rb2d;
        private PolygonCollider2D _poly;
        private Animator _anim;

        public float upForce = 200f;

        public void attach(Rigidbody2D _rb2d_, PolygonCollider2D _Poly_, Animator _anim_)
        {
            _rb2d = _rb2d_;
            _poly = _Poly_;
            _anim = _anim_;
        }
        public void Bird_Move()
        {
            _OnGameOver();

            if (StartCheck) _rb2d.gravityScale = 1f;

            if (Life>0&&StartCheck&&Input.GetMouseButtonDown(0))
            {
                //속도는 0
                _rb2d.velocity = Vector2.zero;
                //가하는 힘은?
                _rb2d.AddForce(new Vector2(0, upForce));
                //_animation Move
                _anim.SetTrigger("SetFlap");
            }
        }
        public void _Collider()
        {
            _anim.SetTrigger("SetCollider");
        }

        public void _OnGameOver()
        {
            if (Life < 1)
            {
                _anim.SetTrigger("SetDie");
                isGameOver = true;
            }
        }
    }
}

