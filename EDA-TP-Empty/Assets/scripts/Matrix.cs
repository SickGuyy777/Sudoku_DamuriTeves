using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Matrix<T> : IEnumerable<T>
{
    //IMPLEMENTAR: ESTRUCTURA INTERNA- DONDE GUARDO LOS DATOS?
    T[,] _matrix;

    public Matrix(int width, int height)
    {
        //IMPLEMENTAR: constructor
        _matrix = new T[width, height];
        Width = width;
        Height = height;
        Capacity = width * height;
    }

    public Matrix(T[,] copyFrom)
    {
        //IMPLEMENTAR: crea una version de Matrix a partir de una matriz básica de C#
        //_matrix = copyFrom;
        Width = copyFrom.GetLength(0);
        Height = copyFrom.GetLength(1);
        Capacity = Width * Height;

        _matrix = new T[Width, Height];

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                _matrix[x, y] = copyFrom[x, y];
            }
        }
    }

    public Matrix<T> Clone()
    {
        Matrix<T> aux = new Matrix<T>(Width, Height);
        //IMPLEMENTAR

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                aux[x, y] = this[x, y];
            }
        }
        return aux;
    }

    public void SetRangeTo(int x0, int y0, int x1, int y1, T item)
    {
        //IMPLEMENTAR: iguala todo el rango pasado por parámetro a item
        for (int x = x0; x < x1; x++)
        {
            for (int y = y0; y < y1; y++)
            {
                _matrix[x, y] = item;
            }
        }

    }

    //Todos los parametros son INCLUYENTES
    public List<T> GetRange(int x0, int y0, int x1, int y1)
    {
        List<T> range = new List<T>();
        //IMPLEMENTAR
        for (int x = x0; x < x1; x++)
        {
            for (int y = y0; y < y1; y++)
            {
                range.Add(_matrix[x, y]);
            }
        }

        return range;
    }

    //Para poder igualar valores en la matrix a algo
    public T this[int x, int y]
    {
        get
        {
            //IMPLEMENTAR
            return _matrix[x, y];

            //return default(T);
        }
        set
        {
            //IMPLEMENTAR
            _matrix[x, y] = value;
        }
    }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public int Capacity { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        //IMPLEMENTAR


        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                yield return _matrix[x, y];
            }
        }
        //yield return default(T);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
