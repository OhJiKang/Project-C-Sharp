using doanNet.Models;
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

namespace doanNet.ApiControllers
{
    public class PostController : ApiController
    {
        KTXTDTUEntities1 db = new KTXTDTUEntities1();

        public List<Post> GetAll()
        {
            return db.Posts.ToList();
        }


        public Post GetByPostId(int id)
        {
            return db.Posts.Where(row => row.IDPost == id).FirstOrDefault();
        }
        public IHttpActionResult AddingPost([FromBody] PostDTO Post)
        {
            try
            {
                var tempPost = new Post();
                tempPost.PostTitle = Post.PostTittle;
                tempPost.PostDetail = Post.PostDetail;
                tempPost.DateBegin=DateTime.Now;
                tempPost.Hide = 0;

                db.Posts.Add(tempPost);
                db.SaveChangesAsync();
                foreach (var category in Post.CategoryList) {
                    var tempCategory = new CategoryBridge();
                    tempCategory.IDCategory = category.IDCategory;
                    tempCategory.IDPost = tempPost.IDPost;
                    tempCategory.DateBegin = DateTime.Now;
                    tempCategory.Hide = 0;
                    db.CategoryBridges.Add(tempCategory);
                }
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

        private bool EntityExists(int id)
        {
            return db.Posts.Any(e => e.IDPost == id);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutPost(int? id, [FromBody] PostDTO Post)
        {

            try
            {
                var Postmodifier = db.Posts.Where(row => row.IDPost == id).FirstOrDefault();
                Postmodifier.PostDetail = Post.PostDetail;
                Postmodifier.PostTitle = Post.PostTittle;
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
        [HttpPut]
        public IHttpActionResult HiddingPost(int id)
        {
            Post hidePost = db.Posts.Where(row => row.IDPost == id).FirstOrDefault();
            hidePost.Hide = hidePost.Hide == 0 ? 1 : 0;
            db.SaveChangesAsync();
            return Json(new { Message = "Hiding Succesfully!" });
        }
    }
}
