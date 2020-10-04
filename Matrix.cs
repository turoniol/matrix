using System;
using System.Collections.Generic;
using ElementSpace;

namespace MatrixSpace
{
  class Matrix 
  {
    public int Width {get; private set;}
    public int Height {get; private set;}
    public List<Element> elements {get; private set;}

    // funstions
    public Matrix() {Width = 0; Height = 0; elements = new List<Element>();}
    public Matrix(int width, int height, int[] arr)
    {
      Width = width;
      Height = height;
     elements = new List<Element>();
      
      for (int h = 0; h < Height; ++h) 
      {
        for (int w = 0; w < Width; ++w)
        {
         elements.Add(new Element(arr[w + h*Width], (w, h)));
        }
      }
    }
    public int GetElementValue(int x, int y) => elements[x + y*Width].Val;
    public int GetElementValue((int x, int y) pos) => elements[pos.x + pos.y*Width].Val;
    public Element GetElement((int x, int y) pos) => elements[pos.x + pos.y*Width];
    public List<int> GetLine(int i)
    {
      var line = new List<int>();
      i--;

      for (int w = 0; w < Width; ++w)
      {
          line.Add(GetElementValue(w, i));
      }

      return line;
    }

    public List<int> GetColumn(int i)
    {
      List<int> column = new List<int>();
      i--;

      for (int h = 0; h < Height; ++h) 
      {
          column.Add(GetElementValue(i, h));
      }

      return column;
    }

    public void Print() 
    {
      for (int h = 0; h < Height; ++h) 
      {
          for (int w = 0; w < Width; ++w) 
          {
              Console.Write("{0} ", GetElementValue(w, h));
          }
          Console.Write("\n");
      }
    }

    public Matrix Transpose()
    {
      List<int> elements = new List<int>();

      for (int w = 1; w <= Width; ++w) 
          elements.AddRange(GetColumn(w));

      return new Matrix(Height, Width, elements.ToArray());
    }
    private static int CalculateScalar(List<int> l, List<int> r) 
    {
      int a = 0;

      for (int i = 0; i < l.Count; ++i)
        a += (l[i] * r[i]);
      return a;
    } 
    public static Matrix operator +(Matrix l, Matrix r)
    {
      List<int> values = new List<int>();
      int lsize = l.Width*l.Height;
      int rsize = r.Width*r.Height;
      if (lsize == rsize) 
      { 
        foreach (Element el in l.elements)
          values.Add(r.GetElement(el.coordinates).Val + l.GetElement(el.coordinates).Val);

        return new Matrix(l.Width, l.Height, values.ToArray());
      }
      else 
        Console.WriteLine("Sizes aren`t equal");
      return null;
    }
    public static Matrix operator *(Matrix l, Matrix r)
    {
      var _height = r.Height;
      var _width = l.Width;
      if (_height == _width) 
      {
        List<int> values = new List<int>();

        for (int h = 1; h <= _height; ++h)
        {
          for (int w = 1; w <= _width; ++w) 
          {
            values.Add(CalculateScalar(l.GetLine(h), r.GetColumn(w)));
          }
        }

        return new Matrix(_width, _height, values.ToArray());
      }
      Console.WriteLine("Fail *.");
      return null;
    }
    public static Matrix operator *(Matrix el, int n) 
    {
      List<int> values = new List<int>();  

      foreach (var obj in el.elements)
        values.Add(n*obj.Val);

      return new Matrix(el.Width, el.Height, values.ToArray());
    }

    public static Matrix operator *(int n, Matrix el) => el*n;
  }
}