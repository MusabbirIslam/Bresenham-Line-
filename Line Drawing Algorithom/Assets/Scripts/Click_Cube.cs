using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Cube : MonoBehaviour
{
    int x;
    int y;

    public void Set_XY(int x,int y)
    {
        this.x = x;
        this.y = y;
    }

    private void OnMouseDown()
    {
        Debug.Log("x "+x+" y "+y);
        MAtrix_Generator.instance.Get_Point(x, y);
    }
}


/*public class Nafis
{
    void drawline(int x0,int x1,int y0,int y1)
    {
        //array is the array of yours

        int dx, dy, p, x, y;

        int xIncrement = 1;
        int yIncrement = 1;

        x = x0;
        y = y0;

        dx = x1 - x0;
        dy = y1 - y0;

        if (dy < 0)
        {
            dy = dy * -1;
            yIncrement = -1;
        }

        if (dx < 0)
        {
            dx = dx * -1;
            xIncrement = -1;
        }
        else if (dx == 0)
        {
            Vertical_Line(y, dy, yIncrement, x);
            return;
        }

        int slope = dy / dx;

        if (slope < 1)
        {
            array[x, y]= 0; // reeference your array
            p = 2 * dy - dx;

            for (int i = 0; i < dx; i++)
            {
                x = x + xIncrement;
                if (p >= 0)
                {
                    y = y + yIncrement;
                    p = p + 2 * dy - 2 * dx;
                }
                else
                {
                    p = p + 2 * dy;
                }
                array[x, y] = 0; // reeference your array

            }

        }
        else
        {
            array[x, y] = 0; // reeference your array

            p = 2 * dx - dy;

            for (int i = 0; i < dy; i++)
            {
                y = y + yIncrement;
                if (p < 0)
                {
                    p = p + 2 * dx;
                }
                else
                {
                    x = x + xIncrement;
                    p = p + 2 * dx - 2 * dy;
                }

                array[x, y] = 0; // reeference your array
            }
        }
    }

    void Vertical_Line(int y, int dy, int increment, int x)
    {
        for (int i = 0; i <= dy; i++)
        {
            array[x, y] = 0; // reeference your array
            y += increment;
        }
    }
}*/
