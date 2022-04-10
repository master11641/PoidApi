using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
public class UploadController : Controller {
    private readonly IWebHostEnvironment _environment;

    public UploadController (IWebHostEnvironment environment) {
        _environment = environment;
    }
    // [HttpPost("[action]")]
    // public async Task<IActionResult> SaveTicket([FromForm]Ticket ticket)
    // {
    //     var file1Path = await saveFileAsync(ticket.File1);
    //     var file2Path = await saveFileAsync(ticket.File2);

    //     //TODO: save the ticket ... get id

    //     return Created("", new { id = 1001 });
    // }
    // [HttpPost ("SaveFile")]
    // public async Task<IActionResult> SaveFileAsync (IFormFile file) {
    //     const string uploadsFolder = "uploads";
    //     var uploadsRootFolder = Path.Combine (_environment.WebRootPath, "uploads");
    //     if (!Directory.Exists (uploadsRootFolder)) {
    //         Directory.CreateDirectory (uploadsRootFolder);
    //     }

    //     //TODO: Do security checks ...!

    //     if (file == null || file.Length == 0) {
    //         return Ok (string.Empty);
    //     }

    //     var filePath = Path.Combine (uploadsRootFolder, file.FileName);
    //     using (var fileStream = new FileStream (filePath, FileMode.Create)) {
    //         await file.CopyToAsync (fileStream);
    //     }

    //     return Ok ($"/{uploadsFolder}/{file.FileName}");
    // }
    [HttpPost ("SaveFile")]
    public async Task<IActionResult> SaveFileAsync (IFormFile file) {
        // const string uploadsFolder = "uploads";
        var uploadsRootFolder = Path.Combine (_environment.WebRootPath, "uploads");
        if (!Directory.Exists (uploadsRootFolder)) {
            Directory.CreateDirectory (uploadsRootFolder);
        }

        //TODO: Do security checks ...!

        if (file == null || file.Length == 0) {
            return Ok (string.Empty);
        }
        string newFileName = Guid.NewGuid () + "." + file.FileName.Split ('.').Last ();
        var filePath = Path.Combine (uploadsRootFolder, newFileName);
        using (var fileStream = new FileStream (filePath, FileMode.Create)) {
            await file.CopyToAsync (fileStream);
        }

        return Ok ($"{newFileName}");
    }

    [HttpPost]
    public ActionResult Save (IEnumerable<IFormFile> files) {
        if (files != null) {
            foreach (var file in files) {

                var uploadsRootFolder = Path.Combine (_environment.WebRootPath, "uploads");
                if (!Directory.Exists (uploadsRootFolder)) {
                    Directory.CreateDirectory (uploadsRootFolder);
                }

                //TODO: Do security checks ...!

                if (file == null || file.Length == 0) {
                    return Ok (string.Empty);
                }

                var filePath = Path.Combine (uploadsRootFolder, file.FileName);
                using (var fileStream = new FileStream (filePath, FileMode.Create)) {
                    file.CopyTo (fileStream);
                }
            }
        }
        string result = string.Join (",", files.Select (x => x.FileName).ToList ());
        // Return an empty string to signify success
        return Json (result);
    }

    [HttpPost]
    public ActionResult SaveTemp () {
        var files = HttpContext.Request.Form.Files;
        List<string> UniqueFileNames = new List<string>();
        if (files != null) {
            foreach (var file in files) {

                var uploadsRootFolder = Path.Combine (_environment.WebRootPath, "uploads");
                if (!Directory.Exists (uploadsRootFolder)) {
                    Directory.CreateDirectory (uploadsRootFolder);
                }

                //TODO: Do security checks ...!

                if (file == null || file.Length == 0) {
                    return Ok (string.Empty);
                }

                string newFileName = Guid.NewGuid () + "." + file.FileName.Split ('.').Last ();
                var filePath = Path.Combine (uploadsRootFolder, newFileName);
                UniqueFileNames.Add(newFileName);
                using (var fileStream = new FileStream (filePath, FileMode.Create)) {
                    file.CopyTo (fileStream);
                }
            }
        }
        string result = string.Join (",", UniqueFileNames.ToList ());
        // Return an empty string to signify success
        return Json (result);
    }
}