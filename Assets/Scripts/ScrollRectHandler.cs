using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ScrollRectHandler{


    public static void ScrollToRight(this ScrollRect scrollRect, float delta)
    {
        float curPos = scrollRect.horizontalNormalizedPosition;
        scrollRect.normalizedPosition = new Vector2(curPos + delta, 0);
    }
    public static void ScrollToLeft(this ScrollRect scrollRect, float delta)
    {
        float curPos = scrollRect.horizontalNormalizedPosition;
        scrollRect.normalizedPosition = new Vector2(curPos - delta, 0);
    }

}
