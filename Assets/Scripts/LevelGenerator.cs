using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static ushort cubes = 20;

    public float pointSize = 0.25F;
    public Vector3 origin = Vector3.zero;

    //readonly Color[] colors = { Color.blue, Color.blue, Color.green, Color.green, Color.red, Color.red };

    public void Generate2D()
    {
        GameObject parent = this.gameObject;
        Shader vertexlit_shader = Shader.Find("Mobile/VertexLit");
        Texture cube_texture = Resources.Load("Grass&Rock") as Texture;

        Shader diffuse_shader = Shader.Find("Mobile/Diffuse");
        Texture ball_texture = Resources.Load("yellow") as Texture;

        System.Random rnd = new System.Random();

        Transform parentTransform = parent.transform;
        Vector3 pointsOrigin = new Vector3(0F, 1F, 0F);
        Vector3 pointSizeVec = new Vector3(pointSize, pointSize, pointSize);
        int Value;
        int lastValue = -1;
        GameObject g;
        Renderer renderer;

        GameObject defaultCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        renderer = defaultCube.GetComponent<Renderer>();
        renderer.receiveShadows = false;
        renderer.material.shader = vertexlit_shader;
        renderer.material.mainTexture = cube_texture;
        //renderer.material.color = colors[0];

        GameObject defaultPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        defaultPoint.transform.localScale = pointSizeVec;
        renderer = defaultPoint.GetComponent<Renderer>();
        renderer.receiveShadows = true;
        renderer.material.shader = diffuse_shader;
        renderer.material.mainTexture = ball_texture;
        defaultPoint.GetComponent<Collider>().isTrigger = true;
        defaultPoint.AddComponent<PointCollected>();

        //0
        GameObject cube = defaultCube;
        cube.transform.parent = parentTransform;
        cube.transform.position = origin;
        //cube.GetComponent<Renderer>().material.color = colors[colors.Length - 1];

        for (ushort i = 0; i < cubes; ++i)
        {
            do
            {
                Value = rnd.Next(8);
            } while (Value == lastValue);

            switch (Value)
            {
                case 0:
                    origin.x += 1;
                    lastValue = 1;
                    break;
                case 1:
                    origin.x -= 1;
                    lastValue = 0;
                    break;
                case 2:
                    origin.z -= 1;
                    lastValue = 3;
                    break;
                case 3:
                    origin.z += 1;
                    lastValue = 2;
                    break;

                case 4:
                    origin.x += 1;
                    origin.z += 1;
                    lastValue = 7;
                    break;
                case 5:
                    origin.x -= 1;
                    origin.z += 1;
                    lastValue = 6;
                    break;
                case 6:
                    origin.x += 1;
                    origin.z -= 1;
                    lastValue = 5;
                    break;
                case 7:
                    origin.x -= 1;
                    origin.z -= 1;
                    lastValue = 4;
                    break;
            }

            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            var cubetransform = cube.transform;
            cubetransform.parent = parentTransform;
            cubetransform.position = origin;

            renderer = cube.GetComponent<Renderer>();
            renderer.receiveShadows = false;
            renderer.material.shader = vertexlit_shader;
            renderer.material.mainTexture = cube_texture;
            //renderer.material.color = colors[i % colors.Length];

            g = Instantiate(defaultPoint);
            g.transform.parent = cubetransform;
            g.transform.localPosition = pointsOrigin;
        }

        Destroy(defaultPoint);

        Game.MaxPoints = cubes;
    }

}
