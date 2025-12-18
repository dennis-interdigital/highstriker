using UnityEngine;
using UnityEngine.UI;

namespace HighStriker
{
    public class HammerController : MonoBehaviour
    {
        public AnimationCurve powerCurve;
        public float minChargeSpeed;
        public float maxChargeSpeed;
        public Slider sliderBar;
        public Image imgbar;

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

                sliderBar.value = currentPower;
                
                

            }
        }

        void Update()
        {
            if (isPlaying && Input.GetMouseButtonDown(0))
            {
                Hit();
            }
            else if (!isPlaying && Input.GetMouseButtonDown(0))
            {
                StartCharge();
            }

            if (isPlaying)
            {
                if (currentPower < 0.5f)
                {
                    imgbar.color = Color.Lerp(Color.red, Color.yellow, currentPower / 0.5f);
                }
                else
                {
                    imgbar.color = Color.Lerp(Color.yellow, Color.green, (currentPower - 0.5f) / 0.5f);
                }
            }
        }

        public void StartCharge()
        {
            currentPower = 0;
            chargeTime = 0;
            currChargeSpeed = Random.Range(minChargeSpeed, maxChargeSpeed);

            isPlaying = true;
        }

        public void Hit()
        {
            isPlaying = false;

            bool isPerfectScore = currentPower >= stageManager.perfectScoreTreshold;

            if (isPerfectScore)
            {
                currentPower = 1f;
                sliderBar.value = 1f;
            }

            stageManager.highStrikerMachine.AnimateHit(currentPower);

            Debug.Log($"Power: {currentPower}");
        }
    }
}

