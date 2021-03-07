﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[ExecuteInEditMode][SaveDuringPlay][AddComponentMenu("")]
public class LockCameraY : CinemachineExtension
{
    [Tooltip("Lock the camera's Y position to this value")]
    public float m_YPosition = 1.57f;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(enabled && stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = m_YPosition;
            state.RawPosition = pos;
        }
    }
}
