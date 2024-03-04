using UnityEngine;

public class UIPanel : MonoBehaviour
{
    [field :SerializeField] public bool isPanelActive { get; private set; }
    [field :SerializeField] public string panelName { get; private set; }
    public virtual void Open()
    {
        isPanelActive = true;
    }

    public virtual void Close()
    {
        isPanelActive = false;
        gameObject.SetActive(false);
    }
}
