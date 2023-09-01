using Backend.CodersHub.Models;
using Backend.CodersHub.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.CodersHub.Files
{
    public interface IFileContext
    {
        /// <summary>
        /// User qo'shish
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Qo'shilgan userning tokenini qaytaradi</returns>
        Guid AddUser(User user);

        /// <summary>
        /// token orqali userni olish
        /// </summary>
        User GetUser(Guid token);

        /// <summary>
        /// token orqali topib userni o'chirish
        /// </summary>
        /// <param name="token"></param>
        void DeleteUser(Guid token);

        /// <summary>
        /// Token orqali topilgan userni berilgan user malumotlari bilan update qiladi
        /// </summary>
        /// <param name="token"></param>
        /// <param name="user"></param>
        void UpdateUser(Guid token, UserDto user);

        /// <summary>
        /// Hech narsa qabul qilmaydi
        /// </summary>
        /// <returns>Barcha userlarni qaytaradi</returns>
        List<User> GetUsers();

        /// <summary>
        /// emailaddress va password qabul qiladi
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns>topilgan userni qaytaradi aks xolda null</returns>
        User GetUser(string emailAddress, string password);

        /// <summary>
        /// faylga yangi blogpost qo'shadi
        ///</summary>
        Guid AddPost(BlogPost blogPost);

        ///<summary>
        ///id orqali topib post ni o'chiradi
        ///</summary>
        void DeletePost(Guid id);

        /// <summary>
        /// id orqali postni topib berilgan blogPostDto modeli bo'yicha update qiladi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blogPostDto"></param>
        void UpdatePost(Guid id, BlogPostDto blogPostDto);

        /// <summary>
        /// Id orqali postni topib qaytaradi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BlogPost GetPost(Guid id);

        /// <summary>
        /// barcha postlarni qaytaradi
        /// </summary>
        /// <returns></returns>
        public List<BlogPost> GetPosts();

        /// <summary>
        /// unique bo'lgan token orqali userning postlarini qaytaradi
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<BlogPost> GetUserPosts(Guid token);

        /// <summary>
        /// keyword orqali search qiladi
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<BlogPost> SearchPost(string keyword);
    }

}
