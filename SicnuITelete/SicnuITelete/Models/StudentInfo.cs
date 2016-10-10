using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SicnuITelete.Models
{
    public class StudentInfo
    {
        public string StudentName { get; set; }

        public string StudentNumber { get; set; }

        public string QQNumber { get; set; }

        public string Phone { get; set; }


        public int GroupType { get; set; }


        public string Intro { get; set; }


        public string ITEleteInfo { get; set; }


        public string Photo { get; set; }

        public DateTime CreateTime { get; set; }


        public DateTime BirthDay { get; set; }


        public bool Save()
        {
            string sql = @"INSERT INTO student (StudentName, StudentNumber, QQNumber, GroupType, Intro, ITEleteInfo, Photo, CreateTime,BirthDay)  
                     VALUES (@StudentName, @StudentNumber, @QQNumber, @GroupType, @Intro, @ITEleteInfo, @Photo, @CreateTime,@BirthDay)";
            MySqlParameter[] para = new MySqlParameter[]
					{
						new MySqlParameter("@StudentName", ToDBValue(StudentName)),
						new MySqlParameter("@StudentNumber", ToDBValue(StudentNumber)),
						new MySqlParameter("@QQNumber", ToDBValue(QQNumber)),
						new MySqlParameter("@GroupType", ToDBValue(GroupType)),
						new MySqlParameter("@Intro", ToDBValue(Intro)),
						new MySqlParameter("@CreateTime", ToDBValue(CreateTime)),
						new MySqlParameter("@ITEleteInfo", ToDBValue(ITEleteInfo)),
						new MySqlParameter("@Photo", ToDBValue(Photo)),
                        new MySqlParameter("@BirthDay", ToDBValue(BirthDay)),
					};

            int AddId = (int)MyDBHelper.ExecuteScalar(sql, para);
            if (AddId == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
    }



}