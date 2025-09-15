using UnityEngine;

public class SlotGameAni : MonoBehaviour
{
    public Transform[] symbols; // Array of symbols on the reel

/*    public void SpinReel()
    {
        foreach (Transform symbol in symbols)
        {
            symbol.DOLocalMoveY(symbol.localPosition.y - 500, 1.5f)
                  .SetLoops(-1, LoopType.Yoyo) // Loop animation for continuous spin
                  .SetEase(Ease.Linear);
        }
    }

    public void StopReel(int stopIndex)
    {
        foreach (Transform symbol in symbols)
        {
            symbol.DOKill(); // Stop animation
            symbol.DOLocalMoveY(stopIndex * 100, 0.5f).SetEase(Ease.OutBounce); // Smooth stop
        }
    }*/
}
