using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7Deneme
{
    // Düğüm Sınıfı
    class TreeNode
    {
        public int data;
        public TreeNode leftChild;
        public TreeNode rightChild;
        public void displayNode() { Console.Write(" " + data + " "); }
    }

    // Agaç Sınıfı
    class Tree
    {
        private TreeNode root;

        //variables for traverse statistics
        public int totalDepth;
        public int maxDepth;
        public int leavesDepthTotal;
        public int leavesCount;
        public int[] elementCountForEachDepth;
        public int[] sumElementValuesForEachDepth;

        public Tree() { root = null; }

        public TreeNode getRoot()
        { return root; }

        // Agacın preOrder Dolasılması
        public void preOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                localRoot.displayNode();
                preOrder(localRoot.leftChild);
                preOrder(localRoot.rightChild);
            }
        }

        // Agacın inOrder Dolasılması
        public void inOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.leftChild);
                localRoot.displayNode();
                inOrder(localRoot.rightChild);
            }
        }

        // Agacın postOrder Dolasılması
        public void postOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.leftChild);
                postOrder(localRoot.rightChild);
                localRoot.displayNode();
            }
        }

        // Agaca bir dügüm eklemeyi saglayan metot
        public void insert(int newdata)
        {
            TreeNode newNode = new TreeNode();
            newNode.data = newdata;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (newdata < current.data)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } // end while
            } // end else not root
        } // end insert()

        //traverse preorder to extract information about depth, element count, and value of nodes
        private void traverseTreeForInfo(TreeNode node, int depth)
        {
            if (node != null)
            {
                depth++;

                elementCountForEachDepth[depth]++;
                sumElementValuesForEachDepth[depth] += node.data;

                if (depth > maxDepth)
                    maxDepth = depth; //update max depth

                totalDepth += depth;

                //for calculating the average leaves depth
                if (node.leftChild == null && node.rightChild == null)
                {
                    leavesCount++;
                    leavesDepthTotal += depth;
                }

                traverseTreeForInfo(node.leftChild, depth); //traverse left sub-tree
                traverseTreeForInfo(node.rightChild, depth); //traverse right sub-tree

            }
        }

        public void findAndWriteTreeInfo(TreeNode rootNode, int treeSize)
        {

            totalDepth = 0;
            maxDepth = 0;

            elementCountForEachDepth = new int[treeSize];
            sumElementValuesForEachDepth = new int[treeSize];

            //For average leaves depth
            leavesDepthTotal = 0;
            leavesCount = 0;

            traverseTreeForInfo(rootNode, -1);

            Console.WriteLine("\nDepth of the tree: " + maxDepth);
            Console.WriteLine("Element counts and sum of the values for each depth");
            for (int i = 0; i <= maxDepth; i++)
            {
                Console.WriteLine("\tFor depth {0}: Number of elements: {1}  Sum of elements {2}", i, elementCountForEachDepth[i], sumElementValuesForEachDepth[i]);
            }
            Console.WriteLine("Average depth of leaves: " + ((double)leavesDepthTotal / leavesCount));

        }

    } // class Tree


    // Test Sınıfı
    class TreeTest
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            Tree agac = new Tree();
            int treeSize = 15;

            // Ağaca treeSize tane sayı yerleştirilmesi
            Console.WriteLine("Sayılar : ");
            for (int i = 0; i < treeSize; ++i)
            {
                int sayi = (int)(r.Next(500));
                Console.Write(sayi + " ");
                agac.insert(sayi);
            };

            Console.Write("\nAgacın InOrder Dolasılması : ");
            agac.inOrder(agac.getRoot());
            Console.Write("\nAgacın PreOrder Dolasılması : ");
            agac.preOrder(agac.getRoot());
            Console.Write("\nAgacın PostOrder Dolasılması : ");
            agac.postOrder(agac.getRoot());

            agac.findAndWriteTreeInfo(agac.getRoot(), treeSize);


            Console.ReadKey();
        }
    }
}
