using UnityEngine;
using UnityEngine.UI;

public class BChangeColor : MonoBehaviour
{
    private bool _changedMusic;

    [SerializeField] private Image _iMusic;
    [SerializeField] private Sprite[] _sprites;

    public void ChangeSprite()
    {
        if (_changedMusic)
        {
            _changedMusic = false;
            _iMusic.sprite = _sprites[0];
        }
        else
        {
            _changedMusic = true;
            _iMusic.sprite = _sprites[1];
        }
    }

    public void ChangeColor()
        => _iMusic.color += (_iMusic.color) - Color.red;
}
