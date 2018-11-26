using UnityEngine;
using UnityEngine.Events;
using Common.Base;

namespace Common.Tween
{
    public class TweenBase : BaseBehaviour
    {
        public enum PlayStyle
        {
            Once, //1回だけ
            Loop, //繰り返し
            Pong  //往復
        }

        [SerializeField] private AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] private PlayStyle playStyle = PlayStyle.Once;
        [SerializeField] private bool isPlayAwake = false;
        [SerializeField, HeaderAttribute("往復の際もこの秒数で往復")] private float playTime = 1f;
        public System.Action startCallBack { private get; set; }
        public System.Action finishedCallBack { private get; set; }

        private float playElapesdTime = 0f;
        private bool isPlay = false;
        private bool isPlayTurnBack = false;
        private bool isPouse = false;
        private bool isPlayTimeOver = false;

        protected override void OnAwake()
        {
            isPlay = false;
            isPouse = false;
            isPlayTurnBack = false;
            base.OnAwake();
        }

        protected override void OnStart()
        {
            if (isPlayAwake)
            {
                PlayTween();
            }
            base.OnStart();
        }

        public virtual void SetUp(float playTime)
        {
            this.playTime = playTime;
        }

        public void PlayTween()
        {
            if (isPlay)
            {
                // 現在実行中の際はどうするか、リセットするか、はじくか
                return;
            }

            isPlay = true;
            isPouse = false;
            playElapesdTime = 0f;
            UpdateManager.Instance.AddUpdateTarget(this);
            if (startCallBack != null)
            {
                startCallBack();
            }
        }

        public void StopTween()
        {

        }

        // 継承先での処理、呼ばれるタイミングは時間加算後呼ばれる
        protected virtual void UpdateProc()
        {

        }


        public override void UpdateCallBack(float addTime)
        {
            if (!isPlay)
            {
                return;
            }

            playElapesdTime += addTime;
            if (playElapesdTime > playTime)
            {
                playElapesdTime = playTime;
                isPlayTimeOver = true;
            }

            UpdateProc();

            if (isPlayTimeOver)
            {
                PlayEnd();
            }

            base.UpdateCallBack(addTime);
        }

        private void PlayEnd()
        {
            switch (playStyle)
            {
                case PlayStyle.Once:
                    {
                        isPlay = false;
                        if (finishedCallBack != null)
                        {
                            finishedCallBack();
                        }
                    }
                    break;
                case PlayStyle.Loop:
                case PlayStyle.Pong:
                    {
                        playElapesdTime = 0;
                    }
                    break;
            }
            isPlayTimeOver = false;
        }

        private float tmpTime = 0f;
        public float GetPlayPer()
        {
            if (playTime <= 0)
                return 1.0f;

            tmpTime = playElapesdTime;

            if (playStyle == PlayStyle.Pong)
            {
                if (tmpTime > (playTime / 2.0f))
                {
                    tmpTime -= (playTime / 2.0f);
                    tmpTime = (playTime / 2.0f) - tmpTime;
                }
                tmpTime *= 2.0f;
            }
            return tmpTime / playTime;
        }
    }
}
