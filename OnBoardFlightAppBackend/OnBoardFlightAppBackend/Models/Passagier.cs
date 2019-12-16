using OnBoardFlightAppBackend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;

namespace On_board_flight_app_backend.Models
{
    public class Passagier
    {
        #region Properties
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        // public ICollection<Bestelling> Bestellingen { get; set; }
        public Groepschat Groepschat { get; set; }
        public int? GroepschatId { get; set; }
        public ICollection<Melding> Meldingen { get; set; }
        #endregion

        #region Constructors
        public Passagier clone()
        {
            return new Passagier() { Id = this.Id, Voornaam = this.Voornaam, Naam = this.Naam ,Groepschat =null};
        }
        private Passagier()
        {

        }
        public Passagier(int id, string voornaam, string naam)
        {
            this.Id = id;
            this.Voornaam = voornaam;
            this.Naam = naam;
            Meldingen = new List<Melding>();
            generateBoardingpass();
        }
        #endregion
        public void generateBoardingpass()
        {
            //var writer = new QRCodeWriter();
            //var bitmap = writer.encode(Voornaam + Naam + Id, BarcodeFormat.QR_CODE, 300, 300);
            //bitmap.
            var width = 250; // width of the Qr Code   
            var height = 250; // height of the Qr Code   
            var margin = 0;
            var qrCodeWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = margin
                }
            };
            var pixelData = qrCodeWriter.Write(Id + Naam + Voornaam);
            // creating a bitmap from the raw pixel data; if only black and white colors are used it makes no difference   
            // that the pixel data ist BGRA oriented and the bitmap is initialized with RGB   
            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            using (var ms = new MemoryStream())
            {
                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image   
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }
                // save to stream as PNG   
                bitmap.Save("Boardingpasses/"+Voornaam+Naam+Id+".png");
            }
        }
    }
}
    

