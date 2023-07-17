using DocumentFormat.OpenXml.Vml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Helpers;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage.Streams;
using Path = System.IO.Path;

namespace EmployeeManagement.Controllers
{
    public class AttendanceController : Controller
    {
        private MediaCapture _mediaCapture; 
        // GET: AttendanceController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AttendanceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AttendanceController/Create
        public ActionResult Create()
        {
            // Trích xuất dữ liệu hình ảnh từ imageData
            const jsonString = '{"image": "data:image/png;base64,iVBORw0KG..."}';

            var jsonData = Json.parse(jsonString);
            var imageData = jsonData.image;
            var imageFile = Request.Form.Files.FirstOrDefault();
            if (imageFile == null || imageFile.Length == 0)
            {
                return BadRequest("Không tìm thấy dữ liệu hình ảnh.");
            }

            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                byte[] bytes = memoryStream.ToArray();

                // Lưu hoặc xử lý dữ liệu hình ảnh ở đây...
            }
            return View();
        }

        // POST: AttendanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CapturePhoto()
        {

            _mediaCapture = new MediaCapture();
            await _mediaCapture.InitializeAsync();

            var imageProperties = _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.Photo) as ImageEncodingProperties;
            var imageStream = new InMemoryRandomAccessStream();
            await _mediaCapture.CapturePhotoToStreamAsync(imageProperties, imageStream);

            var imageBytes = new byte[imageStream.Size];
            await imageStream.ReadAsync(imageBytes.AsBuffer(), (uint)imageStream.Size, InputStreamOptions.None);

            var fileName = $"{Guid.NewGuid()}.jpg";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

            return RedirectToAction("ShowPhoto", new { fileName });
        }

        public IActionResult ShowPhoto(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);
            var imageStream = System.IO.File.OpenRead(filePath);
            var contentType = "image/jpeg";
            return File(imageStream, contentType);
        }

        public async Task<IActionResult> StopCamera()
        {
            await _mediaCapture.StopPreviewAsync();
            _mediaCapture.Dispose();
            _mediaCapture = null;
            return RedirectToAction("CapturePhoto");
        }

        // GET: AttendanceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AttendanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AttendanceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AttendanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
