public class TreeService{

    private readonly TreeRepository _treeRepository;

    public TreeService(TreeRepository treeRepository)
    {
        _treeRepository = treeRepository;
    }

    public List<TreeNode> GetNodesByParent(int parentId){
        return _treeRepository.GetNodesByParent(parentId);
    }

    public bool UpdateNode(int id, UpdateNodeDTO updateNodeDto){
        var node = GetNode(id);
        if (node == null) return false;

        if (node.parent_node_id != updateNodeDto.NewParentId)
        {
            node.parent_node_id = updateNodeDto.NewParentId;
            node.ordering = updateNodeDto.NewOrdering;
            AdjustChildOrderings(node.parent_node_id, node.ordering);
        }
        else
        {
            AdjustChildOrderings(node.parent_node_id, updateNodeDto.NewOrdering);
        }

        SaveNode(node);
        return true;
    }

    public void SaveNode(TreeNode node){
        node.parent_node_id = _treeRepository.GetLatestOrdering(node.parent_node_id);
        _treeRepository.Update(node);
    }

    private void AdjustChildOrderings(int parentId, int newOrdering){
        var siblings = GetNodesByParent(parentId);

        foreach (var sibling in siblings)
        {
            if (sibling.Ordering >= newOrdering)
            {
                sibling.Ordering++;
                SaveNode(sibling);
            }
        }
    }

    public List<TreeNode> GetTree(){
        return _treeRepository.GetTree();
    }
    public bool CreateNode(TreeNode newTreeNode){
        _treeRepository.CreateNode(TreeNode newTreeNode);
        return true;
    }
    public TreeNode GetNode(int id){
        return _treeRepository.GetNode(id);
    }
    public bool DeleteNode(int id){
        List<TreeNode> children = _treeRepository.GetChildrenNodes(id);
        //rekurzivno brisanje svih child čvorova
        if(children.Any()){
            foreach(TreeNode child: children){
                DeleteNode(child.Id);
            }
        }
        _treeRepository.DeleteNode(id);
        return true;
    }
}