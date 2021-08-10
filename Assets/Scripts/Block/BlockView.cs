using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Block))]
public class BlockView : MonoBehaviour
{
    [SerializeField] private TMP_Text _viewText;

    private Block _block;

    private void Awake()
    {
        _block = GetComponent<Block>();
    }

    private void OnEnable()
    {
        _block.FillingUpdatend += OnFillingUpdatend;
    }

    private void OnDisable()
    {
        _block.FillingUpdatend -= OnFillingUpdatend;
    }

    private void OnFillingUpdatend(int leftToFill)
    {
        _viewText.text = leftToFill.ToString();
    }

}
