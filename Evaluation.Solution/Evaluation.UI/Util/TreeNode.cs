using Evaluation.UI.Util;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace Evaluation.UI.Util
{
    public class TreeNode
    {
        [JsonProperty("id")]
        public int Id { get; set; } 

        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; } 
        [JsonProperty("backColor")]
        public string BackColor { get; set; } 
        [JsonProperty("minRange")]
        public int MinRange { get; set; } 
        [JsonProperty("maxRange")]
        public int MaxRange { get; set; }  
        [JsonProperty("countSalesTrx")]
        public int CountSalesTrx { get; set; }

        [JsonProperty("nodes")]
        public List<TreeNode> Nodes { get; set; }

        public TreeNode(int id, string text,string code, string href, string color, int minRange, int maxRange, List<string> tags, int countSalesTrx, string backColor)
        {
            Id = id;
            Text = text;
            Code = code;
            Href = href;
            Color = color;
            BackColor = backColor;
            MinRange = minRange;
            MaxRange = maxRange;
            Tags = new List<string>(tags);
            Nodes = new List<TreeNode>();
            CountSalesTrx = countSalesTrx;
        }

        public void AddChild(TreeNode childNode)
        {
            Nodes.Add(childNode);
        }

        public static List<TreeNode> BuildTree(List<Node> nodes)
        {
            Dictionary<int, TreeNode> dict = new Dictionary<int, TreeNode>();
            List<TreeNode> roots = new List<TreeNode>();

            // Add all nodes to dictionary with ID as key
            foreach (Node node in nodes)
            {
                if (string.IsNullOrEmpty(node.Href))
                {
                    node.Href = "#";
                }
                dict.Add(node.Id, new TreeNode(node.Id,node.Name,node.Code, node.Href, node.Color,node.MinRange,node.MaxRange,node.Tags,node.CountSalesTrx,node.BackColor));
            }

            // Build tree by adding child nodes to their parent nodes
            foreach (Node node in nodes)
            {
                if (node.ParentId > 0)
                {
                    TreeNode parentNode = dict[node.ParentId.Value];
                    TreeNode childNode = dict[node.Id];
                    parentNode.AddChild(childNode);
                }
                else
                {
                    if (!roots.Contains(dict[node.Id]))
                    {
                        roots.Add(dict[node.Id]);
                    }
                  
                }
            }

            return roots;
        }
        //public static List<TreeNode> BuildTree(List<Node> nodes)
        //{
        //    List<TreeNode> roots = new List<TreeNode>();
        //    // Create a dictionary to store all nodes for efficient lookup
        //    var dict = new Dictionary<int, TreeNode>();

        //    // Create a HashSet to keep track of added parent nodes
        //    var addedParents = new HashSet<int>();

        //    // Create the tree nodes for each node in the list and add them to the dictionary
        //    foreach (Node node in nodes)
        //    {
        //        dict.Add(node.Id, new TreeNode(node.Id,node.Name, "#" + node.Name.Replace(" ", "_"), "red"));
        //    }

        //    // Build tree by adding child nodes to their parent nodes
        //    foreach (Node node in nodes)
        //    {
        //        if (node.ParentId>0)
        //        {
        //            int parentId = node.ParentId.Value;
        //            if (dict.TryGetValue(parentId, out TreeNode parentNode))
        //            {
        //                if (!addedParents.Contains(parentId))
        //                {
        //                    roots.Add(parentNode);
        //                    addedParents.Add(parentId);
        //                }
        //                TreeNode childNode = dict[node.Id];
        //                parentNode.AddChild(childNode);
        //            }
        //        }
        //        else
        //        {
        //            TreeNode rootNode = dict[node.Id];
        //            roots.Add(rootNode);
        //        }
        //    }
        //    List<TreeNode> result = roots.Distinct().ToList();
        //    return result;
        //}

    }
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Href { get; set; }
        public string Color { get; set; }
        public string BackColor { get; set; }
        public List<string> Tags { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public int CountSalesTrx { get; set; }
        public int? ParentId { get; set; }
    }


}

