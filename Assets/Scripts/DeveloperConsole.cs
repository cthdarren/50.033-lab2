using UnityEngine;

public class DeveloperConsole : MonoBehaviour
{
    public DevConsole devConsole;
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = devConsole.timeScale;
    }
}
