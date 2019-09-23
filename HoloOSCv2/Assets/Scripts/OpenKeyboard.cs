// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using TMPro;

public class OpenKeyboard : UnityEngine.MonoBehaviour {
    // For System Keyboard
    private TouchScreenKeyboard keyboard;
    public static string keyboardText = "192.168.178.20:8000";
    [SerializeField]
    private TextMeshPro debugMessage = null;

    private void Update() {
        if (keyboard != null) {
            keyboardText = keyboard.text;
            if (TouchScreenKeyboard.visible) {
                debugMessage.text = keyboardText;
            }
            else {
                debugMessage.text = keyboardText;
                keyboard = null;
            }
        }
    }
    public void OpenSystemKeyboard() {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumbersAndPunctuation, false, false, false, false);
        Debug.Log("OpenSystemKeyboard: Opening System Keyboard");
    }
}