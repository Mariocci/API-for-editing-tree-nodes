public class TreeRepository{
    private readonly AppDbContext _dbContext;

    public TreeRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<TreeNode    > GetTree(){
        return _dbContext.TreeNodes.ToList();
    }/*SELECT * FROM TreeNodes*/
    public TreeNode GetNode(int id){
        return _dbContext.TreeNodes.Find(id);
    } /* SELECT * FROM TreeNodes WHERE Id = @id */


    public TreeNode CreateNode(TreeNode node)
    {
        _dbContext.TreeNodes.Add(node);
        _dbContext.SaveChanges();
        return node;
    }/* INSERT into TreeNodes 
        VALUES (@Title, @ParentNodeId, @Ordering)*/

    public void Update(TreeNode node)
    {
        _dbContext.TreeNodes.Update(node);
        _dbContext.SaveChanges();
    }/* UPDATE TreeNode 
        set  Title = @Title, ParentNodeId = @ParentNodeId, Ordering = @Ordering
        WHERE Id=@Id*/
    public void DeleteNode(int id)
    {
        var node = _dbContext.TreeNodes.Find(id);
        if (node != null)
        {
            _dbContext.TreeNodes.Remove(node);
            _dbContext.SaveChanges();
        }
    }/* DELETE FROM TreeNodes
        WHERE Id = @id;*/
}