using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalRMvcChat.Entites;

namespace SignalRMvcChat.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 定义消息存储实例模型
        /// </summary>
        public static ChatContext DbContext = new ChatContext();
        /// <summary>
        /// 调用消息转发服务的消息储存对象（神级操作）
        /// </summary>
        public HomeController()
        {
            DbContext = ChatHub.DbContext;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "應用描述頁";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "聯繫方式頁";

            return View();
        }

        /// <summary>
        /// 聊天頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Chat()
        {
            return View();
        }

        [HttpPost]
        /// <summary>
        /// 文件上传
        /// </summary>
        public JsonResult UploadFile()
        {
            FileOperateHelper fileOperate = new FileOperateHelper();
            fileOperate.SavePath = $"~/UpLoadFiles/{DateTime.Now.ToString("yyyyMMdd")}/";
            int isSuccess=fileOperate.Upload();
            return Json(isSuccess,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 清除文件缓存
        /// </summary>
        /// <returns></returns>
        public JsonResult DelCache()
        {
            FileOperateHelper fileOperate = new FileOperateHelper();
            bool isSuccess = fileOperate.DeleteFolder($"~/UpLoadFiles/{DateTime.Now.ToString("yyyyMMdd")}/");
            return Json(isSuccess,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        /// <summary>
        /// 缓存聊天消息
        /// </summary>
        /// <param name="roomName">房间名</param>
        /// <param name="divContent">房间消息</param>
        /// <returns></returns>
        public JsonResult saveTempMessage(string roomName, string divContent)
        {
            var room = DbContext.Rooms.Find(a => a.RoomName == roomName);
            bool sContent = true;
            if (room != null)
            {
                room.ChatDiv = divContent.Replace("\\","");                
                ChatHub.DbContext = DbContext;
            }
            else
            {
                sContent = false;
            }
            return Json(sContent, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        ///读取相应房间的缓存消息
        /// </summary>
        /// <param name="roomName">房间名</param>
        /// <returns></returns>
        public JsonResult readTempMessage(string roomName)
        {
            if (!string.IsNullOrEmpty(roomName))
            {
                var room = DbContext.Rooms.FirstOrDefault(p => p.RoomName == roomName);
                string tempMessage = room is null ? null : room.ChatDiv;
                return Json(tempMessage.ToJson(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
            
        /// <summary>
        /// 轻聊版本
        /// </summary>
        /// <returns></returns>
        public ActionResult TimTalk()
        {
            return View();
        }
    }
}