using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Aspose.BarCode.Generation;
namespace ManagementSystemMobileApp.Components.Pages
{
    public partial class MemberPoints
    {
        string codeImg = "";
        protected override async Task OnInitializedAsync()
        {
            using (var generator = new Aspose.BarCode.Generation.BarcodeGenerator(EncodeTypes.Code128, "0376355565"))
            {
                // Set parameters
                generator.Parameters.Barcode.XDimension.Millimeters *= 2;
                generator.Parameters.Barcode.CodeTextParameters.Location = CodeLocation.Below;

                // Generate image
                var res = generator.GenerateBarCodeImage();
                using MemoryStream stream = new MemoryStream();
                res.Save(stream, Aspose.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = stream.ToArray();
                codeImg = $"data:image/png;base64,{Convert.ToBase64String(imageBytes)}";
            }
        }
    }
}
