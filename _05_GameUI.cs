using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace __HorzTools
{
    public class _05_GameUI : _04_HorzScroll
    {

        private string[] Num;
        private float delay = 1f;

        private string[] playernumber;
        private Text[] player;

        private const string sPlayerIndex = "_playerindex";
        private const string sBestScore = "_BestScore";

        private string[] PlayerName;
        private string[] _PlayerScore;
       
        public void Reset(Text _SetNum)
        {
            Num=new string[] {
            "3",
            "2",
            "1",
            "GO"
            };
            SetNum = _SetNum;

            playernumber = new string[]{
                "01",
                "02",
                "03",
                "04",
                "05",
                "06",
                "07",
                "08",
                "09",
                "10",
            };
            PlayerName = new string[]
            {
                "Player1",
                "Player2",
                "Player3",
                "Player4",
                "Player5",
                "Player6",
                "Player7",
                "Player8",
                "Player9",
                "Player10"
            };
            _PlayerScore = new string[]
            {
                "sPlayer1",
                "sPlayer2",
                "sPlayer3",
                "sPlayer4",
                "sPlayer5",
                "sPlayer6",
                "sPlayer7",
                "sPlayer8",
                "sPlayer9",
                "sPlayer10"
            };
        }
        public IEnumerator Startnum(GameObject _obj)
        {
            for (int i = 0; i < Num.Length; i++)
            {
                SetNum.text = Num[i];
                yield return new WaitForSeconds(delay);

                if (i == Num.Length - 1)
                {
                    GameObject obj = _obj;
                    obj.SetActive(false);
                    StartCheck = true;
                }
            }
        }


        //게임이 끝나면 유니티 GameUI스크립트에 넘겨주면서 PlayerPrefs File is Save.
        public void PlayerInformation(Text[] _player)
        {

            player = _player;

            Playername[PlayerIndex] = GetName;
            PlayerScore[PlayerIndex] = GetScore;

            for (int i = 0; i < player.Length; i++)
            {
                if (Playername[i] == "") Playername[i] = "N/A";

                if (BestSocre == PlayerScore[i]) PlayerPrefs.SetInt("sBestScoreIndex",i);
                player[i].text =
                    string.Format
                    ("{0}.{1} ({2})",
                    playernumber[i], Playername[i], PlayerScore[i]);
            }

            PlayerPrefs.SetInt(_PlayerScore[PlayerIndex], PlayerScore[PlayerIndex]);
            PlayerPrefs.SetString(PlayerName[PlayerIndex], Playername[PlayerIndex]);
            PlayerPrefs.SetInt("sBestScore", BestSocre);

            PlayerIndex = (PlayerIndex + 1) % 10;
            PlayerPrefs.SetInt("sPlayerIndex", PlayerIndex);
        }

        public void  GameIndexReset()
        {
            isGameOver = false;
            StartCheck = false;
            _Score = 0;
            Life = 3;
        }
    }
}
