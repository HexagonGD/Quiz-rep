using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private Color _color;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void FadeIn()
    {
        _text.color = new Color(0, 0, 0, 0);
        _text.DOColor(_color, 1f);
    }

    public void SetQuest(string text)
    {
        _text.text = "Find " + text;
    }

    public void Hide()
    {
        _text.color = new Color(0, 0, 0, 0);
    }
}
