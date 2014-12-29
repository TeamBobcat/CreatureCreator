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
        load_neck(parent, 5);
        load_tail(parent, 4);
        load_head(parent);
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
                    create_bone(position, body_part, 0.2f, 1.0f, 0.2f);
                }

                if (j == 1)
                {
                    create_thigh(position, body_part, 0.2f, 1.0f, 0.2f);
                }

                body_part.RecalculateBounds();
                body_part.Optimize();

                position.y = body_part.bounds.max.y;

            }   
            position.x += 0.5f;
        }

    }

    void load_body(GameObject obj, int number_of_segments)
    {
        position.x = 0.1f; position.z = 0.1f;
        GameObject body = new GameObject("Body");
        body.transform.parent = obj.transform;

        GameObject section = gameObject;
        int number_of_sections = 3; //upper, mid, lower torso
        float size = 0.0f;

        for (int i = 0; i < number_of_sections; i++)
        {

            if (i == 0)
            {
                section = new GameObject("Lower Torso");
                section.transform.parent = body.transform;
                size = 0.5f;
            }

            if (i == 1)
            {
                section = new GameObject("Mid Torso");
                section.transform.parent = body.transform;
                position.x -= 0.15f;
                size = 0.8f;
            }

            if (i == 2)
            {
                section = new GameObject("Upper Torso");
                section.transform.parent = body.transform;
                size = 0.5f;

            }

            for (int j = 0; j < number_of_segments; j++)
            {
                GameObject segment = new GameObject("Segment: " + (j + 1));
                segment.transform.parent = section.transform;
                create_mesh(segment);
                if (j == 0)
                {
                    create_body(position, body_part, size, 1.0f, size);
                }

                if (j == 1)
                {
                    
                    create_left_side(position, body_part, 0.2f, 1.0f, 0.5f);
                }

                if (j == 2)
                {
                    create_right_side(position, body_part, 0.2f, 1.0f, 0.5f);

                }

                body_part.RecalculateBounds();
                body_part.Optimize();

                if (j == 0) { 
           
                    position.x += size + 0.1f;
                
                }
                else if (j == 1)
                {
                    position.x -= size +0.4f;
                }
            }
            position.x = 0.1f;
            position.y = body_part.bounds.max.y;
        }
    }

    void load_arms(GameObject obj, int number_of_segments)
    {

        GameObject right_upper_torso = GameObject.Find("Upper Torso/Segment: 3");
        GameObject left_upper_torso = GameObject.Find("Upper Torso/Segment: 2");
        position.y = (right_upper_torso.renderer.bounds.max.y + right_upper_torso.renderer.bounds.min.y)/2;
        

        GameObject arms = new GameObject("Arms");
        arms.transform.parent = obj.transform;

        GameObject section = gameObject;
        int number_of_arms = 2; //upper and lower arm

        for (int i = 0; i < number_of_arms; i++)
        {

            if (i == 0)
            {
                section = new GameObject("Left arm");
                section.transform.parent = arms.transform;
                position.x = left_upper_torso.renderer.bounds.max.x + 1.0f;

            }

            if (i == 1)
            {
                section = new GameObject("Right Arm");
                section.transform.parent = arms.transform;
                position.x = right_upper_torso.renderer.bounds.min.x;
            }


            for (int j = 0; j < number_of_segments; j++)
            {
                GameObject segment = new GameObject("Segment: " + (j + 1));
                segment.transform.parent = section.transform;
                if (j == 0)
                {
                    create_mesh(segment);
                    if (i == 0)
                    {
                        create_left_bicep(position, body_part, -1.0f, 0.2f, 0.2f);
                    }
                    if (i == 1)
                    {
                        create_right_bicep(position, body_part, -1.0f, 0.2f, 0.2f);
                 
                    }
                    body_part.RecalculateBounds();
                    body_part.Optimize();     
                }

                if (j == 1)
                {
                    create_mesh(segment);
                    create_bone(position, body_part, 1.0f, 0.2f, 0.2f);

                    body_part.RecalculateBounds();
                    body_part.Optimize();
   
                }

                if (i == 0)
                {
                position.x = body_part.bounds.max.x;
                }

                if (i == 1)
                {
                position.x = body_part.bounds.min.x - 1.0f;
                }
            }            

        }
    }

    void load_neck(GameObject obj, int number_of_segments)
    {
        GameObject mid_upper_torso = GameObject.Find("Upper Torso/Segment: 1");
        position.y = mid_upper_torso.renderer.bounds.max.y;
        position.x = 0.3f;
        position.z = (mid_upper_torso.renderer.bounds.max.z + mid_upper_torso.renderer.bounds.min.z) / 2;

        GameObject neck = new GameObject("Neck");
        neck.transform.parent = obj.transform;

            for (int j = 0; j < number_of_segments; j++)
            {
                GameObject segment = new GameObject("Segment: " + (j + 1));
                segment.transform.parent = neck.transform;
            
                create_mesh(segment);
                create_bone(position, body_part, 0.1f, 0.1f, 0.1f);

                body_part.RecalculateBounds();
                body_part.Optimize();

                position.y = body_part.bounds.max.y;
            }            
    }

    void load_tail(GameObject obj, int number_of_segments)
    {
        GameObject mid_lower_torso = GameObject.Find("Lower Torso/Segment: 1");
        position.y = (mid_lower_torso.renderer.bounds.max.y + mid_lower_torso.renderer.bounds.min.y) / 2;
        position.x = (mid_lower_torso.renderer.bounds.max.x + mid_lower_torso.renderer.bounds.min.x) / 2;
        position.z = mid_lower_torso.renderer.bounds.max.z;

        GameObject tail = new GameObject("Tail");
        tail.transform.parent = obj.transform;

        for (int j = 0; j < number_of_segments; j++)
        {
            GameObject segment = new GameObject("Segment: " + (j + 1));
            segment.transform.parent = tail.transform;

            create_mesh(segment);
            create_bone(position, body_part, 0.1f, 0.1f, 1.0f);

            body_part.RecalculateBounds();
            body_part.Optimize();
            position.z = body_part.bounds.max.z;
        }   
    }

    void load_head(GameObject obj)
    {
        GameObject neck = GameObject.Find("Neck/Segment: 4");
        position.y = neck.renderer.bounds.max.y;
        position.x = 0.2f;
        position.z = neck.renderer.bounds.max.z;

        GameObject head = new GameObject("Head");
        head.transform.parent = obj.transform;

        create_mesh(head);
        create_head(position, body_part, 0.3f, 0.2f, -1.0f);

        body_part.RecalculateBounds();
        body_part.Optimize();

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


