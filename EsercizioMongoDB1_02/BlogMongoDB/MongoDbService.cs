using BlogMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogMongoDB
{
    public class MongoDbService : IDbService
    {
        #region Blogs

        private IMongoDatabase _db;
        public MongoDbService()
        {
            var client = new MongoClient();
            _db = client.GetDatabase("MyBlogProva2");
        }
        private IMongoCollection<Blog> getPostCollection()
        {
            return _db.GetCollection<Blog>("Posts");
        }

        public async Task<List<Blog>> GetPosts()
        {
            var collection = getPostCollection();
            var tmp = await collection.FindAsync(new BsonDocument());
            return await tmp.ToListAsync();
        }

        public async Task<Blog> GetPosts(string id)
        {
            var collection = getPostCollection();
            var post = await collection.FindAsync(x => x.Id == id);
            return await post.FirstOrDefaultAsync();
        }

        public async Task<bool> AddPost(Blog post)
        {
            var collection = getPostCollection();
            try
            {
                await collection.InsertOneAsync(post);
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
        }
        public async Task EditPost(Blog post)
        {
            var collection = getPostCollection();
            var filter = Builders<Blog>.Filter.Eq(x => x.Id, post.Id);
            await collection.ReplaceOneAsync(filter, post);
        }

        public async Task DeletePost(Blog post)
        {
            var collection = getPostCollection();
            await collection.DeleteOneAsync(x => x.Id == post.Id);
        }
        #endregion

        #region Comments
        public Task<List<Comment>> GetComments(Blog post)
        {
            throw new NotImplementedException();
        }
        public Task AddComment(Blog post, Comment comment)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
