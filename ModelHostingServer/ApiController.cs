// using Microsoft.AspNetCore.Mvc; // Contains APIController/Routing

// [ApiController]
// [Route("api/models")]
// public class ModelsController : ControllerBase
// {
//     // Endpoint to get .obj model file
//     [HttpGet("{modelName}.obj")]
//     public IActionResult GetObjFile(string modelName)
//     {
//         var filePath = Path.Combine("wwwroot", "models", modelName, $"{modelName}.obj");
//         if (!System.IO.File.Exists(filePath))
//         {
//             return NotFound();      // returns 404 error
//         }

//         var fileBytes = System.IO.File.ReadAllBytes(filePath);
//         return File(fileBytes, "text/plain", $"{modelName}.obj");
//     }

//     // Endpoint to get .mtl file
//     [HttpGet("{modelName}.mtl")]
//     public IActionResult GetMtlFile(string modelName)
//     {
//         var filePath = Path.Combine("wwwroot", "models", modelName, $"{modelName}.mtl");
//         if (!System.IO.File.Exists(filePath))
//         {
//             return NotFound();      // returns 404 response
//         }

//         var fileBytes = System.IO.File.ReadAllBytes(filePath);
//         return File(fileBytes, "text/plain", $"{modelName}.mtl");
//     }

//     // Optionally, you can add another endpoint to list available models.
//     [HttpGet("list")]
//     public IActionResult GetModelsList()
//     {
//         var modelsDirectory = Path.Combine("wwwroot", "models");
//         var modelFolders = Directory.GetDirectories(modelsDirectory)
//                                     .Select(Path.GetFileName)
//                                     .ToList();
//         return Ok(modelFolders);    // returns 200 response
//     }
// }
