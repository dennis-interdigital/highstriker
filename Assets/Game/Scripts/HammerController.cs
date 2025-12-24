using UnityEngine;
using UnityEngine.UI;

namespace HighStriker
{
    public class HammerController : MonoBehaviour
    {
        public AnimationCurve powerCurve;
        public float minChargeSpeed;
        public float maxChargeSpeed;

        [Header("Runtime")]
        public float currentPower;
        public float currChargeSpeed;
        public float chargeTime;

        StageManager stageManager;

        public bool isPlaying;

        public void Init(StageManager inStageManager)
        {
            stageManager = inStageManager;
            isPlaying = false;
        }

        public void DoUpdate(float dt)
        {
            if (isPlaying)
            {
                chargeTime += dt * currChargeSpeed;
                float t = chargeTime % 1f;
                currentPower = powerCurve.Evaluate(t);
            }
        }

        //void Update()
        //{
        //    if (isPlaying && Input.GetMouseButtonDown(0))
        //    {
        //        Hit();
        //    }
        //}

        public void StartCharge()
        {
            currentPower = 0;
            chargeTime = 0;
            currChargeSpeed = Random.Range(minChargeSpeed, maxChargeSpeed);

            GameplayUI gameplayUI = stageManager.uiManager.currActiveUI as GameplayUI;
            gameplayUI.SetButtonHit(true);

            isPlaying = true;
        }

        public void Hit()
        {
            isPlaying = false;

            bool isPerfectScore = currentPower >= stageManager.perfectScoreTreshold;

            if (isPerfectScore)
            {
                currentPower = 1f;
                GameplayUI gameplayUI = stageManager.uiManager.currActiveUI as GameplayUI;
                gameplayUI.RefreshSliderHitBar(1f);
            }

            stageManager.highStrikerMachine.AnimateHit(currentPower);

            Debug.Log($"Power: {currentPower}");
        }
    }
}

