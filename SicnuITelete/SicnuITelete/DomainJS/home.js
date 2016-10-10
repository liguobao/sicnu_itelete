$(document).ready(function () {// DOM的onload事件处理函数  
    $('#btnSaveUserInfo').bind('click', function (e) {
        e.preventDefault();
        SaveUserInfo();
        e.stopPropagation();
    });

    $('#uploadFile').fileupload({
        url: userImgUploadUrl,
        dataType: 'json',
        done: function (e, rsp) {
            if (rsp.result.IsSuccess) {
                alert(rsp.result.SuccessMessage);
                userImgPath = rsp.result.ResultID;

            } else {
                alert(rsp.result.ErrorMessage);
            }
        }
    });

});

function SaveUserInfo()
{
    var name = $("#StudentName").val();

    var studentNumber = $("#StudentNumber").val();

    var phone = $("#UserPhone").val();


    var QQ = $("#UserQQ").val();

    var Intro = $("#Intro").val();

    var ITEleteInfo = $("#ITEleteInfo").val();

    var groupType = $("input[name='groupType']:checked").val();


    var studentInfo =
   {
       StudentName: name,
       StudentNumber: studentNumber,
       QQNumber: QQ,
       Phone: phone,
       GroupType: groupType,
       Intro: Intro,
       ITEleteInfo: ITEleteInfo,
       Photo : userImgPath,
   };


    $.ajax({
        type: "post",
        url: "./Home/SaveStudentInfo",
        data: studentInfo,
        success:
            function (rsp) {
                if (rsp.IsSuccess) {
                    alert(rsp.SuccessMessage);

                }
                else
                    alert(rsp.ErrorMessage);
            }
    });
}