using TMPro;
using UnityEngine;

public class DeveloperConsoleBehaviour : MonoBehaviour
{
    [SerializeField] private string prefix = string.Empty;
    [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

    [Header("UI")]
    [SerializeField] private GameObject uiCanvas = null;
    [SerializeField] private TMP_InputField inputField = null;

    private float pausedTimeScale;

    private static DeveloperConsoleBehaviour instance;
    private DeveloperConsole developerConsole;
    private DeveloperConsole DeveloperConsole
    {
        get
        {
            if(developerConsole != null) { return developerConsole; }
            return developerConsole = new DeveloperConsole(prefix, commands);
        }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Toggle();
        }
        if(uiCanvas.activeSelf && inputField.text.Length > 0 && Input.GetKeyDown(KeyCode.E))
        {
            ProcessCommand(inputField.text);
        }
    }

    public void Toggle()
    {
        if (uiCanvas.activeSelf)
        {
            Time.timeScale = 1;
            uiCanvas.SetActive(false);
        }
        else
        {
            pausedTimeScale = Time.timeScale;
            Time.timeScale = 0;
            uiCanvas.SetActive(true);
            inputField.ActivateInputField();
        }
    }
    public void ProcessCommand(string inputValue)
    {
        DeveloperConsole.ProcessCommand(inputValue);

        inputField.text = string.Empty;
    }
}
