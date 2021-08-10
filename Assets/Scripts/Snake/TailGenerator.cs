using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailGenerator : MonoBehaviour
{    
    [SerializeField] private Segment _segmentTemplate;
    public List<Segment> Generator(int count) 
    {
        List<Segment> Tail = new List<Segment>();

        for (int i = 0; i < count; i++)
        {
            Tail.Add(Instantiate(_segmentTemplate, transform));
        }

        return Tail;
    }
}
