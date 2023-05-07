using UnityEngine;
using SFB;

public class OpenWindow : MonoBehaviour
{
    [SerializeField] public GameObject sphere;

    public void ShowDialog()
    {
        var extensions = new[] {
            new ExtensionFilter("Text Files", "txt"),
            new ExtensionFilter("All Files", "*"),
        };

        StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(worldPos, Vector3.forward, out hit))
            {
                if (hit.collider.gameObject == sphere)
                {
                    ShowDialog();
                }
            }
        }
    }
}

