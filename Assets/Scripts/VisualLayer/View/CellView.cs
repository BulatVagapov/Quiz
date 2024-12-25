using Quiz.Models;
using UnityEngine;

namespace Quiz.VisualLayer
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer symbolSpriteRenderer;
        [SerializeField] private SpriteRenderer mainObjectSpriteRenderer;
        public SpriteRenderer SymbolSpriteRenderer => symbolSpriteRenderer;

        public void SetCellSymbolView(CellDataModel cellData, Color backgroundColor)
        {
            symbolSpriteRenderer.sprite = cellData.SymbolView;
            symbolSpriteRenderer.transform.rotation = Quaternion.Euler(cellData.SymbolRotation);
            mainObjectSpriteRenderer.color = backgroundColor;
        }
    }
}