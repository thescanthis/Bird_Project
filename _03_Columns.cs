using UnityEngine;
using UnityEngine.UI;

namespace __HorzTools
{
    public abstract class _03_Columns : _02_BirdMove
    {
        protected Rigidbody2D _rb2d;
        protected BoxCollider2D _box;

        private BoxCollider2D ColumBox;
        private BoxCollider2D ScoreBox;

        protected float speed = -2f;
        protected float GroundLength;


        private GameObject ColumnPreFab;
        private GameObject[] Columns;
        private float SpwanXPosition = 10f;
        private float YpositionMin = -0.5f;
        private float YpositionMax = 3f;
        private int Objsize = 5;
        private int ObjIndex=0;
       

        public void Attach(BoxCollider2D _box)
        {
            ScoreBox = _box;
            ScoreBox.isTrigger = true;
        }

        public void ColumnBoxAttach(BoxCollider2D _box)
        {

            ColumBox = _box;
            ColumBox.isTrigger = true;
        }
        public void ColumnTriggerFalse()
        {
            
            if (Life<1)
            {
                ColumBox.isTrigger = false;
            }
        }


        public Vector2 RepositionBackGround(float _GroundLength)
        {
            GroundLength = _GroundLength;
            Vector2 _move= new Vector2( GroundLength* 2, 0f);
            return _move;
        }

        //Ground and walls are common functions.
        public void _GroundMove(Rigidbody2D rb2d)
        {
            _rb2d = rb2d;
            _rb2d.velocity = new Vector2(speed, 0);
        }

        public void PreFabAttach(GameObject _pefab)
        {
            ColumnPreFab = _pefab;
        }

        public void InitColumnsCreate()
        {
            Columns = new GameObject[Objsize];
            for (int i = 0; i < Columns.Length; i++)
            {
                Columns[i] = Transform.Instantiate(ColumnPreFab, new Vector2(-15, -25), Quaternion.identity);
            }
        }

        public void Spwan()
        {
            if (isGameOver) return;

            float Y_RePosition = Random.Range(YpositionMin, YpositionMax);
            Columns[ObjIndex].transform.position = new Vector2(SpwanXPosition, Y_RePosition);
            ObjIndex = (ObjIndex + 1) % Objsize;
        }
        public abstract void HorzObjectAttach(Rigidbody2D rb2d, BoxCollider2D box,float _GroundLength);
    }
}
