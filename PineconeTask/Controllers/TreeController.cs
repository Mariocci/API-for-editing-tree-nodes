using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TreeController{
    private readonly TreeService _treeService;
    public TreeController(TreeService treeService){
        _treeService = treeService;
    }
    //Dohvat stabla
    [HttpGet]
    public IActionResult GetTree()
    {
        var res = _treeService.GetTree();
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);
    }
    //Dohvat čvora
    [HttpGet("id")]
    public IActionResult GetNode(int id)
    {
        var res = _treeService.GetNode(id);
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);
    }
    //Unos čvora
    [HttpPost]
    public IActionResult CreateNode([FromBody] TreeNode treeNode){
        var res = _treeService.CreateNode(treeNode);
        return CreatedAtAction(nameof(GetTree), new { id = res.Id }, res);
    }
    //Promjena čvora
    [HttpPut("{id}")]
    public IActionResult UpdateNode(int id, [FromBody] TreeNode treeNode){
        var res = _treeService.UpdateNode(id, updateNodeDto);
        if (!res) return BadRequest();
        return NoContent();
    }
    //Brisanje čvora
    [HttpDelete("{id}")]
    public IActionResult DeleteNode(int id)
    {   
        if(id = 1){//Provjera korjena
            return BadRequest();
        }
        _treeService.DeleteNode(id);
        return NoContent();
    }
}