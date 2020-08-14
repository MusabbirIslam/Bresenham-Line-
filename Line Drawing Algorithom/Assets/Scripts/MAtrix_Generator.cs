using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAtrix_Generator : MonoBehaviour
{
    public int x;
    public int y;
    public GameObject prefab;

    public GameObject[,] array;

    public static MAtrix_Generator instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        array = new GameObject[20,20];

        for (int i = 0; i < x; i++)
        {
            for(int j=0;j<y;j++)
            {
                Vector3 pos = new Vector3(i, j, 0);
                GameObject cube = Instantiate(prefab,pos,Quaternion.identity);

                Click_Cube click = cube.GetComponent<Click_Cube>();
                click.Set_XY(i,j);
                array[i,j] = cube;
            }
        }
    }


    //line draw mech

    bool first_came = false;

    int x0, y0, x1, y1;

    public Material red;

    public void Get_Point(int x, int y)
    {
        if (!first_came)
        {
            x0 = x;
            y0 = y;
            first_came = true;
        }
        else
        {
            x1 = x;
            y1 = y;
            first_came = false;
            drawline();
        }
    }

    void drawline()
    {
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
            instance.array[x, y].GetComponent<MeshRenderer>().material = red;
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
                instance.array[x, y].GetComponent<MeshRenderer>().material = red;

            }

        }
        else
        {
            instance.array[x, y].GetComponent<MeshRenderer>().material = red;
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

                instance.array[x, y].GetComponent<MeshRenderer>().material = red;
            }
        }
    }

    void Vertical_Line(int y, int dy, int increment, int x)
    {
        for (int i = 0; i <= dy; i++)
        {
            instance.array[x, y].GetComponent<MeshRenderer>().material = red;
            y += increment;
        }
    }
}
