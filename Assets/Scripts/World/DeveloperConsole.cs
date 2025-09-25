using UnityEngine;

public class DeveloperConsole : MonoBehaviour
{
    public DevConsole devConsole;
    // Update is called once per frame
    void Update()
    {
        if (!devConsole.cheatsOn) return;
        if (devConsole.overrideTime)
        {
            Time.timeScale = devConsole.timeScale;
        }
    }
}
