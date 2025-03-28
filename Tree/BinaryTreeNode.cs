﻿using System;
using System.Collections.Generic;

namespace Tree
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }
    }
}
