﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour {

    [SerializeField]
    float gizmoSize = .75f;
    [SerializeField]
    Color gizmoColor = Color.yellow;

	// Use this for initialization
	void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}