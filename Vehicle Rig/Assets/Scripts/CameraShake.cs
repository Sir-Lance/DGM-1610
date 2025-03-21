﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator Shake(float duration, float magnitude)
    {
        
        //saves original position
        Vector3 origPos = transform.localPosition;

        float elapsed = 0.0f;

        //when couroutine is called to this action will repeat under a timer
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, origPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = origPos;
    }
}
