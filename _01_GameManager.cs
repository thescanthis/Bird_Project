using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//UI와 게임정보에 대한것을 최상단 부모클래스로 구성해 놓을 예정임.
namespace __HorzTools
{
    public class _01_GameManager
    {
        [HideInInspector] public bool _ColumnCheck = false;
        [HideInInspector] public bool _ButtonCheck = false;


        public static bool StartCheck = false;
        public static bool isGameOver = false;
        public static int _Score = 0;
        public static int Life = 3;

        public static int PlayerIndex = 0;
        public static int BestSocre = 0;
        public static int GetScore = 0;
        public static string GetName="None";


        public static int BestScoreIndex = 0;
        public static int[] PlayerScore = new int[10];
        public static string[] Playername = new string[10];

        protected Text _txtBestScore;
        protected Text _txtScore;
        protected Text SetNum;

        protected Text _txtName;
        protected Text _NameBox;

        protected Text _Life;

        private Text _GameTitle;
        private string none = "None";

        public void Load()
        {
            PlayerIndex = PlayerPrefs.GetInt("sPlayerIndex", 0);
            BestScoreIndex = PlayerPrefs.GetInt("sBestScoreIndex", 0);
            BestSocre = PlayerPrefs.GetInt("sBestScore", 0);
            PlayerScore[0] = PlayerPrefs.GetInt("sPlayer1", 0);
            PlayerScore[1] = PlayerPrefs.GetInt("sPlayer2", 0);
            PlayerScore[2] = PlayerPrefs.GetInt("sPlayer3", 0);
            PlayerScore[3] = PlayerPrefs.GetInt("sPlayer4", 0);
            PlayerScore[4] = PlayerPrefs.GetInt("sPlayer5", 0);
            PlayerScore[5] = PlayerPrefs.GetInt("sPlayer6", 0);
            PlayerScore[6] = PlayerPrefs.GetInt("sPlayer7", 0);
            PlayerScore[7] = PlayerPrefs.GetInt("sPlayer8", 0);
            PlayerScore[8] = PlayerPrefs.GetInt("sPlayer9", 0);
            PlayerScore[9] = PlayerPrefs.GetInt("sPlayer10", 0);

            Playername[0] = PlayerPrefs.GetString("Player1", "");
            Playername[1] = PlayerPrefs.GetString("Player2", "");
            Playername[2] = PlayerPrefs.GetString("Player3", "");
            Playername[3] = PlayerPrefs.GetString("Player4", "");
            Playername[4] = PlayerPrefs.GetString("Player5", "");
            Playername[5] = PlayerPrefs.GetString("Player6", "");
            Playername[6] = PlayerPrefs.GetString("Player7", "");
            Playername[7] = PlayerPrefs.GetString("Player8", "");
            Playername[8] = PlayerPrefs.GetString("Player9", "");
            Playername[9] = PlayerPrefs.GetString("Player10", "");
        }

        public void ObjAttach(Text bestscore, Text name,Text _namebox)
        { 
            _txtBestScore = bestscore;
            _txtName = name;
            _NameBox = _namebox;
        }
        public void GameTitle(Text _title)
        {
            _GameTitle = _title;
            _GameTitle.text = string.Format("FLAPPY BIRD");
        }

        public void TitleUi()
        {
            _txtBestScore.text = string.Format("Best Score : {0}",(BestSocre == 0) ? none : BestSocre);
            _txtName.text = string.Format("NickName : {0}",(Playername[BestScoreIndex]=="")? none : Playername[BestScoreIndex]);
        }

        public void GameSceneUI(Text score,Text life,Text bestscore)
        {
            _txtScore = score;
            _Life = life;
            _txtBestScore = bestscore;
        }

        public void _TextObject()
        {
            _txtBestScore.text = string.Format("Best Score : {0}", BestSocre);
            _txtScore.text = string.Format("Score : {0}", _Score);
            _Life.text = string.Format("Life : {0}", Life);
        }

        public void StartNextScene(int SceneNum)
        {
            if(_ButtonCheck) SceneManager.LoadScene(SceneNum);
        }
        public void ResultNextScene(int Scenenum)
        {
            SceneManager.LoadScene(Scenenum);
        }

        public void NameBox()
        {
            if (_NameBox.text == "") _ButtonCheck = false;
            else
            {
                GetName = _NameBox.text;
                Playername[PlayerIndex] = GetName;
                _ButtonCheck = true;
            }
        }

        public void SetAddScore()
        {
            _Score += 10;
            GetScore = _Score;
           if(_Score>BestSocre)
            {
                BestSocre = _Score;
            }

        }

        public void Speed_zero(Rigidbody2D _rb2d)
        {
            _rb2d.velocity = Vector2.zero;
        }
    }
}
