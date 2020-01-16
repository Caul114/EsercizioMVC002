using BlogMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogMongoDB
{
    public interface IDbService
    {
        #region Posts
        Task<List<Blog>> GetPosts();
        Task<Blog> GetPosts(string id);
        Task<bool> AddPost(Blog post);
        Task EditPost(Blog post);
        Task DeletePost(Blog post);
        #endregion

        #region Comments
        Task AddComment(Blog post, Comment comment);
        Task<List<Comment>> GetComments(Blog post);
        #endregion
    }
}
