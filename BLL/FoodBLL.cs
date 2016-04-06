using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class FoodBLL
    {
        private FoodDAL foodDAL = new FoodDAL();
        private FarvoriteDAL farvoriteDAL = new FarvoriteDAL();
        private LikeDAL likeDAL = new LikeDAL();

        //查询Food信息
        public Food Query(string id)
        {
            return foodDAL.QueryOneRecord(id);
        }

        //查询Food信息
        public DataTable QueryAllByUID(string uid)
        {
            return foodDAL.QueryAllRecordByUID(uid);
        }

        //搜索Food信息
        public DataTable Search(String[] keywords)
        {
            return foodDAL.Search(keywords);
        }

        //插入Food信息
        public bool Insert(Food food)
        {
            return foodDAL.InsertOneRecord(food);
        }

        //查询最新的num条Food信息
        public DataTable QueryN(int num)
        {
            return foodDAL.QueryMultRecord(num);
        }

        //喜欢
        public bool FarvoriteFromUser(string userID, string foodID)
        {
            Farvorite farvorite = farvoriteDAL.QueryOneRecord(userID, foodID);
            if (farvorite == null)
            {
                return farvoriteDAL.InsertOneRecord(userID, foodID);
            }
            else
            {
                return false;
            }
        }

        //取消喜欢
        public bool RemoveFarvorite(string userID, string foodID)
        {
            return farvoriteDAL.DeleteOneRecord(userID, foodID);
        }

        //点赞
        public bool LikeFromAny(string liker, string foodID)
        {
            if (!likeDAL.IsLikeToday(liker, foodID))
            {
                return likeDAL.InsertOneRecord(liker, foodID);
            }
            else
            {
                return false;
            }
        }

    }
}
