using UnityEngine;
using System.Collections;

public class TestVertices : MonoBehaviour
{

    private SkinnedMeshRenderer smr;
    private Mesh mesh;
    private Hashtable boneIndex;
    Vector3[] oldVertices;
    // Use this for initialization
    void Start()
    {

        //mesh.RecalculateNormals();
        //mesh.RecalculateBounds();
        //mc.sharedMesh = null;
        //mc.sharedMesh = mesh;

        boneIndex = new Hashtable();
        boneIndex.Add("Hips", 0);
        boneIndex.Add("Spine", 1);
        boneIndex.Add("Spine1", 2);
        boneIndex.Add("Spine2", 3);
        boneIndex.Add("Neck", 4);
        boneIndex.Add("Neck1", 5);
        boneIndex.Add("Head", 6);
        boneIndex.Add("LeftShoulder", 7);
        boneIndex.Add("LeftArm", 8);
        boneIndex.Add("LeftForeArm", 9);
        boneIndex.Add("LeftHand", 10);
        boneIndex.Add("RightShoulder", 26);
        boneIndex.Add("RightArm", 27);
        boneIndex.Add("RightForeArm", 28);
        boneIndex.Add("RightHand", 29);
        boneIndex.Add("LeftUpLeg", 45);
        boneIndex.Add("LeftLeg", 46);
        boneIndex.Add("LeftFoot", 47);
        boneIndex.Add("RightUpLeg", 49);
        boneIndex.Add("RightLeg", 50);
        boneIndex.Add("RightFoot", 51);

    }


    Vector3[] vertices;
    BoneWeight[] boneWeights;
    Transform[] bones;
    // Update is called once per frame
    private int tempCount = 0;
    void Update()
    {
        if (tempCount <= 100)
            tempCount++;
        if (tempCount == 1)
        {
            // NiteWrapper.getFatness(
            smr = GetComponentInChildren<SkinnedMeshRenderer>();
            mesh = smr.sharedMesh;

            oldVertices = smr.sharedMesh.vertices;
            vertices = smr.sharedMesh.vertices;

            boneWeights = mesh.boneWeights;
            bones = smr.bones;

            //Adjust("Hips");
           // Adjust("Spine");
            Adjust("Spine");
            Adjust("Spine2");
            Adjust("Spine2");
            Adjust("Neck");
            //Adjust("LeftForeArm");
            //Adjust("RightForeArm");
            //Adjust("LeftLeg");
            //Adjust("RightLeg");
            //Adjust("LeftArm");
            //Adjust("RightArm");

            mesh.vertices = vertices;
            Debug.Log("Bigger!!!");
            if (vertices == oldVertices) Debug.Log("Wrong!!! old same!!!");
        }
        if (tempCount == 200)
        {
            mesh.vertices = oldVertices;
            Debug.Log("Back!!!");
        }
    }

    private void Adjust(string boneName)
    {
        int testBoneIndex = (int)boneIndex[boneName];
        for (int index = 0; index < vertices.Length; index++)
        {
            //vertices[index].y += 10;
            //if ((boneWeights[index].boneIndex0 == testBoneIndex && boneWeights[index].weight0 > 0.0f)
            //    || (boneWeights[index].boneIndex1 == testBoneIndex && boneWeights[index].weight1 > 0.0f)
            //|| (boneWeights[index].boneIndex2 == testBoneIndex && boneWeights[index].weight2 > 0.0f)
            //|| (boneWeights[index].boneIndex3 == testBoneIndex && boneWeights[index].weight3 > 0.0f))
            //{
            //    Vector3 change = mesh.normals[index]*boneWeights[index].weight0 / 100;
            //    vertices[index] += change;
            //}
            int factor = 50;
            if (boneWeights[index].boneIndex0 == testBoneIndex && boneWeights[index].weight0 > 0.0f) {
                Vector3 change = mesh.normals[index] * boneWeights[index].weight0 / factor;
                vertices[index] += change;
            }
            else if (boneWeights[index].boneIndex1 == testBoneIndex && boneWeights[index].weight1 > 0.0f)
            {
                Vector3 change = mesh.normals[index] * boneWeights[index].weight1 / factor;
                vertices[index] += change;
            }
            else if(boneWeights[index].boneIndex2 == testBoneIndex && boneWeights[index].weight2 > 0.0f)
            {
                Vector3 change = mesh.normals[index] * boneWeights[index].weight2 / factor;
                vertices[index] += change;
            }
            else if(boneWeights[index].boneIndex3 == testBoneIndex && boneWeights[index].weight3 > 0.0f)
            {
                Vector3 change = mesh.normals[index] * boneWeights[index].weight3 / factor;
                vertices[index] += change;
            }
        }
    }
}
