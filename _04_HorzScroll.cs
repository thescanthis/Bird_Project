using System;
using UnityEngine;

namespace __HorzTools
{
    public class _04_HorzScroll : _03_Columns
    {
        //재정의를 할땐 public으로 해야 오류발생이 안됨.
        public override void HorzObjectAttach(Rigidbody2D rb2d,BoxCollider2D box,float _GroundLength)
        {
            _rb2d = rb2d;
            _box = box;

            _rb2d.bodyType = RigidbodyType2D.Kinematic;
            GroundLength = _GroundLength;

        }
    }
}
