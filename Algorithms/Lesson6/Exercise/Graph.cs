using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lesson6
{
    public class Graph
    {
        private List<Node> nodes = new List<Node>();
        public List<Node> Nodes { get => nodes; }

        public Graph()
        {
            InitiliseGraph();
        }

        private void InitiliseGraph()
        {
            Node aNode = new Node();
            Node bNode = new Node();
            Node cNode = new Node();
            Node dNode = new Node();
            Node eNode = new Node();
            Node fNode = new Node();

            aNode = new Node
            {
                Name = "A",
                Edges = new List<Edge> { new Edge { Node = "B", Weight = 3 },
                                         new Edge { Node = "C", Weight = 2 }
                }
            };
            bNode = new Node
            {
                Name = "B",
                Edges = new List<Edge> { new Edge { Node = "A", Weight = 3 },
                                         new Edge { Node = "C", Weight = 9 },
                                         new Edge { Node = "D", Weight = 10 }
                }
            };
            cNode = new Node
            {
                Name = "C",
                Edges = new List<Edge> { new Edge { Node = "A", Weight = 2 },
                                         new Edge { Node = "B", Weight = 9 },
                                         new Edge { Node = "D", Weight = 8 },
                                         new Edge { Node = "E", Weight = 5 }
                }
            };
            dNode = new Node
            {
                Name = "D",
                Edges = new List<Edge> { new Edge { Node = "B", Weight = 10 },
                                         new Edge { Node = "C", Weight = 8 },
                                         new Edge { Node = "E", Weight = 3 },
                                         new Edge { Node = "F", Weight = 1 }
                }
            };
            eNode = new Node
            {
                Name = "E",
                Edges = new List<Edge> { new Edge { Node = "C", Weight = 5 },
                                         new Edge { Node = "D", Weight = 3 },
                                         new Edge { Node = "F", Weight = 3 },
                }
            };
            fNode = new Node
            {
                Name = "F",
                Edges = new List<Edge> { new Edge { Node = "D", Weight = 1 },
                                         new Edge { Node = "E", Weight = 3 },
                }
            };

            nodes = new List<Node> { aNode, bNode, cNode, dNode, eNode, fNode };

        }

        public void BFG(List<string> searchPath, Node node, string searchNode)
        {
            if (node == null)
            {
                searchNode = null;
                return;
            }

            if (node.Name == searchNode)
            {
                searchPath.Add(node.Name);
                return;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            Node temp = null;
            string edge = "";
            while (queue.Count != 0)
            {
                
                temp = queue.Dequeue();
                temp.IsChecked = true;
                if (temp.Name == searchNode)
                {                            
                    searchPath.Add(edge);
                    return;
                }
                for (int i = 0; i < temp.Edges.Count; i++)
                {
                    Node secondNode = (from n in nodes where n.Name == temp.Edges[i].Node select n).First();
                    if (!secondNode.IsChecked)
                    {
                        secondNode.IsChecked = true;
                        edge += temp.Name + secondNode.Name;
                        Console.WriteLine("Текущее ребро - " + edge);
                        searchPath.Add(edge);
                        queue.Enqueue(secondNode);
                    }
                    edge = "";                                        
                }
                if (queue.Count == 0 ) //если 
                    searchPath.Clear();
            }
        }

        public void DFG(List<string> searchPath, Node node, string searchNode)
        {
            if (node == null)
            {
                searchNode = null;
                return;
            }           

            if (node.Name == searchNode)
            {
                if (searchPath.Count == 0)
                {
                    searchPath.Add(node.Name);
                }
                return;
            }

            Node isExistNode = (from n in nodes where n.Name == searchNode select n).FirstOrDefault();
            if (isExistNode == null)
            {
                return;
            }
            
            Node temp = (from n in nodes where n == node select n).First();
            string edge = "";
            temp.IsChecked = true;
            for (int i = 0; i < temp.Edges.Count; i++)
            {
                Node secondNode = (from n in nodes where n.Name == temp.Edges[i].Node select n).First();
                if (!secondNode.IsChecked)
                {
                    edge += node.Name + secondNode.Name;
                    Console.WriteLine("Текущий узел - " + edge);
                    searchPath.Add(edge);
                    DFG(searchPath, secondNode, searchNode);
                    if (searchPath != null)
                    {
                        break;
                    }
                }
            }    
        }
    }
}
