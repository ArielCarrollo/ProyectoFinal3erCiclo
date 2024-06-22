using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnTree<T> : MonoBehaviour
{
    class Node
    {
        public T Value { get; set; }
        public List<Node> listChilds;

        public Node(T value)
        {
            Value = value;
            listChilds = new List<Node>();
        }

        public void AddChild(Node node)
        {
            listChilds.Add(node);
        }
    }
    private Node root;
    private List<Node> listAllNodes = new List<Node>();

    public void AddNode(T value, T fatherValue)
    {
        if (root == null)
        {
            Node newNode = new Node(value);
            root = newNode;
            listAllNodes.Add(newNode);
        }
        else
        {
            Node newNode = new Node(value);
            Node father = GetFather(fatherValue);
            father.AddChild(newNode);
            listAllNodes.Add(newNode);
        }
    }
    private Node GetFather(T value)
    {
        dynamic fatherValue = value;
        Node father = null;
        for (int i = 0; i < listAllNodes.Count; ++i)
        {
            if (listAllNodes[i].Value == fatherValue)
            {
                father = listAllNodes[i];
                break;
            }
        }
        return father;
    }

    public void PreOrden()
    {
        PreOrdenRecursive(root);
        Debug.Log("\n");
    }

    private void PreOrdenRecursive(Node node)
    {
        if (node != null)
        {
            Debug.Log(node.Value + " ");
            for (int i = 0; i < node.listChilds.Count; ++i)
            {
                PreOrdenRecursive(node.listChilds[i]);
            }
        }
    }

    public void PostOrden()
    {
        PostOrdenRecursive(root);
        Debug.Log("\n");
    }

    private void PostOrdenRecursive(Node node)
    {
        if (node != null)
        {
            for (int i = 0; i < node.listChilds.Count; ++i)
            {
                PostOrdenRecursive(node.listChilds[i]);
            }
            Debug.Log(node.Value + " ");
        }
    }

    public void InOrden()
    {
        InOrdenRecursive(root);
        Debug.Log("\n");
    }

    private void InOrdenRecursive(Node node)
    {
        if (node != null)
        {
            if (node.listChilds.Count > 0)
            {
                InOrdenRecursive(node.listChilds[0]);
            }
            Debug.Log(node.Value + " ");
            for (int i = 1; i < node.listChilds.Count; ++i)
            {
                InOrdenRecursive(node.listChilds[i]);
            }
        }
    }

    public void InDepthSearch()
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            Node currentNode = queue.Dequeue();
            Debug.Log(currentNode.Value + " ");
            for (int i = 0; i < currentNode.listChilds.Count; ++i)
            {
                queue.Enqueue(currentNode.listChilds[i]);
            }
        }
        Debug.Log("\n");
    }
}
