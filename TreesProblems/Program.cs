// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Globalization;

List<string> strs = SplitWords(Console.ReadLine());

int pos = 0;
Node<int> root = BuildTree(strs, ref pos, int.Parse);
//int res = CountGoodNodes(root);

//int res = TreeMaxDepth(root);

//bool res = BalancedTree(root);
//Console.WriteLine(res);
Node<int> newRoot = Deserialize(Serialize(root));
List<string> tree = new List<string>();
PrintTree(newRoot, tree);
Console.WriteLine(string.Join(" ", tree));

//please uncomment the below lines to traverse tree

//PreOrderTraversal(root);
//pos = 0;
//root = BuildTree(strs, ref pos, int.Parse);
//PostOrderTraversal(root);
//pos = 0;
//root = BuildTree(strs, ref pos, int.Parse);
//InOrderTraversal(root);

//PLR
void PreOrderTraversal(Node<int> root)
{
    if (root != null)
    {
        Console.WriteLine(root.Value);
        PreOrderTraversal(root.Left);
        PreOrderTraversal(root.Right);

    }
}
//LRP
void PostOrderTraversal(Node<int> root)
{
    if (root != null)
    {

        PostOrderTraversal(root.Left);
        PostOrderTraversal(root.Right);
        Console.WriteLine(root.Value);

    }
}
//LPR
void InOrderTraversal(Node<int> root)
{
    if (root != null)
    {

        InOrderTraversal(root.Left);
        Console.WriteLine(root.Value);
        InOrderTraversal(root.Right);
        

    }
}


bool BalancedTree(Node<int> root)
{
   int height= TreeHeight(root);
    if (height == -1)
        return false;
    else return true;
}

int TreeHeight(Node<int> root)
{
   if(root!= null)
    {
       var left=TreeHeight(root.Left);
       var right = TreeHeight(root.Right);
       var h=Math.Max(left,right)+1;
        if (left == -1 || right == -1) return -1;
        if (Math.Abs(left - right)>1)
        {
            return -1;
        }

        return h;
    }
    return 0;
}

int CountGoodNodes(Node<int> root)
{
    int max=0;
   
    if (root != null)
    {
      int noOfNodes=  GoodNode(root, max);
        return noOfNodes;
    }
    return 0;
}

int GoodNode(Node<int> root, int max)
{
    var count=0;
    //Base condition
    if (root == null)
    {
        return 0;
    }
    if(root.Value >= max)
    {
        //3 additions will take place cont=count of left node+count of right node+current node
        //1. If the current node is good add 1
        count++;
    }
    //2. if the left subtree has any good node add those
     count += GoodNode(root.Left, Math.Max(root.Value,max));
    //3.If the right subtree returns any good node add those
     count += GoodNode(root.Right, Math.Max(root.Value,max));
    return count;
}

static int Dfs(Node<int> root)
{
    //Base case
    if (root == null)
    {
        return 0;
    }
  var l=Dfs(root.Left);
  var r=Dfs(root.Right);
   var max=Math.Max(l, r)+1;
    return max;
}
 static int TreeMaxDepth(Node<int> root)
{
    //max depth (from leaf node to upwards)=inverse of height
    //max depth=edge count
    //obtain the number of nodes in the longest root-to-leaf path in the tree then subtract 1
    //from node count
    if (root != null)
    {
       var c= Dfs(root) - 1;
        return c;
    }
    return 0;
}
string Serialize(Node<int> root)
{
    List<string> res = new List<string>();
    SerializeDFS(root, res);
    return string.Join(" ", res);
}
static void SerializeDFS(Node<int> root, List<string> result)
{
    // WRITE YOUR BRILLIANT CODE HERE
    if(root != null)
    {
        result.Add(root.Value.ToString());
        SerializeDFS(root.Left,result);
        SerializeDFS(root.Right, result);
       
    }
    else
    {
        result.Add("x");
        return;
    }
    
}

  Node<int> Deserialize(string root)
{
    // AND HERE
    int pos = 0;
    return DeserializeDFS(root.Split(" ").ToList(), ref pos);
}
 Node<int> DeserializeDFS(List<string> nodes, ref int pos)
{
    string val = nodes[pos];
    pos++;
    if (val == "x") return null;
    Node<int> cur = new Node<int>(int.Parse(val));
    cur.Left = DeserializeDFS(nodes, ref pos);
    cur.Right = DeserializeDFS(nodes, ref pos);
    return cur;

}


void PrintTree<T>(Node<T> root, List<string> tree)
{
    if (root == null)
    {
        tree.Add("x");
    }
    else
    {
        tree.Add(root.Value.ToString());
        PrintTree(root.Left, tree);
        PrintTree(root.Right, tree);
    }
}

static List<string> SplitWords(string s)
{
    return string.IsNullOrEmpty(s) ? new List<string>() : s.Trim().Split(' ').ToList();
}


 static Node<T> BuildTree<T>(List<string> strs, ref int pos, Func<string, T> f)
{
    var value = strs[pos];
    pos++;
    //LRP construct tree using pre order traversal
    if(value == "x")
    {
        return null;
    }
    var left=BuildTree(strs, ref pos, f);
    var right=BuildTree(strs, ref pos, f);
    return new Node<T>(left, right, f(value));

}
