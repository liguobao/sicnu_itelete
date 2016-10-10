using SicnuITelete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SicnuITelete.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SaveStudentInfo(StudentInfo studentInfo)
        {
            try
            {
               studentInfo.CreateTime = DateTime.Now;
               var result= studentInfo.Save();
               if(result)
               {
                   EmailInfo email = new EmailInfo();
                   email.Receiver = studentInfo.QQNumber.Trim() + "@qq.com";
                   email.ReceiverName = studentInfo.StudentName;
                   email.Subject = "IT培优招新报名成功！";
                   email.Body = "<p>报名成功！如有其他问题请回复此邮箱！</p>";
                   email.Send();
               }
               
               return Json(new { IsSuccess = result ,SuccessMessage="报名成功！" });
            }catch(Exception ex)
            {
                return Json(new { IsSuccess = false,Erroe = ex.ToString() });
            }
        }

        public ActionResult SaveUserImag()
        {
            BizResultInfo result = UploadFileHelper.UploadFileToUserImg(Request);
            if (result.IsSuccess)
            {
                result.SuccessMessage = "上传成功！";
            }
            return Json(result);
        }
    }
}
