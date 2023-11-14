using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectUI : MonoBehaviour
{
    public Transform targetObject; // ���� ������Ʈ
    public RectTransform uiElement; // ����ٴϴ� UI ���

    private Vector3 uiOriginalPosition;
    private Vector3 targetObjectOriginalPosition;

    private void Awake()
    {
        targetObjectOriginalPosition = targetObject.position;
        uiOriginalPosition = uiElement.position;
    }

    void Update()
    {
        if (targetObject == null)
            return;

        if (uiElement == null)
            return;

        var temp = targetObject.position - targetObjectOriginalPosition;

        uiElement.position = temp + uiOriginalPosition;
    }
}
