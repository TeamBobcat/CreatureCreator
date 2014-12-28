using UnityEngine;
using System.Collections;

public class Creature : BodyPart
{
   
    Vector3 position;

    Mesh body_part = new Mesh();

    // Use this for initialization
    void Start()
    {
        GameObject parent = GameObject.Find("Creature");
        load_legs(parent, 2);
        load_body(parent, 3);
        load_arms(parent, 2);
        load_neck(parent, 2);
        load_tail(parent, 4);
        //  load_wings();


        GameObject left_leg = GameObject.Find("Legs/Left Leg");
        GameObject left_lower_torso = GameObject.Find("Body/Lower Torso/Segment: 3");
        Bounds left_torso_bounds = left_lower_torso.transform.renderer.bounds;
        Vector3 left_leg_position = new Vector3(left_torso_bounds.min.x, left_torso_bounds.min.y - 2.0f, 0.1f);
        left_leg.transform.position =  left_leg_position;

        GameObject right_leg = GameObject.Find("Legs/Right Leg");
        GameObject right_lower_torso = GameObject.Find("Body/Lower Torso/Segment: 1");
        Bounds right_torso_bounds = right_lower_torso.transform.renderer.bounds;
        Vector3 right_leg_position = new Vector3(right_torso_bounds.min.x, right_torso_bounds.min.y - 2.0f, 0.1f);
        right_leg.transform.position = right_leg_position;

       
      //  GameObject left_thigh = GameObject.Find("Left Leg/Segment: 2");
      
    }

    void load_legs(GameObject obj, int number_of_segments)
    {
        position = new Vector3(0.1f, 0.0f, 0.1f);
        GameObject legs = new GameObject("Legs");
        legs.transform.parent = obj.transform;

        GameObject section = gameObject;

        int number_of_legs = 2;

        for (int i = 0; i < number_of_legs; i++)
        {
            position.y = 0.0f;

            if (i == 0)
            {
                section = new GameObject("Left Leg");
                section.transform.parent = legs.transform;
            }

            if (i == 1)
            {
                section = new GameObject("Right Leg");
                section.transform.parent = legs.transform;
            }

            for (int j = 0; j < number_of_segments; j++)
            {

                GameObject segment = new GameObject("Segment: " + (j + 1));
                segment.transform.parent = section.transform;
                create_mesh(segment);
                      
                if (j == 0)
                {
                    create_bone(position, body_part, 0.3f, 1.0f, 0.3f);
                }

                if (j == 1)
                {
                    create_thigh(position, body_part, 0.3f, 1.0f, 0.3f);
                }

                body_part.RecalculateBounds();
                body_part.Optimize();

                position.y = body_part.bounds.max.y;

            }   
            position.x += 0.5f;
        }

        GameObject shin = GameObject.Find("Left Leg/Segment: 1");
        GameObject left_thigh = GameObject.Find("Left Leg/Segment: 2");
      
    }

    void load_body(GameObject obj, int number_of_segments)
    {
        position.x = 0.1f; position.z = 0.1f;
        GameObject body = new GameObject("Body");
        body.transform.parent = obj.transform;

        GameObject section = gameObject;
        int number_of_sections = 3; //upper, mid, lower torso

        for (int i = 0; i < number_of_sections; i++)
        {

            if (i == 0)
            {
                section = new GameObject("Lower Torso");
                section.transform.parent = body.transform;
            }

            if (i == 1)
            {
                section = new GameObject("Mid Torso");
                section.transform.parent = body.transform;
            }

            if (i == 2)
            {
                section = new GameObject("Upper Torso");
                section.transform.parent = body.transform;
            }

            for (int j = 0; j < number_of_segments; j++)
            {
                GameObject segment = new GameObject("Segment: " + (j + 1));
                segment.transform.parent = section.transform;
                create_mesh(segment);
                create_bone(position, body_part, 0.5f, 1.0f, 0.5f);

                body_part.RecalculateBounds();
                body_part.Optimize();

                if (j == 0) { 
           
                    position.x += 0.5f;
                
                }
                else if (j == 1)
                {
                    position.x -= 0.5f * 2;
                }
            }
            position.x = 0.1f;
            position.y = body_part.bounds.max.y;
        }
    }

    void load_arms(GameObject obj, int number_of_segments)
    {

        GameObject right_upper_torso = GameObject.Find("Mid Torso/Segment: 3");
        GameObject left_upper_torso = GameObject.Find("Mid Torso/Segment: 2");
        position.y = right_upper_torso.renderer.bounds.max.y;
        

        GameObject arms = new GameObject("Arms");
        arms.transform.parent = obj.transform;

        GameObject section = gameObject;
        int number_of_arms = 2; //upper and lower arm

        for (int i = 0; i < number_of_arms; i++)
        {

            if (i == 0)
            {
                section = new GameObject("Right arm");
                section.transform.parent = arms.transform;
                position.x = right_upper_torso.renderer.bounds.min.x;

            }

            if (i == 1)
            {
                section = new GameObject("Left Arm");
                section.transform.parent = arms.transform;
                position.x = left_upper_torso.renderer.bounds.max.x;
            }


            for (int j = 0; j < number_of_segments; j++)
            {
                GameObject segment = new GameObject("Segment: " + (j + 1));
                segment.transform.parent = section.transform;
                if (i == 0)
                {
                    create_mesh(segment);
                    create_bone(position, body_part, -1.0f, 0.2f, 0.2f);

                    body_part.RecalculateBounds();
                    body_part.Optimize();

                    position.x = body_part.bounds.min.x;
                }

                if (i == 1)
                {
                    create_mesh(segment);
                    create_bone(position, body_part, 1.0f, 0.2f, 0.2f);

                    body_part.RecalculateBounds();
                    body_part.Optimize();

                    position.x = body_part.bounds.max.x;
                }
            }            

        }
    }

    void load_neck(GameObject obj, int number_of_segments)
    {
        GameObject mid_upper_torso = GameObject.Find("Upper Torso/Segment: 1");
        position.y = mid_upper_torso.renderer.bounds.max.y;
        position.x = mid_upper_torso.renderer.bounds.min.x;

        GameObject neck = new GameObject("Neck");
        neck.transform.parent = obj.transform;

            for (int j = 0; j < number_of_segments; j++)
            {
                GameObject segment = new GameObject("Segment: " + (j + 1));
                segment.transform.parent = neck.transform;
            
                create_mesh(segment);
                create_bone(position, body_part, 0.5f, 0.2f, 0.5f);

                body_part.RecalculateBounds();
                body_part.Optimize();

                position.y = body_part.bounds.max.y;
            }            
    }

    void load_tail(GameObject obj, int number_of_segments)
    {
        GameObject mid_lower_torso = GameObject.Find("Lower Torso/Segment: 1");
        position.y = mid_lower_torso.renderer.bounds.min.y;
        position.x = mid_lower_torso.renderer.bounds.min.x;
        position.z = mid_lower_torso.renderer.bounds.min.z;

        GameObject tail = new GameObject("Tail");
        tail.transform.parent = obj.transform;

        for (int j = 0; j < number_of_segments; j++)
        {
            GameObject segment = new GameObject("Segment: " + (j + 1));
            segment.transform.parent = tail.transform;

            create_mesh(segment);
            create_bone(position, body_part, 0.1f, 0.1f, -1.0f);

            body_part.RecalculateBounds();
            body_part.Optimize();
            position.z = body_part.bounds.min.z;
        }   
    }


    void load_wings()
    {



    }

    void create_mesh(GameObject obj)
    {
        MeshFilter filter = obj.AddComponent<MeshFilter>();
        MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
        renderer.material = new Material(Shader.Find("Diffuse"));
        body_part = filter.mesh;
        body_part.Clear();

    }

    void Update()
    {
 
	}
 }


