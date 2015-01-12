using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Creature : BodyPart
{
	Mesh body_part = new Mesh();
	
	Vector3 position;
	
	//Transform[] bones = new Transform[;
	
	// Use this for initialization
	void Start()
	{
		
		List<Transform>Bones = new List<Transform>();
		GameObject parent = GameObject.Find("Creature");
		parent.AddComponent<Animation> ();
		load_legs(parent,Bones, 2);
		load_body(parent,Bones, 3);
		load_arms(parent,Bones, 2);
		load_neck(parent,Bones, 5);
		load_tail(parent,Bones, 4);
		load_head(parent,Bones);
		
		/*for (int i = 0; i<Bones.Count;i++)
		{
			Debug.Log (i);
			Debug.Log (Bones[i].name);
		}*/
		
		//arrange bones into hirearchy
		GameObject.Find ("hip bone").transform.parent = GameObject.Find ("Creature").transform;
		GameObject.Find ("left shoulder").transform.parent = GameObject.Find ("upper spine").transform;
		GameObject.Find ("right shoulder").transform.parent = GameObject.Find ("upper spine").transform;
		GameObject.Find ("right knee").transform.parent = GameObject.Find ("right thigh").transform;
		GameObject.Find ("left knee").transform.parent = GameObject.Find ("left thigh").transform;
		GameObject.Find ("right thigh").transform.parent = GameObject.Find ("hip bone").transform;
		GameObject.Find ("left thigh").transform.parent = GameObject.Find ("hip bone").transform;
		GameObject.Find ("head bone").transform.parent = GameObject.Find ("neck bone").transform;
		GameObject.Find ("tail 1").transform.parent = GameObject.Find ("hip bone").transform;
		GameObject.Find ("neck bone").transform.parent = GameObject.Find ("upper spine").transform;
		
		//animation


		AnimationCurve left_leg_curve_z = new AnimationCurve ();
		AnimationCurve left_leg_curve_y = new AnimationCurve ();
		AnimationCurve left_leg_curve_x = new AnimationCurve ();
		AnimationCurve left_leg_curve_w = new AnimationCurve ();

		AnimationCurve left_knee_curve_z = new AnimationCurve ();
		AnimationCurve left_knee_curve_y = new AnimationCurve ();
		AnimationCurve left_knee_curve_x = new AnimationCurve ();
		AnimationCurve left_knee_curve_w = new AnimationCurve ();

	

		left_leg_curve_x.AddKey (0, 0);
		left_knee_curve_w.AddKey (0, 0);
	
		left_leg_curve_y.AddKey (2, 0);
		left_leg_curve_z.AddKey (2, 0);	
		left_leg_curve_x.AddKey (2, 45);
		left_leg_curve_w.AddKey (2, 45);	

		left_knee_curve_y.AddKey (4, 0);
		left_knee_curve_z.AddKey (4, 0);
		left_knee_curve_x.AddKey (4, -45);
		left_knee_curve_w.AddKey (4, 45);
	

		AnimationClip raise_leg = new AnimationClip ();


	    raise_leg.SetCurve ("hip bone/left thigh", typeof(Transform), "localRotation.z", left_leg_curve_z);
		raise_leg.SetCurve ("hip bone/left thigh", typeof(Transform), "localRotation.y", left_leg_curve_y);
		raise_leg.SetCurve ("hip bone/left thigh", typeof(Transform), "localRotation.x", left_leg_curve_x);
		raise_leg.SetCurve ("hip bone/left thigh", typeof(Transform), "localRotation.w", left_leg_curve_w);

		raise_leg.SetCurve ("hip bone/left thigh/left knee", typeof(Transform), "localRotation.z", left_knee_curve_z);
	    raise_leg.SetCurve ("hip bone/left thigh/left knee", typeof(Transform), "localRotation.y", left_knee_curve_y);
		raise_leg.SetCurve ("hip bone/left thigh/left knee", typeof(Transform), "localRotation.x", left_knee_curve_x);
		raise_leg.SetCurve ("hip bone/left thigh/left knee", typeof(Transform), "localRotation.w", left_knee_curve_w);
	
		animation.AddClip (raise_leg, "walk");

	}

	
	void load_legs(GameObject obj,List<Transform>bone,int number_of_segments)
	{
		position = new Vector3(-0.1f, 0.0f, 0.3f);
		GameObject legs = new GameObject("Legs");
		legs.transform.parent = obj.transform;
		
		GameObject section = gameObject;
		
		int number_of_legs = 2;
		
		for (int i = 0; i < number_of_legs; i++)
		{
			position.y = 0.0f;
			//position.z += 0.1f;
			
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
				segment.AddComponent<SkinnedMeshRenderer>();
				SkinnedMeshRenderer render = segment.GetComponent<SkinnedMeshRenderer>();
				render.material = new Material(Shader.Find("Diffuse"));
				
				if (j == 0)
				{
					create_bone(position, body_part, 0.2f, 1.0f, 0.2f);
					//create leg bones
					Transform[] leg_bones = new Transform[2];
					
					leg_bones[0] = new GameObject("knee").transform;
					leg_bones[0].localRotation = Quaternion.identity;
					
					leg_bones[1] = new GameObject("ankle").transform;
					leg_bones[1].parent = leg_bones[0];
					leg_bones[1].localRotation = Quaternion.identity;
					leg_bones[1].localPosition = new Vector3(0,-1.0f,0.0f);
					
					if(i == 0)
					{	
						
						GameObject ankle = GameObject.Find ("ankle");
						ankle.name = "right angkle";
						leg_bones[0].localPosition = new Vector3(position.x+0.1f,position.y+1.0f,position.z+0.15f);
						GameObject knee = GameObject.Find ("knee");
						knee.name = "right knee";
					}
					if(i == 1)
					{	
						GameObject ankle = GameObject.Find ("ankle");
						ankle.name = "left ankle";
						leg_bones[0].localPosition = new Vector3(position.x+0.1f,position.y+1.0f,position.z+0.15f);
						GameObject knee = GameObject.Find ("knee");
						knee.name = "left knee";
					}
					
					bone.Add(leg_bones[0]);
					bone.Add (leg_bones[1]);
					Debug.Log (body_part.vertexCount);
					BoneWeight[] weights = new BoneWeight[body_part.vertexCount];
					for (int k = 0; k<body_part.vertexCount;k++)
					{
						if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==18||k==19)
						{
							weights[k].boneIndex0 = bone.Count-1;
							weights[k].weight0 = 1;
							weights[k].boneIndex1 = bone.Count-2;
							weights[k].weight1 = 0;
						}
						else
						{
							weights[k].boneIndex0 = bone.Count-1;
							weights[k].weight0 = 0;
							weights[k].boneIndex1 = bone.Count-2;
							weights[k].weight1 = 1;
						}
					}
					body_part.boneWeights = weights;
					
					//bind pose
					Matrix4x4[] shin_bindPose = new Matrix4x4[bone.Count];
					prepare_skinMesh(segment,shin_bindPose,bone,body_part,render);
				}
				
				if (j == 1)
				{
					create_thigh(position,body_part,0.2f, 1.0f, 0.2f);
					Transform[] thigh_bone = new Transform[1];
					thigh_bone[0] = new GameObject("thigh").transform;
					thigh_bone[0].localRotation = Quaternion.identity;
					if(i == 0)
					{	
						thigh_bone[0].localPosition = new Vector3(position.x+0.1f,position.y+1.0f,position.z+0.15f);
						GameObject.Find ("thigh").name = "right thigh";
					}
					if(i == 1)
					{	
						thigh_bone[0].localPosition = new Vector3(position.x+0.1f,position.y+1.0f,position.z+0.15f);
						GameObject thigh = GameObject.Find ("thigh");
						thigh.name = "left thigh";
					}
					
					bone.Add(thigh_bone[0]);
					BoneWeight[] thigh_weights = new BoneWeight[body_part.vertexCount];
					for (int k = 0; k<body_part.vertexCount;k++)
					{
						if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==18||k==19)
						{
							thigh_weights[k].boneIndex0 = bone.Count-3;
							thigh_weights[k].weight0 = 1;
						}
						else
						{
							thigh_weights[k].boneIndex0 = bone.Count-1;
							thigh_weights[k].weight0 = 1;
						}
					}
					body_part.boneWeights = thigh_weights;
					
					//bind pose
					Matrix4x4[] thigh_bindPose = new Matrix4x4[bone.Count];
					thigh_bindPose[bone.Count-3] = bone[bone.Count-3].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					prepare_skinMesh(segment,thigh_bindPose,bone,body_part,render);
				}
				position.y = body_part.bounds.max.y;
			}   
			position.x += 0.7f;
		}
	}
	
	void load_body(GameObject obj,List<Transform>bone, int number_of_segments)
	{
		position.x = 0.1f; position.z = 0.1f;
		GameObject body = new GameObject("Body");
		body.transform.parent = obj.transform;
		
		GameObject section = gameObject;
		int number_of_sections = 3; //upper, mid, lower torso
		float size = 0.0f;
		
		//create spine bones
		Transform[] spine = new Transform[4];
		spine[0] = new GameObject("hip bone").transform;
		spine[0].localPosition = new Vector3(position.x+0.25f, position.y, position.z+0.25f);
		spine[0].localRotation = Quaternion.identity;
		spine[1] = new GameObject("lower spine").transform;
		spine[1].localPosition = new Vector3(position.x+0.25f, position.y+1.0f, position.z+0.25f);
		spine[1].localRotation = Quaternion.identity;
		spine[2] = new GameObject("mid spine").transform;
		spine[2].localPosition = new Vector3(position.x+0.25f, position.y+2.0f, position.z+0.25f);
		spine[2].localRotation = Quaternion.identity;
		spine[3] = new GameObject("upper spine").transform;
		spine[3].localPosition = new Vector3(position.x+0.25f, position.y+3.0f, position.z+0.25f);
		spine[3].localRotation = Quaternion.identity;
		spine[3].parent = spine[2];
		spine[2].parent = spine[1];
		spine[1].parent = spine[0];
		for(int k = 0; k < spine.Length; k++){bone.Add(spine[k]);}
		
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
				segment.AddComponent<SkinnedMeshRenderer>();
				SkinnedMeshRenderer render = segment.GetComponent<SkinnedMeshRenderer>();
				render.material = new Material(Shader.Find("Diffuse"));
				Matrix4x4[]torso_bindPose = new Matrix4x4[bone.Count];
				if (j == 0)
				{
					create_body(position, body_part, size, 1.0f, size);
					//Debug.Log (body_part.vertexCount);
					
					//create bone weight an binde pose for torso
					BoneWeight[] torsor_weights = new BoneWeight[body_part.vertexCount];
					
					if(i == 0)
					{
						for(int k = 0;k < body_part.vertexCount;k++)
						{
							if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==22||
							    k==26||k==27||k==30||k==31||k==36||k==37||k==38||k==39)
							{
								torsor_weights[k].boneIndex0 = bone.Count-4;
								torsor_weights[k].weight0 = 1;
							}
							else
							{
								torsor_weights[k].boneIndex0 = bone.Count-3;
								torsor_weights[k].weight0 = 1;
							}
						}
						torso_bindPose[bone.Count-4] = bone[bone.Count-4].worldToLocalMatrix*segment.transform.localToWorldMatrix;
						torso_bindPose[bone.Count-3] = bone[bone.Count-3].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					}
					if(i == 1)
					{
						for(int k = 0;k < body_part.vertexCount;k++)
						{
							if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==22||
							    k==26||k==27||k==30||k==31||k==36||k==37||k==38||k==39)
							{
								torsor_weights[k].boneIndex0 = bone.Count-3;
								torsor_weights[k].weight0 = 1;
							}
							else
							{
								torsor_weights[k].boneIndex0 = bone.Count-2;
								torsor_weights[k].weight0 = 1;
							}
						}
						torso_bindPose[bone.Count-2] = bone[bone.Count-2].worldToLocalMatrix*segment.transform.localToWorldMatrix;
						torso_bindPose[bone.Count-3] = bone[bone.Count-3].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					}
					if(i == 2)
					{
						for(int k = 0;k < body_part.vertexCount;k++)
						{
							if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==22||
							    k==26||k==27||k==30||k==31||k==36||k==37||k==38||k==39)
							{
								torsor_weights[k].boneIndex0 = bone.Count-2;
								torsor_weights[k].weight0 = 1;
							}
							else
							{
								torsor_weights[k].boneIndex0 = bone.Count-1;
								torsor_weights[k].weight0 = 1;
							}			
						}
						torso_bindPose[bone.Count-1] = bone[bone.Count-1].worldToLocalMatrix*segment.transform.localToWorldMatrix;
						torso_bindPose[bone.Count-2] = bone[bone.Count-2].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					}
					body_part.boneWeights = torsor_weights;
					body_part.bindposes = torso_bindPose;
					render.bones = bone.ToArray();
					render.sharedMesh = body_part;
				}
				
				if (j == 1)
				{    
					create_left_side(position, body_part, 0.2f, 1.0f, 0.5f);
					BoneWeight[] left_side_weights = new BoneWeight[body_part.vertexCount];
					if(i==0)
					{
						for(int k = 0;k < body_part.vertexCount;k++)
						{
							if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==18||k==19)
							{
								left_side_weights[k].boneIndex0 = bone.Count-4;
								left_side_weights[k].weight0 = 1;
							}
							else
							{
								left_side_weights[k].boneIndex0 = bone.Count-3;
								left_side_weights[k].weight0 = 1;
							}
						}
						torso_bindPose[bone.Count-3] = bone[bone.Count-3].worldToLocalMatrix*segment.transform.localToWorldMatrix;
						torso_bindPose[bone.Count-4] = bone[bone.Count-4].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					}
					if(i==1)
					{
						for(int k = 0;k < body_part.vertexCount;k++)
						{
							if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==18||k==19)
							{
								left_side_weights[k].boneIndex0 = bone.Count-3;
								left_side_weights[k].weight0 = 1;
							}
							else
							{
								left_side_weights[k].boneIndex0 = bone.Count-2;
								left_side_weights[k].weight0 = 1;
							}
						}
						torso_bindPose[bone.Count-2] = bone[bone.Count-2].worldToLocalMatrix*segment.transform.localToWorldMatrix;
						torso_bindPose[bone.Count-3] = bone[bone.Count-3].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					}
					if(i==2)
					{
						for(int k = 0;k < body_part.vertexCount;k++)
						{if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==18||k==19)
							{
								left_side_weights[k].boneIndex0 = bone.Count-2;
								left_side_weights[k].weight0 = 1;
							}
							else
							{
								left_side_weights[k].boneIndex0 = bone.Count-1;
								left_side_weights[k].weight0 = 1;
							}
						}
						torso_bindPose[bone.Count-2] = bone[bone.Count-2].worldToLocalMatrix*segment.transform.localToWorldMatrix;
						torso_bindPose[bone.Count-1] = bone[bone.Count-1].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					}
					body_part.boneWeights = left_side_weights;
					body_part.bindposes = torso_bindPose;
					render.bones = bone.ToArray();
					render.sharedMesh = body_part;
				}
				
				if (j == 2)
				{
					create_right_side(position, body_part, 0.2f, 1.0f, 0.5f);
					BoneWeight[] right_side_weights = new BoneWeight[body_part.vertexCount];
					if(i==0)
					{
						for(int k = 0;k < body_part.vertexCount;k++)
						{
							if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==18||k==19)
							{
								right_side_weights[k].boneIndex0 = bone.Count-4;
								right_side_weights[k].weight0 = 1;
							}
							else
							{
								right_side_weights[k].boneIndex0 = bone.Count-3;
								right_side_weights[k].weight0 = 1;
							}
						}
						torso_bindPose[bone.Count-3] = bone[bone.Count-3].worldToLocalMatrix*segment.transform.localToWorldMatrix;
						torso_bindPose[bone.Count-4] = bone[bone.Count-4].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					}
					if(i==1)
					{
						for(int k = 0;k < body_part.vertexCount;k++)
						{
							if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==18||k==19)
							{
								right_side_weights[k].boneIndex0 = bone.Count-3;
								right_side_weights[k].weight0 = 1;
							}
							else
							{
								right_side_weights[k].boneIndex0 = bone.Count-2;
								right_side_weights[k].weight0 = 1;
							}
						}
						torso_bindPose[bone.Count-2] = bone[bone.Count-2].worldToLocalMatrix*segment.transform.localToWorldMatrix;
						torso_bindPose[bone.Count-3] = bone[bone.Count-3].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					}
					if(i==2)
					{
						for(int k = 0;k < body_part.vertexCount;k++)
						{if (k==0||k== 1||k== 2||k==3||k==6||k==7||k==10||k==11||k==14||k==15||k==18||k==19)
							{
								right_side_weights[k].boneIndex0 = bone.Count-2;
								right_side_weights[k].weight0 = 1;
							}
							else
							{
								right_side_weights[k].boneIndex0 = bone.Count-1;
								right_side_weights[k].weight0 = 1;
							}
						}
						torso_bindPose[bone.Count-2] = bone[bone.Count-2].worldToLocalMatrix*segment.transform.localToWorldMatrix;
						torso_bindPose[bone.Count-1] = bone[bone.Count-1].worldToLocalMatrix*segment.transform.localToWorldMatrix;
					}
					body_part.boneWeights = right_side_weights;
					body_part.bindposes = torso_bindPose;
					render.bones = bone.ToArray();
					render.sharedMesh = body_part;
				}
				
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
	
	void load_arms(GameObject obj, List<Transform>bone,int number_of_segments)
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
				segment.AddComponent<SkinnedMeshRenderer>();
				SkinnedMeshRenderer render = segment.GetComponent<SkinnedMeshRenderer>();
				render.material = new Material(Shader.Find("Diffuse"));
				
				if (j == 0)
				{
					//create arm bones
					Transform[]arm_bones = new Transform[2];
					
					create_mesh(segment);
					
					if (i == 0)
					{
						create_left_bicep(position, body_part, -1.0f, 0.2f, 0.2f);
						
						//left shoulder bone
						arm_bones[0] = new GameObject("left shoulder").transform;
						arm_bones[0].localRotation = Quaternion.identity;
						arm_bones[0].localPosition = new Vector3(position.x-1.0f,position.y+0.1f,position.z+0.1f);
						bone.Add (arm_bones[0]);
						
						//left elbow bone
						arm_bones[1] = new GameObject("left elbow").transform;
						arm_bones[1].localRotation = Quaternion.identity;
						arm_bones[1].parent = arm_bones[0];
						arm_bones[1].localPosition = new Vector3(1.0f,0.0f,0.0f);
						bone.Add (arm_bones[1]);
						
						//bone weight for left arm
						BoneWeight[]upperArm_weight = new BoneWeight[body_part.vertexCount];
						for(int k = 0; k<body_part.vertexCount;k++)
						{
							if(k==0||k==3||k==4||k==5||k==6||k==7||k==8||k==11||k==13||k==14||k==20||k==23)
							{
								upperArm_weight[k].boneIndex0 = bone.Count-2;
								upperArm_weight[k].weight0=1;
							}
							else
							{
								upperArm_weight[k].boneIndex0 = bone.Count-1;
								upperArm_weight[k].weight0=1;
							}
						}
						body_part.boneWeights = upperArm_weight;
					}
					if (i == 1)
					{
						create_right_bicep(position, body_part, -1.0f, 0.2f, 0.2f);
						
						//right shoulder bone
						arm_bones[0] = new GameObject("right shoulder").transform;
						arm_bones[0].localRotation = Quaternion.identity;
						arm_bones[0].localPosition = new Vector3(position.x,position.y+0.1f,position.z+0.1f);
						bone.Add (arm_bones[0]);
						
						//right elbow bone
						arm_bones[1] = new GameObject("right elbow").transform;
						arm_bones[1].parent = arm_bones[0];
						arm_bones[1].localRotation = Quaternion.identity;
						arm_bones[1].localPosition = new Vector3(-1.0f,0.0f,0.0f);
						bone.Add (arm_bones[1]);
						
						//bone weight for right arm
						BoneWeight[]upperArm_weight = new BoneWeight[body_part.vertexCount];
						for(int k = 0; k<body_part.vertexCount;k++)
						{
							if(k==0||k==3||k==4||k==5||k==6||k==7||k==8||k==11||k==13||k==14||k==20||k==23)
							{
								upperArm_weight[k].boneIndex0 = bone.Count-1;
								upperArm_weight[k].weight0=1;
							}
							else
							{
								upperArm_weight[k].boneIndex0 = bone.Count-2;
								upperArm_weight[k].weight0=1;
							}
						}
						body_part.boneWeights = upperArm_weight;
						
					}
					//bind pose
					Matrix4x4[] arm_bindPose = new Matrix4x4[bone.Count];
					prepare_skinMesh(segment,arm_bindPose,bone,body_part,render);
				}
				
				if (j == 1)
				{
					//create wrist bones
					Transform[]wrist_bones = new Transform[1];
					if(i == 0)
					{ 
						wrist_bones[0] = new GameObject("left wrist").transform;
						wrist_bones[0].parent = bone[bone.Count-1];
						wrist_bones[0].localPosition = new Vector3(1.0f,0.0f,0.0f);
						wrist_bones[0].localRotation = Quaternion.identity;
					}
					if(i == 1)
					{ 
						wrist_bones[0] = new GameObject("right wrist").transform;
						wrist_bones[0].parent = bone[bone.Count-1];
						wrist_bones[0].localPosition = new Vector3(-1.0f,0.0f,0.0f);
						wrist_bones[0].localRotation = Quaternion.identity;
					}
					bone.Add(wrist_bones[0]);
					
					create_mesh(segment);
					create_bone(position, body_part, 1.0f, 0.2f, 0.2f);
					BoneWeight[]lowerArm_weight = new BoneWeight[body_part.vertexCount];
					if(i==0)
					{
						for(int k = 0; k<body_part.vertexCount;k++)
						{
							if(k==0||k==3||k==4||k==5||k==6||k==7||k==8||k==11||k==13||k==14||k==20||k==23)
							{
								lowerArm_weight[k].boneIndex0 = bone.Count-1;
								lowerArm_weight[k].weight0=1;
							}
							else
							{
								lowerArm_weight[k].boneIndex0 = bone.Count-2;
								lowerArm_weight[k].weight0=1;
							}
						}
						body_part.boneWeights = lowerArm_weight;
					}
					if(i==1)
					{
						for(int k = 0; k<body_part.vertexCount;k++)
						{
							if(k==0||k==3||k==4||k==5||k==6||k==7||k==8||k==11||k==13||k==14||k==20||k==23)
							{
								lowerArm_weight[k].boneIndex0 = bone.Count-2;
								lowerArm_weight[k].weight0=1;
							}
							else
							{
								lowerArm_weight[k].boneIndex0 = bone.Count-1;
								lowerArm_weight[k].weight0=1;
							}
						}
						body_part.boneWeights = lowerArm_weight;
					}
					
					//bind pose
					Matrix4x4[] lowerArm_bindPose = new Matrix4x4[bone.Count];
					prepare_skinMesh(segment,lowerArm_bindPose,bone,body_part,render);
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
	
	void load_neck(GameObject obj, List<Transform>bone,int number_of_segments)
	{
		GameObject mid_upper_torso = GameObject.Find("Upper Torso/Segment: 1");
		position.y = mid_upper_torso.renderer.bounds.max.y;
		position.x = 0.3f;
		position.z = (mid_upper_torso.renderer.bounds.max.z + mid_upper_torso.renderer.bounds.min.z) / 2;
		
		GameObject neck = new GameObject("Neck");
		neck.transform.parent = obj.transform;
		Transform[] neck_bone = new Transform[1];
		neck_bone [0] = new GameObject ("neck bone").transform;
		neck_bone [0].localRotation = Quaternion.identity;
		neck_bone [0].localPosition = new Vector3 (position.x - 0.05f, position.y, position.z - 0.05f);
		bone.Add (neck_bone [0]);
		
		for (int j = 0; j < number_of_segments; j++)
		{
			GameObject segment = new GameObject("Segment: " + (j + 1));
			segment.transform.parent = neck.transform;
			segment.AddComponent<SkinnedMeshRenderer>();
			SkinnedMeshRenderer render = segment.GetComponent<SkinnedMeshRenderer>();
			render.material = new Material(Shader.Find("Diffuse"));
			
			create_mesh(segment);
			create_bone(position, body_part, 0.1f, 0.1f, 0.1f);
			
			BoneWeight[]neck_weight = new BoneWeight[body_part.vertexCount];
			for(int k = 0; k<body_part.vertexCount;k++)
			{
				neck_weight[k].boneIndex0 = bone.Count-1;
				neck_weight[k].weight0=1;
			}
			body_part.boneWeights = neck_weight;
			Matrix4x4[] neck_bindPose = new Matrix4x4[bone.Count];
			prepare_skinMesh(segment,neck_bindPose,bone,body_part,render);
			position.y = body_part.bounds.max.y;
		}  
		
	}
	
	void load_tail(GameObject obj, List<Transform>bone,int number_of_segments)
	{
		GameObject mid_lower_torso = GameObject.Find("Lower Torso/Segment: 1");
		position.y = (mid_lower_torso.renderer.bounds.max.y + mid_lower_torso.renderer.bounds.min.y) / 2;
		position.x = (mid_lower_torso.renderer.bounds.max.x + mid_lower_torso.renderer.bounds.min.x) / 2;
		position.z = mid_lower_torso.renderer.bounds.max.z;
		
		GameObject tail = new GameObject("Tail");
		tail.transform.parent = obj.transform;
		
		Transform[] tail_bone_segment1 = new Transform[1];
		tail_bone_segment1[0] = new GameObject("tail "+1).transform;
		tail_bone_segment1[0].localRotation = Quaternion.identity;
		tail_bone_segment1[0].localPosition = new Vector3(position.x+0.05f,position.y,position.z);
		bone.Add (tail_bone_segment1 [0]);
		//position.z += 1.0f;
		for (int j = 0; j < number_of_segments; j++)
		{
			GameObject segment = new GameObject("Segment: " + (j + 1));
			segment.transform.parent = tail.transform;
			
			segment.AddComponent<SkinnedMeshRenderer>();
			SkinnedMeshRenderer render = segment.GetComponent<SkinnedMeshRenderer>();
			render.material = new Material(Shader.Find("Diffuse"));
			
			create_mesh(segment);
			create_bone(position, body_part, 0.1f, 0.1f, 1.0f);
			
			position.z = body_part.bounds.max.z;
			
			//create tail bone
			Transform[] tail_bone = new Transform[1];
			tail_bone[0] = new GameObject("tail "+(j+2)).transform;
			tail_bone[0].localRotation = Quaternion.identity;
			tail_bone[0].localPosition = new Vector3(position.x+0.05f,position.y+0.1f,position.z);
			tail_bone[0].parent = bone[bone.Count-1];
			bone.Add (tail_bone[0]);
			
			BoneWeight[]tail_weight = new BoneWeight[body_part.vertexCount];
			for(int k = 0; k<body_part.vertexCount;k++)
			{
				if(k==0||k==1||k==5||k==6||k==8||k==9||k==10||k==11||k==16||k==19||k==22||k==23)
				{
					tail_weight[k].boneIndex0 = bone.Count-2;
					tail_weight[k].weight0=1;
					tail_weight[k].boneIndex1 = bone.Count-1;
					tail_weight[k].weight1=0;
				}
				else
				{
					tail_weight[k].boneIndex0 = bone.Count-1;
					tail_weight[k].weight0=1;
					tail_weight[k].boneIndex1 = bone.Count-2;
					tail_weight[k].weight1=0;
				}
				
			}
			body_part.boneWeights = tail_weight;
			Matrix4x4[] tail_bindPose = new Matrix4x4[bone.Count];
			prepare_skinMesh(segment,tail_bindPose,bone,body_part,render);
			position.y = body_part.bounds.max.y;
		}   
	}
	
	void load_head(GameObject obj,List<Transform>bone)
	{
		GameObject neck = GameObject.Find("Neck/Segment: 4");
		position.y = neck.renderer.bounds.max.y;
		position.x = 0.2f;
		position.z = neck.renderer.bounds.max.z;
		
		GameObject head = new GameObject("Head");
		head.transform.parent = obj.transform;
		head.AddComponent<SkinnedMeshRenderer>();
		SkinnedMeshRenderer render = head.GetComponent<SkinnedMeshRenderer>();
		render.material = new Material(Shader.Find("Diffuse"));
		
		Transform[]head_bone = new Transform[1];
		head_bone[0] = new GameObject("head bone").transform;
		head_bone [0].localRotation = Quaternion.identity;
		head_bone [0].localPosition = new Vector3 (position.x + 0.15f, position.y + 0.1f, position.z - 0.1f);
		bone.Add (head_bone [0]);
		create_mesh(head);
		create_head(position, body_part, 0.3f, 0.2f, -1.0f);
		BoneWeight[]head_weight = new BoneWeight[body_part.vertexCount];
		for(int k = 0; k<body_part.vertexCount;k++)
		{
			head_weight[k].boneIndex0 = bone.Count-1;
			head_weight[k].weight0=1;
		}
		body_part.boneWeights = head_weight;
		Matrix4x4[] head_bindPose = new Matrix4x4[bone.Count];
		prepare_skinMesh(head,head_bindPose,bone,body_part,render);
	}
	
	
	void load_wings()
	{
		
		
		
	}
	
	void create_mesh(GameObject obj)
	{
		MeshFilter filter = obj.AddComponent<MeshFilter>();
		//MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
		//renderer.material = new Material(Shader.Find("Diffuse"));
		body_part = filter.mesh;
		body_part.Clear();
		
	}
	void prepare_skinMesh(GameObject obj,Matrix4x4[]bindPose,List<Transform>bone,Mesh part,SkinnedMeshRenderer renderer)
	{
		bindPose[bone.Count-1] = bone[bone.Count-1].worldToLocalMatrix*obj.transform.localToWorldMatrix;
		bindPose[bone.Count-2] = bone[bone.Count-2].worldToLocalMatrix*obj.transform.localToWorldMatrix;
		body_part.bindposes = bindPose;
		renderer.bones = bone.ToArray ();
		renderer.sharedMesh = part;
	}
	
	void Update()
	{
		animation.Play ("walk");
	}
}


