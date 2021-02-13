using ALGO.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALGO.Problems
{
    // Problem: https://gyazo.com/3e462a057bf26b56dc8a374b13e4162f
    public class FindClosestValueInBST : IProblem
    {
        private BinaryNode<int> Tree;
        private int Target = 12;

        public FindClosestValueInBST()
        {
            Tree = new BinaryNode<int>
            {
                Value = 10,
                Left = new BinaryNode<int> {
                    Value = 5,
                    Left = new BinaryNode<int>
                    {
                        Value = 2,
                        Left = new BinaryNode<int>
                        {
                            Value = 1
                        }
                    },
                    Right = new BinaryNode<int>
                    {
                        Value = 5
                    }
                },
                Right = new BinaryNode<int>
                {
                    Value = 15,
                    Left = new BinaryNode<int>
                    {
                        Value = 13,
                        Right = new BinaryNode<int>
                        {
                            Value = 14
                        }
                    },
                    Right = new BinaryNode<int>
                    {
                        Value = 22
                    }
                }
            };
        }

        public void Run()
        {
            Console.WriteLine($"Closest value to {Target} Recursive is: {FindClosestTargetRecursive(Tree, Target, Tree.Value)}");
            Console.WriteLine($"Closest value to {Target} Iterative is: {FindClosestTargetIterative(Tree, Target, Tree.Value)}");
        }

        public int FindClosestTargetRecursive(BinaryNode<int> tree, int target, int closest)
        {
            if (Math.Abs(target - tree.Value) < Math.Abs(target - closest))
            {
                closest = tree.Value;
            }

            if (target > tree.Value && tree.Right != null)
            {
                return FindClosestTargetRecursive(tree.Right, target, closest);
            }
            else if (target < tree.Value && tree.Left != null)
            {
                return FindClosestTargetRecursive(tree.Left, target, closest);
            }

            return closest;
        }

        public int FindClosestTargetIterative(BinaryNode<int> tree, int target, int closest)
        {
            BinaryNode<int> currentNode = tree;

            while (currentNode != null)
            {
                if (Math.Abs(currentNode.Value - target) < Math.Abs(closest - target))
                {
                    closest = currentNode.Value;
                }

                if (target > currentNode.Value)
                {
                    currentNode = currentNode.Right;
                }
                else if (target < currentNode.Value)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    break;
                }
            }

            return closest;
        }
    }
}
