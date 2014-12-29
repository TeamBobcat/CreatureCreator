using UnityEngine;
using System.Collections;

public class BodyPart : MonoBehaviour
{
    
   public void create_bone(Vector3 position, Mesh part, float x_size, float y_size, float z_size)
    {
       
            #region Vertices_
        Vector3 p0 = new Vector3(position.x + x_size, position.y, position.z);
        Vector3 p1 = new Vector3(position.x, position.y, position.z);
        Vector3 p2 = new Vector3(position.x, position.y, position.z + z_size);
        Vector3 p3 = new Vector3(position.x + x_size, position.y, position.z + z_size);

        Vector3 p4 = new Vector3(position.x + x_size, position.y + y_size, position.z);
        Vector3 p5 = new Vector3(position.x, position.y + y_size, position.z);
        Vector3 p6 = new Vector3(position.x, position.y + y_size, position.z + z_size);
        Vector3 p7 = new Vector3(position.x + x_size, position.y + y_size, position.z + z_size);

            Vector3[] vertices = new Vector3[]
{
	// Bottom
	p0, p1, p2, p3,
 
	// Left
	p7, p4, p0, p3,
 
	// Front
	p4, p5, p1, p0,
 
	// Back
	p6, p7, p3, p2,
 
	// Right
	p5, p6, p2, p1,
 
	// Top
	p7, p6, p5, p4
};
            #endregion

            #region Normales
            Vector3 up = Vector3.up;
            Vector3 down = Vector3.down;
            Vector3 front = Vector3.forward;
            Vector3 back = Vector3.back;
            Vector3 left = Vector3.left;
            Vector3 right = Vector3.right;

            Vector3[] normales = new Vector3[]
{
	// Bottom
	down, down, down, down,
 
	// Left
	left, left, left, left,
 
	// Front
	front, front, front, front,
 
	// Back
	back, back, back, back,
 
	// Right
	right, right, right, right,
 
	// Top
	up, up, up, up
};
            #endregion

            #region UVs
            Vector2 _00 = new Vector2(0f, 0f);
            Vector2 _10 = new Vector2(1f, 0f);
            Vector2 _01 = new Vector2(0f, 1f);
            Vector2 _11 = new Vector2(1f, 1f);

            Vector2[] uvs = new Vector2[]
{
	// Bottom
	_11, _01, _00, _10,
 
	// Left
	_11, _01, _00, _10,
 
	// Front
	_11, _01, _00, _10,
 
	// Back
	_11, _01, _00, _10,
 
	// Right
	_11, _01, _00, _10,
 
	// Top
	_11, _01, _00, _10,
};
            #endregion

            #region Triangles
            int[] triangles = new int[]
{
	// Bottom
	3, 1, 0,
	3, 2, 1,			
 
	// Left
	3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
	3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
 
	// Front
	3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
	3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
 
	// Back
	3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
	3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
 
	// Right
	3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
	3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
 
	// Top
	3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
	3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
 
};
            #endregion
        
 
            part.vertices = vertices;
            part.normals = normales;
            part.uv = uvs;
            part.triangles = triangles;

    }

   public void create_thigh(Vector3 position, Mesh part, float x_size, float y_size, float z_size)
    {
       
            #region Vertices_
        Vector3 p0 = new Vector3(position.x + x_size, position.y, position.z);
        Vector3 p1 = new Vector3(position.x, position.y, position.z);
        Vector3 p2 = new Vector3(position.x, position.y, position.z + z_size);
        Vector3 p3 = new Vector3(position.x + x_size, position.y, position.z + z_size);

        Vector3 p4 = new Vector3(position.x + x_size + 0.1f, position.y + y_size, position.z - 0.1f);
        Vector3 p5 = new Vector3(position.x - 0.1f , position.y + y_size, position.z - 0.1f);
        Vector3 p6 = new Vector3(position.x - 0.1f, position.y + y_size, position.z + z_size + 0.1f);
        Vector3 p7 = new Vector3(position.x + x_size + 0.1f, position.y + y_size, position.z + z_size + 0.1f);

            Vector3[] vertices = new Vector3[]
{
	// Bottom
	p0, p1, p2, p3,
 
	// Left
	p7, p4, p0, p3,
 
	// Front
	p4, p5, p1, p0,
 
	// Back
	p6, p7, p3, p2,
 
	// Right
	p5, p6, p2, p1,
 
	// Top
	p7, p6, p5, p4
};
            #endregion

            #region Normales
            Vector3 up = Vector3.up;
            Vector3 down = Vector3.down;
            Vector3 front = Vector3.forward;
            Vector3 back = Vector3.back;
            Vector3 left = Vector3.left;
            Vector3 right = Vector3.right;

            Vector3[] normales = new Vector3[]
{
	// Bottom
	down, down, down, down,
 
	// Left
	left, left, left, left,
 
	// Front
	front, front, front, front,
 
	// Back
	back, back, back, back,
 
	// Right
	right, right, right, right,
 
	// Top
	up, up, up, up
};
            #endregion

            #region UVs
            Vector2 _00 = new Vector2(0f, 0f);
            Vector2 _10 = new Vector2(1f, 0f);
            Vector2 _01 = new Vector2(0f, 1f);
            Vector2 _11 = new Vector2(1f, 1f);

            Vector2[] uvs = new Vector2[]
{
	// Bottom
	_11, _01, _00, _10,
 
	// Left
	_11, _01, _00, _10,
 
	// Front
	_11, _01, _00, _10,
 
	// Back
	_11, _01, _00, _10,
 
	// Right
	_11, _01, _00, _10,
 
	// Top
	_11, _01, _00, _10,
};
            #endregion

            #region Triangles
            int[] triangles = new int[]
{
	// Bottom
	3, 1, 0,
	3, 2, 1,			
 
	// Left
	3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
	3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
 
	// Front
	3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
	3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
 
	// Back
	3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
	3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
 
	// Right
	3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
	3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
 
	// Top
	3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
	3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
 
};
            #endregion
        
 
            part.vertices = vertices;
            part.normals = normales;
            part.uv = uvs;
            part.triangles = triangles;

    }

   public void create_left_bicep(Vector3 position, Mesh part, float x_size, float y_size, float z_size)
   {

       #region Vertices_
       Vector3 p0 = new Vector3(position.x + x_size, position.y - 0.1f, position.z - 0.1f);
       Vector3 p1 = new Vector3(position.x, position.y, position.z);
       Vector3 p2 = new Vector3(position.x, position.y, position.z + z_size);
       Vector3 p3 = new Vector3(position.x + x_size, position.y - 0.1f, position.z + z_size + 0.1f);

       Vector3 p4 = new Vector3(position.x + x_size, position.y + y_size + 0.1f, position.z - 0.1f);
       Vector3 p5 = new Vector3(position.x, position.y + y_size, position.z);
       Vector3 p6 = new Vector3(position.x, position.y + y_size, position.z + z_size);
       Vector3 p7 = new Vector3(position.x + x_size, position.y + y_size + 0.1f, position.z + z_size + 0.1f);

       Vector3[] vertices = new Vector3[]
{
	// Bottom
	p0, p1, p2, p3,
 
	// Left
	p7, p4, p0, p3,
 
	// Front
	p4, p5, p1, p0,
 
	// Back
	p6, p7, p3, p2,
 
	// Right
	p5, p6, p2, p1,
 
	// Top
	p7, p6, p5, p4
};
       #endregion

       #region Normales
       Vector3 up = Vector3.up;
       Vector3 down = Vector3.down;
       Vector3 front = Vector3.forward;
       Vector3 back = Vector3.back;
       Vector3 left = Vector3.left;
       Vector3 right = Vector3.right;

       Vector3[] normales = new Vector3[]
{
	// Bottom
	down, down, down, down,
 
	// Left
	left, left, left, left,
 
	// Front
	front, front, front, front,
 
	// Back
	back, back, back, back,
 
	// Right
	right, right, right, right,
 
	// Top
	up, up, up, up
};
       #endregion

       #region UVs
       Vector2 _00 = new Vector2(0f, 0f);
       Vector2 _10 = new Vector2(1f, 0f);
       Vector2 _01 = new Vector2(0f, 1f);
       Vector2 _11 = new Vector2(1f, 1f);

       Vector2[] uvs = new Vector2[]
{
	// Bottom
	_11, _01, _00, _10,
 
	// Left
	_11, _01, _00, _10,
 
	// Front
	_11, _01, _00, _10,
 
	// Back
	_11, _01, _00, _10,
 
	// Right
	_11, _01, _00, _10,
 
	// Top
	_11, _01, _00, _10,
};
       #endregion

       #region Triangles
       int[] triangles = new int[]
{
	// Bottom
	3, 1, 0,
	3, 2, 1,			
 
	// Left
	3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
	3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
 
	// Front
	3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
	3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
 
	// Back
	3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
	3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
 
	// Right
	3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
	3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
 
	// Top
	3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
	3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
 
};
       #endregion


       part.vertices = vertices;
       part.normals = normales;
       part.uv = uvs;
       part.triangles = triangles;

   }

   public void create_right_bicep(Vector3 position, Mesh part, float x_size, float y_size, float z_size)
   {

       #region Vertices_
       Vector3 p0 = new Vector3(position.x + x_size, position.y, position.z);
       Vector3 p1 = new Vector3(position.x, position.y - 0.1f, position.z - 0.1f);
       Vector3 p2 = new Vector3(position.x, position.y - 0.1f, position.z + z_size + 0.1f);
       Vector3 p3 = new Vector3(position.x + x_size, position.y, position.z + z_size);

       Vector3 p4 = new Vector3(position.x + x_size, position.y + y_size, position.z);
       Vector3 p5 = new Vector3(position.x, position.y + y_size + 0.1f, position.z - 0.1f);
       Vector3 p6 = new Vector3(position.x, position.y + y_size + 0.1f, position.z + z_size + 0.1f);
       Vector3 p7 = new Vector3(position.x + x_size, position.y + y_size, position.z + z_size);

       Vector3[] vertices = new Vector3[]
{
	// Bottom
	p0, p1, p2, p3,
 
	// Left
	p7, p4, p0, p3,
 
	// Front
	p4, p5, p1, p0,
 
	// Back
	p6, p7, p3, p2,
 
	// Right
	p5, p6, p2, p1,
 
	// Top
	p7, p6, p5, p4
};
       #endregion

       #region Normales
       Vector3 up = Vector3.up;
       Vector3 down = Vector3.down;
       Vector3 front = Vector3.forward;
       Vector3 back = Vector3.back;
       Vector3 left = Vector3.left;
       Vector3 right = Vector3.right;

       Vector3[] normales = new Vector3[]
{
	// Bottom
	down, down, down, down,
 
	// Left
	left, left, left, left,
 
	// Front
	front, front, front, front,
 
	// Back
	back, back, back, back,
 
	// Right
	right, right, right, right,
 
	// Top
	up, up, up, up
};
       #endregion

       #region UVs
       Vector2 _00 = new Vector2(0f, 0f);
       Vector2 _10 = new Vector2(1f, 0f);
       Vector2 _01 = new Vector2(0f, 1f);
       Vector2 _11 = new Vector2(1f, 1f);

       Vector2[] uvs = new Vector2[]
{
	// Bottom
	_11, _01, _00, _10,
 
	// Left
	_11, _01, _00, _10,
 
	// Front
	_11, _01, _00, _10,
 
	// Back
	_11, _01, _00, _10,
 
	// Right
	_11, _01, _00, _10,
 
	// Top
	_11, _01, _00, _10,
};
       #endregion

       #region Triangles
       int[] triangles = new int[]
{
	// Bottom
	3, 1, 0,
	3, 2, 1,			
 
	// Left
	3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
	3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
 
	// Front
	3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
	3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
 
	// Back
	3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
	3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
 
	// Right
	3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
	3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
 
	// Top
	3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
	3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
 
};
       #endregion


       part.vertices = vertices;
       part.normals = normales;
       part.uv = uvs;
       part.triangles = triangles;

   }

   public void create_body(Vector3 position, Mesh part, float x_size, float y_size, float z_size)
   {

       #region Vertices_
       Vector3 p0 = new Vector3(position.x + x_size, position.y, position.z);
       Vector3 p1 = new Vector3(position.x, position.y, position.z);
       Vector3 p2 = new Vector3(position.x, position.y, position.z + z_size + 0.1f);
       Vector3 p3 = new Vector3(position.x + x_size, position.y, position.z + z_size);

       Vector3 p4 = new Vector3(position.x + x_size + 0.1f, position.y + y_size, position.z - 0.1f);
       Vector3 p5 = new Vector3(position.x - 0.1f, position.y + y_size, position.z - 0.1f);
       Vector3 p6 = new Vector3(position.x - 0.1f, position.y + y_size, position.z + z_size + 0.1f);
       Vector3 p7 = new Vector3(position.x + x_size + 0.1f, position.y + y_size, position.z + z_size + 0.1f);

       Vector3 p8 = new Vector3(position.x + x_size, position.y + y_size, position.z + z_size + 0.5f);
       Vector3 p9 = new Vector3(position.x, position.y + y_size, position.z + z_size + 0.5f);
       Vector3 p10 = new Vector3(position.x + x_size - 0.1f, position.y + 0.3f, position.z + z_size + 0.5f);
       Vector3 p11 = new Vector3(position.x + 0.1f, position.y + 0.3f, position.z + z_size + 0.5f);
       Vector3[] vertices = new Vector3[]
{
	// Bottom
	p0, p1, p2, p3,
    
    //arch back
    p10, p11, p2, p3,
 	
    // Right
	p5, p6, p2, p1,

    //arch right
    p9, p11, p2, p6,

    //arch top
    p8, p9, p10, p11,

    //arch left
    p8, p7, p3, p10,

	// Left
	p7, p4, p0, p3,
 
	// Front
	p4, p5, p1, p0,
 
    // Top
	p7, p6, p5, p4,

	// Back
	p6, p7, p3, p2,

  //arch front
    p6, p7, p8, p9,
};
       #endregion

       #region Normales
       Vector3 up = Vector3.up;
       Vector3 down = Vector3.down;
       Vector3 front = Vector3.forward;
       Vector3 back = Vector3.back;
       Vector3 left = Vector3.left;
       Vector3 right = Vector3.right;

       Vector3[] normales = new Vector3[]
{
	// Bottom
	down, down, down, down,
 
	// Left
	left, left, left, left,
 
	// Front
	front, front, front, front,
 
	// Back
	back, back, back, back,
 
	// Right
	right, right, right, right,
 
	// Top
	up, up, up, up,

      //arch top
    front, front, front, front,

    //arch left
    left, left, left, left,

    //arch right
    right, right, right, right,
 
    //arch front
    up, up, up, up,

    //arch back
    down, down, down, down,
};
       #endregion

       #region UVs
       Vector2 _00 = new Vector2(0f, 0f);
       Vector2 _10 = new Vector2(1f, 0f);
       Vector2 _01 = new Vector2(0f, 1f);
       Vector2 _11 = new Vector2(1f, 1f);

       Vector2[] uvs = new Vector2[]
{
	// Bottom
	_11, _01, _00, _10,
 
	// Left
	_11, _01, _00, _10,
 
	// Front
	_11, _01, _00, _10,
 
	// Back
	_11, _01, _00, _10,
 
	// Right
	_11, _01, _00, _10,
 
	// Top
	_11, _01, _00, _10,

    _11, _01, _00, _10,

    _11, _01, _00, _10,

    _11, _01, _00, _10,

    _11, _01, _00, _10,

    _11, _01, _00, _10,
};
       #endregion

       #region Triangles
       int[] triangles = new int[]
{
	// Bottom
	3, 1, 0,
	3, 2, 1,			
 
	// Left
	3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
	3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
 
	// Front
	3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
	3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
 
	// Back
	3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
	3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
 
	// Right
	3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
	3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
 
	// Top
	3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
	3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,

    //arch top
    3 + 4 * 6, 1 + 4 * 6, 0 + 4 * 6,
	3 + 4 * 6, 2 + 4 * 6, 1 + 4 * 6,

    //arch left
    3 + 4 * 7, 1 + 4 * 7, 0 + 4 * 7,
	3 + 4 * 7, 2 + 4 * 7, 1 + 4 * 7,

    //arch right
    3 + 4 * 8, 1 + 4 * 8, 0 + 4 * 8,
	3 + 4 * 8, 2 + 4 * 8, 1 + 4 * 8,

    //arch front
    3 + 4 * 9, 1 + 4 * 9, 0 + 4 * 9,
	3 + 4 * 9, 2 + 4 * 9, 1 + 4 * 9,

    //arch back
 	3 + 4 * 10, 1 + 4 * 10, 0 + 4 * 10,
	3 + 4 * 10, 2 + 4 * 10, 1 + 4 * 10,

};
       #endregion


       part.vertices = vertices;
       part.normals = normales;
       part.uv = uvs;
       part.triangles = triangles;

   }

   public void create_right_side(Vector3 position, Mesh part, float x_size, float y_size, float z_size)
   {

       #region Vertices_
       Vector3 p0 = new Vector3(position.x + x_size + 0.1f, position.y, position.z);
       Vector3 p1 = new Vector3(position.x, position.y, position.z + 0.2f);
       Vector3 p2 = new Vector3(position.x, position.y, position.z + z_size - 0.2f);
       Vector3 p3 = new Vector3(position.x + x_size + 0.1f, position.y, position.z + z_size);

       Vector3 p4 = new Vector3(position.x + x_size, position.y + y_size, position.z);
       Vector3 p5 = new Vector3(position.x, position.y + y_size, position.z + 0.2f);
       Vector3 p6 = new Vector3(position.x, position.y + y_size, position.z + z_size - 0.2f);
       Vector3 p7 = new Vector3(position.x + x_size, position.y + y_size, position.z + z_size);

       Vector3[] vertices = new Vector3[]
{
	// Bottom
	p0, p1, p2, p3,
 
	// Left
	p7, p4, p0, p3,
 
	// Front
	p4, p5, p1, p0,
 
	// Back
	p6, p7, p3, p2,
 
	// Right
	p5, p6, p2, p1,
 
	// Top
	p7, p6, p5, p4
};
       #endregion

       #region Normales
       Vector3 up = Vector3.up;
       Vector3 down = Vector3.down;
       Vector3 front = Vector3.forward;
       Vector3 back = Vector3.back;
       Vector3 left = Vector3.left;
       Vector3 right = Vector3.right;

       Vector3[] normales = new Vector3[]
{
	// Bottom
	down, down, down, down,
 
	// Left
	left, left, left, left,
 
	// Front
	front, front, front, front,
 
	// Back
	back, back, back, back,
 
	// Right
	right, right, right, right,
 
	// Top
	up, up, up, up
};
       #endregion

       #region UVs
       Vector2 _00 = new Vector2(0f, 0f);
       Vector2 _10 = new Vector2(1f, 0f);
       Vector2 _01 = new Vector2(0f, 1f);
       Vector2 _11 = new Vector2(1f, 1f);

       Vector2[] uvs = new Vector2[]
{
	// Bottom
	_11, _01, _00, _10,
 
	// Left
	_11, _01, _00, _10,
 
	// Front
	_11, _01, _00, _10,
 
	// Back
	_11, _01, _00, _10,
 
	// Right
	_11, _01, _00, _10,
 
	// Top
	_11, _01, _00, _10,
};
       #endregion

       #region Triangles
       int[] triangles = new int[]
{
	// Bottom
	3, 1, 0,
	3, 2, 1,			
 
	// Left
	3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
	3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
 
	// Front
	3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
	3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
 
	// Back
	3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
	3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
 
	// Right
	3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
	3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
 
	// Top
	3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
	3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
 
};
       #endregion


       part.vertices = vertices;
       part.normals = normales;
       part.uv = uvs;
       part.triangles = triangles;

   }

   public void create_left_side(Vector3 position, Mesh part, float x_size, float y_size, float z_size)
   {

       #region Vertices_
       Vector3 p0 = new Vector3(position.x + x_size, position.y, position.z + 0.2f);
       Vector3 p1 = new Vector3(position.x - 0.1f, position.y, position.z);
       Vector3 p2 = new Vector3(position.x - 0.1f, position.y, position.z + z_size);
       Vector3 p3 = new Vector3(position.x + x_size, position.y, position.z + z_size - 0.2f);

       Vector3 p4 = new Vector3(position.x + x_size, position.y + y_size, position.z + 0.2f);
       Vector3 p5 = new Vector3(position.x, position.y + y_size, position.z);
       Vector3 p6 = new Vector3(position.x, position.y + y_size, position.z + z_size);
       Vector3 p7 = new Vector3(position.x + x_size, position.y + y_size, position.z + z_size - 0.2f);

       Vector3[] vertices = new Vector3[]
{
	// Bottom
	p0, p1, p2, p3,
 
	// Left
	p7, p4, p0, p3,
 
	// Front
	p4, p5, p1, p0,
 
	// Back
	p6, p7, p3, p2,
 
	// Right
	p5, p6, p2, p1,
 
	// Top
	p7, p6, p5, p4
};
       #endregion

       #region Normales
       Vector3 up = Vector3.up;
       Vector3 down = Vector3.down;
       Vector3 front = Vector3.forward;
       Vector3 back = Vector3.back;
       Vector3 left = Vector3.left;
       Vector3 right = Vector3.right;

       Vector3[] normales = new Vector3[]
{
	// Bottom
	down, down, down, down,
 
	// Left
	left, left, left, left,
 
	// Front
	front, front, front, front,
 
	// Back
	back, back, back, back,
 
	// Right
	right, right, right, right,
 
	// Top
	up, up, up, up
};
       #endregion

       #region UVs
       Vector2 _00 = new Vector2(0f, 0f);
       Vector2 _10 = new Vector2(1f, 0f);
       Vector2 _01 = new Vector2(0f, 1f);
       Vector2 _11 = new Vector2(1f, 1f);

       Vector2[] uvs = new Vector2[]
{
	// Bottom
	_11, _01, _00, _10,
 
	// Left
	_11, _01, _00, _10,
 
	// Front
	_11, _01, _00, _10,
 
	// Back
	_11, _01, _00, _10,
 
	// Right
	_11, _01, _00, _10,
 
	// Top
	_11, _01, _00, _10,
};
       #endregion

       #region Triangles
       int[] triangles = new int[]
{
	// Bottom
	3, 1, 0,
	3, 2, 1,			
 
	// Left
	3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
	3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
 
	// Front
	3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
	3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
 
	// Back
	3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
	3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
 
	// Right
	3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
	3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
 
	// Top
	3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
	3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
 
};
       #endregion


       part.vertices = vertices;
       part.normals = normales;
       part.uv = uvs;
       part.triangles = triangles;

   }

   public void create_head(Vector3 position, Mesh part, float x_size, float y_size, float z_size)
   {

       #region Vertices_
       Vector3 p0 = new Vector3(position.x + x_size + 0.2f, position.y - 0.1f, position.z - 0.1f);
       Vector3 p1 = new Vector3(position.x - 0.2f, position.y - 0.1f, position.z - 0.1f);
       Vector3 p2 = new Vector3(position.x, position.y, position.z + z_size);
       Vector3 p3 = new Vector3(position.x + x_size, position.y, position.z + z_size);

       Vector3 p4 = new Vector3(position.x + x_size + 0.2f, position.y + y_size + 0.1f, position.z - 0.1f);
       Vector3 p5 = new Vector3(position.x - 0.2f, position.y + y_size + 0.1f, position.z - 0.1f);
       Vector3 p6 = new Vector3(position.x, position.y + y_size, position.z + z_size);
       Vector3 p7 = new Vector3(position.x + x_size, position.y + y_size, position.z + z_size);

       Vector3[] vertices = new Vector3[]
{
	// Bottom
	p0, p1, p2, p3,
 
	// Left
	p7, p4, p0, p3,
 
	// Front
	p4, p5, p1, p0,
 
	// Back
	p6, p7, p3, p2,
 
	// Right
	p5, p6, p2, p1,
 
	// Top
	p7, p6, p5, p4
};
       #endregion

       #region Normales
       Vector3 up = Vector3.up;
       Vector3 down = Vector3.down;
       Vector3 front = Vector3.forward;
       Vector3 back = Vector3.back;
       Vector3 left = Vector3.left;
       Vector3 right = Vector3.right;

       Vector3[] normales = new Vector3[]
{
	// Bottom
	down, down, down, down,
 
	// Left
	left, left, left, left,
 
	// Front
	front, front, front, front,
 
	// Back
	back, back, back, back,
 
	// Right
	right, right, right, right,
 
	// Top
	up, up, up, up
};
       #endregion

       #region UVs
       Vector2 _00 = new Vector2(0f, 0f);
       Vector2 _10 = new Vector2(1f, 0f);
       Vector2 _01 = new Vector2(0f, 1f);
       Vector2 _11 = new Vector2(1f, 1f);

       Vector2[] uvs = new Vector2[]
{
	// Bottom
	_11, _01, _00, _10,
 
	// Left
	_11, _01, _00, _10,
 
	// Front
	_11, _01, _00, _10,
 
	// Back
	_11, _01, _00, _10,
 
	// Right
	_11, _01, _00, _10,
 
	// Top
	_11, _01, _00, _10,
};
       #endregion

       #region Triangles
       int[] triangles = new int[]
{
	// Bottom
	3, 1, 0,
	3, 2, 1,			
 
	// Left
	3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
	3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
 
	// Front
	3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
	3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
 
	// Back
	3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
	3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
 
	// Right
	3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
	3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
 
	// Top
	3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
	3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
 
};
       #endregion


       part.vertices = vertices;
       part.normals = normales;
       part.uv = uvs;
       part.triangles = triangles;

   }

}
