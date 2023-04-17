// See https://aka.ms/new-console-template for more information

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }
    public Node(T val)
    {
        Value = val;
    }
    public Node(Node<T> l, Node<T> r,T val)
    {
        Left = l;
        Right = r;
        Value = val;
    }
}

