using doanNet.Models;
using System.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using doanNet.Controllers.DTO;
using System.Collections;
using System.IO;
using System.Web.Mvc;

namespace doanNet.ApiControllers
{
    public class PostController : ApiController
    {
        KTXTDTUEntities2 db = new KTXTDTUEntities2();

        public List<Post> GetAll()
        {
            return db.Posts.ToList();
        }


        public Post GetByPostId(int id)
        {
            return db.Posts.Where(row => row.IDPost == id).FirstOrDefault();
        }
        
        [System.Web.Http.HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> AddingPost(PostDTO Post)
        {
            try
            {
                var tempPost = new Post();

                // Handle file upload
                if (Post.PostImage != null && Post.PostImage.ContentLength > 0)
                {
                    var serverFileName = $"{DateTime.Now.Ticks}_{Path.GetFileName(Post.PostImage.FileName)}";
                    var uploadPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/upload/img/news"), serverFileName);
                    Post.PostImage.SaveAs(uploadPath);
                    tempPost.PostImage = serverFileName;
                }
                else
                {
                    tempPost.PostImage = "default.png";
                }

                // Set other properties
                tempPost.PostTitle = Post.PostTittle;
                tempPost.PostDetail = Post.PostDetail;
                tempPost.DateBegin = DateTime.Now;
                tempPost.Hide = 0;
                tempPost.Meta = Post.meta;

                // Save the post
                db.Posts.Add(tempPost);
                await db.SaveChangesAsync();

                // Add category bridges
                foreach (var category in Post.CategoryList)
                {
                    var tempCategory = new CategoryBridge
                    {
                        IDCategory = category.IDCategory,
                        IDPost = tempPost.IDPost,
                        DateBegin = DateTime.Now,
                        Hide = 0
                    };
                    db.CategoryBridges.Add(tempCategory);
                    await db.SaveChangesAsync();
                }

                return Json(new { Message = "Data received successfully!" });
            }
            catch (DbEntityValidationException e)
            {
                // Handle validation errors
                var errorMessage = GetValidationErrorMessage(e);
                return Json(new { Message = errorMessage });
            }
        }

        private string GetValidationErrorMessage(DbEntityValidationException e)
        {
            var errorMessage = "";
            foreach (var eve in e.EntityValidationErrors)
            {
                errorMessage += $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:";

                foreach (var ve in eve.ValidationErrors)
                {
                    errorMessage += $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";
                }
            }
            return errorMessage;
        }
        private bool EntityExists(int id)
        {
            return db.Posts.Any(e => e.IDPost == id);
        }

        [System.Web.Mvc.HttpPut]
        public async Task<IHttpActionResult> PutPost(int? id, [FromBody] PostDTO Post)
        {

            try
            {
                var Postmodifier = db.Posts.Where(row => row.IDPost == id).FirstOrDefault();
                Postmodifier.PostTitle = Post.PostTittle;
                Postmodifier.PostDetail = Post.PostDetail;
                Postmodifier.DateBegin = DateTime.Now;
                Postmodifier.IDAccount = Post.IDAccount;
                var oldCategories = db.CategoryBridges.Where(row => row.IDPost == id).ToList();
               
                // 1. Identify categories to hide in OldCategory:
                var categoriesToHide = oldCategories
                    .Where(oldCat => !Post.CategoryList.Any(newCat => newCat.IDCategory == oldCat.IDCategory))
                    .ToList();

                // 2. Update Hidden property:
                foreach (var category in categoriesToHide)
                {
                    category.DateBegin= DateTime.Now;
                    category.Hide = 1; // Set Hidden to true for categories not in NewCategory
                }

                // 3. Identify new categories to add:
                var categoriesToAdd = Post.CategoryList
                    .Where(newCat => !oldCategories.Any(oldCat => oldCat.IDCategory == newCat.IDCategory))
                    .ToList();

                // 4. Add new categories to database:
                foreach (var category in categoriesToAdd)
                {
                    var tempCategory = new CategoryBridge();
                    tempCategory.IDCategory = category.IDCategory;
                    tempCategory.IDPost = Postmodifier.IDPost;
                    tempCategory.DateBegin= DateTime.Now;
                    tempCategory.Hide = 0;
                    db.CategoryBridges.Add(tempCategory); // Use your database access method
                }

                // 5. Remove Hidden flag for categories in both lists:
                foreach (var oldCat in oldCategories)
                {
                    if (Post.CategoryList.Any(newCat => newCat.IDCategory == oldCat.IDCategory))
                    {
                        oldCat.Hide = 0; // Set Hidden to false if category exists in both lists
                    }
                }
                db.Entry(Postmodifier).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                    return Json(new { Message = "Data received successfully!" });

                }
                catch (DbEntityValidationException e)
                {
                    string mes = "";
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        mes += $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:";

                        foreach (var ve in eve.ValidationErrors)
                        {
                            mes += $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";


                        }
                    }
                    return Json(new { Message = mes });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Message = "Adding Failed!Error: " + ex, });
            }
        }
        [System.Web.Mvc.HttpPut]
        public IHttpActionResult HiddingPost(int id)
        {
            Post hidePost = db.Posts.Where(row => row.IDPost == id).FirstOrDefault();
            hidePost.Hide = hidePost.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }
    }
}
