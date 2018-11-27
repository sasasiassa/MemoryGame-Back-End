using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class ImgsLogic : BaseLogic
    {
        public List<ImgModel> GetAllImages() // Gets all images from the DB and returns them as a list
        {
            return DB.Images.Select(f => new ImgModel
            {
                fileName = f.FileName,
                imgId = f.ImgID
            }).ToList();
        }

        public ImgModel GetOneImg(int id) // Gets one image from the DB and returns it
        {
            return DB.Images.Where(f => f.ImgID == id).Select(f => new ImgModel
            {
                fileName = f.FileName,
                imgId = f.ImgID
            }).SingleOrDefault();
        }

       public ImgModel AddImg(ImgModel imgModel) // Adds one image to the DB
        {
            Image image = new Image
            {
                FileName = imgModel.fileName
            };
            DB.Images.Add(image);
            DB.SaveChanges();

            imgModel.imgId = image.ImgID;

            return GetOneImg(imgModel.imgId);
        }

    }
}
