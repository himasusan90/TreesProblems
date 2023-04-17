// See https://aka.ms/new-console-template for more information

using System.Globalization;

List<string> strs = SplitWords(Console.ReadLine());

int pos = 0;
Node<int> root = BuildTree(strs, ref pos, int.Parse);

PreOrderTraversal(root);
pos = 0;
root = BuildTree(strs, ref pos, int.Parse);
PostOrderTraversal(root);
pos = 0;
root = BuildTree(strs, ref pos, int.Parse);
InOrderTraversal(root);

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
