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
        var result = _treeService.GetTree();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    //Dohvat čvora
    [HttpGet("id")]
    public IActionResult GetNode(int id)
    {
        var result = _treeService.GetNode(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    //Unos čvora
    [HttpPost]
    public IActionResult CreateNode([FromBody] TreeNodeDTO treeNode){
        var res = _treeService.CreateNode(treeNode);
        return CreatedAtAction(nameof(GetTree), new { id = result.Id }, result);
    }
    //Promjena čvora
    [HttpPut("{id}")]
    public IActionResult UpdateNode(int id, [FromBody] TreeNodeDto treeNode){
        var result = _treeService.UpdateNode(id, updateNodeDto);
        if (!result) return BadRequest();
        return NoContent();
    }
    //Brisanje čvora
    [HttpDelete("{id}")]
    public IActionResult DeleteNode(int id)
    {
        _treeService.DeleteNode(id);
        return NoContent();
    }
}