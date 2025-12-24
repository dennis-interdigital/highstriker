using HighStriker;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHitListener : MonoBehaviour, IPointerDownHandler
{
    GameplayUI gameplayUI;

    public void Init(GameplayUI inGameplayUI)
    {
        gameplayUI = inGameplayUI;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameplayUI.Hit();
    }
}
