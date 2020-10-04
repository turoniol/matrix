using System;
using System.Collections.Generic;

namespace ElementSpace 
{
  class Element
  {
    public int Val { get; private set; }
    public (int, int) coordinates { get; private set; }

    // functions
    public Element() 
    { 
      Val = 0; 
      coordinates = (0, 0); 
    }
    public Element(int value, (int, int) pos) 
    {
      Val = value;
      coordinates = pos;
    }

    public int GetX() => coordinates.Item1;
    public int GetY() => coordinates.Item2;
    public static Element operator +(Element l, Element r) => new Element(l.Val + r.Val, l.coordinates);
    public static Element operator *(int n, Element el) => new Element(n*el.Val, el.coordinates);
    public static Element operator *(Element el, int n) => new Element(n*el.Val, el.coordinates);
  }
}