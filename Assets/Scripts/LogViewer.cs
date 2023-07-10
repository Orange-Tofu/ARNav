using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// This scripts is purely used for visual debugging, i.e. it will show the log files in AR mode.
// This helps in seeing the debuglog while moving around and using the app in your mobile.
// To use this script attach a text element to canvas and in other scripts call DebugLog function.
public class LogViewer : MonoBehaviour
{
    public Text logText;
    private List<string> logMessages = new List<string>();

    private void Start()
    {
        // Clear the log text initially
        logText.text = string.Empty;
    }

    private void Update()
    {
        // Check for new log messages
        if (logMessages.Count > 0)
        {
            // Update the log text with all the log messages
            logText.text = string.Join("\n", logMessages);

            // Clear the log messages list
            logMessages.Clear();
        }
    }

    private void OnEnable()
    {
        // Subscribe to Unity's debug log handler
        Application.logMessageReceived += HandleLogMessage;
    }

    private void OnDisable()
    {
        // Unsubscribe from Unity's debug log handler
        Application.logMessageReceived -= HandleLogMessage;
    }

    public void HandleLogMessage(string logString, string stackTrace, LogType logType)
    {
        // Add the log message to the list
        logMessages.Add(logString);
    }
}
