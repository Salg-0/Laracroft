using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class debugScript : MonoBehaviour
{
    public TextMeshPro debugText;
    string output = "";
    string stack = "";
    private void OnEnable() {
        Application.logMessageReceived += HandleLog;
        Debug.Log("Debugging enabled");
    }

    private void OnDisable() {
        Application.logMessageReceived -= HandleLog;
        ClearLog();
        
    }

    void HandleLog(string logString, string stackTrace, LogType type) {
        output = logString + "\n" + output;
        stack = stackTrace;
    }

    public void OnGUI() {
        debugText.text = output;
    }

    public void ClearLog() {
        output = "";
        stack = "";
    }
}
