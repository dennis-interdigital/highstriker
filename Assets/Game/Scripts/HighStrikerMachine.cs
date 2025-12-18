using DG.Tweening;
using HighStriker;
using UnityEngine;

public class HighStrikerMachine : MonoBehaviour
{
    [SerializeField] Transform rootBell;
    [SerializeField] Transform rootBullet;

    [Header("Config")]
    [SerializeField] float yBulletMin;
    [SerializeField] float yBulletMax;

    StageManager stageManager;

    public void Init(StageManager inStageManager)
    {
        stageManager = inStageManager;


    }

    public void AnimateHit(float hitPower)
    {
        bool isPerfectScore = hitPower >= stageManager.perfectScoreTreshold;

        float score = isPerfectScore ? 1 : hitPower;

        float yPosition = Mathf.Lerp(yBulletMin, yBulletMax, score);
        Vector3 punchPos = new Vector3(0, yPosition, 0);

        Sequence seq = DOTween.Sequence();

        Tween tweenMoveUp = rootBullet.DOMoveY(yPosition, hitPower).SetEase(Ease.OutCubic);
        Tween tweenShakeBell = null;
        Tween tweenMoveDown = rootBullet.DOMoveY(yBulletMin, hitPower).SetEase(Ease.InCubic);

        seq.Append(tweenMoveUp);

        if (isPerfectScore)
        {
            Vector3 punchScale = new Vector3(0.2f, 0.2f, 0f);
            tweenShakeBell = rootBell.DOPunchScale(punchScale, 0.5f);
            seq.Append(tweenShakeBell);

            seq.Join(tweenMoveDown);
        }
        else
        {
            seq.Append(tweenMoveDown);
        }   
    }
}
