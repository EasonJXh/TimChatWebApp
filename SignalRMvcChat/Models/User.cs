using System.Collections.Generic;

namespace SignalRMvcChat.Models
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户的连接集合
        /// </summary>
        public List<Connection> Connections { get; set; }

        /// <summary>
        /// 用户房间集合，一个用户可以加入多个房间
        /// </summary>
        public List<ChatRoom> Rooms { get; set; }

        public User()
        {
            Connections = new List<Connection>();
            Rooms = new List<ChatRoom>();
        }
    }

    /// <summary>
    /// 连接类
    /// </summary>
    public class Connection
    {
        //连接ID
        public string ConnectionId { get; set; }

        //用户代理
        public string UserAgent { get; set; }
        //是否连接
        public bool Connected { get; set; }
    }

    /// <summary>
    /// 房间类
    /// </summary>
    public class ChatRoom
    {
        // 房间名称
        public string RoomName { get; set; }

        //房间头像ID
        public decimal RoomImage { get; set; }

        //房间聊天内容
        public string ChatDiv { get; set; }

        // 用户集合
        public List<User> Users { get; set; }

        public ChatRoom()
        {
            Users = new List<User>();
        }
    }
}