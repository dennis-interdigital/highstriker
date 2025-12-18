using UnityEngine;

namespace HighStriker
{
    public class UIManager : MonoBehaviour
    {
        StageManager stageManager;

        public void Init(StageManager inStageManager)
        {
            stageManager = inStageManager;
        }
    }
}

