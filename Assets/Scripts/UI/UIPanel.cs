using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    [field :SerializeField] public bool isPanelActive { get; private set; }
    [field :SerializeField] public string panelName { get; private set; }
    public virtual void Open()
    {
        gameObject.SetActive(true);
        isPanelActive = true;
    }

    public virtual void Close()
    {
        isPanelActive = false;
        gameObject.SetActive(false);
    }
}
